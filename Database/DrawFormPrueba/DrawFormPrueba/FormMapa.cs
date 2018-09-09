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
        int tamanoApuntador = 0;
        int pX;
        int pY;
        int A, S, D, W, Z, X = 0;
        int XW = 235;
        int YW = 175;
        int AutoMove = 0;
        int scale = 1;
        Random r = new Random();
        Rectangle mapa = new Rectangle();
        List<Puntos> apuntadores = new List<Puntos>();
        List<Puntos> puntos = new List<Puntos>();


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
            XW = 375 - Convert.ToInt32(jugador.getX());
            YW = 270 - Convert.ToInt32(jugador.getY());

            //agregar puntos
            for (int i = 0; i < 2000; i++)
            {
                Puntos punto = new Puntos(r.Next(0, mapa.Width + 1), r.Next(0, mapa.Height + 1), r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                puntos.Add(punto);
            }

        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (A == 1)            //if (pX + XW < 400)
            {
                XW = XW + 5;
            }
            if (D == 1) //if (pX > this.ClientSize.Width/2 - 400 - XW)
            {
                XW = XW - 5;
            }

            if (W == 1)//if (pY + YW <200)
            {
                YW = YW + 5;
            }

            if (S == 1) //if (pY> this.ClientSize.Height/2 - 200 - YW)
            {
                YW = YW - 5;
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
                c.dibujarball(buffer.Graphics);
            }

            foreach (Puntos b in apuntadores)
            {
              //  b.dibujarball(buffer.Graphics);
              //  b.moverball(pX, pY);
                b.impedirSalida(mapa.Width, mapa.Height);

                if (AutoMove == 1)
                {
                    XW = ClientSize.Width / (2 * scale) - Convert.ToInt32(b.getX() + 30);
                    YW = ClientSize.Height / (2 * scale) - Convert.ToInt32(b.getY() + 30);
                }
            }



            buffer.Render();





        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            try
            {



                if (A == 1)            //if (pX + XW < 400)
                {
                    XW = XW + 5;
                }
                if (D == 1) //if (pX > this.ClientSize.Width/2 - 400 - XW)
                {
                    XW = XW - 5;
                }

                if (W == 1)//if (pY + YW <200)
                {
                    YW = YW + 5;
                }

                if (S == 1) //if (pY> this.ClientSize.Height/2 - 200 - YW)
                {
                    YW = YW - 5;
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
                    c.dibujarball(buffer.Graphics);
                }

                foreach (Puntos b in apuntadores)
                {
                    //  b.dibujarball(buffer.Graphics);
                    //  b.moverball(pX, pY);
                    b.impedirSalida(mapa.Width, mapa.Height);

                    if (AutoMove == 1)
                    {
                        XW = ClientSize.Width / (2 * scale) - Convert.ToInt32(b.getX() + 30);
                        YW = ClientSize.Height / (2 * scale) - Convert.ToInt32(b.getY() + 30);
                    }
                }



                buffer.Render();


            }catch(Exception g)
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
                scale = scale + 1;

            }
            if (e.KeyCode == Keys.Subtract)
            {
                if (scale != 1)
                    scale = scale - 1;
            }
            if (e.KeyCode == Keys.Space)
            {

                if (AutoMove == 1)
                    AutoMove = 0;
                else
                    AutoMove = 1;

            }




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


        }

        private void FormMapa_MouseMove(object sender, MouseEventArgs e)
        {
            pX = (e.X - tamanoApuntador * scale / 2) / scale - XW;
            pY = (e.Y - tamanoApuntador * scale / 2) / scale - YW;


        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            pX = (e.X - tamanoApuntador * scale / 2) / scale - XW;
            pY = (e.Y - tamanoApuntador * scale / 2) / scale - YW;



        }

        private void btnAbrirMapa_Click(object sender, EventArgs e)
        {
            FormMapa frm = new FormMapa();
            frm.Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
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
                scale = scale + 1;

            }
            if (e.KeyCode == Keys.Subtract)
            {
                if (scale != 1)
                    scale = scale - 1;
            }
            if (e.KeyCode == Keys.Space)
            {

                if (AutoMove == 1)
                    AutoMove = 0;
                else
                    AutoMove = 1;

            }



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
