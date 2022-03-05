using System;
using System.Windows.Forms;
using System.IO;

namespace SUNRISE_Launcher_UltraLite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        string errorMessage = "Kullanıcı adı 3 harften az olamaz, boşluk içeremez, özel karakter içeremez.";

        private void button1_Click(object sender, EventArgs e)
        {
            userSettings.setUsername = textBox1.Text;
            LaunchPage l = new LaunchPage();
            l.Show();
            this.Hide();
        }

        bool messageShowed = false;
        int waitcount = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (waitcount == 3)
            {
                if (textBox1.TextLength < 3)
                {
                    button1.Enabled = false;

                    if (!messageShowed)
                        MessageBox.Show(errorMessage);
                    messageShowed = true;
                }
                else
                {
                    if (textBox1.Text.Contains(" "))
                    {
                        button1.Enabled = false;
                        if (!messageShowed)
                            MessageBox.Show(errorMessage);
                        messageShowed = true;
                    }
                    else
                    {
                        if (textBox1.Text.ToLower() == "EgeLosing".ToLower() || textBox1.Text.ToLower() == "MrSpikePvP".ToLower())
                        {
                            if (File.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\.minecraft\SUNRISE\Ultralight\config.enablenames"))
                            {
                                button1.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("SUNRISE varconfig'i bu ismi kullanmanıza izin vermiyor.", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                button1.Enabled = false;
                            }
                        }
                        else
                        {
                            button1.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                waitcount++;
            }
        }
    }
}
