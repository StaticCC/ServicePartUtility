namespace PartChecker
{
    partial class PartInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartInventory));
            this.AddPart = new MaterialSkin.Controls.MaterialButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.LastUpdateDateTime = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.PWBStatus = new System.Windows.Forms.Label();
            this.colonialLabel = new System.Windows.Forms.Label();
            this.PartsList = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ROList = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProgressBar = new MaterialSkin.Controls.MaterialProgressBar();
            this.SuspendLayout();
            // 
            // AddPart
            // 
            this.AddPart.AutoSize = false;
            this.AddPart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddPart.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AddPart.Depth = 0;
            this.AddPart.HighEmphasis = true;
            this.AddPart.Icon = null;
            this.AddPart.Location = new System.Drawing.Point(9, 77);
            this.AddPart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddPart.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddPart.Name = "AddPart";
            this.AddPart.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AddPart.Size = new System.Drawing.Size(118, 36);
            this.AddPart.TabIndex = 1;
            this.AddPart.Text = "Add Part";
            this.AddPart.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddPart.UseAccentColor = false;
            this.AddPart.UseVisualStyleBackColor = true;
            this.AddPart.Click += new System.EventHandler(this.AddPart_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(3, 64);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 386);
            this.splitter1.TabIndex = 16;
            this.splitter1.TabStop = false;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(135, 77);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(100, 36);
            this.materialButton1.TabIndex = 21;
            this.materialButton1.Text = "Check ETA";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // LastUpdateDateTime
            // 
            this.LastUpdateDateTime.AutoSize = true;
            this.LastUpdateDateTime.Depth = 0;
            this.LastUpdateDateTime.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LastUpdateDateTime.Location = new System.Drawing.Point(699, 68);
            this.LastUpdateDateTime.MouseState = MaterialSkin.MouseState.HOVER;
            this.LastUpdateDateTime.Name = "LastUpdateDateTime";
            this.LastUpdateDateTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LastUpdateDateTime.Size = new System.Drawing.Size(248, 19);
            this.LastUpdateDateTime.TabIndex = 22;
            this.LastUpdateDateTime.Text = "Last Update: 03/22/2024 01:23PM";
            this.LastUpdateDateTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSize = false;
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.BackColor = System.Drawing.Color.Transparent;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.DrawShadows = false;
            this.materialButton2.HighEmphasis = false;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(962, 31);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(32, 22);
            this.materialButton2.TabIndex = 23;
            this.materialButton2.Text = "?";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = false;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // PWBStatus
            // 
            this.PWBStatus.AutoSize = true;
            this.PWBStatus.BackColor = System.Drawing.Color.Transparent;
            this.PWBStatus.ForeColor = System.Drawing.Color.Red;
            this.PWBStatus.Location = new System.Drawing.Point(620, 71);
            this.PWBStatus.Name = "PWBStatus";
            this.PWBStatus.Size = new System.Drawing.Size(74, 13);
            this.PWBStatus.TabIndex = 25;
            this.PWBStatus.Text = "PWB is down!";
            this.PWBStatus.Visible = false;
            // 
            // colonialLabel
            // 
            this.colonialLabel.AutoSize = true;
            this.colonialLabel.BackColor = System.Drawing.Color.Transparent;
            this.colonialLabel.ForeColor = System.Drawing.Color.White;
            this.colonialLabel.Location = new System.Drawing.Point(230, 37);
            this.colonialLabel.Name = "colonialLabel";
            this.colonialLabel.Size = new System.Drawing.Size(123, 13);
            this.colonialLabel.TabIndex = 26;
            this.colonialLabel.Text = "Dealership name";
            // 
            // PartsList
            // 
            this.PartsList.AutoSizeTable = false;
            this.PartsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PartsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PartsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.PartsList.Depth = 0;
            this.PartsList.FullRowSelect = true;
            this.PartsList.HideSelection = false;
            this.PartsList.Location = new System.Drawing.Point(242, 116);
            this.PartsList.MinimumSize = new System.Drawing.Size(200, 100);
            this.PartsList.MouseLocation = new System.Drawing.Point(-1, -1);
            this.PartsList.MouseState = MaterialSkin.MouseState.OUT;
            this.PartsList.Name = "PartsList";
            this.PartsList.OwnerDraw = true;
            this.PartsList.Size = new System.Drawing.Size(752, 331);
            this.PartsList.TabIndex = 27;
            this.PartsList.UseCompatibleStateImageBehavior = false;
            this.PartsList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Part #";
            this.columnHeader1.Width = 118;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ETA";
            this.columnHeader2.Width = 195;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 439;
            // 
            // ROList
            // 
            this.ROList.AutoSizeTable = false;
            this.ROList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ROList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ROList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.ROList.Depth = 0;
            this.ROList.FullRowSelect = true;
            this.ROList.HideSelection = false;
            this.ROList.Location = new System.Drawing.Point(9, 116);
            this.ROList.MinimumSize = new System.Drawing.Size(200, 100);
            this.ROList.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ROList.MouseState = MaterialSkin.MouseState.OUT;
            this.ROList.Name = "ROList";
            this.ROList.OwnerDraw = true;
            this.ROList.Size = new System.Drawing.Size(226, 331);
            this.ROList.TabIndex = 28;
            this.ROList.UseCompatibleStateImageBehavior = false;
            this.ROList.View = System.Windows.Forms.View.Details;
            this.ROList.ItemActivate += new System.EventHandler(this.ROList_ItemActivate_1);
            this.ROList.SelectedIndexChanged += new System.EventHandler(this.ROList_SelectedIndexChanged_1);
            this.ROList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ROList_MouseDown_1);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "RO/Cust ID";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status";
            this.columnHeader5.Width = 106;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Depth = 0;
            this.ProgressBar.Location = new System.Drawing.Point(242, 95);
            this.ProgressBar.MaximumSize = new System.Drawing.Size(752, 15);
            this.ProgressBar.Minimum = 10;
            this.ProgressBar.MinimumSize = new System.Drawing.Size(752, 15);
            this.ProgressBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(752, 15);
            this.ProgressBar.TabIndex = 29;
            this.ProgressBar.Value = 15;
            this.ProgressBar.Visible = false;
            // 
            // PartInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 453);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.ROList);
            this.Controls.Add(this.PartsList);
            this.Controls.Add(this.colonialLabel);
            this.Controls.Add(this.PWBStatus);
            this.Controls.Add(this.materialButton2);
            this.Controls.Add(this.LastUpdateDateTime);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.AddPart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1001, 453);
            this.MinimumSize = new System.Drawing.Size(1001, 453);
            this.Name = "PartInventory";
            this.Text = "Service Part Utility v1.5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PartInventory_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton AddPart;
        private System.Windows.Forms.Splitter splitter1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialLabel LastUpdateDateTime;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private System.Windows.Forms.Label PWBStatus;
        private System.Windows.Forms.Label colonialLabel;
        private MaterialSkin.Controls.MaterialListView PartsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private MaterialSkin.Controls.MaterialListView ROList;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private MaterialSkin.Controls.MaterialProgressBar ProgressBar;
    }
}