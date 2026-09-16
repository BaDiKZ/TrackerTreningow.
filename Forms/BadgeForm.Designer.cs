namespace TrackerTreningow_.Forms
{
    partial class BadgeForm
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
            flowBadges = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flowBadges
            // 
            flowBadges.AutoScroll = true;
            flowBadges.Dock = DockStyle.Fill;
            flowBadges.Location = new Point(0, 0);
            flowBadges.Name = "flowBadges";
            flowBadges.Size = new Size(800, 450);
            flowBadges.TabIndex = 0;
            // 
            // BadgeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowBadges);
            Name = "BadgeForm";
            Text = "BadgeForm";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowBadges;
    }
}