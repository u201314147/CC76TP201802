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

        int maxlineas = 145225;
        int maxpuntos = 145225;
        int idciudad = 112029;
      
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
            } catch (Exception e)
            {
                MessageBox.Show("No se pudo encontrar el archivo metadata.md");
            }
        }

        void obtenervalores()
        {
            try
            {
                maxlineas = Convert.ToInt32(txtMaxLineas.Text);
                maxpuntos = Convert.ToInt32(txtMaxPuntos.Text);
                idciudad = Convert.ToInt32(txtId.Text);
             

            }
            catch (Exception f)
            {

            }
        }
        private void btnAbrirMapa_Click(object sender, EventArgs e)
        {

            obtenervalores();

            FormMapa frm = new FormMapa(maxlineas, maxpuntos, 112029, "Puerto Pardo");
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

        private void btnNombreBusqueda_Click(object sender, EventArgs e)
        {
            obtenervalores();
            FormMapa frm = new FormMapa(maxlineas, maxpuntos, 0, txtNombre.Text);
            frm.Show();
        }

        private void btnCiudadbusqueda_Click(object sender, EventArgs e)
        {
            obtenervalores();
            FormMapa frm = new FormMapa(maxlineas, maxpuntos, idciudad, "");
            frm.Show();

        }
    }
}
