using TrackerTreningow_.Forms;

namespace TrackerTreningow_
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using var profileForm = new ProfileForm();
            if(profileForm.ShowDialog() != DialogResult.OK || profileForm.SelectedProfile == null)
            {
                return;
            }

            Application.Run(new MainForm(profileForm.SelectedProfile));
        }
    }
}