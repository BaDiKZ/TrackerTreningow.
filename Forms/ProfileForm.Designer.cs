namespace TrackerTreningow_.Forms
{
    partial class ProfileForm
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
            lstProfiles = new ListBox();
            txtNewName = new TextBox();
            btnCreate = new Button();
            btnDelete = new Button();
            btnSelect = new Button();
            SuspendLayout();
            // 
            // lstProfiles
            // 
            lstProfiles.FormattingEnabled = true;
            lstProfiles.Location = new Point(12, 12);
            lstProfiles.Name = "lstProfiles";
            lstProfiles.Size = new Size(237, 94);
            lstProfiles.TabIndex = 0;
            // 
            // txtNewName
            // 
            txtNewName.Location = new Point(12, 122);
            txtNewName.Name = "txtNewName";
            txtNewName.Size = new Size(237, 23);
            txtNewName.TabIndex = 1;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(12, 173);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Utworz";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(93, 173);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Usun";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(174, 173);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(75, 23);
            btnSelect.TabIndex = 4;
            btnSelect.Text = "Wybierz";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSelect);
            Controls.Add(btnDelete);
            Controls.Add(btnCreate);
            Controls.Add(txtNewName);
            Controls.Add(lstProfiles);
            Name = "ProfileForm";
            Text = "ProfileForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstProfiles;
        private TextBox txtNewName;
        private Button btnCreate;
        private Button btnDelete;
        private Button btnSelect;
    }
}