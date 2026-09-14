namespace TrackerTreningow_
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnAdd = new Button();
            dgvTrainings = new DataGridView();
            lblSum = new Label();
            lblCount = new Label();
            btnDelete = new Button();
            dtpMonth = new DateTimePicker();
            label1 = new Label();
            lblAvg = new Label();
            btnEdit = new Button();
            lblSaveInfo = new Label();
            btnOpen = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTrainings).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            resources.ApplyResources(btnAdd, "btnAdd");
            btnAdd.Name = "btnAdd";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvTrainings
            // 
            resources.ApplyResources(dgvTrainings, "dgvTrainings");
            dgvTrainings.AllowUserToAddRows = false;
            dgvTrainings.AllowUserToDeleteRows = false;
            dgvTrainings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTrainings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrainings.MultiSelect = false;
            dgvTrainings.Name = "dgvTrainings";
            dgvTrainings.ReadOnly = true;
            dgvTrainings.RowHeadersVisible = false;
            dgvTrainings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrainings.CellContentClick += dgvTrainings_CellContentClick_1;
            dgvTrainings.CellMouseDoubleClick += dgvTrainings_CellMouseDoubleClick;
            dgvTrainings.SelectionChanged += dgvTrainings_SelectionChanged;
            dgvTrainings.SizeChanged += dgvTrainings_SizeChanged;
            // 
            // lblSum
            // 
            resources.ApplyResources(lblSum, "lblSum");
            lblSum.Name = "lblSum";
            // 
            // lblCount
            // 
            resources.ApplyResources(lblCount, "lblCount");
            lblCount.Name = "lblCount";
            lblCount.Click += lblInfo_Click;
            // 
            // btnDelete
            // 
            resources.ApplyResources(btnDelete, "btnDelete");
            btnDelete.Name = "btnDelete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dtpMonth
            // 
            resources.ApplyResources(dtpMonth, "dtpMonth");
            dtpMonth.Format = DateTimePickerFormat.Custom;
            dtpMonth.Name = "dtpMonth";
            dtpMonth.ShowUpDown = true;
            dtpMonth.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            label1.Click += label1_Click;
            // 
            // lblAvg
            // 
            resources.ApplyResources(lblAvg, "lblAvg");
            lblAvg.Name = "lblAvg";
            // 
            // btnEdit
            // 
            resources.ApplyResources(btnEdit, "btnEdit");
            btnEdit.Name = "btnEdit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // lblSaveInfo
            // 
            resources.ApplyResources(lblSaveInfo, "lblSaveInfo");
            lblSaveInfo.Name = "lblSaveInfo";
            // 
            // btnOpen
            // 
            resources.ApplyResources(btnOpen, "btnOpen");
            btnOpen.Name = "btnOpen";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnOpen);
            Controls.Add(lblSaveInfo);
            Controls.Add(btnEdit);
            Controls.Add(lblAvg);
            Controls.Add(label1);
            Controls.Add(dtpMonth);
            Controls.Add(btnDelete);
            Controls.Add(lblCount);
            Controls.Add(lblSum);
            Controls.Add(dgvTrainings);
            Controls.Add(btnAdd);
            Name = "MainForm";
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvTrainings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private DataGridView dgvTrainings;
        private Label lblSum;
        private Label lblCount;
        private Button btnDelete;
        private DateTimePicker dtpMonth;
        private Label label1;
        private Label lblAvg;
        private Button btnEdit;
        private Label lblSaveInfo;
        private Button btnOpen;
    }
}
