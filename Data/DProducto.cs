using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace Data
{
    public class DProducto
    {  
        public List<Producto> Listar(Producto producto){
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<Producto> productos = null;

            try
            {
                comandText = "USP_GetProducto";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto",SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                productos = new List<Producto>();
            
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection,comandText,CommandType.StoredProcedure, parameters)) 
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            IdProducto = reader["prodId"] != null ? Convert.ToInt32(reader["prodId"]) : 0,
                            NombreProducto = reader["nombre"] != null ? Convert.ToString(reader["nombre"]) : String.Empty,
                            Proveedor = reader["proveedor"] != null ? Convert.ToString(reader["proveedor"]) : String.Empty
                        });

                    }
                }
            }catch (Exception ex)
            {
                throw ex;
            }
            return productos;
        }

        public void Insertar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_InsProducto";
                parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@nombreProducto", SqlDbType.VarChar);
                parameters[0].Value = producto.NombreProducto;
                parameters[1] = new SqlParameter("@proveedor", SqlDbType.Float);
                parameters[1].Value = producto.Proveedor;
                SqlHelper.ExecuteReader(SqlHelper.Connection, comandText, CommandType.StoredProcedure);
                
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }

    }
}
