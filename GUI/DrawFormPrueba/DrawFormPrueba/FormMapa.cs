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

namespace DrawFormPrueba
{
    public partial class FormMapa : Form
    {
        int aux2 = 0;
        int A, S, D, W = 0;
        float XW = 15.0f;
        float YW = 15.0f;
        int AutoMove = 0;
        float scale = 1.0f;
        int lenght = 72000;
        Random r = new Random();
        Rectangle mapa = new Rectangle();
        List<Puntos> apuntadores = new List<Puntos>();
        List<Puntos> puntos = new List<Puntos>();

        List<String> nombres = new List<String>();
        public FormMapa()
        {
            InitializeComponent();
            mapa.X = 0;
            mapa.Y = 0;
            mapa.Width = 3500;
            mapa.Height = 2000;

            InitializeComponent();

            Puntos jugador = new Puntos(r.Next(0, mapa.Width + 1), r.Next(0, mapa.Height + 1), r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            apuntadores.Add(jugador);


            //agregar puntos
            for (int i = 0; i < lenght; i++)
            {
                Puntos punto = new Puntos(r.Next(0, mapa.Width + 1), r.Next(0, mapa.Height + 1), r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                puntos.Add(punto);
            }
            leerArchivoAlMap();
        }
        void leerArchivoAlMap()
        {

            string line = "";
            Char delimiter = ',';
            int maximo = 0;
            int aum = 0;
            string[] datos;
            // textBox1.Text = "";
            using (StreamReader sr = new StreamReader(@"data.csv"))

                while (maximo < lenght - 1)
                {
                    line = sr.ReadLine();
                    if (aum>0)
                    {
                    line = sr.ReadLine();
                        datos = line.Split(delimiter);
                        maximo++;

                        
                        puntos.ElementAt(aum).setNombre(datos[1]);
                        puntos.ElementAt(aum).setX(float.Parse(datos[2]) * 100);
                        puntos.ElementAt(aum).setY(float.Parse(datos[3]) * -100);

                     }
                    aum++;
                }

        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
           
            try
            {



                if (A == 1)            //if (pX + XW < 400)
                {
                    XW = XW + 10*5 / scale;
                }
                if (D == 1) //if (pX > this.ClientSize.Width/2 - 400 - XW)
                {
                    XW = XW - 10*5 / scale;
                }

                if (W == 1)//if (pY + YW <200)
                {
                    YW = YW + 10*5 / scale;
                }

                if (S == 1) //if (pY> this.ClientSize.Height/2 - 200 - YW)
                {
                    YW = YW - 10*5 / scale;
                }


                Graphics g = this.CreateGraphics();

                BufferedGraphicsContext contexto = BufferedGraphicsManager.Current;
                BufferedGraphics buffer = contexto.Allocate(g, this.ClientRectangle);
                buffer.Graphics.ScaleTransform(scale, scale);
                buffer.Graphics.TranslateTransform(XW, YW);
                buffer.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


                buffer.Graphics.Clear(Color.Black);


                buffer.Graphics.DrawRectangle(Pens.Blue, 1, 1, mapa.Width - 3, mapa.Height - 3);


                foreach (Puntos c in puntos)
                {
                    c.dibujarball(buffer.Graphics, XW*-1, YW*-1, scale, ClientSize.Width, ClientSize.Height);
                }

              


              
                buffer.Render();


            } catch (Exception g)
            {

            }
        }

        private void FormMapa_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.A)
            {
                A = 1;
            }
            if (e.KeyCode == Keys.W)
            {
                W = 1;
            }
            if (e.KeyCode == Keys.S)
            {
                S = 1;
            }
            if (e.KeyCode == Keys.D)
            {
                D = 1;
            }
            if (e.KeyCode == Keys.Add)
            {
                scale = scale + 0.1f;

            }
            if (e.KeyCode == Keys.Subtract)
            {
            
                    scale = scale - 0.1f;
            }
            if (e.KeyCode == Keys.Space)
            {
                if (aux2 < lenght)
                {
                    XW = puntos.ElementAt(aux2).getX() * -1 + ClientSize.Width / scale - (scale) / 2;
                    YW = puntos.ElementAt(aux2).getY() * -1 + ClientSize.Height / scale - (scale) / 2;
                    aux2++;
                         }
                else
                    aux2 = 0;
            }

            label1.Text = "XW: " + ((XW * -1)/100).ToString() + "  YW:" + ((YW) / 100).ToString() + "  Escala: " + scale;



        }

        private void FormMapa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                A = 0;
            }
            if (e.KeyCode == Keys.W)
            {
                W = 0;
            }
            if (e.KeyCode == Keys.S)
            {
                S = 0;
            }
            if (e.KeyCode == Keys.D)
            {
                D = 0;
            }


            label1.Text = "XW: " + ((XW * -1) / 100).ToString() + "  YW:" + ((YW) / 100).ToString() + "  Escala: " + scale;

        }


        private void btnAbrirMapa_Click(object sender, EventArgs e)
        {
            FormMapa frm = new FormMapa();
            frm.Show();
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                A = 0;
            }
            if (e.KeyCode == Keys.W)
            {
                W = 0;
            }
            if (e.KeyCode == Keys.S)
            {
                S = 0;
            }
            if (e.KeyCode == Keys.D)
            {
                D = 0;
            }


        }




       
       
        
    }
}
