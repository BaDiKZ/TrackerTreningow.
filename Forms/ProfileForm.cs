using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrackerTreningow;

namespace TrackerTreningow_.Forms
{
    public partial class ProfileForm : Form
    {
        private readonly JsonStore<UserProfile> _store = new("users.json");
        private List<UserProfile> _profiles;

        public UserProfile? SelectedProfile { get; private set; }

        public ProfileForm()
        {
            InitializeComponent();

            _profiles = _store.Load();
            RefreshList();
        }

        private void RefreshList()
        {
            lstProfiles.DataSource = null;
            lstProfiles.DataSource = _profiles;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = txtNewName.Text.Trim();

            if (name.Length == 0)
            {
                MessageBox.Show("Podaj nazwę profilu.", "Brak nazwy",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_profiles.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Profil o takiej nazwie już istnieje.", "Nazwa zajęta",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _profiles.Add(new UserProfile { Name = name });
            _store.Save(_profiles);

            txtNewName.Clear();
            RefreshList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            UserProfile? profile = lstProfiles.SelectedItem as UserProfile;

            if (profile == null)
            {
                MessageBox.Show("Wybierz profil z listy.", "Nic nie wybrano",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SelectedProfile = profile;
            DialogResult = DialogResult.OK;
        }
    }
}

