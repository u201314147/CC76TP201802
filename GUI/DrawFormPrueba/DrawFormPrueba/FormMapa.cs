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
        int mini = 0;
        int aux2 = 0; int aux3 = 0;
        int A, S, D, W, ADD, SUB = 0;
      
        float XW = 15.0f;
        float YW = 15.0f;
        float scale = 1.0f;
        int lenght = 145225;
        int lenghtlineas = 145225;
        int auxLineas = 0;
        int idpuntoinicio = 112029; //puerto  pardo
       Random r = new Random();
        Puntos randomstart = new Puntos(0,0,0,0,0);
        Rectangle mapa = new Rectangle();
        List<Puntos> apuntadores = new List<Puntos>();
        List<Puntos> puntos = new List<Puntos>();
        List<Lineas> lineas = new List<Lineas>();
        List<String> nombres = new List<String>();
       String nombreciudadinicio = "Puerto Pardo";
        //punto de inicio para el algoritmo de union aleatoria
        Puntos randomprev = new Puntos(0,0,0,0,0);
        int auxLineas2 = 0;
        public FormMapa(int maximoLineas, int maximoPuntos,int puntoinicio, String ciudadinicio, String archivo)
        {
           
            idpuntoinicio = puntoinicio;
            nombreciudadinicio = ciudadinicio;
            lenght = maximoPuntos;
            lenghtlineas = maximoLineas;
             XW = 7667.456f;
             YW = -802.6277f;


            randomprev = new Puntos(0, 0, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));

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
               
                Lineas linea = new Lineas();
                lineas.Add(linea);

            }
            leerArchivoAlMap(archivo);
           leerLineasAlMap();

            if(idpuntoinicio==0)
            { busquedaporNombre(); }
            if(nombreciudadinicio =="")
            { busquedaporid(); }
        }

        void busquedaporNombre()
        {
           
                randomprev = puntos.FirstOrDefault(x => x.getNombre() == nombreciudadinicio);
                randomstart = randomprev;

            try
            {
                if (randomstart.getId() == 0)
                {

                }
                if (randomprev.getId() == 0)
                {

                }
            }
            catch (Exception e)
            {
                randomprev = puntos.ElementAt(0);
                randomstart = puntos.ElementAt(0);
            }

        }
        void busquedaporid()
        {

            randomprev = puntos.FirstOrDefault(x => x.getId() == idpuntoinicio);
            randomstart = randomprev;
        }
        void leerLineasAlMap()
        {

           
                string line = "";
                Char delimiter = ';';

                int maximo = 0;
                int aum = 0;
                string[] datos;
              





                using (StreamReader sr = new StreamReader(@"matrix.al"))

                    while (maximo < lenghtlineas - 1)
                    {

                        line = sr.ReadLine();
                        datos = line.Split(delimiter);

                        maximo++;




                        lineas.ElementAt(aum).setId(Convert.ToInt32(datos[0]));
                        lineas.ElementAt(aum).setId1(Convert.ToInt32(datos[2]));
                        lineas.ElementAt(aum).setId2(Convert.ToInt32(datos[4]));
                        lineas.ElementAt(aum).setId3(Convert.ToInt32(datos[6]));
                        lineas.ElementAt(aum).setId4(Convert.ToInt32(datos[8]));
                          lineas.ElementAt(aum).setColor(-1);
                    auxLineas = 0;
                    aum++;
                    }
        


        }

        void leerArchivoAlMap(String archivo)
        {
            
                string line = "";
                Char delimiter = ';';
                int maximo = 0;
                int aum = 0;
                string[] datos;
                string[] datos2;
            try
            { 
            using (StreamReader sr = new StreamReader(archivo))

                    while (maximo < lenght - 1)
                    {
                    

                    if(lenght< 72613)
                    {   line = sr.ReadLine();
                        datos = line.Split(delimiter);
                        maximo++;

                        puntos.ElementAt(aum).setId(Convert.ToInt32(datos[0]));
                        puntos.ElementAt(aum).setNombre(datos[1]);
                        puntos.ElementAt(aum).setX(float.Parse(datos[2]) * 100);
                        puntos.ElementAt(aum).setY(float.Parse(datos[3]) * -100);

                        aum++;}

                    if (lenght > 72613)
                    {
                        line = sr.ReadLine();
                        datos2 = line.Split(delimiter);
                        maximo++;

                        puntos.ElementAt(aum).setId(Convert.ToInt32(datos2[0]));
                        puntos.ElementAt(aum).setNombre(datos2[1]);
                        puntos.ElementAt(aum).setX(float.Parse(datos2[2]) * 100);
                        puntos.ElementAt(aum).setY(float.Parse(datos2[3]) * -100);
                       
                        aum++;
                    }


                    }

            }catch(Exception e)
            {

            }


        }

        void randomDrawLineas()
        {
            Puntos puntorandom1 = puntos.ElementAt(r.Next(0, lenght));
            Puntos puntorandom2 = puntos.ElementAt(r.Next(0, lenght));


           int linerandom = r.Next(0, lenghtlineas);


            lineas.ElementAt(linerandom).setX(puntorandom1.getX());
            lineas.ElementAt(linerandom).setY(puntorandom1.getY());
            lineas.ElementAt(linerandom).setX1(puntorandom2.getX());
            lineas.ElementAt(linerandom).setY1(puntorandom2.getY());
            lineas.ElementAt(linerandom).setColor(2);


        }
        void randomDrawLineasContinuo()
        {
            Puntos randomnext = puntos.ElementAt(r.Next(0, lenght));

            int linerandom = r.Next(0, lenghtlineas);

            lineas.ElementAt(linerandom).setX(randomprev.getX());
            lineas.ElementAt(linerandom).setY(randomprev.getY());
            lineas.ElementAt(linerandom).setX1(randomnext.getX());
            lineas.ElementAt(linerandom).setY1(randomnext.getY());
            lineas.ElementAt(linerandom).setColor(1);

            randomprev = randomnext;

            //if (auxLineas2 < lenghtlineas)
            //{
            //    auxLineas2++;
            //}
        }

        void unirPorRadio()
        {
            float a = randomprev.getX();
            float b = randomprev.getY();
            float x = 0;
            float y = 0;
            Puntos randomnext = puntos.ElementAt(r.Next(0, lenght));
            int contadormega = 0;
            float radio = 0.1f;
            while(contadormega <=0)
            { 
            foreach (Puntos p in puntos)
            {

                 x = p.getX();
                 y = p.getY();

                    if (Math.Pow((x - a), 2) + Math.Pow((y - b), 2) <= Math.Pow(radio, 2) && p.getId() != randomprev.getId() && p.getBooleano() != true)
                    {
                        randomnext = p;
                        p.setBooleano();
                        contadormega++;
                    break;
                    }
            }
                radio = radio + 0.5f;
            }
            //   Puntos randomnext = puntos.ElementAt(r.Next(0, lenght));




            int linerandom = r.Next(0, lenghtlineas);




            lineas.ElementAt(linerandom).setX(a);
            lineas.ElementAt(linerandom).setY(b);
            lineas.ElementAt(linerandom).setX1(x);
            lineas.ElementAt(linerandom).setY1(y);
            lineas.ElementAt(linerandom).setColor(2);

            randomprev = randomnext;

            //if (auxLineas2 < lenghtlineas)
            //{
            //    auxLineas2++;
            //}
           
        }

        void unirpuntosCercanos()
        {
            try
            {
                label2.Text = lineas.ElementAt(auxLineas).getId().ToString();

                lineas.ElementAt(auxLineas).setX(puntos.FirstOrDefault(x => x.getId() == lineas.ElementAt(auxLineas).getId()).getX());
                lineas.ElementAt(auxLineas).setX1(puntos.FirstOrDefault(x => x.getId() == lineas.ElementAt(auxLineas).getId1()).getX());
                // lineas.ElementAt(auxLineas).setX2(puntos.FirstOrDefault(x => x.getId() == lineas.ElementAt(auxLineas).getId2()).getX());
                //  lineas.ElementAt(auxLineas).setX3(puntos.FirstOrDefault(x => x.getId() == lineas.ElementAt(auxLineas).getId3()).getX());
                //   lineas.ElementAt(auxLineas).setX4(puntos.FirstOrDefault(x => x.getId() == lineas.ElementAt(auxLineas).getId4()).getX());

                lineas.ElementAt(auxLineas).setY(puntos.FirstOrDefault(x => x.getId() == lineas.ElementAt(auxLineas).getId()).getY());
                lineas.ElementAt(auxLineas).setY1(puntos.FirstOrDefault(x => x.getId() == lineas.ElementAt(auxLineas).getId1()).getY());

                lineas.ElementAt(auxLineas).setColor(0);
                //   lineas.ElementAt(auxLineas).setY2(puntos.FirstOrDefault(x => x.getId() == lineas.ElementAt(auxLineas).getId2()).getY());
                //   lineas.ElementAt(auxLineas).setY3(puntos.FirstOrDefault(x => x.getId() == lineas.ElementAt(auxLineas).getId3()).getY());
                //   lineas.ElementAt(auxLineas).setY4(puntos.FirstOrDefault(x => x.getId() == lineas.ElementAt(auxLineas).getId4()).getY());
            }
            catch (Exception e)
            { }
            auxLineas++;
        }
        private void FormMapa_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
           
            //mini++;
            //if (mini % 2 == 0)
            //{
            //    unirPorRadio();
            //}
            //if (mini == 2)
            //{
            //    mini = 0;
            //}

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
                if (ADD == 1)
                {
                    scale = scale + 0.02f * scale;
                }
                if (SUB == 1)
                {
                    scale = scale - 0.02f * scale;
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
            if (e.KeyCode == Keys.T)
            {

                unirPorRadio();

            }

            if (e.KeyCode == Keys.F)
            {
                
                XW = randomstart.getX() * -1 + (ClientSize.Width/2-scale )/ scale ;
                YW = randomstart.getY() * -1 + (ClientSize.Height/2 - scale )/ scale ;
              
            }
            if (e.KeyCode == Keys.C)
            {
                leerLineasAlMap();
            }
            if (e.KeyCode == Keys.U)
            {
                unirpuntosCercanos();

            }
            if (e.KeyCode == Keys.R)
            {
                randomDrawLineas();

            }
            if (e.KeyCode == Keys.O)
            {
                randomDrawLineasContinuo();

            }
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
            label2.Text = "XWR:" + XW + " YW: " + YW;



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
