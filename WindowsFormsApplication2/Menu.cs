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
            fuentemenu.AddFontFile("POORICH.ttf");
            Font menufont = new Font(fuentemenu.Families[0], 26.25f, FontStyle.Regular);
            label1.Font = menufont;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SoundPlayer musicmenu = new SoundPlayer(@"Capital Cities - Kangaroo Court.wav");
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
