using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RareCommodityHelper
{
    public partial class MainForm : Form
    {
        public class Settings
        {
            public string JumpDistance;
            public string CurrentSystem;
            public string DestinationSystem;

            public Settings()
            {
                JumpDistance = "12.0";
                CurrentSystem = "Eranin";
                DestinationSystem = "Orrere";
            }
        }

        private Galaxy galaxy;
        private Dictionary<string,RareGood> rareData;
        private int rareColumn = 0;
        private bool rareAscending = true;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Setup bindings
            ComputeButton.Click += ComputeRareGoodsDistances;
            RouteButton.Click += ComputePath;

            // Rare tab
            RareResults.ItemSelectionChanged += SetNewDestination;
            RareResults.Columns.Add("System", 120);
            RareResults.Columns.Add("Station", 150);
            RareResults.Columns.Add("Commodity", 200);
            RareResults.Columns.Add("Distance", 70);
            RareResults.Columns.Add("Station Distance", 70);
            RareResults.Columns.Add("Last Known Price", 50);
            RareResults.Columns.Add("Station Allegiance", 90);
            RareResults.ColumnClick += SortRareGoodsResults;

            // Route tab
            RouteResults.ItemSelectionChanged += SetCurrentLocation;
            RouteResults.Columns.Add("System", 150);
            RouteResults.Columns.Add("#", 50);
            RouteResults.Columns.Add("Jump Dist.", 80);
            RouteResults.Columns.Add("Travelled", 80);
            RouteResults.Columns.Add("Dist. To Target", 80);
            
            this.FormClosing += OnExit;

            // Load previous settings
            Settings settings;
            if (!LocalData<Settings>.LoadLocalData("Settings.xml", out settings))
            {
                settings = new Settings();
            }
            MaxJumpDistance.Text = settings.JumpDistance;
            CurrentSystem.Text = settings.CurrentSystem;
            DestinationSystem.Text = settings.DestinationSystem;

            // Load spaaaace
            galaxy = new Galaxy();
            UpdateSystems();
        }

        private void OnExit(object sender, EventArgs e)
        {
            // Save off settings
            Settings settings = new Settings();
            settings.JumpDistance = MaxJumpDistance.Text;
            settings.CurrentSystem = CurrentSystem.Text;
            settings.DestinationSystem = DestinationSystem.Text;
            LocalData<Settings>.SaveLocalData(settings, "Settings.xml");
        }

        private async void UpdateSystems()
        {
            // Get galaxy data from the web / hard drive
            SetLoadingStatus(true);
            await galaxy.GetData();
            SetLoadingStatus(false);

            // Populate the combo boxen
            string[] systemNames = galaxy.Systems.Values.Select(s => s.Name).ToArray();
            CurrentSystem.Items.Clear();
            CurrentSystem.Items.AddRange(systemNames);
            DestinationSystem.Items.Clear();
            DestinationSystem.Items.AddRange(systemNames);

            // Fill in data in rare good fields
            List<RareGood> rares = RareData.GetRares();
            rareData = new Dictionary<string, RareGood>();
            foreach(RareGood rare in rares)
            { 
                try
                {
                    rare.Location = galaxy.Systems[rare.LocationName];
                    rareData[rare.Name] = rare;
                }
                catch
                {
                    MessageBox.Show(String.Format("Failed to get data for system {0} associated with rare good {1}, rare data may be out-of-date, or we may have failed to get data from EDStarCoordinator.", rare.LocationName, rare.Name), "Fuck!", MessageBoxButtons.OK);
                }
            }
        }

        // Compute the distance to each rare good location from the player's current system
        private void ComputeRareGoodsDistances(object sender, EventArgs e)
        {
            if (!ValidateComboBox(CurrentSystem))
            {
                return;
            }

            RareResults.Items.Clear();

            List<Destination> sorted;
            galaxy.SortRaresByDistance(CurrentSystem.Text, rareData.Values.ToList(), out sorted);
            foreach (Destination dest in sorted)
            {
                RareGood rare = dest.Rare;
                ListViewItem newItem = new ListViewItem();
                newItem.Text = rare.LocationName;
                newItem.SubItems.Add(rare.Station);
                newItem.SubItems.Add(rare.Name);
                newItem.SubItems.Add(dest.Distance.ToString("0.00"));
                newItem.SubItems.Add(rare.StationDistance);
                newItem.SubItems.Add(rare.LastKnownCost.ToString());
                newItem.SubItems.Add(rare.Allegiance);
                RareResults.Items.Add(newItem);
            }
        }

        private void SortRareGoodsResults(object sender, System.Windows.Forms.ColumnClickEventArgs args)
        {
            bool ascending = false;
            if (args.Column == rareColumn)
            {
                rareAscending = !rareAscending;
                ascending = rareAscending;
            }
            else
            {
                rareAscending = ascending;
            }

            switch (args.Column)
            {
                case 3:
                case 5:
                    RareResults.ListViewItemSorter = new FloatSorter(args.Column, ascending);
                    break;
                default:
                    RareResults.ListViewItemSorter = new StringSorter(args.Column, ascending);
                    break;
            }
            RareResults.Sort();
            rareColumn = args.Column;
        }

        // Compute a path from the player's current system to the selected destination system
        private void ComputePath(object sender, EventArgs e)
        {
            float jumpDistance = 0.0f;
            try
            {
                jumpDistance = (float)Convert.ToDouble(MaxJumpDistance.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid floating point jump distance.", "Fuck!", MessageBoxButtons.OK);
                return;
            }

            if (!ValidateComboBox(CurrentSystem) || !ValidateComboBox(DestinationSystem))
            {
                return;
            }

            PathPlanner finder = new PathPlanner(galaxy.Systems.Values.ToList(), jumpDistance);
            List<PathNode> path = finder.FindPath(CurrentSystem.Text, DestinationSystem.Text);
            if (path == null)
            {
                MessageBox.Show("No route to destination.", "FUCK!", MessageBoxButtons.OK);
                return;
            }

            RouteResults.Items.Clear();
            float travelled = 0.0f;
            for (int i = 0; i < path.Count; i++)
            {
                PathNode n = path[i];
                float distance = n.TraversalCost;
                travelled += distance;
                ListViewItem newItem = new ListViewItem();
                newItem.Text = n.Local.Name;
                newItem.SubItems.Add(i.ToString());
                newItem.SubItems.Add(distance.ToString("0.00"));
                newItem.SubItems.Add(travelled.ToString("0.00"));
                newItem.SubItems.Add(n.HScore.ToString("0.00"));
                RouteResults.Items.Add(newItem);
            }
        }

        // Just a helper method to make sure our combo boxes have valid values
        private bool ValidateComboBox(ComboBox c)
        {
            if (c.Items.Contains(c.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show(string.Format("Please set a valid selection for {0}.", c.Name), "Fuck!", MessageBoxButtons.OK);
                return false;
            }
        }

        // Enable and disable various components to indicate that loading is happening
        private void SetLoadingStatus(bool isLoading)
        {
            CurrentSystem.Enabled = !isLoading;
            MaxJumpDistance.Enabled = !isLoading;
            ComputeButton.Enabled = !isLoading;
            DestinationSystem.Enabled = !isLoading;
            RouteButton.Enabled = !isLoading;
            LoadProgressBar.Visible = isLoading;
            LoadProgressLabel.Visible = isLoading;
        }
        private void SetCurrentLocation(object sender, EventArgs e)
        {
            if (RareResults.SelectedItems.Count > 0)
            {
                CurrentSystem.Text = RareResults.SelectedItems[0].Text;
            }
        }

        private void SetNewDestination(object sender, EventArgs e)
        {
            if (RareResults.SelectedItems.Count > 0)
            {
                DestinationSystem.Text = RareResults.SelectedItems[0].Text;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
