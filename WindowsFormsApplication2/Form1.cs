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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string music1 = @"Capital-Cities-Kangaroo-Court.wav";
            try
            {
                SoundPlayer musicmenu = new SoundPlayer(music1);
                musicmenu.Play();
           }
            catch (Exception er)
                {
                    MessageBox.Show("Error " + er.Message, "no se escucha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
