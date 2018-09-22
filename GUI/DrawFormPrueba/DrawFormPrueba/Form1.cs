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
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();


        }
        void leerArchivo()
        {
            
            string line = "";
            int maximo = 0;
            textBox1.Text = "";
            try { 
            using (StreamReader sr = new StreamReader("metadata.md"))

                while (maximo < Convert.ToInt32(txtMaximo.Text))
                {
                    line = sr.ReadLine();
                    maximo++;

                    textBox1.Text = textBox1.Text + line + "                   ";

                }
               }catch(Exception e)
            {
                MessageBox.Show("No se pudo encontrar el archivo metadata.md");
            }
        }

        private void btnAbrirMapa_Click(object sender, EventArgs e)
        {
            FormMapa frm = new FormMapa();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            leerArchivo();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string line = "";
            int maximo = 0;
            textBox1.Text = "";
            try
            {
                using (StreamReader sr = new StreamReader("matrix.al"))

                    while (maximo < Convert.ToInt32(txtMaximo.Text))
                    {
                        line = sr.ReadLine();
                        maximo++;

                        textBox1.Text = textBox1.Text + line + "                   ";

                    }
            }
            catch (Exception f)
            {
                MessageBox.Show("No se pudo encontrar el archivo matrix.al");
            }
        }
    }
}
