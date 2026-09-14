using System.Diagnostics;
using TrackerTreningow;

namespace TrackerTreningow_
{
    public partial class MainForm : Form
    {
        private readonly TrainingRepository _repository = new();
        private List<Training> _trainings = new List<Training>();
        public Training? lastSelectedTraining = null;

        public MainForm()
        {
            InitializeComponent();
            LoadData();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvTrainings.DataSource = null;
            dgvTrainings.DataSource = GetVisibleTrainings();
            ConfigureColumns();
            refreshStats();
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new AddTrainingForm(lastSelectedTraining);

            if (form.ShowDialog(this) == DialogResult.OK && form.NewTraining != null)
            {
                _trainings.Add(form.NewTraining);
                RefreshGrid();
                dgvTrainings.Rows[dgvTrainings.Rows.Count - 1].Selected = true;
                lblCount.Text = $"Dodano trening: {form.NewTraining.Type} - {form.NewTraining.Minutes} minut";
            }
            SaveData();
        }

        private void dgvTrainings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTrainings_SizeChanged(object sender, EventArgs e)
        {

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

            return _trainings
                .Where(t => t.Date.Year == year && t.Date.Month == month)
                .OrderByDescending(t => t.Date)
                .ToList();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

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
        }

        private void dgvTrainings_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvTrainings_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        //zapois odczyt
        private void LoadData()
        {
            _trainings = _repository.Load();

            if (_repository.LastLoadWarning != null)
            {
                MessageBox.Show(_repository.LastLoadWarning + "\n\nProgram startuje z pustą listą.",
                    "Uszkodzone dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveData()
        {
            try
            {
                _repository.Save(_trainings);
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
            Process.Start("explorer.exe",_repository.DataFolder);
        }
    }
}
