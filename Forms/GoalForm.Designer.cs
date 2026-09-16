namespace TrackerTreningow_
{
    partial class GoalForm
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
            numTarget = new NumericUpDown();
            lblMonth = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numTarget).BeginInit();
            SuspendLayout();
            // 
            // numTarget
            // 
            numTarget.Increment = new decimal(new int[] { 30, 0, 0, 0 });
            numTarget.Location = new Point(42, 12);
            numTarget.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numTarget.Name = "numTarget";
            numTarget.Size = new Size(120, 23);
            numTarget.TabIndex = 0;
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Location = new Point(83, 49);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(38, 15);
            lblMonth.TabIndex = 1;
            lblMonth.Text = "label1";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 80);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Zapisz";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(106, 80);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Anuluj";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // GoalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblMonth);
            Controls.Add(numTarget);
            Name = "GoalForm";
            Text = "GoalForm";
            ((System.ComponentModel.ISupportInitialize)numTarget).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numTarget;
        private Label lblMonth;
        private Button btnSave;
        private Button btnCancel;
    }
}