using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        string puntomapa = "";
        string archivo = "";
        string archivo2 = "";
        int maxlineas = 145225;
        int maxpuntos = 145225;
        int idciudad = 0;
      
        public Form1()
        {
            InitializeComponent();


        }
        void leerArchivo(String archivo)
        {

            string line = "";
            int maximo = 0;
            textBox1.Text = "";
            try {
                using (StreamReader sr = new StreamReader(archivo))

                    while (maximo < Convert.ToInt32(txtMaximo.Text))
                    {
                        line = sr.ReadLine();
                        maximo++;

                        textBox1.Text = textBox1.Text + line + "                   ";

                    }
            } catch (Exception e)
            {
               // MessageBox.Show("No se pudo encontrar el archivo" + archivo);
            }
        }

        void obtenervalores(int num)
        {
            try
            {
               
                if (num == 0)
                { 
                maxlineas = Convert.ToInt32(txtMaxLineas.Text);
                maxpuntos = Convert.ToInt32(txtMaxPuntos.Text);
                puntomapa = txtNombre.Text;
                idciudad = Convert.ToInt32(txtId.Text);
                    
                }
                if(num ==1)
                {
                    maxlineas = Convert.ToInt32(maxLineas2.Text);
                    maxpuntos = Convert.ToInt32(maxPuntos2.Text);
                    puntomapa = txtBuscarNombre2.Text;
                    idciudad = Convert.ToInt32(txtBuscarId2.Text);
                   
                }
               
               
              
            }
            catch (Exception f)
            {

            }
        }
       
        private void btnAbrirMapa_Click(object sender, EventArgs e)
        {
            comprobarArchivo();
            obtenervalores(0);

            FormMapa frm = new FormMapa(maxlineas, maxpuntos, 0, "", archivo, "");
            frm.Show();
        }
         private void comprobarArchivo()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(path);


            if (chkFile.Checked == false)
            {
                archivo = directory + "\\" + cmbFindData.Text;
            }
            else
            {
                archivo = cmbFindData.Text;
            }
            try
            {
                leerArchivo(archivo);
            }
            catch (Exception g)
            {
                MessageBox.Show("No se pudo encontrar el archivo " + archivo);
                return;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            comprobarArchivo();

           
         

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
            obtenervalores(0);
            FormMapa frm = new FormMapa(maxlineas, maxpuntos, 0, puntomapa, archivo, "");
            frm.Show();
        }

        private void btnCiudadbusqueda_Click(object sender, EventArgs e)
        {
            obtenervalores(0);
            FormMapa frm = new FormMapa(maxlineas, maxpuntos, idciudad, "", archivo, "");
            frm.Show();

        }

        private void btnCentrosEducativos_Click(object sender, EventArgs e)
        {
            comprobarArchivo();
            obtenervalores(1);

            FormMapa frm = new FormMapa(maxlineas, maxpuntos, 0, "", archivo, "CentrosEscolares.csv");
            frm.Show();


        }

        private void btnFindData_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                cmbFindData.Text = fdlg.FileName;
            }
        }

        private void chkFile_CheckStateChanged(object sender, EventArgs e)
        {
            if (cmbFindData.Enabled == false)
                cmbFindData.Enabled = true;
            else
                cmbFindData.Enabled = false;
        }

        private void btnBuscarNombre2_Click(object sender, EventArgs e)
        {
            obtenervalores(1);
            FormMapa frm = new FormMapa(maxlineas, maxpuntos, 0, puntomapa, "metadata.md", "CentrosEscolares.csv");
            frm.Show();
        }

        private void btnBuscarId2_Click(object sender, EventArgs e)
        {
            obtenervalores(1);
            FormMapa frm = new FormMapa(maxlineas, maxpuntos, idciudad, "", "metadata.md", "CentrosEscolares.csv");
            frm.Show();
        }
    }
}
