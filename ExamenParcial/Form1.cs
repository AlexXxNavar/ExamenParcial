using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenParcial
{
    public partial class Form1 : Form
    {
        List<Temperatura> temperaturas = new List<Temperatura>();
        List<Departamento> departamentos = new List<Departamento>();
        private void CargarDepartamentos(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            while (sr.Peek() != -1)
            {
                Departamento departamento = new Departamento()
                {
                    id = Convert.ToInt32(sr.ReadLine()),
                    nombre = sr.ReadLine(),
                };
                departamentos.Add(departamento);
            }
            sr.Close();
            fs.Close();

        }
        public Form1()
        {
            InitializeComponent();
        }
        //Cargar departamentos en combobox
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDepartamentos("Departamentos.txt");
            CargarTemperaturas("Temperaturas.txt");
            foreach (Departamento departamento in departamentos)
            {
                comboBox1.Items.Add(departamento.nombre);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void CargarTemperaturas(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                Temperatura temperatura = new Temperatura()
                {
                    id = Convert.ToInt32(sr.ReadLine()),
                    magnitud = Convert.ToDouble(sr.ReadLine()),
                    fecha = Convert.ToDateTime(sr.ReadLine())
                };
                temperaturas.Add(temperatura);
            }
            sr.Close();
            fs.Close();
        }
        private void GuardarDatos(string file)
        {
            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Temperatura temperatura in temperaturas)
            {
                sw.WriteLine(temperatura.id);
                sw.WriteLine(temperatura.magnitud);
                sw.WriteLine(temperatura.fecha);
            }
            sw.Close();
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
