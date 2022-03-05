using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace SUNRISE_Launcher_UltraLite
{
    public partial class LaunchPage : Form
    {
        public LaunchPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe /k dotnet \"Ultralight Launcher.dll\" \"1024\"" +
                "\"" + userSettings.getUsername + "\""
                );
        }

        private void LaunchPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
