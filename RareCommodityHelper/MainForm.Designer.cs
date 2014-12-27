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
            this.ResultsView = new System.Windows.Forms.ListView();
            this.ComputeButton = new System.Windows.Forms.Button();
            this.LoadProgressBar = new System.Windows.Forms.ProgressBar();
            this.LoadProgressLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DestinationSystem = new System.Windows.Forms.ComboBox();
            this.RouteButton = new System.Windows.Forms.Button();
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
            // ResultsView
            // 
            this.ResultsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultsView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ResultsView.ForeColor = System.Drawing.Color.Silver;
            this.ResultsView.FullRowSelect = true;
            this.ResultsView.Location = new System.Drawing.Point(285, 10);
            this.ResultsView.Name = "ResultsView";
            this.ResultsView.Size = new System.Drawing.Size(840, 567);
            this.ResultsView.TabIndex = 4;
            this.ResultsView.UseCompatibleStateImageBehavior = false;
            this.ResultsView.View = System.Windows.Forms.View.Details;
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
            this.LoadProgressBar.Location = new System.Drawing.Point(14, 558);
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
            this.LoadProgressLabel.Location = new System.Drawing.Point(14, 544);
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
            // RouteButton
            // 
            this.RouteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RouteButton.Location = new System.Drawing.Point(17, 231);
            this.RouteButton.Name = "RouteButton";
            this.RouteButton.Size = new System.Drawing.Size(202, 23);
            this.RouteButton.TabIndex = 10;
            this.RouteButton.Text = "Compute Route";
            this.RouteButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1139, 587);
            this.Controls.Add(this.RouteButton);
            this.Controls.Add(this.DestinationSystem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LoadProgressLabel);
            this.Controls.Add(this.LoadProgressBar);
            this.Controls.Add(this.ComputeButton);
            this.Controls.Add(this.ResultsView);
            this.Controls.Add(this.MaxJumpDistance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CurrentSystem);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Silver;
            this.Name = "MainForm";
            this.Text = "Rare Commodity Helper";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CurrentSystem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MaxJumpDistance;
        private System.Windows.Forms.ListView ResultsView;
        private System.Windows.Forms.Button ComputeButton;
        private System.Windows.Forms.ProgressBar LoadProgressBar;
        private System.Windows.Forms.Label LoadProgressLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox DestinationSystem;
        private System.Windows.Forms.Button RouteButton;
    }
}

