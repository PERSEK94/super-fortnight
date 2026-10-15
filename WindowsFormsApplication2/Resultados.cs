using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TestDePersonajes
{
    public partial class Resultados : Form
    {
        System.Drawing.Text.PrivateFontCollection coleccionFuentes = new System.Drawing.Text.PrivateFontCollection();
        private string personajeCampeon;
        public Resultados(string ganador)
        {
            InitializeComponent();
            personajeCampeon = ganador;
            try
            {
                string rutaBase = AppDomain.CurrentDomain.BaseDirectory;


                string rutaTuffy = Path.Combine(rutaBase, "Assets", "Tuffy.ttf");
                string rutaRoboto = Path.Combine(rutaBase, "Assets", "RobotoCondensed-Regular.ttf");

                if (File.Exists(rutaTuffy))
                {
                    coleccionFuentes.AddFontFile(rutaTuffy);
                }
                if (File.Exists(rutaRoboto))
                {
                    coleccionFuentes.AddFontFile(rutaRoboto);
                }
            }
            catch
            {

            }

            this.Load += new EventHandler(Resultados_Load);
            this.Resize += new EventHandler(Resultados_Resize);
            CargarFichaDelGanador();

        }

        private void Resultados_Load(object sender, EventArgs e)
        {
            this.Size = new Size(950, 650);
            this.StartPosition = FormStartPosition.CenterScreen;

            Resultados_Resize(this, EventArgs.Empty);
        }

        private void Resultados_Resize(object sender, EventArgs e)
        {
            int anchoForm = this.ClientSize.Width;
            int altoForm = this.ClientSize.Height;

            pictureBox1.Left = 40;
            pictureBox1.Top = 50;
            pictureBox1.Size = new Size(300, 300);

            if (button1 != null)
            {
                button1.Anchor = AnchorStyles.None;
                button1.Size = new Size(140, 140);
                button1.Left = 40;
                button1.Top = pictureBox1.Bottom + 25;
            }

            if (button2 != null)
            {
                button2.Anchor = AnchorStyles.None;
                button2.Size = new Size(140, 140);
                button2.Left = 40 + button1.Width + 20;
                button2.Top = pictureBox1.Bottom + 25;
            }

            int inicioDerecho = pictureBox1.Right + 50;
            int anchoTextoDisponible = anchoForm - inicioDerecho - 60;

            if (label2 != null)
            {
                label2.Left = inicioDerecho;
                label2.Top = 80;
                label2.Width = anchoTextoDisponible;
                label2.Height = 70;
                label2.TextAlign = ContentAlignment.MiddleCenter;

                if (coleccionFuentes.Families.Length > 0)
                {
                    float tamañoTitulo = (this.WindowState == FormWindowState.Maximized) ? 36f : 24f;
                    label2.Font = new Font(coleccionFuentes.Families[0], tamañoTitulo, FontStyle.Bold);
                }
            }

            if (richTextBox1 != null)
            {
                richTextBox1.Left = inicioDerecho;
                richTextBox1.Top = label2.Bottom + 30;
                richTextBox1.Width = anchoTextoDisponible;
                richTextBox1.Height = altoForm - richTextBox1.Top - 80;

                if (coleccionFuentes.Families.Length > 1)
                {
                    float tamañoDescripcion = (this.WindowState == FormWindowState.Maximized) ? 18f : 14f;
                    richTextBox1.Font = new Font(coleccionFuentes.Families[1], tamañoDescripcion, FontStyle.Regular);
                }

                richTextBox1.SelectAll();
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                richTextBox1.DeselectAll();
            }
        }
        private void CargarFichaDelGanador()
        {
            label2.Text = personajeCampeon;
            string cancion = "Bleach-Soundtrack-Going-Home-_432hz_.wav";
            switch (personajeCampeon)
            {
                case "Ichigo Kurosaki":
                    pictureBox1.Image = Image.FromFile("Assets\\ichigoresultado.jpg");
                    richTextBox1.Text = "Te destacás por un instinto protector gigante. No buscás los problemas, ni te interesa figurar como un héroe o llamar la atención, pero si tocan a alguien de tu entorno, sos el primero en poner el cuerpo y dar la cara. Llevás cargas pesadas en silencio y a veces te cuesta lidiar con tu lado más impulsivo o con la frustración, pero tu lealtad inquebrantable y tu sentido de la responsabilidad son lo que te define como una persona transparente en la que todos pueden confiar a ciegas.";
                    break;
                case "Orihime Inoue":
                    pictureBox1.Image = Image.FromFile("Assets\\orihimeresultado.jpg");
                    richTextBox1.Text = "Tu energía se rige por una sensibilidad y una empatía inmensas. Tenés una mente sumamente creativa, te colgás seguido en tus propios mundos imaginarios y tenés gustos o pasiones particulares que a veces a los demás les cuesta entender. Te sentís identificado porque, ante un mundo que puede ser frío o duro, vos elegís mantenerte genuino, bondadoso y siempre buscás rescatar el lado positivo de cada persona.";
                    break;

                case "Uryu Ishida":
                    pictureBox1.Image = Image.FromFile("Assets\\uryuresultado.jpg");
                    richTextBox1.Text = "Sos una persona extremadamente prolija, detallista y analítica. Valorás el orden, te da un orgullo tremendo hacer las cosas con tus propias manos y defendés tus ideales a capa y espada. En los trabajos en grupo o situaciones de estrés, preferís parar la pelota, estudiar el panorama con calma y armar una estrategia fría antes que actuar al voleo. Tu elegancia y tu código moral te hacen destacar.";
                    break;

                case "Yoruichi Shihoin":
                    pictureBox1.Image = Image.FromFile("Assets\\yoruichiresultado.jpg");
                    richTextBox1.Text = "Te definís por una mente libre, independiente y sumamente ágil. No te bancás los formalismos aburridos ni las reglas rígidas que no tienen sentido. Te encanta usar el humor, tirar chistes y tomarle el pelo de buena onda a la gente que se ganó tu confianza. Te sentís identificado con ella porque sos una persona descontracturada, segura de sí misma y que sabe disfrutar de la vida sin pedirle permiso a nadie.";
                    break;

                case "Yasutora 'Chad' Sado":
                    pictureBox1.Image = Image.FromFile("Assets\\chadresultado.jpg");
                    richTextBox1.Text = "Sos una persona de pocas palabras, que sabe escuchar y respeta profundamente el espacio de los demás. No demostrás tu fuerza o tus capacidades de forma violenta ni prepotente; al contrario, preferís la calma y evitás los conflictos innecesarios. Tenés principios muy claros basados en el respeto y en las enseñanzas de tus mayores, usando tu templanza únicamente para proteger a los tuyos.";
                    break;

                case "Soi Fon":
                    pictureBox1.Image = Image.FromFile("Assets\\soifonresultado.jpg");
                    richTextBox1.Text = "Te destacás por una disciplina inquebrantable, una seriedad absoluta ante tus responsabilidades y un carácter reservado. No le abrís tu corazón a cualquiera, pero cuando alguien logra ganarse tu respeto o admiración, tu lealtad hacia esa persona es total y vas con ella hasta el final del camino. Preferís mantener un perfil enfocado, eficiente y cumplir con tu deber de forma impecable.";
                    break;

                case "Kon":
                    pictureBox1.Image = Image.FromFile("Assets\\konpachi.jpg");
                    cancion = "Three-Days-Grace-I-Hate-Everything-About-You-_HD_.wav";
                    richTextBox1.Text = "¡Felicidades, rompiste el test! Te tocó 'Konpachi' por no tomarte en serio las preguntas o responder lo mismo, pedazo de vago...";
                    break;
            }
            try
            {
                string rutaMusica = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", cancion);

                if (File.Exists(rutaMusica))
                {
                    SoundPlayer reproductor = new SoundPlayer(rutaMusica);
                    reproductor.PlayLooping();
                }
            }
            catch (Exception ex)
            {
              
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Media.SoundPlayer detenerMusica = new System.Media.SoundPlayer();
                detenerMusica.Stop();
            }
            catch { 
            
            }
            TestDePersonajes.Menu ventanaInicio = new TestDePersonajes.Menu();
            ventanaInicio.Show();
            this.Close();
        }
    }
}
