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
        string archivo = "";
        int maxlineas = 145225;
        int maxpuntos = 145225;
        int idciudad = 112029;
      
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
            comprobarArchivo();
            obtenervalores();

            FormMapa frm = new FormMapa(maxlineas, maxpuntos, 112029, "Puerto Pardo", archivo);
            frm.Show();
        }
         private void comprobarArchivo()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(path);


            if (chkFile.Checked == true)
            {
                archivo = directory + "\\" + txtFindData.Text;
            }
            else
            {
                archivo = txtFindData.Text;
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
            obtenervalores();
            FormMapa frm = new FormMapa(maxlineas, maxpuntos, 0, txtNombre.Text, archivo);
            frm.Show();
        }

        private void btnCiudadbusqueda_Click(object sender, EventArgs e)
        {
            obtenervalores();
            FormMapa frm = new FormMapa(maxlineas, maxpuntos, idciudad, "", archivo);
            frm.Show();

        }

        private void btnCentrosEducativos_Click(object sender, EventArgs e)
        {
 

           
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
                txtFindData.Text = fdlg.FileName;
            }
        }

        private void chkFile_CheckStateChanged(object sender, EventArgs e)
        {
            if (txtFindData.Enabled == false)
                txtFindData.Enabled = true;
            else
                txtFindData.Enabled = false;
        }
    }
}
