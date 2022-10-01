using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Semana05
{
    /// <summary>
    /// Interaction logic for ManProducto.xaml
    /// </summary>
    public partial class ManProducto : Window
    {
        public int ID { get; set; }

        public ManProducto( int Id)
        {
            InitializeComponent();

            ID = Id;
            if(ID > 0)
            {
                BProducto bProducto = new BProducto();
                List<Producto> productos = new List<Producto>();
                productos = bProducto.Listar(ID);
                if(productos.Count > 0)
                {
                    lblID.Content = productos[0].IdProducto.ToString();
                    txtNombre.Text = productos[0].NombreProducto;
                    txtProveedor.Text = productos[0].Proveedor;
                }
            }
        }
        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BProducto Bproducto = null;
            bool result = true;
            try
            {
                Bproducto = new BProducto();
                if (ID > 0)
                    result = Bproducto.Insertar(producto: new Producto { NombreProducto = txtNombre.Text, Proveedor = txtProveedor.Text });

                if (result)
                {
                    MessageBox.Show("Comunicarse con el administrador 22");
                }
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el administrador 22");
            }
            finally
            {
                Bproducto = null;
            }
        }
        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
