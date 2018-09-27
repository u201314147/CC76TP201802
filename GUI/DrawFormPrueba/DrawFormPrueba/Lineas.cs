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
        int id, id1, id2, id3, id4 = 0;
        int tipoalg;
        float x, y, x1, x2, x3, x4, y1, y2, y3, y4 = 0;
        Pen pen = new Pen(Color.Black, 0.1f);
        public Lineas()
        {
            tipoalg =-1;
            id = 0;
            id1 = 0;
            id2 = 0;
            id3 = 0;
            id4 = 0;
            x = 0;
            y = 0;
            x1 = 0;
            x2 = 0;
            x3 = 0;
            x4 = 0;
            y1 = 0;
            y2 = 0;
            y3 = 0;
            y4 = 0;
        }

       public void dibujar(Graphics g, float XW, float YW, float scale, int width, int height)
        {
           
                //  if (scale > 5)
                // { 
                
                if (tipoalg == 0)
                {
                     pen = new Pen(Color.Red, 0.1f);
                }
                if (tipoalg==1)
                { 
                     pen = new Pen(Color.Blue, 0.1f);
                  }

                if (tipoalg == 2)
                {
                    pen = new Pen(Color.Green, 0.1f);
                }
                if(tipoalg >=0)
                { 
                if (x1 != 0 && y1 != 0)
                    g.DrawLine(pen, x, y, x1, y1);

                if(x2 !=0 && y2!=0)
                g.DrawLine(pen, x, y, x2, y2);

                if (x3 != 0 && y3 != 0)
                    g.DrawLine(pen, x, y, x3, y3);

                if (x4 != 0 && y4 != 0)
                    g.DrawLine(pen, x, y, x4, y4);
                  }
                //   }
             
        }


        public void setX(float pX) { x = pX; }
        public void setX1(float pX) { x1 = pX;}
        public void setX2(float pX) { x2 = pX; }
        public void setX3(float pX) { x3 = pX; }
        public void setX4(float pX) { x4 = pX; }
      
        public void setY(float pY){ y = pY;}
        public void setY1(float pY) { y1 = pY; }
        public void setY2(float pY) { y2 = pY; }
        public void setY3(float pY) { y3 = pY; }
        public void setY4(float pY) { y4 = pY; }

        public float getX(){ return x; }
        public float getX1() { return x1; }
        public float getX2() { return x2; }
        public float getX3() { return x3; }
        public float getX4() { return x4; }

        public float getY() { return y; }
        public float getY1() { return y1; }
        public float getY2() { return y2; }
        public float getY3() { return y3; }
        public float getY4() { return y4; }
 
        public void setId(int pid) {id = pid;  }
        public void setId1(int pid) { id1 = pid; }
        public void setId2(int pid) { id2 = pid; }
        public void setId3(int pid) { id3 = pid; }
        public void setId4(int pid) { id4 = pid; }

        public int getId() { return id; }
        public int getId1() { return id1; }
        public int getId2() { return id2; }
        public int getId3() { return id3; }
        public int getId4() { return id4; }

        public void setColor(int ptipoalg) { tipoalg = ptipoalg; }


    }
}
