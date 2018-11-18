using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Windows.Forms;
namespace DrawFormPrueba
{

    class Puntos
    {
        int seleccionado = 0;

        int id = 0;
        float x = 0;
        float y = 0;
        bool visitado = false;
        Color color;
        SolidBrush br;
        double velocidad = 10.00;
        double angulo = 0;
        double m;
        int enemX;
        int enemY;
        int minitimer;
        
        String nombre;
        Rectangle r = new Rectangle();


        Font Font = new Font("Arial", 10);
        public Puntos(int pX, int pY, int R, int G, int B)
        {
            minitimer = 49;
            enemX = 0;
            enemY = 0;
            x = pX;
            y = pY;
            color = Color.FromArgb(255, R, G, B);
            br = new SolidBrush(color);
            nombre = "";
        }

        public int getMiniTimer()
        {
            if (minitimer == 50)
                minitimer = 0;

            minitimer++;

            return minitimer;
        }

        public void impedirSalida(int pX, int pY)
        {
            if (x < 0)
                x = 0;
            if (y < 0)
                y = 0;

        }

      
        public Rectangle getRectangle()
        {

            r.X = Convert.ToInt32(x);
            r.Y = Convert.ToInt32(y);
            return r;
        }
       
        public void dibujarball(Graphics g, float XW, float YW, float scale, int width, int height)
        {
           if (this.getX() > XW && this.getX() < XW+width/scale && this.getY() > YW && this.getY() < YW+height/ scale)
            {

                if(seleccionado ==0)
                { 
                if (scale <= 1 && id%16==0)
                    g.FillEllipse(br, x + 6f, y + 6f, 6f, 6f);

                if (scale > 1 && scale < 5 && id % 16 == 0)
                g.FillEllipse(br, x+ 3f, y+ 3f, 3f,3f);

                if (scale > 5 && scale <= 10)
                   g.FillEllipse(br, x+ 2f, y+ 2f, 2f, 2f);

                if (scale > 10 && scale < 20)
                    g.FillEllipse(br, x+ 1f, y+ 1f, 1f, 1f);
                if (scale > 20 && scale < 50)
                    g.FillEllipse(br, x - 0.5f/2, y - 0.5f / 2, 0.5f, 0.5f);
                if (scale > 50 )
                    g.FillEllipse(br, x - 0.3f / 2, y - 0.3f / 2, 0.3f, 0.3f);
                }
                
                if(seleccionado ==1)
                {
                    if (scale <= 1 && id % 16 == 0)
                        g.FillEllipse(new SolidBrush(Color.White), x + 6f, y + 6f, 6f, 6f);

                    if (scale > 1 && scale < 5 && id % 16 == 0)
                        g.FillEllipse(new SolidBrush(Color.White), x + 3f, y + 3f, 3f, 3f);

                    if (scale > 5 && scale <= 10)
                        g.FillEllipse(new SolidBrush(Color.White), x + 2f, y + 2f, 2f, 2f);

                    if (scale > 10 && scale < 20)
                        g.FillEllipse(new SolidBrush(Color.White), x + 1f, y + 1f, 1f, 1f);
                    if (scale > 20 && scale < 50)
                        g.FillEllipse(new SolidBrush(Color.White), x - 0.5f / 2, y - 0.5f / 2, 0.5f, 0.5f);
                    if (scale > 50)
                        g.FillEllipse(new SolidBrush(Color.White), x - 0.3f / 2, y - 0.3f / 2, 0.3f, 0.3f);
                }

                if (scale > 20)
                {
                    if (seleccionado == 0)
                    {
                        Font = new Font("Arial Black", 0.1f);

                        Size textSize = TextRenderer.MeasureText(id.ToString() + " " + nombre, Font);

                        g.DrawString(nombre, Font, Brushes.White, x - 0.3f, y - 0.3f / 2 + 0.3f);
                    }
                    if (seleccionado == 1)
                    {
                        Font = new Font("Arial Black", 0.1f);

                        Size textSize = TextRenderer.MeasureText(id.ToString() + " " + nombre, Font);

                        g.DrawString(nombre, Font, Brushes.White, x - 0.3f, y - 0.3f / 2 + 0.3f);
                        g.DrawString("S", Font, Brushes.Black, x - 0.3f/2, y - 0.3f/2);
                    }
                }
           }
        }
        public void setColorRed()
        {
            color = Color.Red;
            br = new SolidBrush(color);
        }
        public void setColorBlue()
        {
            color = Color.Blue;
            br = new SolidBrush(color);
        }
        public void setNombre(String pnombre)
        {
            nombre = pnombre;
        }
        public void setX(float pX)
        {
            x = pX;
        }
        public void setY(float pY)
        {
             y = pY;
        }
        public float getX()
        {
            return x;
        }
        public float getY()
        {
            return y;
        }

        public void setBooleano()
        {
            visitado = true;
        }
        public bool getBooleano()
        {
            return visitado;
        }
        public double getVelocidad()
        {
            return velocidad;
        }
        public void SetSeleccionado(float XW, float YW, float scale)
        {
            float ancho = 0f;

            if (scale <= 1)
                ancho = 6f;

                if (scale > 1 && scale < 5)
                ancho = 3f;

            if (scale > 5 && scale <= 10)
                ancho = 2f;

            if (scale > 10 && scale < 20)
                ancho =1f;
            if (scale > 20 && scale < 50)
                ancho = 0.5f;
            if (scale > 50)
                ancho = 0.3f;


            if (this.getX() > XW - ancho/2 && this.getX() < XW + ancho/2 && this.getY() > YW - ancho/2 && this.getY() < YW + ancho/2)
            {
              
                    seleccionado = 1;
               
                
            }

      
                
            


        }

        public void SetDeseleccionado(float XW, float YW, float scale)
        {
            float ancho = 0f;

            if (scale <= 1)
                ancho = 6f;

            if (scale > 1 && scale < 5)
                ancho = 3f;

            if (scale > 5 && scale <= 10)
                ancho = 2f;

            if (scale > 10 && scale < 20)
                ancho = 1f;
            if (scale > 20 && scale < 50)
                ancho = 0.5f;
            if (scale > 50)
                ancho = 0.3f;


            if (this.getX() > XW - ancho / 2 && this.getX() < XW + ancho / 2 && this.getY() > YW - ancho / 2 && this.getY() < YW + ancho / 2)
            {
               
                    seleccionado = 0;
                

            }






        }
        public String getNombre()
        {
            return nombre;
        }
        public void setId(int pid)
        {
            id = pid;
        }
        public int getId()
        {
           return id;
        }
    }
}
