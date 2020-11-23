using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using SQL;
using System.Collections.Generic;
using Excepciones;
using System.Threading;
using Archivos;

namespace FormPrincipal
{
    public partial class Form1 : Form
    {
        public Stock<Camiseta> stockCa;
        public Stock<Pantalon> stockPant;

        Thread hilo2;

        public object MensageBox { get; private set; }

        public Form1()
        {
            InitializeComponent();
            stockCa = new Stock<Camiseta>();
            stockPant = new Stock<Pantalon>();
            SQL.SQL.CargarDatos(out stockPant.prendas, out stockCa.prendas);
            this.Pantalones.DataSource = stockPant.prendas;
            this.dataGridView2.DataSource = stockCa.prendas;

            hilo2 = new Thread(imagenes);

            hilo2.Start();

        }

        
        private void imagenes()
        {
            string str = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\tp_laboratorio_2\TP4- Agustin Clas\Clas.Agustin.2A.TP4\CamisetaTitular_.jpg";
            Bitmap imagen1 = new Bitmap(str);

            str = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\tp_laboratorio_2\TP4- Agustin Clas\Clas.Agustin.2A.TP4\PantalonTitular_.jpg";
            Bitmap imagen2 = new Bitmap(str);

            str = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\tp_laboratorio_2\TP4- Agustin Clas\Clas.Agustin.2A.TP4\CamisetaSuplente_.jpg";
            Bitmap imagen3 = new Bitmap(str);

            str = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\tp_laboratorio_2\TP4- Agustin Clas\Clas.Agustin.2A.TP4\PantalonSuplente_.jpg";
            Bitmap imagen4 = new Bitmap(str);

            while (true)
            {
                this.pictureBox1.Image = imagen1;
                Thread.Sleep(7000);
                this.pictureBox1.Image = imagen2;
                Thread.Sleep(7000);
                this.pictureBox1.Image = imagen3;
                Thread.Sleep(7000);
                this.pictureBox1.Image = imagen4;
                Thread.Sleep(7000);
            }
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            int id;

            try
            {
                if (int.TryParse(this.textBox2.Text, out id))
                    generarVenta(id);
            }
            catch (fueraDeStockException f)
            {
                MessageBox.Show(f.Message);
            }

        }

        private void generarVenta(int id)
        {

            Camiseta camiseta = new Camiseta();
            Pantalon pantalon = new Pantalon();
            if (stockCa.buscarPrenda(id, out camiseta))
            {
                if (camiseta.mangaLarga)
                    MessageBox.Show("Usted compro una camiseta manga larga!");
                else
                    MessageBox.Show("Usted compro una camiseta manga corta!");


                stockCa.prendas.Remove(camiseta);
                SQL.SQL.BorrarPrenda(id);
                this.dataGridView2.DataSource = stockCa.prendas;
            }
            else if (stockPant.buscarPrenda(id, out pantalon))
            {
                if (pantalon.conBolsillo)
                    MessageBox.Show("Usted compro un pantalon con bolsillo!");
                else
                    MessageBox.Show("Usted compro un pantalon sin bolsillo!");


                SQL.SQL.BorrarPrenda(id);
                stockPant.prendas.Remove(pantalon);
                this.Pantalones.DataSource = stockPant.prendas;

            }
            else
            {
                throw new fueraDeStockException();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarContraseña(this.textBox1.Text))
                {
                    Form2 form2 = new Form2();
                    bool flag = false;
                    Pantalon pantalon;
                    Camiseta camiseta;


                    if (form2.ShowDialog() == DialogResult.OK)
                    {
                        if (form2.EsCamiseta)
                        {
                            camiseta = stockCa.agregarCamiseta(form2.Numero, form2.Talle, form2.Equipacion, form2.Manga);
                            if (SQL.SQL.agregarCamiseta(camiseta))
                            {
                                flag = true;
                            }
                        }
                        else
                        {
                            pantalon = stockPant.agregarPantalon(form2.Numero, form2.Talle, form2.Equipacion, form2.Bolsillo);
                            if (SQL.SQL.agregarPantalon(pantalon))
                            {
                                flag = true;
                            }
                        }

                        if (flag)
                        {
                            SQL.SQL.CargarDatos(out stockPant.prendas, out stockCa.prendas);
                            this.Pantalones.DataSource = stockPant.prendas;
                            this.dataGridView2.DataSource = stockCa.prendas;
                            MessageBox.Show("Producto agregado con exito!");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el producto");
                        }
                    }
                }
            }
            catch (contraseñaIncorrecta exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    
        public bool ValidarContraseña(string contraseña)
        {
            if (contraseña == "sport2020")
                return true;
            else
                throw new contraseñaIncorrecta();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Xml<Stock<Camiseta>> serializadorCamisetas = new Xml<Stock<Camiseta>>();
            Xml<Stock<Pantalon>> serializadorPantalones = new Xml<Stock<Pantalon>>();

            string archivoCamisetas = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Camisetas";
            string archivoPantalones = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Pantalones";

            if (serializadorPantalones.Guardar(archivoPantalones, stockPant) && serializadorCamisetas.Guardar(archivoCamisetas, stockCa))
                MessageBox.Show("Back up realizado con exito");
            else
                MessageBox.Show("No se pudo realizar el Back up");

        }

        
    }
}
