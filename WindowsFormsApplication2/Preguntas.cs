using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2;


namespace TestDePersonajes
{
    public partial class Preguntas : Form
    {
        System.Windows.Forms.Timer relojCongelar = new System.Windows.Forms.Timer();
        System.Drawing.Text.PrivateFontCollection fuentesPreguntas = new System.Drawing.Text.PrivateFontCollection();
        
        Dictionary<string, int> puntajes = new Dictionary<string, int>()
    {
        // BLEACH
        { "Ichigo Kurosaki", 0 },
        { "Orihime Inoue", 0 },
        { "Uryu Ishida", 0 },
        { "Yoruichi Shihoin", 0 },
        { "Yasutora 'Chad' Sado", 0 },
        { "Soi Fon", 0 }
    };
        // diccionario de puntajes para cada personaje
        List<PreguntasClase> listaPreguntas = new List<PreguntasClase>()
        {
            // Ichigo Kurosaki
            new PreguntasClase("¿Sentís la necesidad constante de cuidar y poner la cara por tus amigos o familiares cuando la pasan mal?", "Ichigo Kurosaki", "ichigito.jpg"),
            new PreguntasClase("¿A veces sentís que tenés que lidiar con una parte tuya más seria o impulsiva que preferís ocultar?", "Ichigo Kurosaki", "Ichigo.jpg"),
            // Orihime Inoue
            new PreguntasClase("¿Te considerás una persona muy sensible, creativa y que siempre intenta buscarle el lado bueno a todos?", "Orihime Inoue", "inouesita.jpg"),
            new PreguntasClase("¿Solés distraerte seguido en tu propio mundo o tenés gustos bastante raros que a los demás les cuesta entender?", "Orihime Inoue", "Orihime.jpg"),
            // Uryu Ishida
            new PreguntasClase("¿Sos muy perfeccionista con tus cosas, valorás el orden y te da orgullo hacer las tareas con tus propias manos?", "Uryu Ishida", "uryusito.jpg"),
            new PreguntasClase("¿En los trabajos en grupo preferís analizar la situación con calma y estrategia antes de actuar al voleo?", "Uryu Ishida", "Uryu.jpg"),
            // Yoruichi Shihoin
            new PreguntasClase("¿Te gusta usar el humor, hacer chistes y tomarle el pelo de buena onda a la gente de tu confianza?", "Yoruichi Shihoin", "miyoruichi.jpg"),
            new PreguntasClase("¿Te considerás alguien independiente, de mente libre y que prefiere evitar los formalismos aburridos?", "Yoruichi Shihoin", "Yoruichi.jpg"),
            // Yasodora 'Chad' Sado
            new PreguntasClase("¿Sos una persona de pocas palabras, que prefiere escuchar antes que hablar, pero con una lealtad inquebrantable?", "Yasutora 'Chad' Sado", "sadito.jpg"),
            new PreguntasClase("¿Tenés principios muy claros basados en las enseñanzas de tus mayores y preferís evitar la violencia innecesaria?", "Yasutora 'Chad' Sado", "Chad.jpg"),
            // Soi Fon
            new PreguntasClase("¿Te considerás alguien muy disciplinado, reservado y que se toma sus responsabilidades con total seriedad?", "Soi Fon", "soifonsita.jpg"),
            new PreguntasClase("¿Cuando alguien se gana tu confianza o admiración, sos capaz de seguir esa lealtad hasta el final?", "Soi Fon", "Soi Fon.jpg")
        };
        // diccionario de puntajes para cada personaje y lista de preguntas con sus respectivas respuestas y rutas de imagen
        int preguntaActual = 0;

        public Preguntas()
        {
            InitializeComponent();
            // fuentes
            fuentesPreguntas.AddFontFile("Assets\\Oswald-Regular.ttf");
            this.Load += new EventHandler(Preguntas_Load);
            this.Resize += new EventHandler(Preguntas_Resize);
            //fuentes

            // delay botones
            relojCongelar.Interval = 1500;
            relojCongelar.Tick += new EventHandler(RelojCongelar_Tick);
            // delay botones

            MostrarPreguntaActual();
        }
        // inicio ajuste de ventana
        private void Preguntas_Resize(object sender, EventArgs e)
        {
            int anchoVentana = this.ClientSize.Width;
            int altoVentana = this.ClientSize.Height;
            if (pictureBox1 != null)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    pictureBox1.Size = new Size(380, 380);
                    pictureBox1.Top = 40;
                }
                else
                {
                    pictureBox1.Size = new Size(250, 250);
                    pictureBox1.Top = 25;
                }
                pictureBox1.Left = (anchoVentana - pictureBox1.Width) / 2;

            }
            if (label1 != null)
            {
                label1.AutoSize = false;
                label1.Width = anchoVentana;
                label1.Left = 0;

                if (this.WindowState == FormWindowState.Maximized)
                {
                    label1.Height = 110;
                    label1.Top = pictureBox1.Bottom + 20;
                }
                else
                {
                    label1.Height = 85;
                    label1.Top = pictureBox1.Bottom + 10;
                }

                label1.TextAlign = ContentAlignment.MiddleCenter;

                if (fuentesPreguntas.Families.Length > 0)
                {
                    float tamañoFuente = (this.WindowState == FormWindowState.Maximized) ? 26f : 16f;
                    label1.Font = new Font(fuentesPreguntas.Families[0], tamañoFuente, FontStyle.Regular);
                }
            }
            if (panel1 != null)
            {
                panel1.Left = (anchoVentana - panel1.Width) / 2;

                if (this.WindowState == FormWindowState.Maximized)
                {
                    panel1.Top = altoVentana - panel1.Height - 50;
                }
                else
                {
                    panel1.Top = label1.Bottom + 15;
                }
            }
        }
        // fin ajuste de ventana

        // inicio delay botones
        private void CongelarInterfaz()
        {
            if (panel1 != null)
            {
                panel1.Enabled = false;
            }
            relojCongelar.Start();
        }

        private void RelojCongelar_Tick(object sender, EventArgs e)
        {
            relojCongelar.Stop(); 
            if (panel1 != null)
            {
                panel1.Enabled = true;
            }
        }
        // fin delay botones
        private void MostrarPreguntaActual()
        {
            CongelarInterfaz();
            if (preguntaActual < listaPreguntas.Count)
            {
                label1.Text = listaPreguntas[preguntaActual].Pregunta;
                string nombreFoto = listaPreguntas[preguntaActual].RutaImagen;
                string rutaFisica = Path.Combine("Assets", nombreFoto);
                if (File.Exists(rutaFisica))
                {
                    pictureBox1.Image = Image.FromFile(rutaFisica);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else {
                FinalizarTest();
            }
            label1.AutoSize = false;
            label1.Width = this.ClientSize.Width;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Left = 0;
            label1.Height = 60;
        }
        private void FinalizarTest()
        {
            int puntajeMaximo = puntajes.Values.Max();
            int puntajeMinimo = puntajes.Values.Min();

            string personajeGanador = "";

            if (puntajeMaximo == 24 || puntajeMaximo == -24 || puntajeMaximo == puntajeMinimo)
            {
                personajeGanador = "Kon";
            }
            else
            {
                var tablaDePosiciones = puntajes.OrderByDescending(x => x.Value).ToList();
                personajeGanador = tablaDePosiciones[0].Key;
            }
            Resultados ventanaFinal = new Resultados(personajeGanador);
            ventanaFinal.Show();
            this.Hide();
        }
        private void RegistrarRespuesta(int puntosAModificar)
        {
            string personajeDeEstaRonda = listaPreguntas[preguntaActual].Personaje;
            if (puntajes.ContainsKey(personajeDeEstaRonda))
            {
                puntajes[personajeDeEstaRonda] += puntosAModificar;
            }
            preguntaActual++;
            MostrarPreguntaActual();
        }
        private void button1_Click(object sender, EventArgs e) // boton Si
        {
            RegistrarRespuesta(2);
        }
        private void button2_Click(object sender, EventArgs e) // boton No
        {
            RegistrarRespuesta(-2);
        }
        private void button3_Click(object sender, EventArgs e) // boton No se
        {
            RegistrarRespuesta(0);
        }
        private void button4_Click(object sender, EventArgs e) // boton Quiza Si
        {
            RegistrarRespuesta(1);
        }
        private void button5_Click(object sender, EventArgs e) // Boton Quiza No
        {
            RegistrarRespuesta(-1);
        }
        private void Preguntas_Load(object sender, EventArgs e) // Ajuste de ventana al cargar (alias ajustes extra de ventana)
        {
            this.Size = new Size(950, 650);
            this.StartPosition = FormStartPosition.CenterScreen;

            Preguntas_Resize(this, EventArgs.Empty);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
