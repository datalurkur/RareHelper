namespace RareCommodityHelper
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CurrentSystem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxJumpDistance = new System.Windows.Forms.TextBox();
            this.RareResults = new System.Windows.Forms.ListView();
            this.ComputeButton = new System.Windows.Forms.Button();
            this.LoadProgressBar = new System.Windows.Forms.ProgressBar();
            this.LoadProgressLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DestinationSystem = new System.Windows.Forms.ComboBox();
            this.PathButton = new System.Windows.Forms.Button();
            this.ResultsTabControl = new System.Windows.Forms.TabControl();
            this.RareResultsTab = new System.Windows.Forms.TabPage();
            this.PathResultsTab = new System.Windows.Forms.TabPage();
            this.PathResults = new System.Windows.Forms.ListView();
            this.RouteTab = new System.Windows.Forms.TabPage();
            this.RouteResults = new System.Windows.Forms.ListView();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.MaxDistanceUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxDistanceLabel = new System.Windows.Forms.Label();
            this.IgnoreUnknownStationDistanceCheckBox = new System.Windows.Forms.CheckBox();
            this.MaxDistanceCheckBox = new System.Windows.Forms.CheckBox();
            this.ReadDirectionsCheckBox = new System.Windows.Forms.CheckBox();
            this.ReadDirectionsLabel = new System.Windows.Forms.Label();
            this.logDirectoryNote = new System.Windows.Forms.Label();
            this.applyLogDirectoryButton = new System.Windows.Forms.Button();
            this.LogDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RouteButton = new System.Windows.Forms.Button();
            this.MaxJumps = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.JumpsPerLeg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IdealSellDistance = new System.Windows.Forms.TextBox();
            this.QuickSaveRouteButton = new System.Windows.Forms.Button();
            this.QuickLoadRouteButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.RareGoodSelector = new System.Windows.Forms.ComboBox();
            this.RareGoodLabel = new System.Windows.Forms.Label();
            this.BlacklistButton = new System.Windows.Forms.Button();
            this.UnblacklistButton = new System.Windows.Forms.Button();
            this.UpdateFromLogButton = new System.Windows.Forms.Button();
            this.ResultsTabControl.SuspendLayout();
            this.RareResultsTab.SuspendLayout();
            this.PathResultsTab.SuspendLayout();
            this.RouteTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxDistanceUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrentSystem
            // 
            this.CurrentSystem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CurrentSystem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CurrentSystem.BackColor = System.Drawing.Color.Silver;
            this.CurrentSystem.FormattingEnabled = true;
            this.CurrentSystem.Location = new System.Drawing.Point(17, 21);
            this.CurrentSystem.Name = "CurrentSystem";
            this.CurrentSystem.Size = new System.Drawing.Size(201, 22);
            this.CurrentSystem.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max Jump Distance";
            // 
            // MaxJumpDistance
            // 
            this.MaxJumpDistance.BackColor = System.Drawing.Color.Silver;
            this.MaxJumpDistance.Location = new System.Drawing.Point(19, 97);
            this.MaxJumpDistance.Name = "MaxJumpDistance";
            this.MaxJumpDistance.Size = new System.Drawing.Size(201, 21);
            this.MaxJumpDistance.TabIndex = 3;
            // 
            // RareResults
            // 
            this.RareResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RareResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RareResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RareResults.ForeColor = System.Drawing.Color.Silver;
            this.RareResults.FullRowSelect = true;
            this.RareResults.Location = new System.Drawing.Point(3, 3);
            this.RareResults.Name = "RareResults";
            this.RareResults.Size = new System.Drawing.Size(745, 631);
            this.RareResults.TabIndex = 4;
            this.RareResults.UseCompatibleStateImageBehavior = false;
            this.RareResults.View = System.Windows.Forms.View.Details;
            // 
            // ComputeButton
            // 
            this.ComputeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ComputeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComputeButton.Location = new System.Drawing.Point(19, 137);
            this.ComputeButton.Name = "ComputeButton";
            this.ComputeButton.Size = new System.Drawing.Size(202, 23);
            this.ComputeButton.TabIndex = 5;
            this.ComputeButton.Text = "Compute Rare Distances";
            this.ComputeButton.UseVisualStyleBackColor = false;
            // 
            // LoadProgressBar
            // 
            this.LoadProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadProgressBar.ForeColor = System.Drawing.Color.Silver;
            this.LoadProgressBar.Location = new System.Drawing.Point(14, 661);
            this.LoadProgressBar.Name = "LoadProgressBar";
            this.LoadProgressBar.Size = new System.Drawing.Size(204, 19);
            this.LoadProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.LoadProgressBar.TabIndex = 6;
            this.LoadProgressBar.Visible = false;
            // 
            // LoadProgressLabel
            // 
            this.LoadProgressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadProgressLabel.AutoSize = true;
            this.LoadProgressLabel.Location = new System.Drawing.Point(14, 647);
            this.LoadProgressLabel.Name = "LoadProgressLabel";
            this.LoadProgressLabel.Size = new System.Drawing.Size(207, 14);
            this.LoadProgressLabel.TabIndex = 7;
            this.LoadProgressLabel.Text = "Fetching Data From Web...";
            this.LoadProgressLabel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Destination System";
            // 
            // DestinationSystem
            // 
            this.DestinationSystem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DestinationSystem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DestinationSystem.BackColor = System.Drawing.Color.Silver;
            this.DestinationSystem.FormattingEnabled = true;
            this.DestinationSystem.Location = new System.Drawing.Point(18, 190);
            this.DestinationSystem.Name = "DestinationSystem";
            this.DestinationSystem.Size = new System.Drawing.Size(200, 22);
            this.DestinationSystem.TabIndex = 9;
            // 
            // PathButton
            // 
            this.PathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PathButton.Location = new System.Drawing.Point(17, 231);
            this.PathButton.Name = "PathButton";
            this.PathButton.Size = new System.Drawing.Size(202, 23);
            this.PathButton.TabIndex = 10;
            this.PathButton.Text = "Compute Path";
            this.PathButton.UseVisualStyleBackColor = true;
            // 
            // ResultsTabControl
            // 
            this.ResultsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsTabControl.Controls.Add(this.RareResultsTab);
            this.ResultsTabControl.Controls.Add(this.PathResultsTab);
            this.ResultsTabControl.Controls.Add(this.RouteTab);
            this.ResultsTabControl.Controls.Add(this.SettingsTab);
            this.ResultsTabControl.Location = new System.Drawing.Point(236, 13);
            this.ResultsTabControl.Name = "ResultsTabControl";
            this.ResultsTabControl.SelectedIndex = 0;
            this.ResultsTabControl.Size = new System.Drawing.Size(759, 665);
            this.ResultsTabControl.TabIndex = 11;
            // 
            // RareResultsTab
            // 
            this.RareResultsTab.Controls.Add(this.RareResults);
            this.RareResultsTab.Location = new System.Drawing.Point(4, 24);
            this.RareResultsTab.Name = "RareResultsTab";
            this.RareResultsTab.Padding = new System.Windows.Forms.Padding(3);
            this.RareResultsTab.Size = new System.Drawing.Size(751, 637);
            this.RareResultsTab.TabIndex = 0;
            this.RareResultsTab.Text = "Rare Distances";
            this.RareResultsTab.UseVisualStyleBackColor = true;
            // 
            // PathResultsTab
            // 
            this.PathResultsTab.Controls.Add(this.PathResults);
            this.PathResultsTab.Location = new System.Drawing.Point(4, 24);
            this.PathResultsTab.Name = "PathResultsTab";
            this.PathResultsTab.Padding = new System.Windows.Forms.Padding(3);
            this.PathResultsTab.Size = new System.Drawing.Size(751, 637);
            this.PathResultsTab.TabIndex = 1;
            this.PathResultsTab.Text = "Path";
            this.PathResultsTab.UseVisualStyleBackColor = true;
            // 
            // PathResults
            // 
            this.PathResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PathResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PathResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PathResults.ForeColor = System.Drawing.Color.Silver;
            this.PathResults.FullRowSelect = true;
            this.PathResults.Location = new System.Drawing.Point(3, 3);
            this.PathResults.Name = "PathResults";
            this.PathResults.Size = new System.Drawing.Size(745, 631);
            this.PathResults.TabIndex = 5;
            this.PathResults.UseCompatibleStateImageBehavior = false;
            this.PathResults.View = System.Windows.Forms.View.Details;
            // 
            // RouteTab
            // 
            this.RouteTab.Controls.Add(this.RouteResults);
            this.RouteTab.Location = new System.Drawing.Point(4, 24);
            this.RouteTab.Name = "RouteTab";
            this.RouteTab.Padding = new System.Windows.Forms.Padding(3);
            this.RouteTab.Size = new System.Drawing.Size(751, 637);
            this.RouteTab.TabIndex = 2;
            this.RouteTab.Text = "Route";
            this.RouteTab.UseVisualStyleBackColor = true;
            // 
            // RouteResults
            // 
            this.RouteResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RouteResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RouteResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RouteResults.ForeColor = System.Drawing.Color.Silver;
            this.RouteResults.FullRowSelect = true;
            this.RouteResults.Location = new System.Drawing.Point(3, 3);
            this.RouteResults.Name = "RouteResults";
            this.RouteResults.Size = new System.Drawing.Size(745, 631);
            this.RouteResults.TabIndex = 6;
            this.RouteResults.UseCompatibleStateImageBehavior = false;
            this.RouteResults.View = System.Windows.Forms.View.Details;
            // 
            // SettingsTab
            // 
            this.SettingsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SettingsTab.Controls.Add(this.MaxDistanceUpDown);
            this.SettingsTab.Controls.Add(this.MaxDistanceLabel);
            this.SettingsTab.Controls.Add(this.IgnoreUnknownStationDistanceCheckBox);
            this.SettingsTab.Controls.Add(this.MaxDistanceCheckBox);
            this.SettingsTab.Controls.Add(this.ReadDirectionsCheckBox);
            this.SettingsTab.Controls.Add(this.ReadDirectionsLabel);
            this.SettingsTab.Controls.Add(this.logDirectoryNote);
            this.SettingsTab.Controls.Add(this.applyLogDirectoryButton);
            this.SettingsTab.Controls.Add(this.LogDirectoryTextBox);
            this.SettingsTab.Controls.Add(this.label7);
            this.SettingsTab.ForeColor = System.Drawing.Color.Gainsboro;
            this.SettingsTab.Location = new System.Drawing.Point(4, 24);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTab.Size = new System.Drawing.Size(751, 637);
            this.SettingsTab.TabIndex = 3;
            this.SettingsTab.Text = "Settings";
            // 
            // MaxDistanceUpDown
            // 
            this.MaxDistanceUpDown.Location = new System.Drawing.Point(285, 173);
            this.MaxDistanceUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.MaxDistanceUpDown.Name = "MaxDistanceUpDown";
            this.MaxDistanceUpDown.Size = new System.Drawing.Size(80, 21);
            this.MaxDistanceUpDown.TabIndex = 17;
            this.MaxDistanceUpDown.Value = new decimal(new int[] {
            1250,
            0,
            0,
            0});
            this.MaxDistanceUpDown.Leave += new System.EventHandler(this.RareFiltersChanged);
            // 
            // MaxDistanceLabel
            // 
            this.MaxDistanceLabel.AutoSize = true;
            this.MaxDistanceLabel.Location = new System.Drawing.Point(371, 175);
            this.MaxDistanceLabel.Name = "MaxDistanceLabel";
            this.MaxDistanceLabel.Size = new System.Drawing.Size(199, 14);
            this.MaxDistanceLabel.TabIndex = 16;
            this.MaxDistanceLabel.Text = "Ls from the primary star";
            // 
            // IgnoreUnknownStationDistanceCheckBox
            // 
            this.IgnoreUnknownStationDistanceCheckBox.AutoSize = true;
            this.IgnoreUnknownStationDistanceCheckBox.Location = new System.Drawing.Point(28, 209);
            this.IgnoreUnknownStationDistanceCheckBox.Name = "IgnoreUnknownStationDistanceCheckBox";
            this.IgnoreUnknownStationDistanceCheckBox.Size = new System.Drawing.Size(333, 18);
            this.IgnoreUnknownStationDistanceCheckBox.TabIndex = 15;
            this.IgnoreUnknownStationDistanceCheckBox.Text = "Ignore stations with unknown distances";
            this.IgnoreUnknownStationDistanceCheckBox.UseVisualStyleBackColor = true;
            this.IgnoreUnknownStationDistanceCheckBox.CheckedChanged += new System.EventHandler(this.RareFiltersChanged);
            // 
            // MaxDistanceCheckBox
            // 
            this.MaxDistanceCheckBox.AutoSize = true;
            this.MaxDistanceCheckBox.Location = new System.Drawing.Point(28, 175);
            this.MaxDistanceCheckBox.Name = "MaxDistanceCheckBox";
            this.MaxDistanceCheckBox.Size = new System.Drawing.Size(253, 18);
            this.MaxDistanceCheckBox.TabIndex = 15;
            this.MaxDistanceCheckBox.Text = "Ignore stations further than";
            this.MaxDistanceCheckBox.UseVisualStyleBackColor = true;
            this.MaxDistanceCheckBox.CheckedChanged += new System.EventHandler(this.RareFiltersChanged);
            // 
            // ReadDirectionsCheckBox
            // 
            this.ReadDirectionsCheckBox.AutoSize = true;
            this.ReadDirectionsCheckBox.Location = new System.Drawing.Point(28, 100);
            this.ReadDirectionsCheckBox.Name = "ReadDirectionsCheckBox";
            this.ReadDirectionsCheckBox.Size = new System.Drawing.Size(149, 18);
            this.ReadDirectionsCheckBox.TabIndex = 12;
            this.ReadDirectionsCheckBox.Text = "Read Directions";
            this.ReadDirectionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReadDirectionsLabel
            // 
            this.ReadDirectionsLabel.AutoSize = true;
            this.ReadDirectionsLabel.Location = new System.Drawing.Point(36, 121);
            this.ReadDirectionsLabel.MaximumSize = new System.Drawing.Size(700, 0);
            this.ReadDirectionsLabel.Name = "ReadDirectionsLabel";
            this.ReadDirectionsLabel.Size = new System.Drawing.Size(679, 28);
            this.ReadDirectionsLabel.TabIndex = 11;
            this.ReadDirectionsLabel.Text = "When following a path, read the next system to navigate to after each system shif" +
    "t. Requires the Log Directory to be set correctly.";
            // 
            // logDirectoryNote
            // 
            this.logDirectoryNote.AutoSize = true;
            this.logDirectoryNote.Location = new System.Drawing.Point(36, 48);
            this.logDirectoryNote.Name = "logDirectoryNote";
            this.logDirectoryNote.Size = new System.Drawing.Size(671, 14);
            this.logDirectoryNote.TabIndex = 11;
            this.logDirectoryNote.Text = "You must enable verbose logging, or we won\'t be able to tell what system you\'re i" +
    "n.";
            // 
            // applyLogDirectoryButton
            // 
            this.applyLogDirectoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.applyLogDirectoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyLogDirectoryButton.ForeColor = System.Drawing.Color.Silver;
            this.applyLogDirectoryButton.Location = new System.Drawing.Point(656, 22);
            this.applyLogDirectoryButton.Name = "applyLogDirectoryButton";
            this.applyLogDirectoryButton.Size = new System.Drawing.Size(75, 23);
            this.applyLogDirectoryButton.TabIndex = 10;
            this.applyLogDirectoryButton.Text = "Apply";
            this.applyLogDirectoryButton.UseVisualStyleBackColor = false;
            this.applyLogDirectoryButton.Click += new System.EventHandler(this.UpdateLogDirectory);
            // 
            // LogDirectoryTextBox
            // 
            this.LogDirectoryTextBox.Location = new System.Drawing.Point(150, 22);
            this.LogDirectoryTextBox.Name = "LogDirectoryTextBox";
            this.LogDirectoryTextBox.Size = new System.Drawing.Size(500, 21);
            this.LogDirectoryTextBox.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "Log Directory:";
            // 
            // RouteButton
            // 
            this.RouteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RouteButton.Location = new System.Drawing.Point(14, 421);
            this.RouteButton.Name = "RouteButton";
            this.RouteButton.Size = new System.Drawing.Size(200, 23);
            this.RouteButton.TabIndex = 12;
            this.RouteButton.Text = "Compute Route";
            this.RouteButton.UseVisualStyleBackColor = true;
            // 
            // MaxJumps
            // 
            this.MaxJumps.Location = new System.Drawing.Point(14, 397);
            this.MaxJumps.Name = "MaxJumps";
            this.MaxJumps.Size = new System.Drawing.Size(100, 21);
            this.MaxJumps.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "Max Jumps";
            // 
            // JumpsPerLeg
            // 
            this.JumpsPerLeg.Location = new System.Drawing.Point(14, 362);
            this.JumpsPerLeg.Name = "JumpsPerLeg";
            this.JumpsPerLeg.Size = new System.Drawing.Size(100, 21);
            this.JumpsPerLeg.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 14);
            this.label5.TabIndex = 16;
            this.label5.Text = "Jumps Per Leg";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "Ideal Sell Distance";
            // 
            // IdealSellDistance
            // 
            this.IdealSellDistance.Location = new System.Drawing.Point(14, 325);
            this.IdealSellDistance.Name = "IdealSellDistance";
            this.IdealSellDistance.Size = new System.Drawing.Size(100, 21);
            this.IdealSellDistance.TabIndex = 18;
            // 
            // QuickSaveRouteButton
            // 
            this.QuickSaveRouteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuickSaveRouteButton.Location = new System.Drawing.Point(13, 451);
            this.QuickSaveRouteButton.Name = "QuickSaveRouteButton";
            this.QuickSaveRouteButton.Size = new System.Drawing.Size(95, 23);
            this.QuickSaveRouteButton.TabIndex = 19;
            this.QuickSaveRouteButton.Text = "Quick Save";
            this.QuickSaveRouteButton.UseVisualStyleBackColor = true;
            this.QuickSaveRouteButton.Click += new System.EventHandler(this.QuickSaveRoute);
            // 
            // QuickLoadRouteButton
            // 
            this.QuickLoadRouteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuickLoadRouteButton.Location = new System.Drawing.Point(114, 451);
            this.QuickLoadRouteButton.Name = "QuickLoadRouteButton";
            this.QuickLoadRouteButton.Size = new System.Drawing.Size(100, 23);
            this.QuickLoadRouteButton.TabIndex = 20;
            this.QuickLoadRouteButton.Text = "Quick Load";
            this.QuickLoadRouteButton.UseVisualStyleBackColor = true;
            this.QuickLoadRouteButton.Click += new System.EventHandler(this.QuickLoadRoute);
            // 
            // SaveButton
            // 
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Location = new System.Drawing.Point(12, 480);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(96, 23);
            this.SaveButton.TabIndex = 21;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // LoadButton
            // 
            this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadButton.Location = new System.Drawing.Point(114, 480);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(100, 23);
            this.LoadButton.TabIndex = 22;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            // 
            // RareGoodSelector
            // 
            this.RareGoodSelector.BackColor = System.Drawing.Color.Silver;
            this.RareGoodSelector.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.RareGoodSelector.FormattingEnabled = true;
            this.RareGoodSelector.Location = new System.Drawing.Point(12, 541);
            this.RareGoodSelector.Name = "RareGoodSelector";
            this.RareGoodSelector.Size = new System.Drawing.Size(202, 22);
            this.RareGoodSelector.TabIndex = 23;
            // 
            // RareGoodLabel
            // 
            this.RareGoodLabel.AutoSize = true;
            this.RareGoodLabel.Location = new System.Drawing.Point(12, 527);
            this.RareGoodLabel.Name = "RareGoodLabel";
            this.RareGoodLabel.Size = new System.Drawing.Size(79, 14);
            this.RareGoodLabel.TabIndex = 24;
            this.RareGoodLabel.Text = "Rare Good";
            // 
            // BlacklistButton
            // 
            this.BlacklistButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BlacklistButton.Location = new System.Drawing.Point(12, 567);
            this.BlacklistButton.Name = "BlacklistButton";
            this.BlacklistButton.Size = new System.Drawing.Size(96, 23);
            this.BlacklistButton.TabIndex = 25;
            this.BlacklistButton.Text = "Blacklist";
            this.BlacklistButton.UseVisualStyleBackColor = true;
            // 
            // UnblacklistButton
            // 
            this.UnblacklistButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UnblacklistButton.Location = new System.Drawing.Point(114, 567);
            this.UnblacklistButton.Name = "UnblacklistButton";
            this.UnblacklistButton.Size = new System.Drawing.Size(100, 23);
            this.UnblacklistButton.TabIndex = 26;
            this.UnblacklistButton.Text = "Un-Blacklist";
            this.UnblacklistButton.UseVisualStyleBackColor = true;
            // 
            // UpdateFromLogButton
            // 
            this.UpdateFromLogButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UpdateFromLogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateFromLogButton.Location = new System.Drawing.Point(18, 49);
            this.UpdateFromLogButton.Name = "UpdateFromLogButton";
            this.UpdateFromLogButton.Size = new System.Drawing.Size(202, 23);
            this.UpdateFromLogButton.TabIndex = 27;
            this.UpdateFromLogButton.Text = "Update From Log";
            this.UpdateFromLogButton.UseVisualStyleBackColor = false;
            this.UpdateFromLogButton.Click += new System.EventHandler(this.GetCurrentSystemFromLog);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1007, 690);
            this.Controls.Add(this.UpdateFromLogButton);
            this.Controls.Add(this.UnblacklistButton);
            this.Controls.Add(this.BlacklistButton);
            this.Controls.Add(this.RareGoodLabel);
            this.Controls.Add(this.RareGoodSelector);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.QuickLoadRouteButton);
            this.Controls.Add(this.QuickSaveRouteButton);
            this.Controls.Add(this.IdealSellDistance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.JumpsPerLeg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MaxJumps);
            this.Controls.Add(this.RouteButton);
            this.Controls.Add(this.ResultsTabControl);
            this.Controls.Add(this.PathButton);
            this.Controls.Add(this.DestinationSystem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LoadProgressLabel);
            this.Controls.Add(this.LoadProgressBar);
            this.Controls.Add(this.ComputeButton);
            this.Controls.Add(this.MaxJumpDistance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CurrentSystem);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Silver;
            this.Name = "MainForm";
            this.Text = "Rare Commodity Helper";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResultsTabControl.ResumeLayout(false);
            this.RareResultsTab.ResumeLayout(false);
            this.PathResultsTab.ResumeLayout(false);
            this.RouteTab.ResumeLayout(false);
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxDistanceUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CurrentSystem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MaxJumpDistance;
        private System.Windows.Forms.ListView RareResults;
        private System.Windows.Forms.Button ComputeButton;
        private System.Windows.Forms.ProgressBar LoadProgressBar;
        private System.Windows.Forms.Label LoadProgressLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox DestinationSystem;
        private System.Windows.Forms.Button PathButton;
        private System.Windows.Forms.TabControl ResultsTabControl;
        private System.Windows.Forms.TabPage RareResultsTab;
        private System.Windows.Forms.TabPage PathResultsTab;
        private System.Windows.Forms.ListView PathResults;
        private System.Windows.Forms.Button RouteButton;
        private System.Windows.Forms.TabPage RouteTab;
        private System.Windows.Forms.ListView RouteResults;
        private System.Windows.Forms.TextBox MaxJumps;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox JumpsPerLeg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox IdealSellDistance;
        private System.Windows.Forms.Button QuickSaveRouteButton;
        private System.Windows.Forms.Button QuickLoadRouteButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.ComboBox RareGoodSelector;
        private System.Windows.Forms.Label RareGoodLabel;
        private System.Windows.Forms.Button BlacklistButton;
        private System.Windows.Forms.Button UnblacklistButton;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.Button applyLogDirectoryButton;
        private System.Windows.Forms.TextBox LogDirectoryTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label logDirectoryNote;
        private System.Windows.Forms.Button UpdateFromLogButton;
        private System.Windows.Forms.CheckBox ReadDirectionsCheckBox;
        private System.Windows.Forms.Label ReadDirectionsLabel;
        private System.Windows.Forms.CheckBox MaxDistanceCheckBox;
        private System.Windows.Forms.NumericUpDown MaxDistanceUpDown;
        private System.Windows.Forms.Label MaxDistanceLabel;
        private System.Windows.Forms.CheckBox IgnoreUnknownStationDistanceCheckBox;
    }
}

