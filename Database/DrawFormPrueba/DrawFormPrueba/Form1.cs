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
            using (StreamReader sr = new StreamReader(@"C:\Users\Acer\Desktop\Complejidad\TrabajoParcial\CC76TP20182\Database\data.csv"))

                while (maximo < Convert.ToInt32(txtMaximo.Text))
                {
                    line = sr.ReadLine();
                    maximo++;
                    textBox1.Text = textBox1.Text + line + "                   ";

                }

        }

        private void btnAbrirMapa_Click(object sender, EventArgs e)
        {
            FormMapa frm = new FormMapa();
            frm.Show();
        }
    }
}
