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
            label2 = new Label();
            txtSearch = new TextBox();
            chkOnlyImportant = new CheckBox();
            lblEmpty = new Label();
            btnExport = new Button();
            lblGoal = new Label();
            pbGoal = new ProgressBar();
            btnGoal = new Button();
            btnStats = new Button();
            btnBadges = new Button();
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
            dgvTrainings.SelectionChanged += dgvTrainings_SelectionChanged;
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
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // txtSearch
            // 
            resources.ApplyResources(txtSearch, "txtSearch");
            txtSearch.Name = "txtSearch";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // chkOnlyImportant
            // 
            resources.ApplyResources(chkOnlyImportant, "chkOnlyImportant");
            chkOnlyImportant.Name = "chkOnlyImportant";
            chkOnlyImportant.UseVisualStyleBackColor = true;
            chkOnlyImportant.CheckedChanged += chkOnlyImportant_CheckedChanged;
            // 
            // lblEmpty
            // 
            resources.ApplyResources(lblEmpty, "lblEmpty");
            lblEmpty.Name = "lblEmpty";
            // 
            // btnExport
            // 
            resources.ApplyResources(btnExport, "btnExport");
            btnExport.Name = "btnExport";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // lblGoal
            // 
            resources.ApplyResources(lblGoal, "lblGoal");
            lblGoal.Name = "lblGoal";
            // 
            // pbGoal
            // 
            resources.ApplyResources(pbGoal, "pbGoal");
            pbGoal.Name = "pbGoal";
            // 
            // btnGoal
            // 
            resources.ApplyResources(btnGoal, "btnGoal");
            btnGoal.Name = "btnGoal";
            btnGoal.UseVisualStyleBackColor = true;
            btnGoal.Click += btnGoal_Click;
            // 
            // btnStats
            // 
            resources.ApplyResources(btnStats, "btnStats");
            btnStats.Name = "btnStats";
            btnStats.UseVisualStyleBackColor = true;
            btnStats.Click += btnStats_Click;
            // 
            // btnBadges
            // 
            resources.ApplyResources(btnBadges, "btnBadges");
            btnBadges.Name = "btnBadges";
            btnBadges.UseVisualStyleBackColor = true;
            btnBadges.Click += btnBadges_Click;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnBadges);
            Controls.Add(btnStats);
            Controls.Add(btnGoal);
            Controls.Add(pbGoal);
            Controls.Add(lblGoal);
            Controls.Add(btnExport);
            Controls.Add(lblEmpty);
            Controls.Add(chkOnlyImportant);
            Controls.Add(txtSearch);
            Controls.Add(label2);
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
        private Label label2;
        private TextBox txtSearch;
        private CheckBox chkOnlyImportant;
        private Label lblEmpty;
        private Button btnExport;
        private Label lblGoal;
        private ProgressBar pbGoal;
        private Button btnGoal;
        private Button btnStats;
        private Button btnBadges;
    }
}
