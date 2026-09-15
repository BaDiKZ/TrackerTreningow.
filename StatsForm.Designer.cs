namespace TrackerTreningow_
{
    partial class StatsForm
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
            cmbRange = new ComboBox();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            cmbType = new ComboBox();
            lblTotal = new Label();
            lblBestDay = new Label();
            lblAverage = new Label();
            lblActiveDays = new Label();
            lblStreak = new Label();
            pnlChart = new Panel();
            btnExport = new Button();
            btnClose = new Button();
            lblCount = new Label();
            lblLongest = new Label();
            SuspendLayout();
            // 
            // cmbRange
            // 
            cmbRange.FormattingEnabled = true;
            cmbRange.Location = new Point(12, 12);
            cmbRange.Name = "cmbRange";
            cmbRange.Size = new Size(151, 23);
            cmbRange.TabIndex = 0;
            cmbRange.SelectedIndexChanged += cmbRange_SelectedIndexChanged_1;
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(202, 12);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(98, 23);
            dtpFrom.TabIndex = 1;
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(341, 12);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(98, 23);
            dtpTo.TabIndex = 2;
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(331, 355);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(427, 23);
            cmbType.TabIndex = 3;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 93);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(38, 15);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "label1";
            // 
            // lblBestDay
            // 
            lblBestDay.AutoSize = true;
            lblBestDay.Location = new Point(150, 93);
            lblBestDay.Name = "lblBestDay";
            lblBestDay.Size = new Size(38, 15);
            lblBestDay.TabIndex = 5;
            lblBestDay.Text = "label2";
            // 
            // lblAverage
            // 
            lblAverage.AutoSize = true;
            lblAverage.Location = new Point(275, 93);
            lblAverage.Name = "lblAverage";
            lblAverage.Size = new Size(38, 15);
            lblAverage.TabIndex = 6;
            lblAverage.Text = "label1";
            // 
            // lblActiveDays
            // 
            lblActiveDays.AutoSize = true;
            lblActiveDays.Location = new Point(401, 93);
            lblActiveDays.Name = "lblActiveDays";
            lblActiveDays.Size = new Size(38, 15);
            lblActiveDays.TabIndex = 7;
            lblActiveDays.Text = "label1";
            // 
            // lblStreak
            // 
            lblStreak.AutoSize = true;
            lblStreak.Location = new Point(12, 137);
            lblStreak.Name = "lblStreak";
            lblStreak.Size = new Size(38, 15);
            lblStreak.TabIndex = 8;
            lblStreak.Text = "label1";
            // 
            // pnlChart
            // 
            pnlChart.BackColor = SystemColors.Control;
            pnlChart.BorderStyle = BorderStyle.FixedSingle;
            pnlChart.Location = new Point(12, 187);
            pnlChart.Name = "pnlChart";
            pnlChart.Size = new Size(427, 100);
            pnlChart.TabIndex = 9;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(12, 312);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(75, 23);
            btnExport.TabIndex = 0;
            btnExport.Text = "Eksportuj";
            btnExport.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(137, 312);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 10;
            btnClose.Text = "Zamknij";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(150, 137);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(38, 15);
            lblCount.TabIndex = 11;
            lblCount.Text = "label1";
            // 
            // lblLongest
            // 
            lblLongest.AutoSize = true;
            lblLongest.Location = new Point(275, 137);
            lblLongest.Name = "lblLongest";
            lblLongest.Size = new Size(38, 15);
            lblLongest.TabIndex = 12;
            lblLongest.Text = "label1";
            // 
            // StatsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblLongest);
            Controls.Add(lblCount);
            Controls.Add(btnClose);
            Controls.Add(btnExport);
            Controls.Add(pnlChart);
            Controls.Add(lblStreak);
            Controls.Add(lblActiveDays);
            Controls.Add(lblAverage);
            Controls.Add(lblBestDay);
            Controls.Add(lblTotal);
            Controls.Add(cmbType);
            Controls.Add(dtpTo);
            Controls.Add(dtpFrom);
            Controls.Add(cmbRange);
            Name = "StatsForm";
            Text = "StatsForm";
            pnlChart.Paint += pnlChart_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbRange;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private ComboBox cmbType;
        private Label lblTotal;
        private Label lblBestDay;
        private Label lblAverage;
        private Label lblActiveDays;
        private Label lblStreak;
        private Panel pnlChart;
        private Button btnExport;
        private Button btnClose;
        private Label lblCount;
        private Label lblLongest;
    }
}