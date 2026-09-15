using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrackerTreningow;

namespace TrackerTreningow_
{
    public partial class AddTrainingForm : Form
    {
        public Training? NewTraining { get; private set; }
        private Training? lastSelectedTraining = null;
        private readonly Training? _edited;


        public AddTrainingForm()
        {
            InitializeComponent();
            cmbType.SelectedIndex = 0;
        }

        public AddTrainingForm(Training lastSelectedTraining) : this()
        {
            this.lastSelectedTraining = lastSelectedTraining;

            if (lastSelectedTraining != null)
            {
                cmbType.SelectedItem = lastSelectedTraining.Type;
            }
        }

        public AddTrainingForm(Training training, bool edit) : this() // bool edit to po prostu flaga dzieki ktorej nie wywola sie tamten konstruktor u gory
        {
            _edited = training;

            Text = "Edytuj trening";
            btnSave.Text = "Zapisz zmiany";

            dtpDate.Value = training.Date;
            cmbType.SelectedItem = training.Type;
            txtMinutes.Text = training.Minutes.ToString();
            txtNote.Text = training.Note;
            chkImportant.Checked = training.IsImportant;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Guid id = Guid.NewGuid();

            if (_edited != null)
            {
                id = _edited.Id;
            }

            if (!int.TryParse(txtMinutes.Text, out int minutes))
            {
                MessageBox.Show("Niepoprawna wartość dla Minut.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMinutes.Focus();
                txtMinutes.SelectAll();
                return;
            }

            if(minutes <= 0 || minutes > 1440)
            {
                MessageBox.Show("Czas treningu musi mieścić się między 1 a 1440 minut. ","Nieprawidłowe dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMinutes.Focus();
                txtMinutes.SelectAll();
                return;
            }

            NewTraining = new Training
            {
                Id = id,
                Date = dtpDate.Value.Date,
                Type = cmbType.Text,
                Minutes = minutes,
                Note = txtNote.Text.Trim(),
                IsImportant = chkImportant.Checked
            };

            DialogResult = DialogResult.OK;
        }
    }
}
