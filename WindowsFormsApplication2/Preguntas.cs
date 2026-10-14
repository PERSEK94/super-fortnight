using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDePersonajes
{
    public partial class Preguntas : Form
    {
        Dictionary<string, int> puntajes = new Dictionary<string, int>()
    {
        // BLEACH
        { "Ichigo Kurisaki", 0 },
        { "Orihime Inoue", 0 },
        { "Uryu Ishida", 0 },
        { "Rukia Kuchiki", 0 },
        { "Yasodora 'Chad' Sado", 0 }
    };
       
        public Preguntas()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
