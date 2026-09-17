using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using TrackerTreningow;
using TrackerTreningow_.Forms;
using TrackerTreningow_.Managers;

namespace TrackerTreningow_
{
    public partial class MainForm : Form
    {
        private readonly UserProfile _profile;
        private readonly JsonStore<Training> _trainingStore;
        private readonly JsonStore<MonthlyGoal> _goalStore;
        private readonly BadgeService _badges;
        private List<Training> _trainings = new();
        private List<MonthlyGoal> _goals = new();
        public Training? lastSelectedTraining = null;

        private Font? _boldFont;


        [Obsolete("Tylko dla Designera")]
        public MainForm() : this(new UserProfile { Name = "Podgląd" })
        {
        }

        public MainForm(UserProfile profile)
        {
            InitializeComponent();

            _profile = profile;

            _trainingStore = new("trainings.json", profile.FolderName);
            _goalStore = new("goals.json", profile.FolderName);
            _badges = new(new JsonStore<Badge>("badges.json", profile.FolderName));
            _boldFont = new Font(dgvTrainings.Font, FontStyle.Bold);
 
            Text = $"Tracker Treningów - Profil: {_profile.Name}";

            LoadData();
            RefreshGrid();
            CheckBadges();
        }

        private void HighlightRows()
        {
            foreach (DataGridViewRow row in dgvTrainings.Rows)
            {
                var training = row.DataBoundItem as Training;

                if (training == null) continue;

                if (training.IsImportant)
                {
                    row.DefaultCellStyle.Font = _boldFont;
                }

                if (training.Minutes > 90)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(223, 240, 235);
                }
            }
        }

        private void RefreshGrid()
        {
            dgvTrainings.DataSource = null;
            dgvTrainings.DataSource = GetVisibleTrainings();

            ConfigureColumns();
            refreshStats();
            HighlightRows();

            lblEmpty.Visible = dgvTrainings.Rows.Count == 0;
            lblEmpty.BringToFront();
        }

        private void ConfigureColumns()
        {
            if (dgvTrainings.Columns.Count == 0) return;

            dgvTrainings.Columns["Id"].Visible = false;

            dgvTrainings.Columns["Date"].HeaderText = "Data";
            dgvTrainings.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";

            dgvTrainings.Columns["Type"].HeaderText = "Rodzaj";

            dgvTrainings.Columns["Minutes"].HeaderText = "Minuty";
            dgvTrainings.Columns["Minutes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTrainings.Columns["Note"].HeaderText = "Notatka";
            dgvTrainings.Columns["IsImportant"].HeaderText = "Ważny";
            dgvTrainings.Columns["IsImportant"].FillWeight = 30;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new AddTrainingForm(lastSelectedTraining);

            if (form.ShowDialog(this) == DialogResult.OK && form.NewTraining != null)
            {
                _trainings.Add(form.NewTraining);
                RefreshGrid();
                if (dgvTrainings.Rows.Count > 0) dgvTrainings.Rows[dgvTrainings.Rows.Count - 1].Selected = true;
                lblCount.Text = $"Dodano trening: {form.NewTraining.Type} - {form.NewTraining.Minutes} minut";
            }
            SaveData();
            CheckBadges();
        }

        private void dgvTrainings_SelectionChanged(object sender, EventArgs e)
        {
            lastSelectedTraining = GetSelectedTraining();
        }

        private Training? GetSelectedTraining()
        {
            if (dgvTrainings.CurrentRow == null)
            {
                return null;
            }

            return dgvTrainings.CurrentRow.DataBoundItem as Training;
        }

        public void refreshStats()
        {
            List<Training> trainings = GetVisibleTrainings();
            int totalMinutes = trainings.Sum(t => t.Minutes);
            int totalTrainings = trainings.Count;
            int avgMinutes = totalTrainings > 0 ? totalMinutes / totalTrainings : 0;
            lblSum.Text = $"Suma minut w miesiacu: {FormatMinutes(totalMinutes)}";
            lblCount.Text = $"Liczba treningów: {totalTrainings}";
            lblAvg.Text = $"Średnia długość treningu: {FormatMinutes(avgMinutes)}";

            UpdateGoal();
        }
        private static string FormatMinutes(int minutes)
        {
            int hours = minutes / 60;
            int rest = minutes % 60;

            return hours > 0 ? $"{hours} h {rest} min" : $"{rest} min";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedTraining();

            if (selected == null)
            {
                MessageBox.Show("Najpierw zaznacz trening na liście.", "Nic nie wybrano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var question = $"Usunąć trening {selected.Type} z dnia {selected.Date:yyyy-MM-dd}?";

            var answer = MessageBox.Show(question, "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes) return;

            _trainings.Remove(selected);
            RefreshGrid();
            SaveData();
        }

        private List<Training> GetVisibleTrainings()
        {
            int year = dtpMonth.Value.Year;
            int month = dtpMonth.Value.Month;

            List<Training> list = GetMonthTrainings();

            string search = txtSearch.Text.Trim();

            if (search.Length > 0)
            {
                list = list.Where(t =>
                    t.Type.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    t.Note.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (chkOnlyImportant.Checked)
            {
                list = list.Where(t => t.IsImportant).ToList();
            }

            return list.OrderByDescending(t => t.Date).ToList();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedTraining();

            if (selected == null)
            {
                MessageBox.Show("Najpierw zaznacz trening na liście.", "Nic nie wybrano",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var form = new AddTrainingForm(selected, true);

            if (form.ShowDialog(this) == DialogResult.OK && form.NewTraining != null)
            {
                int index = _trainings.FindIndex(t => t.Id == selected.Id);

                if (index >= 0)
                {
                    _trainings[index] = form.NewTraining;
                }
                SaveData();
                RefreshGrid();
            }
            CheckBadges();
        }

        private void dgvTrainings_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void LoadData()
        {
            _trainings = _trainingStore.Load();
            _goals = _goalStore.Load();

            if (_trainingStore.LastLoadWarning != null)
            {
                MessageBox.Show(_trainingStore.LastLoadWarning + "\n\nProgram startuje z pustą listą.",
                    "Uszkodzone dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (_goalStore.LastLoadWarning != null)
            {
                MessageBox.Show(_goalStore.LastLoadWarning + "\n\nProgram startuje z pustą listą.",
                    "Uszkodzone dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveData()
        {
            try
            {
                _trainingStore.Save(_trainings);
                _goalStore.Save(_goals);
                lblSaveInfo.Text = $"Dane zapisane: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie udało się zapisać danych.\n\n{ex.Message}",
                    "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", _trainingStore.Folder);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void chkOnlyImportant_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var list = GetVisibleTrainings();

            if (list.Count == 0)
            {
                MessageBox.Show("Nie ma czego eksportować — lista jest pusta.", "Eksport",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dialog = new SaveFileDialog
            {
                Title = "Zapisz raport",
                Filter = "Raport tekstowy (*.txt)|*.txt|Arkusz CSV (*.csv)|*.csv",
                FileName = $"raport-{dtpMonth.Value:yyyy-MM}.txt"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                string content = dialog.FilterIndex == 2
                    ? RaportBuilder.BuildCsv(list)
                    : RaportBuilder.BuildTextReport(list, dtpMonth.Value);

                File.WriteAllText(dialog.FileName, content, Encoding.UTF8);

                MessageBox.Show($"Zapisano raport:\n{dialog.FileName}", "Gotowe",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie udało się zapisać raportu.\n\n{ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // / Cel miesięczny

        private List<Training> GetMonthTrainings()
        {
            int year = dtpMonth.Value.Year;
            int month = dtpMonth.Value.Month;

            return _trainings.Where(t => t.Date.Year == year && t.Date.Month == month).ToList();
        }

        private void UpdateGoal()
        {
            int done = GetMonthTrainings().Sum(t => t.Minutes);

            var goal = _goals.FirstOrDefault(g =>
                g.Year == dtpMonth.Value.Year && g.Month == dtpMonth.Value.Month);

            if (goal == null || goal.MinutesTarget <= 0)
            {
                lblGoal.Text = "Cel na ten miesiąc: nie ustawiono";
                pbGoal.Value = 0;
                return;
            }

            int percent = (int)Math.Round(100.0 * done / goal.MinutesTarget);

            pbGoal.Value = Math.Min(percent, 100);
            lblGoal.Text = $"Cel: {done} / {goal.MinutesTarget} min ({percent}%)";
        }
        private void btnGoal_Click(object sender, EventArgs e)
        {
            int year = dtpMonth.Value.Year;
            int month = dtpMonth.Value.Month;

            var existing = _goals.FirstOrDefault(g => g.Year == year && g.Month == month);

            using var form = new GoalForm(year, month, existing?.MinutesTarget ?? 0);

            if (form.ShowDialog(this) != DialogResult.OK) return;

            if (existing == null)
            {
                _goals.Add(new MonthlyGoal
                {
                    Year = year,
                    Month = month,
                    MinutesTarget = form.MinutesTarget
                });
            }
            else
            {
                existing.MinutesTarget = form.MinutesTarget;
            }

            _goalStore.Save(_goals);
            UpdateGoal();
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            using var form = new StatsForm(_trainings);
            form.ShowDialog(this);
        }

        //badges 

        private void CheckBadges()
        {
            var fresh = _badges.Check(_trainings);

            if (fresh.Count == 0) return;

            string list = string.Join(Environment.NewLine,
                fresh.Select(b => $"• {b.Name} — {b.Description}"));

            MessageBox.Show($"Nowa odznaka!{Environment.NewLine}{Environment.NewLine}{list}",
                "Gratulacje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBadges_Click(object sender, EventArgs e)
        {
            using var form = new BadgeForm(_badges);
            form.ShowDialog(this);
        }
    }
}
