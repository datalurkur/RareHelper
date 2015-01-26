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
            public string JumpsPerLeg;
            public string MaxJumps;
            public string IdealSellDistance;
            public string LogDirectory;

            public List<string> Blacklist;

            public Settings()
            {
                JumpDistance = "12.0";
                CurrentSystem = "Eranin";
                DestinationSystem = "Orrere";
                JumpsPerLeg = "4";
                MaxJumps = "10";
                IdealSellDistance = "150";
                LogDirectory = null;

                Blacklist = new List<string>();
            }
        }

        private Galaxy galaxy;
        private Dictionary<string, RareGood> rareData;
        private Dictionary<string, RareGood> availableRares;
        private List<RouteNode> currentRoute;
        private int rareColumn = 0;
        private bool rareAscending = true;
        private List<string> blacklist;
        private LogWatcher LogWatcher;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Setup bindings
            ComputeButton.Click += ComputeRareGoodsDistances;
            PathButton.Click += ComputePath;
            RouteButton.Click += ComputeRoute;

            // Rare tab
            RareResults.ItemSelectionChanged += SetNewDestination;
            RareResults.Columns.Add("System", 100);
            RareResults.Columns.Add("Station", 150);
            RareResults.Columns.Add("Commodity", 200);
            RareResults.Columns.Add("Dist.", 60);
            RareResults.Columns.Add("Station Dist.", 60);
            RareResults.Columns.Add("Last Known Price", 50);
            RareResults.Columns.Add("Station Allegiance", 90);
            RareResults.ColumnClick += SortRareGoodsResults;

            // Path tab
            PathResults.ItemSelectionChanged += SetCurrentLocation;
            PathResults.Columns.Add("System", 150);
            PathResults.Columns.Add("#", 30);
            PathResults.Columns.Add("Jump Dist.", 60);
            PathResults.Columns.Add("Travelled", 60);
            PathResults.Columns.Add("Dist. To Target", 60);

            // Route tab
            RouteResults.ItemSelectionChanged += SetCurrentRouteStop;
            RouteResults.Columns.Add("System", 100);
            RouteResults.Columns.Add("#", 30);
            RouteResults.Columns.Add("Station", 150);
            RouteResults.Columns.Add("Station Dist.", 60);
            RouteResults.Columns.Add("Commodity", 150);
            RouteResults.Columns.Add("Dist. To Prev", 60);
            RouteResults.Columns.Add("Good to Sell", 150);
            RouteResults.Columns.Add("Dist. To Sellee", 60);
            
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
            JumpsPerLeg.Text = settings.JumpsPerLeg;
            MaxJumps.Text = settings.MaxJumps;
            IdealSellDistance.Text = settings.IdealSellDistance;
            SaveButton.Click += FullSaveRoute;
            LoadButton.Click += FullLoadRoute;
            RareGoodSelector.DrawItem += DrawRaresComboBox;
            BlacklistButton.Click += Blacklist;
            UnblacklistButton.Click += Unblacklist;
            LogDirectoryTextBox.Text = settings.LogDirectory;

            blacklist = settings.Blacklist;

            // Load spaaaace
            galaxy = new Galaxy();
            UpdateSystems();

            // Start tracking the player.
            LogWatcher = new LogWatcher(settings.LogDirectory);

            currentRoute = null;
        }

        private void OnExit(object sender, EventArgs e)
        {
            // Save off settings
            Settings settings = new Settings();
            settings.JumpDistance = MaxJumpDistance.Text;
            settings.CurrentSystem = CurrentSystem.Text;
            settings.DestinationSystem = DestinationSystem.Text;
            settings.JumpsPerLeg = JumpsPerLeg.Text;
            settings.MaxJumps = MaxJumps.Text;
            settings.IdealSellDistance = IdealSellDistance.Text;
            settings.Blacklist = blacklist;
            if (LogWatcher != null)
                settings.LogDirectory = LogWatcher.LogDirectory();
            else
                settings.LogDirectory = LogDirectoryTextBox.Text;
            LocalData<Settings>.SaveLocalData(settings, "Settings.xml");

            if (LogWatcher != null) LogWatcher.ShutDown();
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
            string[] rareNames = rares.Select(r => r.Name).OrderBy(r => r).ToArray();
            RareGoodSelector.Items.Clear();
            RareGoodSelector.Items.AddRange(rareNames);
            rareData = new Dictionary<string, RareGood>();
            availableRares = new Dictionary<string, RareGood>();
            foreach(RareGood rare in rares)
            { 
                try
                {
                    rare.Location = galaxy.Systems[rare.LocationName];
                    rareData[rare.Name] = rare;
                    if (!blacklist.Contains(rare.Name))
                    {
                        availableRares[rare.Name] = rare;
                    }
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
            galaxy.SortRaresByDistance(CurrentSystem.Text, availableRares.Values.ToList(), out sorted);
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
            var jumpDistance = FloatHelper.AsFloat(MaxJumpDistance.Text);
            if (Math.Abs(jumpDistance) < 0.0000001f)
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

            PathResults.Items.Clear();
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
                PathResults.Items.Add(newItem);
            }
        }

        private void ComputeRoute(object sender, EventArgs args)
        {
            int jumpsPerLeg = 4;
            int maxJumps = 6;

            var jumpDistance = FloatHelper.AsFloat(MaxJumpDistance.Text);
            if (Math.Abs(jumpDistance) < 0.0000001f)
            {
                MessageBox.Show("Please enter a valid floating point jump distance.", "Fuck!", MessageBoxButtons.OK);
                return;
            }

            var idealSellDistance = FloatHelper.AsFloat(IdealSellDistance.Text);
            if (Math.Abs(idealSellDistance) < 0.0000001f)
            {
                MessageBox.Show("Please enter a valid floating point jump distance.", "Fuck!", MessageBoxButtons.OK);
                return;
            }

            try
            {
                jumpsPerLeg = Convert.ToInt32(JumpsPerLeg.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid number of legs per jump.", "Fuck!", MessageBoxButtons.OK);
                return;
            }
            try
            {
                maxJumps = Convert.ToInt32(MaxJumps.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid number of max jumps.", "Fuck!", MessageBoxButtons.OK);
                return;
            }
            if (!ValidateComboBox(CurrentSystem))
            {
                return;
            }

            RoutePlanner planner = new RoutePlanner(availableRares.Values.ToList(), jumpDistance);
            StarSystem start = galaxy.Systems[CurrentSystem.Text];
            currentRoute = planner.FindRoute(start, idealSellDistance, jumpsPerLeg, maxJumps);
            OnRouteUpdated();
        }

        private void OnRouteUpdated()
        {
            RouteResults.Items.Clear();
            for (int i = 0; i < currentRoute.Count; i++)
            {
                RouteNode r = currentRoute[i];
                string distanceToPrev = (i > 0) ? currentRoute[i - 1].Rare.Distance(r.Rare).ToString("0.00") : "N/A";

                ListViewItem newItem = new ListViewItem();
                newItem.Text = r.Rare.LocationName;
                newItem.SubItems.Add(i.ToString());
                newItem.SubItems.Add(r.Rare.Station);
                newItem.SubItems.Add(r.Rare.StationDistance);
                newItem.SubItems.Add(r.Rare.Name);
                newItem.SubItems.Add(distanceToPrev);
                if (currentRoute[i].SellHere.Count == 0)
                {
                    newItem.SubItems.Add("N/A");
                    newItem.SubItems.Add("N/A");
                }
                for (int j = 0; j < currentRoute[i].SellHere.Count; j++)
                {
                    RareGood s = currentRoute[i].SellHere[j];
                    newItem.SubItems.Add(s.Name);
                    newItem.SubItems.Add(s.Distance(r.Rare).ToString("0.00"));
                    if (j < currentRoute[i].SellHere.Count - 1)
                    {
                        RouteResults.Items.Add(newItem);
                        newItem = new ListViewItem();
                        newItem.Text = "";
                        newItem.SubItems.Add("");
                        newItem.SubItems.Add("");
                        newItem.SubItems.Add("");
                        newItem.SubItems.Add("");
                        newItem.SubItems.Add("");
                    }
                }
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
            PathButton.Enabled = !isLoading;
            RouteButton.Enabled = !isLoading;
            QuickSaveRouteButton.Enabled = !isLoading;
            QuickLoadRouteButton.Enabled = !isLoading;
            LoadProgressBar.Visible = isLoading;
            LoadProgressLabel.Visible = isLoading;
        }
        private void SetCurrentLocation(object sender, EventArgs e)
        {
            if (PathResults.SelectedItems.Count > 0)
            {
                CurrentSystem.Text = PathResults.SelectedItems[0].Text;
            }
        }

        private void SetNewDestination(object sender, EventArgs e)
        {
            if (RareResults.SelectedItems.Count > 0)
            {
                DestinationSystem.Text = RareResults.SelectedItems[0].Text;
            }
        }

        private void SetCurrentRouteStop(object sender, EventArgs e)
        {
            if (RouteResults.SelectedIndices.Count > 0)
            {
                int selected = RouteResults.SelectedIndices[0];

                int startIndex = selected;
                for(int i = selected - 1; i >= 0; --i)
                {
                    if (RouteResults.Items[i].Text != "")
                    {
                        startIndex = i;
                        break;
                    }
                }
                if (startIndex != selected)
                {
                    ListViewItem end = RouteResults.Items[selected];
                    DestinationSystem.Text = end.Text;
                    ListViewItem start = RouteResults.Items[startIndex];
                    CurrentSystem.Text = start.Text;
                    ComputePath(sender, e);
                }
            }
        }

        private void QuickLoadRoute(object sender, EventArgs e)
        {
            LoadRoute("Route.xml");
        }

        private void FullLoadRoute(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.RestoreDirectory = true;

            if (open.ShowDialog() == DialogResult.OK)
            {
                LoadRoute(open.FileName);
            }
        }

        private void LoadRoute(string fileName)
        {
            List<RouteNode> updatedRoute;
            if (LocalData<List<RouteNode>>.LoadLocalData(fileName, out updatedRoute))
            {
                currentRoute = new List<RouteNode>();
                foreach (RouteNode r in updatedRoute)
                {
                    RouteNode n = new RouteNode(rareData[r.Rare.Name]);
                    foreach (RareGood s in r.SellHere)
                    {
                        n.SellHere.Add(rareData[s.Name]);
                    }
                    currentRoute.Add(n);
                }
                OnRouteUpdated();
            }
            else
            {
                MessageBox.Show("Failed to load previous route.", "Fuck!", MessageBoxButtons.OK);
            }
        }

        private void QuickSaveRoute(object sender, EventArgs e)
        {
            SaveRoute("Route.xml");
        }

        private void FullSaveRoute(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.RestoreDirectory = true;

            if(save.ShowDialog() == DialogResult.OK)
            {
                SaveRoute(save.FileName);
            }
        }

        private void SaveRoute(string fileName)
        {
            LocalData<List<RouteNode>>.SaveLocalData(currentRoute, fileName);
        }

        private void DrawRaresComboBox(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            string text = ((ComboBox)sender).Items[e.Index].ToString();
            Brush brush = Brushes.Black;
            if (blacklist.Contains(text))
            {
                brush = Brushes.Red;
            }
            e.Graphics.DrawString(text, ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);
        }

        private void Blacklist(object sender, EventArgs e)
        {
            if (!ValidateComboBox(RareGoodSelector))
            {
                return;
            }
            string r = RareGoodSelector.Text;
            blacklist.Add(r);
            availableRares.Remove(r);
        }

        private void Unblacklist(object sender, EventArgs e)
        {
            if (!ValidateComboBox(RareGoodSelector))
            {
                return;
            }
            string r = RareGoodSelector.Text;
            blacklist.Remove(r);
            availableRares.Add(r, rareData[r]);
        }

        private void UpdateLogDirectory(object sender, EventArgs e)
        {
            try
            {
                var newWatcher = new LogWatcher(LogDirectoryTextBox.Text);
                newWatcher.OnSystemChanged += StarSystemChanged;
                if (LogWatcher != null)
                {
                    LogWatcher.ShutDown();
                }
                LogWatcher = newWatcher;
                logDirectoryNote.Text = "Watcher updated";
            }
            catch (Exception exc)
            {
                logDirectoryNote.Text = "Could not watch log directory: " + exc;
            }
        }

        private void StarSystemChanged(StarSystem newSystem)
        {
            if (newSystem == null) return;

            // Broadcast is sent by a background thread -- cannot set text directly.
            CurrentSystem.Invoke((Action) delegate
            {
                this.Text = newSystem.Name;
            });
        }

        private void GetCurrentSystemFromLog(object sender, EventArgs e)
        {
            if (LogWatcher == null) return;
            var loc = LogWatcher.CurrentSystem();
            if (loc == null) return;
            CurrentSystem.Text = loc.Name;
        }
    }
}
