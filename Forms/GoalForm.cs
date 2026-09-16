using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrackerTreningow_
{
    public partial class GoalForm : Form
    {
        public int MinutesTarget { get; private set; }

        public GoalForm(int year, int month, int currentTarget)
        {
            InitializeComponent();

            lblMonth.Text = $"Cel na {year:D4}-{month:D2}";
            numTarget.Value = currentTarget > 0 ? currentTarget : 600;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MinutesTarget = (int)numTarget.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
