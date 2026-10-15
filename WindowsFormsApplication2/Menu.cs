using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Text;
namespace TestDePersonajes
{

    public partial class Menu : Form
    {
        PrivateFontCollection fuentemenu = new PrivateFontCollection();
        public Menu()
        {
        InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Resize += new EventHandler(Menu_Resize);

            fuentemenu.AddFontFile("Assets\\PoorRichardOpti.otf");
            Font menufont = new Font(fuentemenu.Families[0], 22.25f, FontStyle.Regular);
            label1.Font = menufont;

        }
        private void Menu_Resize(object sender, EventArgs e)
        {
            int anchoForm = this.ClientSize.Width;
            int altoForm = this.ClientSize.Height;
            if (label1 != null)
            {
                label1.AutoSize = false;

                label1.Width = anchoForm;
                label1.Left = 0;
                label1.Top = 30; 

                label1.Height = 80;

                label1.TextAlign = ContentAlignment.MiddleCenter;

                if (this.WindowState == FormWindowState.Maximized)
                {
                    label1.Font = new Font(label1.Font.Name, 34f, FontStyle.Bold);
                }
                else
                {
                    label1.Font = new Font(label1.Font.Name, 22f, FontStyle.Bold);
                    label1.Height = 50; 
                }
            }
            button1.Left = (anchoForm / 2) - button1.Width - 20;
            button1.Top = (altoForm - button1.Height) / 2;

            button2.Left = (anchoForm / 2) + 20;
            button2.Top = (altoForm - button2.Height) / 2;

            if (checkBox1 != null)
            {
                checkBox1.Left = anchoForm - checkBox1.Width - 30;
                checkBox1.Top = altoForm - checkBox1.Height - 30;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SoundPlayer musicmenu = new SoundPlayer(@"Assets\\Happypeople.wav");
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            try
            {
                CheckBox cb = (CheckBox)sender;
                
                if (cb.Checked) 
                {
                    musicmenu.PlayLooping();
                }
                else
                {
                    musicmenu.Stop();
                }
           }
            catch (Exception er)
                {
                    MessageBox.Show("Error " + er.Message, "no se escucha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Preguntas ventanaPregunta = new Preguntas();
            ventanaPregunta.Show();
            this.Hide();
        }
    }
}
