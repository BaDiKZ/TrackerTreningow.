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
            pnlTypes.Invalidate();
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

        private void StatsForm_Load(object sender, EventArgs e)
        {


        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private static readonly Color[] TypeColors ={
                Color.FromArgb(14, 107, 98),
                Color.FromArgb(199, 138, 34),
                Color.FromArgb(92, 110, 160),
                Color.FromArgb(150, 90, 120),
                Color.FromArgb(110, 140, 90)
            };
        private void pnlTypes_Paint(object sender, PaintEventArgs e)
        {
            var data = StatsCalculator.MinutesByType(GetSelected());
            Graphics g = e.Graphics;

            if (data.Count == 0)
            {
                g.DrawString("Brak danych w wybranym zakresie", Font, Brushes.Gray, 12, 12);
                return;
            }

            int total = data.Sum(d => d.Minutes);
            if (total == 0) return;

            const int barHeight = 20;
            const int rowHeight = 28;
            const int labelWidth = 110;

            int barArea = pnlTypes.Width - labelWidth - 60;
            if (barArea <= 0) return;

            using var smallFont = new Font(Font.FontFamily, 8f);

            for (int i = 0; i < data.Count; i++)
            {
                int y = 10 + i * rowHeight;
                double percent = 100.0 * data[i].Minutes / total;
                int width = (int)Math.Round(barArea * percent / 100.0);

                using var brush = new SolidBrush(TypeColors[i % TypeColors.Length]);

                g.DrawString(data[i].Type, smallFont, Brushes.DimGray, 8, y + 3);
                g.FillRectangle(brush, labelWidth, y, Math.Max(width, 2), barHeight);
                g.DrawString($"{percent:F0}%", smallFont, Brushes.DimGray, labelWidth + barArea + 8, y + 3);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var list = GetSelected();

            if (list.Count == 0)
            {
                MessageBox.Show("W wybranym zakresie nie ma danych.", "Eksport",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dialog = new SaveFileDialog
            {
                Title = "Zapisz podsumowanie",
                Filter = "Raport tekstowy (*.txt)|*.txt|Arkusz CSV (*.csv)|*.csv",
                FileName = $"statystyki-{dtpFrom.Value:yyyy-MM-dd}.txt"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                string content = dialog.FilterIndex == 2
                    ? RaportBuilder.BuildCsv(list)
                    : BuildSummary(list);

                File.WriteAllText(dialog.FileName, content, Encoding.UTF8);

                MessageBox.Show($"Zapisano:\n{dialog.FileName}", "Gotowe",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie udało się zapisać pliku.\n\n{ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string BuildSummary(List<Training> list)
        {
            var sb = new StringBuilder();
            int total = StatsCalculator.TotalMinutes(list);

            sb.AppendLine($"PODSUMOWANIE {dtpFrom.Value:yyyy-MM-dd} — {dtpTo.Value:yyyy-MM-dd}");
            sb.AppendLine(new string('=', 52));
            sb.AppendLine();
            sb.AppendLine($"Suma minut:        {total} ({total / 60} h {total % 60} min)");
            sb.AppendLine($"Liczba aktywności: {list.Count}");
            sb.AppendLine($"Średni czas:       {StatsCalculator.AverageMinutes(list)} min");
            sb.AppendLine($"Dni z treningiem:  {StatsCalculator.ActiveDays(list)}");
            sb.AppendLine($"Najdłuższa seria:  {StatsCalculator.LongestStreak(list)} dni");
            sb.AppendLine($"Ulubiony rodzaj:   {StatsCalculator.FavouriteType(list)}");
            sb.AppendLine();
            sb.AppendLine("PODZIAŁ WEDŁUG RODZAJU");
            sb.AppendLine(new string('-', 52));

            foreach (var item in StatsCalculator.MinutesByType(list))
            {
                double percent = total == 0 ? 0 : 100.0 * item.Minutes / total;
                sb.AppendLine($"{item.Type,-12} {item.Minutes,5} min   {percent,5:F1}%");
            }

            sb.AppendLine();
            sb.AppendLine($"Wygenerowano: {DateTime.Now:yyyy-MM-dd HH:mm}");

            return sb.ToString();
        }

    }
}
