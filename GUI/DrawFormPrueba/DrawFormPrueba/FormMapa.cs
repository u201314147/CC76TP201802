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
        int aux2 = 0; int aux3 = 0;
        int A, S, D, W, ADD, SUB = 0;
        int LE = 1;
        float XW = 15.0f;
        float YW = 15.0f;
        float scale = 1.0f;
        int lenght = 72000;
        int lenghtlineas = 72000;
        Random r = new Random();
        Rectangle mapa = new Rectangle();
        List<Puntos> apuntadores = new List<Puntos>();
        List<Puntos> puntos = new List<Puntos>();
        List<Lineas> lineas = new List<Lineas>();
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

            //agregar lineas
            for (int i = 0; i < lenghtlineas; i++)
            {
               
                Lineas linea = new Lineas(0, 4, 0, 4);
                lineas.Add(linea);

            }
            leerArchivoAlMap();
           // leerLineasAlMap();
        }
        void leerLineasAlMap()
        {

            string line = "";
            Char delimiter = ';';
          
            int maximo = 0;
            int aum = 0;
            string[] datos;
            // textBox1.Text = "";
            using (StreamReader sr = new StreamReader(@"matrix.al"))

                while (maximo < lenghtlineas - 1)
                {

                    line = sr.ReadLine();
                    datos = line.Split(delimiter);

                    maximo++;



                    lineas.ElementAt(aum).setX1(puntos.FirstOrDefault(x => x.getId() == Convert.ToInt32(datos[0])).getX());
                         lineas.ElementAt(aum).setY1(puntos.FirstOrDefault(x => x.getId() == Convert.ToInt32(datos[0])).getY());
                          lineas.ElementAt(aum).setX2(puntos.FirstOrDefault(x => x.getId() == Convert.ToInt32(datos[2])).getX());
                          lineas.ElementAt(aum).setY2(puntos.FirstOrDefault(x => x.getId() == Convert.ToInt32(datos[2])).getY());
                   

                    aum++;
                }


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
                    
                    line = sr.ReadLine();
                        datos = line.Split(delimiter);
                        maximo++;

                        puntos.ElementAt(aum).setId(Convert.ToInt32(datos[0]));
                        puntos.ElementAt(aum).setNombre(datos[1]);
                        puntos.ElementAt(aum).setX(float.Parse(datos[2]) * 100);
                        puntos.ElementAt(aum).setY(float.Parse(datos[3]) * -100);

                     
                    aum++;
                }
            
       
        }

        private void FormMapa_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
           
            try
            {

                Puntos punto = puntos.ElementAt(r.Next(0, lenght));
                Puntos punto2 = puntos.ElementAt(r.Next(0, lenght));


                int linerandom = r.Next(0, lenghtlineas);
                lineas.ElementAt(linerandom).setX1(punto.getX());
                lineas.ElementAt(linerandom).setY1(punto.getY());
                lineas.ElementAt(linerandom).setX2(punto2.getX());
                lineas.ElementAt(linerandom).setY2(punto2.getY());

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
                if (ADD == 1)
                {
                    scale = scale + 0.01f * scale;
                }
                if (SUB == 1)
                {
                    scale = scale - 0.01f * scale;
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
                
                foreach(Lineas l in lineas)
                {
                    l.dibujar(buffer.Graphics, XW * -1, YW * -1, scale, ClientSize.Width, ClientSize.Height);
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
                ADD = 1;

            }
            if (e.KeyCode == Keys.Subtract)
            {
                SUB = 1;
            }
            if (e.KeyCode == Keys.Z)
            {
                if (aux3 < lenghtlineas)
                {
                    XW = lineas.ElementAt(aux3).getX1() * -1 + ClientSize.Width / scale - (scale) / 2;
                    YW = lineas.ElementAt(aux3).getY1() * -1 + ClientSize.Height / scale - (scale) / 2;
                    aux3++;
                }
                else
                    aux3 = 0;
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
            if (e.KeyCode == Keys.L)
            {
                if (LE == 1)
                {
                    LE = 0;
                }
                else
                {
                    LE = 1;
                }
            }

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
            if (e.KeyCode == Keys.Add)
            {
                ADD = 0;

            }
            if (e.KeyCode == Keys.Subtract)
            {
                SUB = 0;
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
