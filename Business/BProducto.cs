using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BProducto
    {
        private DProducto DProducto = null;

        public List<Producto> Listar(int IdProducto)
        {
            List<Producto> productos = null;
            try
            {
                DProducto = new DProducto();
                productos = DProducto.Listar(new Producto { IdProducto = IdProducto});
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return productos;
        }
        public bool Insertar(Producto producto)
        {
            bool result = true;
            try
            {
                DProducto = new DProducto();
                DProducto.Insertar(producto);
            }
            catch(Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
