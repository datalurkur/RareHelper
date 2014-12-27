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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Setup bindings
            ComputeButton.Click += ComputeRareGoodsDistances;
            RouteButton.Click += ComputePath;
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

            ResultsView.ItemSelectionChanged -= SetCurrentLocation;
            ResultsView.Columns.Clear();
            ResultsView.Columns.Add("System", 150);
            ResultsView.Columns.Add("Station", 150);
            ResultsView.Columns.Add("Commodity", 200);
            ResultsView.Columns.Add("Distance", 80);
            ResultsView.Items.Clear();

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
                ResultsView.Items.Add(newItem);
            }

            ResultsView.ItemSelectionChanged += SetNewDestination;
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

            RoutePlanner finder = new RoutePlanner(galaxy.Systems.Values.ToList(), jumpDistance);
            List<RouteNode> path = finder.FindRoute(CurrentSystem.Text, DestinationSystem.Text);
            if (path == null)
            {
                MessageBox.Show("No route to destination.", "FUCK!", MessageBoxButtons.OK);
                return;
            }

            ResultsView.ItemSelectionChanged -= SetNewDestination;
            ResultsView.Columns.Clear();
            ResultsView.Columns.Add("System", 150);
            ResultsView.Columns.Add("Jump Dist.", 80);
            ResultsView.Columns.Add("Travelled", 80);
            ResultsView.Columns.Add("Dist. To Target", 80);

            ResultsView.Items.Clear();
            float travelled = 0.0f;
            foreach (RouteNode n in path)
            {
                float distance = n.TraversalCost;
                travelled += distance;
                ListViewItem newItem = new ListViewItem();
                newItem.Text = n.Local.Name;
                newItem.SubItems.Add(distance.ToString("0.00"));
                newItem.SubItems.Add(travelled.ToString("0.00"));
                newItem.SubItems.Add(n.HScore.ToString("0.00"));
                ResultsView.Items.Add(newItem);
            }
            ResultsView.ItemSelectionChanged += SetCurrentLocation;
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
            if (ResultsView.SelectedItems.Count > 0)
            {
                CurrentSystem.Text = ResultsView.SelectedItems[0].Text;
            }
        }

        private void SetNewDestination(object sender, EventArgs e)
        {
            if (ResultsView.SelectedItems.Count > 0)
            {
                DestinationSystem.Text = ResultsView.SelectedItems[0].Text;
            }
        }
    }
}
