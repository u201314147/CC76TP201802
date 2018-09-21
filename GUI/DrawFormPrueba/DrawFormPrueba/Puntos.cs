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
        float x = 0;
        float y = 0;
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
            color = Color.Red;
            br = new SolidBrush(Color.FromArgb(255, R, G, B));
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


                if (scale <= 1)
                    g.FillEllipse(br, x, y, 6f, 6f);

                if (scale > 1 && scale < 5)
                g.FillEllipse(br, x, y, 3f,3f);

                if (scale > 5 && scale <= 10)
                   g.FillEllipse(br, x, y, 2f, 2f);

                if (scale > 10 && scale < 20)
                    g.FillEllipse(br, x, y, 1f, 1f);
                if (scale > 20 && scale < 50)
                    g.FillEllipse(br, x, y, 0.5f, 0.5f);
                if (scale > 50 )
                    g.FillEllipse(br, x, y, 0.3f, 0.3f);


                if (scale>10)
                {
                    Font = new Font("Arial Black", 0.2f);

                    Size textSize = TextRenderer.MeasureText(nombre, Font);

                    g.DrawString(nombre, Font, Brushes.White, x, y + 0.3f);
                    }
           }
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


        public double getVelocidad()
        {
            return velocidad;
        }

    }
}
