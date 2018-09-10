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
        double x = 0;
        double y = 0;
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
            nombre = "CIUDAD";
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
        public void moverball(int pX, int pY)
        {
            double mY = Convert.ToDouble(pY) - Convert.ToDouble(y);
            double mX = Convert.ToDouble(pX) - Convert.ToDouble(x);
            m = mY / mX;

            angulo = Math.Atan(m) * 180 / Math.PI;

            if (y - pY > 0 && x - pX > 0)
                angulo = Math.Atan(m) * 180 / Math.PI;

            if (y - pY < 0 && x - pX > 0)
                angulo = Math.Atan(m) * 180 / Math.PI + 180;

            if (y - pY > 0 && x - pX > 0)
                angulo = Math.Atan(m) * 180 / Math.PI + 180;

            if (y - pY > 0 && x - pX < 0)
                angulo = Math.Atan(m) * 180 / Math.PI + 360;

            try
            {



                x = (x + velocidad * Math.Cos(angulo * Math.PI / 180.0));
                y = (y + velocidad * Math.Sin(angulo * Math.PI / 180.0));

            }
            catch (Exception) { }
        }
        public void dibujarball(Graphics g)
        {
            g.FillEllipse(br, Convert.ToInt32(x), Convert.ToInt32(y), 5, 5);

            Font = new Font("Arial Black", 8);

            Size textSize = TextRenderer.MeasureText(nombre, Font);


            g.DrawString(nombre, Font, Brushes.White, Convert.ToInt32(x) + (30 - textSize.Width) / 2 + 3, Convert.ToInt32(y) + 10);

        }

        public void setNombre(String pnombre)
        {
            nombre = pnombre;
        }
        public double getX()
        {
            return x;
        }
        public double getY()
        {
            return y;
        }


        public double getVelocidad()
        {
            return velocidad;
        }

    }
}
