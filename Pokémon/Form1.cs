using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Media;
using System.Threading;

namespace Pokémon
{
    public partial class Form1 : Form
    {
        SoundPlayer player;
        int timeleft = 40;
        int currenttime = 0;
        int score = 0;
        int ok = -1;
        String foto;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image=Image.FromFile("")
            cargar();
            
        }

        public async void cargar()
        {
            if (timeleft > 0)
            {
                //Thread.Sleep(3000);
                ReproducirSonido();
                currenttime = 0;
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                var client = new HttpClient();
                var url = "https://localhost/so/pokemon/index.php";
                var res = await client.GetAsync(url);
                var json = await res.Content.ReadAsStringAsync();
                Root data = JsonConvert.DeserializeObject<Root>(json);
                ok = data.ok;

                /*for(int i=0; i< data.array.Count; i++)
                {
                    this.button1.Text(data.array.ElementAt(i).nom.ToString());
                }*/
                button1.Text = data.array.ElementAt(0).nom.ToString();
                button2.Text = data.array.ElementAt(1).nom.ToString();
                button3.Text = data.array.ElementAt(2).nom.ToString();
                button4.Text = data.array.ElementAt(3).nom.ToString();
                button5.Text = data.array.ElementAt(4).nom.ToString();
                Stream StreamImage;
                StreamImage = getUrl("https://localhost/so/pokemon/" + data.array.ElementAt(ok).black.ToString());
                pictureBox1.Image = System.Drawing.Image.FromStream(StreamImage);
                foto = "https://localhost/so/pokemon/" + data.array.ElementAt(ok).foto.ToString();
                this.timer1.Start();
            }
            else
            {
                MessageBox.Show("GAME OVER\nTu puntuación fue de: " + score.ToString());
            }
            
        }

        private void CalcularScore(int tiempo)
        {
            if (tiempo < 10)
            {
                score += 100 * (10 - tiempo);
            }
            this.label2.Text=score.ToString();
        }

        private void ReproducirSonido()
        {
            player = new SoundPlayer(@"C:\Users\megab\source\repos\Pokémon\audio1.wav");
            try
            {
                // Reproducimos el sonido
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reproducir el sonido: " + ex.Message);
            }
        }

        private Stream getUrl(string URL)
        {

            string strResp = "";
            HttpWebRequest request = ((HttpWebRequest)WebRequest.Create(URL));

            HttpWebResponse response = ((HttpWebResponse)request.GetResponse());

            try
            {

                return response.GetResponseStream();

            }
            catch
            {
                return response.GetResponseStream();
                //elError = ex.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (ok == 0)
            {
                timeleft += 3;
                CalcularScore(currenttime);
                MessageBox.Show("Es Correcto, deberías tocar pasto");
                
            } else
            {
                timeleft -= 5;
                MessageBox.Show("Incorrecto, deberías reconsiderar que has hecho con tu vida");
            }
            Stream StreamImage;
            StreamImage = getUrl(foto);
            pictureBox1.Image = System.Drawing.Image.FromStream(StreamImage);
            //Thread.Sleep(3000);
            timer2.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (ok == 1)
            {
                CalcularScore(currenttime);
                MessageBox.Show("Es Correcto, deberías tocar pasto");
               
            }
            else
            {
                timeleft -= 5;
                MessageBox.Show("Incorrecto, deberías reconsiderar que has hecho con tu vida");
            }
            Stream StreamImage;
            StreamImage = getUrl(foto);
            pictureBox1.Image = System.Drawing.Image.FromStream(StreamImage);
            //Thread.Sleep(3000);
            timer2.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (ok == 2)
            {
                CalcularScore(currenttime);
                MessageBox.Show("Es Correcto, deberías tocar pasto");
                
            }
            else
            {
                timeleft -= 5;
                MessageBox.Show("Incorrecto, deberías reconsiderar que has hecho con tu vida");
            }
            Stream StreamImage;
            StreamImage = getUrl(foto);
            pictureBox1.Image = System.Drawing.Image.FromStream(StreamImage);
            //Thread.Sleep(3000);
            timer2.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (ok == 3)
            {
                CalcularScore(currenttime);
                MessageBox.Show("Es Correcto, deberías tocar pasto");
                
            }
            else
            {
                timeleft -= 5;
                MessageBox.Show("Incorrecto, deberías reconsiderar que has hecho con tu vida");
            }
            Stream StreamImage;
            StreamImage = getUrl(foto);
            pictureBox1.Image = System.Drawing.Image.FromStream(StreamImage);
            //Thread.Sleep(3000);
            timer2.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (ok == 4)
            {
                CalcularScore(currenttime);
                MessageBox.Show("Es Correcto, deberías tocar pasto");
                
            }
            else
            {
                timeleft -= 5;
                MessageBox.Show("Incorrecto, deberías reconsiderar que has hecho con tu vida");
            }
            Stream StreamImage;
            StreamImage = getUrl(foto);
            pictureBox1.Image = System.Drawing.Image.FromStream(StreamImage);
            //Thread.Sleep(3000);
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeleft--;
            currenttime++;
            this.label4.Text = timeleft.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            cargar();
            timer2.Stop();
        }
    }

    public class Array
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string link { get; set; }
        public string foto { get; set; }
        public string black { get; set; }
    }

    public class Root
    {
        public int ok { get; set; }
        public List<Array> array { get; set; }
    }

}
