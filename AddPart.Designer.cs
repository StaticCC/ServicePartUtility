namespace PartChecker
{
    partial class AddPart
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
            this.IDNumberInput = new MaterialSkin.Controls.MaterialTextBox2();
            this.PartNumberInput = new MaterialSkin.Controls.MaterialTextBox2();
            this.EtaInput = new MaterialSkin.Controls.MaterialTextBox2();
            this.StatusCombo = new MaterialSkin.Controls.MaterialComboBox();
            this.AddPartButton = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // IDNumberInput
            // 
            this.IDNumberInput.AnimateReadOnly = false;
            this.IDNumberInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.IDNumberInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.IDNumberInput.Depth = 0;
            this.IDNumberInput.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.IDNumberInput.HelperText = "RO/Cust ID Number";
            this.IDNumberInput.HideSelection = true;
            this.IDNumberInput.Hint = "RO/Cust ID Number";
            this.IDNumberInput.LeadingIcon = null;
            this.IDNumberInput.Location = new System.Drawing.Point(7, 68);
            this.IDNumberInput.MaxLength = 32767;
            this.IDNumberInput.MouseState = MaterialSkin.MouseState.OUT;
            this.IDNumberInput.Name = "IDNumberInput";
            this.IDNumberInput.PasswordChar = '\0';
            this.IDNumberInput.PrefixSuffixText = null;
            this.IDNumberInput.ReadOnly = false;
            this.IDNumberInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IDNumberInput.SelectedText = "";
            this.IDNumberInput.SelectionLength = 0;
            this.IDNumberInput.SelectionStart = 0;
            this.IDNumberInput.ShortcutsEnabled = true;
            this.IDNumberInput.Size = new System.Drawing.Size(250, 36);
            this.IDNumberInput.TabIndex = 0;
            this.IDNumberInput.TabStop = false;
            this.IDNumberInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.IDNumberInput.TrailingIcon = null;
            this.IDNumberInput.UseSystemPasswordChar = false;
            this.IDNumberInput.UseTallSize = false;
            // 
            // PartNumberInput
            // 
            this.PartNumberInput.AnimateReadOnly = false;
            this.PartNumberInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PartNumberInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.PartNumberInput.Depth = 0;
            this.PartNumberInput.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PartNumberInput.HelperText = "Part Number";
            this.PartNumberInput.HideSelection = true;
            this.PartNumberInput.Hint = "Part Number";
            this.PartNumberInput.LeadingIcon = null;
            this.PartNumberInput.Location = new System.Drawing.Point(7, 110);
            this.PartNumberInput.MaxLength = 32767;
            this.PartNumberInput.MouseState = MaterialSkin.MouseState.OUT;
            this.PartNumberInput.Name = "PartNumberInput";
            this.PartNumberInput.PasswordChar = '\0';
            this.PartNumberInput.PrefixSuffixText = null;
            this.PartNumberInput.ReadOnly = false;
            this.PartNumberInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PartNumberInput.SelectedText = "";
            this.PartNumberInput.SelectionLength = 0;
            this.PartNumberInput.SelectionStart = 0;
            this.PartNumberInput.ShortcutsEnabled = true;
            this.PartNumberInput.Size = new System.Drawing.Size(250, 36);
            this.PartNumberInput.TabIndex = 1;
            this.PartNumberInput.TabStop = false;
            this.PartNumberInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PartNumberInput.TrailingIcon = null;
            this.PartNumberInput.UseSystemPasswordChar = false;
            this.PartNumberInput.UseTallSize = false;
            // 
            // EtaInput
            // 
            this.EtaInput.AnimateReadOnly = false;
            this.EtaInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.EtaInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.EtaInput.Depth = 0;
            this.EtaInput.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.EtaInput.HelperText = "ETA";
            this.EtaInput.HideSelection = true;
            this.EtaInput.Hint = "ETA";
            this.EtaInput.LeadingIcon = null;
            this.EtaInput.Location = new System.Drawing.Point(7, 152);
            this.EtaInput.MaxLength = 32767;
            this.EtaInput.MouseState = MaterialSkin.MouseState.OUT;
            this.EtaInput.Name = "EtaInput";
            this.EtaInput.PasswordChar = '\0';
            this.EtaInput.PrefixSuffixText = null;
            this.EtaInput.ReadOnly = false;
            this.EtaInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EtaInput.SelectedText = "";
            this.EtaInput.SelectionLength = 0;
            this.EtaInput.SelectionStart = 0;
            this.EtaInput.ShortcutsEnabled = true;
            this.EtaInput.Size = new System.Drawing.Size(250, 36);
            this.EtaInput.TabIndex = 2;
            this.EtaInput.TabStop = false;
            this.EtaInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.EtaInput.TrailingIcon = null;
            this.EtaInput.UseSystemPasswordChar = false;
            this.EtaInput.UseTallSize = false;
            // 
            // StatusCombo
            // 
            this.StatusCombo.AutoResize = false;
            this.StatusCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.StatusCombo.Depth = 0;
            this.StatusCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.StatusCombo.DropDownHeight = 118;
            this.StatusCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusCombo.DropDownWidth = 121;
            this.StatusCombo.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.StatusCombo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.StatusCombo.FormattingEnabled = true;
            this.StatusCombo.Hint = "Status";
            this.StatusCombo.IntegralHeight = false;
            this.StatusCombo.ItemHeight = 29;
            this.StatusCombo.Items.AddRange(new object[] {
            "No ETA",
            "On Order",
            "Written",
            "Shipped",
            "On Back Order",
            "Received",
            "Cancelled"});
            this.StatusCombo.Location = new System.Drawing.Point(264, 68);
            this.StatusCombo.MaxDropDownItems = 4;
            this.StatusCombo.MouseState = MaterialSkin.MouseState.OUT;
            this.StatusCombo.Name = "StatusCombo";
            this.StatusCombo.Size = new System.Drawing.Size(205, 35);
            this.StatusCombo.StartIndex = 0;
            this.StatusCombo.TabIndex = 3;
            this.StatusCombo.UseTallSize = false;
            // 
            // AddPartButton
            // 
            this.AddPartButton.AutoSize = false;
            this.AddPartButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddPartButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AddPartButton.Depth = 0;
            this.AddPartButton.HighEmphasis = true;
            this.AddPartButton.Icon = null;
            this.AddPartButton.Location = new System.Drawing.Point(264, 110);
            this.AddPartButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddPartButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddPartButton.Name = "AddPartButton";
            this.AddPartButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AddPartButton.Size = new System.Drawing.Size(205, 78);
            this.AddPartButton.TabIndex = 4;
            this.AddPartButton.Text = "Add Part";
            this.AddPartButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddPartButton.UseAccentColor = false;
            this.AddPartButton.UseVisualStyleBackColor = true;
            this.AddPartButton.Click += new System.EventHandler(this.AddPartButton_Click);
            // 
            // AddPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 198);
            this.Controls.Add(this.AddPartButton);
            this.Controls.Add(this.StatusCombo);
            this.Controls.Add(this.EtaInput);
            this.Controls.Add(this.PartNumberInput);
            this.Controls.Add(this.IDNumberInput);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(477, 198);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(477, 198);
            this.Name = "AddPart";
            this.Text = "Add Part (Parts Dep.)";
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 IDNumberInput;
        private MaterialSkin.Controls.MaterialTextBox2 PartNumberInput;
        private MaterialSkin.Controls.MaterialTextBox2 EtaInput;
        private MaterialSkin.Controls.MaterialComboBox StatusCombo;
        private MaterialSkin.Controls.MaterialButton AddPartButton;
    }
}