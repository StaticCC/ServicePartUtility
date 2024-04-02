namespace PartChecker
{
    partial class AddRequest
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
            this.ROIDInput = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.Description = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.PartNumberServiceInput = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.NotesTextbox = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.AddRequestButton = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // ROIDInput
            // 
            this.ROIDInput.AnimateReadOnly = false;
            this.ROIDInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ROIDInput.Depth = 0;
            this.ROIDInput.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ROIDInput.Hint = "RO/Cust. ID";
            this.ROIDInput.LeadingIcon = null;
            this.ROIDInput.Location = new System.Drawing.Point(6, 90);
            this.ROIDInput.MaxLength = 50;
            this.ROIDInput.MouseState = MaterialSkin.MouseState.OUT;
            this.ROIDInput.Multiline = false;
            this.ROIDInput.Name = "ROIDInput";
            this.ROIDInput.Size = new System.Drawing.Size(205, 50);
            this.ROIDInput.TabIndex = 0;
            this.ROIDInput.Text = "";
            this.ROIDInput.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(6, 69);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(124, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "RO/Customer ID: ";
            // 
            // Description
            // 
            this.Description.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Description.Depth = 0;
            this.Description.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Description.Hint = "UCI /PDI / CUSTOMER PAY / AFTERMARKET / GM";
            this.Description.Location = new System.Drawing.Point(6, 165);
            this.Description.MouseState = MaterialSkin.MouseState.HOVER;
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(326, 113);
            this.Description.TabIndex = 2;
            this.Description.Text = "";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(6, 143);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(89, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Description: ";
            // 
            // PartNumberServiceInput
            // 
            this.PartNumberServiceInput.AnimateReadOnly = false;
            this.PartNumberServiceInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PartNumberServiceInput.Depth = 0;
            this.PartNumberServiceInput.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PartNumberServiceInput.Hint = "Part Number (if any)";
            this.PartNumberServiceInput.LeadingIcon = null;
            this.PartNumberServiceInput.Location = new System.Drawing.Point(6, 303);
            this.PartNumberServiceInput.MaxLength = 50;
            this.PartNumberServiceInput.MouseState = MaterialSkin.MouseState.OUT;
            this.PartNumberServiceInput.Multiline = false;
            this.PartNumberServiceInput.Name = "PartNumberServiceInput";
            this.PartNumberServiceInput.Size = new System.Drawing.Size(205, 50);
            this.PartNumberServiceInput.TabIndex = 4;
            this.PartNumberServiceInput.Text = "";
            this.PartNumberServiceInput.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(6, 281);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(94, 19);
            this.materialLabel3.TabIndex = 5;
            this.materialLabel3.Text = "Part Number:";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(6, 359);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(46, 19);
            this.materialLabel4.TabIndex = 7;
            this.materialLabel4.Text = "Notes:";
            // 
            // NotesTextbox
            // 
            this.NotesTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NotesTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NotesTextbox.Depth = 0;
            this.NotesTextbox.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.NotesTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.NotesTextbox.Hint = "Need ASAP";
            this.NotesTextbox.Location = new System.Drawing.Point(6, 381);
            this.NotesTextbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.NotesTextbox.Name = "NotesTextbox";
            this.NotesTextbox.Size = new System.Drawing.Size(326, 113);
            this.NotesTextbox.TabIndex = 6;
            this.NotesTextbox.Text = "";
            // 
            // AddRequestButton
            // 
            this.AddRequestButton.AutoSize = false;
            this.AddRequestButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddRequestButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AddRequestButton.Depth = 0;
            this.AddRequestButton.HighEmphasis = true;
            this.AddRequestButton.Icon = null;
            this.AddRequestButton.Location = new System.Drawing.Point(6, 501);
            this.AddRequestButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddRequestButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddRequestButton.Name = "AddRequestButton";
            this.AddRequestButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AddRequestButton.Size = new System.Drawing.Size(326, 64);
            this.AddRequestButton.TabIndex = 8;
            this.AddRequestButton.Text = "Add Request";
            this.AddRequestButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddRequestButton.UseAccentColor = false;
            this.AddRequestButton.UseVisualStyleBackColor = true;
            this.AddRequestButton.Click += new System.EventHandler(this.AddRequestButton_Click);
            // 
            // AddRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 574);
            this.Controls.Add(this.AddRequestButton);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.NotesTextbox);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.PartNumberServiceInput);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.ROIDInput);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRequest";
            this.Text = "Add Request (Service)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox ROIDInput;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialMultiLineTextBox Description;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox PartNumberServiceInput;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialMultiLineTextBox NotesTextbox;
        private MaterialSkin.Controls.MaterialButton AddRequestButton;
    }
}