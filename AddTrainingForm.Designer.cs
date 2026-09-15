namespace TrackerTreningow_
{
    partial class AddTrainingForm
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
            dtpDate = new DateTimePicker();
            cmbType = new ComboBox();
            txtMinutes = new TextBox();
            txtNote = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            chkImportant = new CheckBox();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(12, 12);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(178, 23);
            dtpDate.TabIndex = 0;
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "Bieg", "Silownia", "Rower", "Plywanie", "Inne" });
            cmbType.Location = new Point(12, 41);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(178, 23);
            cmbType.TabIndex = 2;
            // 
            // txtMinutes
            // 
            txtMinutes.Location = new Point(12, 70);
            txtMinutes.Name = "txtMinutes";
            txtMinutes.Size = new Size(178, 23);
            txtMinutes.TabIndex = 3;
            // 
            // txtNote
            // 
            txtNote.Location = new Point(12, 99);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(178, 80);
            txtNote.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 224);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(85, 28);
            btnSave.TabIndex = 5;
            btnSave.Text = "Zapisz";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(106, 224);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(84, 28);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Anuluj";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // chkImportant
            // 
            chkImportant.AutoSize = true;
            chkImportant.Location = new Point(14, 185);
            chkImportant.Name = "chkImportant";
            chkImportant.Size = new Size(102, 19);
            chkImportant.TabIndex = 7;
            chkImportant.Text = "Wazny trening";
            chkImportant.UseVisualStyleBackColor = true;
            // 
            // AddTrainingForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(364, 321);
            Controls.Add(chkImportant);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtNote);
            Controls.Add(txtMinutes);
            Controls.Add(cmbType);
            Controls.Add(dtpDate);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddTrainingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dodaj Trening";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpDate;
        private ComboBox cmbType;
        private TextBox txtMinutes;
        private TextBox txtNote;
        private Button btnSave;
        private Button btnCancel;
        private CheckBox chkImportant;
    }
}