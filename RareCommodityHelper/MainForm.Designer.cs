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
            this.RouteButton = new System.Windows.Forms.Button();
            this.MaxJumps = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.JumpsPerLeg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IdealSellDistance = new System.Windows.Forms.TextBox();
            this.ResultsTabControl.SuspendLayout();
            this.RareResultsTab.SuspendLayout();
            this.PathResultsTab.SuspendLayout();
            this.RouteTab.SuspendLayout();
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
            this.CurrentSystem.Size = new System.Drawing.Size(201, 19);
            this.CurrentSystem.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 11);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 11);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max Jump Distance";
            // 
            // MaxJumpDistance
            // 
            this.MaxJumpDistance.BackColor = System.Drawing.Color.Silver;
            this.MaxJumpDistance.Location = new System.Drawing.Point(17, 59);
            this.MaxJumpDistance.Name = "MaxJumpDistance";
            this.MaxJumpDistance.Size = new System.Drawing.Size(201, 18);
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
            this.RareResults.Size = new System.Drawing.Size(745, 634);
            this.RareResults.TabIndex = 4;
            this.RareResults.UseCompatibleStateImageBehavior = false;
            this.RareResults.View = System.Windows.Forms.View.Details;
            // 
            // ComputeButton
            // 
            this.ComputeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ComputeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComputeButton.Location = new System.Drawing.Point(17, 99);
            this.ComputeButton.Name = "ComputeButton";
            this.ComputeButton.Size = new System.Drawing.Size(202, 19);
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
            this.LoadProgressLabel.Size = new System.Drawing.Size(180, 11);
            this.LoadProgressLabel.TabIndex = 7;
            this.LoadProgressLabel.Text = "Fetching Data From Web...";
            this.LoadProgressLabel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 11);
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
            this.DestinationSystem.Size = new System.Drawing.Size(200, 19);
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
            this.ResultsTabControl.Location = new System.Drawing.Point(236, 13);
            this.ResultsTabControl.Name = "ResultsTabControl";
            this.ResultsTabControl.SelectedIndex = 0;
            this.ResultsTabControl.Size = new System.Drawing.Size(759, 665);
            this.ResultsTabControl.TabIndex = 11;
            // 
            // RareResultsTab
            // 
            this.RareResultsTab.Controls.Add(this.RareResults);
            this.RareResultsTab.Location = new System.Drawing.Point(4, 21);
            this.RareResultsTab.Name = "RareResultsTab";
            this.RareResultsTab.Padding = new System.Windows.Forms.Padding(3);
            this.RareResultsTab.Size = new System.Drawing.Size(751, 640);
            this.RareResultsTab.TabIndex = 0;
            this.RareResultsTab.Text = "Rare Distances";
            this.RareResultsTab.UseVisualStyleBackColor = true;
            // 
            // PathResultsTab
            // 
            this.PathResultsTab.Controls.Add(this.PathResults);
            this.PathResultsTab.Location = new System.Drawing.Point(4, 21);
            this.PathResultsTab.Name = "PathResultsTab";
            this.PathResultsTab.Padding = new System.Windows.Forms.Padding(3);
            this.PathResultsTab.Size = new System.Drawing.Size(751, 640);
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
            this.PathResults.Size = new System.Drawing.Size(745, 634);
            this.PathResults.TabIndex = 5;
            this.PathResults.UseCompatibleStateImageBehavior = false;
            this.PathResults.View = System.Windows.Forms.View.Details;
            this.PathResults.SelectedIndexChanged += new System.EventHandler(this.RouteResults_SelectedIndexChanged);
            // 
            // RouteTab
            // 
            this.RouteTab.Controls.Add(this.RouteResults);
            this.RouteTab.Location = new System.Drawing.Point(4, 21);
            this.RouteTab.Name = "RouteTab";
            this.RouteTab.Padding = new System.Windows.Forms.Padding(3);
            this.RouteTab.Size = new System.Drawing.Size(751, 640);
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
            this.RouteResults.Size = new System.Drawing.Size(745, 634);
            this.RouteResults.TabIndex = 6;
            this.RouteResults.UseCompatibleStateImageBehavior = false;
            this.RouteResults.View = System.Windows.Forms.View.Details;
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
            this.MaxJumps.Size = new System.Drawing.Size(100, 18);
            this.MaxJumps.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 11);
            this.label4.TabIndex = 14;
            this.label4.Text = "Max Jumps";
            // 
            // JumpsPerLeg
            // 
            this.JumpsPerLeg.Location = new System.Drawing.Point(14, 362);
            this.JumpsPerLeg.Name = "JumpsPerLeg";
            this.JumpsPerLeg.Size = new System.Drawing.Size(100, 18);
            this.JumpsPerLeg.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 11);
            this.label5.TabIndex = 16;
            this.label5.Text = "Jumps Per Leg";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 11);
            this.label6.TabIndex = 17;
            this.label6.Text = "Ideal Sell Distance";
            // 
            // IdealSellDistance
            // 
            this.IdealSellDistance.Location = new System.Drawing.Point(14, 325);
            this.IdealSellDistance.Name = "IdealSellDistance";
            this.IdealSellDistance.Size = new System.Drawing.Size(100, 18);
            this.IdealSellDistance.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1007, 690);
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
    }
}

