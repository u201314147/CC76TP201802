using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Windows.Forms;
namespace DrawFormPrueba
{
    class Lineas
    {
        float x1 = 0;
        float y1 = 0;
        float x2 = 5;
        float y2 = 5;
        public Lineas(float px1, float px2 , float py1, float py2)
        {
             x1 = px1;
             y1 = py1;
             x2 = px2;
             y2 = py2;
        }

       public void dibujar(Graphics g, float XW, float YW, float scale, int width, int height)
        {
            if ((this.getX1() > XW && this.getX1() < XW + width / scale && this.getY1() > YW && this.getY1() < YW + height / scale) ||
               (this.getX2() > XW && this.getX2() < XW + width / scale && this.getY2() > YW && this.getY2() < YW + height / scale))
            {
              //  if (scale > 5)
               // { 
                    Pen pen = new Pen(Color.Red, 0.1f);
                
                    g.DrawLine(pen, x1, y1, x2, y2);
              //   }
            }
        }
        


        public void setX1(float pX)
        {
           x1 = pX;
        }
        public void setY1(float pY)
        {
            y1 = pY;
        }
        public float getX1()
        {
            return x1;
        }
        public float getY1()
        {
            return y1;
        }

        public void setX2(float pX)
        {
            x2 = pX;
        }
        public void setY2(float pY)
        {
            y2= pY;
        }
        public float getX2()
        {
            return x2;
        }
        public float getY2()
        {
            return y2;
        }


    }
}
