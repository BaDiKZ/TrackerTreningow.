using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using TrackerTreningow;

namespace TrackerTreningow_
{
    public partial class StatsForm : Form
    {
        private readonly List<Training> _all;

        public StatsForm(List<Training> trainings)
        {
            InitializeComponent();
            _all = trainings;

            cmbRange.Items.AddRange(new object[]
            {
                "Bieżący miesiąc",
                "Poprzedni miesiąc",
                "Ostatnie 3 miesiące",
                "Wszystko",
                "Własny zakres"
            });

            cmbRange.SelectedIndex = 0;
            Recalculate();
        }

        private List<Training> GetSelected()
        {
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;

            List<Training> list = _all.Where(t => t.Date >= from && t.Date <= to).ToList();

            if (cmbType.SelectedIndex > 0)
            {
                string type = cmbType.Text;
                list = list.Where(t => t.Type == type).ToList();
            }

            return list.OrderBy(t => t.Date).ToList();
        }

        private void Recalculate()
        {
            var list = GetSelected();

            lblTotal.Text = StatsCalculator.TotalMinutes(list).ToString();
            lblCount.Text = list.Count.ToString();
            lblAverage.Text = $"{StatsCalculator.AverageMinutes(list)} min";
            lblActiveDays.Text = StatsCalculator.ActiveDays(list).ToString();

            var longest = StatsCalculator.Longest(list);
            lblLongest.Text = longest == null
                ? "—"
                : $"{longest.Minutes} min ({longest.Type}, {longest.Date:yyyy-MM-dd})";

            var best = StatsCalculator.BestDay(list);
            lblBestDay.Text = best == null
                ? "—"
                : $"{best.Day:yyyy-MM-dd} — {best.Minutes} min";

            lblStreak.Text = $"{StatsCalculator.LongestStreak(list)} dni";
            lblStreak.Text = StatsCalculator.FavouriteType(list);

            pnlChart.Invalidate();
        }

        private void pnlChart_Paint(object sender, PaintEventArgs e)
        {
            var data = StatsCalculator.MinutesPerDay(GetSelected());

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (data.Count == 0)
            {
                g.DrawString("Brak danych w wybranym zakresie", Font, Brushes.Gray, 12, 12);
                return;
            }

            const int marginLeft = 42;
            const int marginTop = 12;
            const int marginBottom = 26;

            int plotWidth = pnlChart.Width - marginLeft - 12;
            int plotHeight = pnlChart.Height - marginTop - marginBottom;

            if (plotWidth <= 0 || plotHeight <= 0) return;

            int max = data.Max(d => d.Minutes);
            if (max == 0) max = 1;

            float slot = (float)plotWidth / data.Count;
            float barWidth = Math.Max(3f, slot * 0.7f);

            using var barBrush = new SolidBrush(Color.FromArgb(14, 107, 98));
            using var axisPen = new Pen(Color.Silver);
            using var smallFont = new Font(Font.FontFamily, 7f);

            g.DrawLine(axisPen, marginLeft, marginTop + plotHeight,
                                marginLeft + plotWidth, marginTop + plotHeight);

            g.DrawString($"{max} min", smallFont, Brushes.Gray, 2, marginTop - 2);

            for (int i = 0; i < data.Count; i++)
            {
                float height = (float)plotHeight * data[i].Minutes / max;
                float x = marginLeft + slot * i + (slot - barWidth) / 2;
                float y = marginTop + plotHeight - height;

                g.FillRectangle(barBrush, x, y, barWidth, height);

                // podpis dnia — tylko co kilka słupków, żeby się nie zlewały
                if (data.Count <= 10 || i % (data.Count / 10) == 0)
                {
                    g.DrawString(data[i].Day.ToString("dd.MM"), smallFont, Brushes.Gray,
                        x - 6, marginTop + plotHeight + 4);
                }
            }

        }

        private void cmbRange_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new(today.Year, today.Month, 1);

            switch (cmbRange.SelectedIndex)
            {
                case 0:
                    dtpFrom.Value = firstOfMonth;
                    dtpTo.Value = firstOfMonth.AddMonths(1).AddDays(-1);
                    break;

                case 1:
                    dtpFrom.Value = firstOfMonth.AddMonths(-1);
                    dtpTo.Value = firstOfMonth.AddDays(-1);
                    break;

                case 2:
                    dtpFrom.Value = firstOfMonth.AddMonths(-2);
                    dtpTo.Value = firstOfMonth.AddMonths(1).AddDays(-1);
                    break;

                case 3:
                    dtpFrom.Value = _all.Count > 0 ? _all.Min(t => t.Date) : today;
                    dtpTo.Value = today;
                    break;
            }

            bool custom = cmbRange.SelectedIndex == 4;
            dtpFrom.Enabled = custom;
            dtpTo.Enabled = custom;

            Recalculate();
        }
    }
}
