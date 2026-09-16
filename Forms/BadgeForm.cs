using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TrackerTreningow_.Managers;

namespace TrackerTreningow_.Forms
{
    public partial class BadgeForm : Form
    {
        public BadgeForm(BadgeService badges)
        {
            InitializeComponent();

            foreach (Badge badge in BadgeList.All)
            { 
                Badge? earned = badges.Earned.FirstOrDefault(b => b.Code == badge.Code);

                flowBadges.Controls.Add(CreateTile(badge, earned));
            }
        }

        private Panel CreateTile(Badge badge, Badge? earned)
        {
            bool isEarned = earned != null;

            var tile = new Panel
            {
                Width = 220,
                Height = 96,
                Margin = new Padding(8),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = isEarned ? Color.FromArgb(223, 240, 235) : SystemColors.Control
            };

            var title = new Label
            {
                Text = isEarned ? badge.Name : "? ? ?",
                Font = new Font(Font, FontStyle.Bold),
                ForeColor = isEarned ? Color.FromArgb(14, 107, 98) : Color.Gray,
                Location = new Point(10, 10),
                AutoSize = true
            };

            var description = new Label
            {
                Text = badge.Description,
                ForeColor = Color.DimGray,
                Location = new Point(10, 34),
                Size = new Size(198, 32)
            };

            var date = new Label
            {
                Text = isEarned ? $"Zdobyta {earned.EarnedAt:yyyy-MM-dd}" : "Jeszcze niezdobyta",
                ForeColor = Color.Gray,
                Location = new Point(10, 70),
                AutoSize = true
            };

            tile.Controls.Add(title);
            tile.Controls.Add(description);
            tile.Controls.Add(date);

            return tile;
        }
    }
}

