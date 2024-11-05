using GestorEmpleados.API.Models;
using Microsoft.EntityFrameworkCore;
using MiWebAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace MiWebAPI.Data
{
    public class CompraData
    {

        private readonly string conexion;
        public CompraData(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("CadenaSQL")!;
        }

        /// <summary>
        /// Consulta lista de compras
        /// <returns></returns>
        public async Task<List<Compra>> GetCompra(string filtro)
        {
            List<Compra> lista = new List<Compra>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_selecciona", con);
                cmd.Parameters.AddWithValue("@filtro", filtro);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())


                    {
                        lista.Add(new Compra
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Producto = reader["Producto"].ToString(),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            Total = Convert.ToDecimal(reader["Total"]),
                            Subtotal = Convert.ToDecimal(reader["Subtotal"]),
                            Cliente = reader["Cliente"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }


        /// <summary>
        /// Agrega un empleado
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public async Task<RespuestaDB> AddCompra(Compra objeto)
        {
            var resultado = new RespuestaDB();

            using (var con = new SqlConnection(conexion))
            {


                SqlCommand cmd = new SqlCommand("sp_agrega", con);
                cmd.Parameters.AddWithValue("@producto", objeto.Producto);
                cmd.Parameters.AddWithValue("@cantidad", objeto.Cantidad);
                cmd.Parameters.AddWithValue("@precio", objeto.Precio);
                cmd.Parameters.AddWithValue("@total", objeto.Total);
                cmd.Parameters.AddWithValue("@subtotal", objeto.Subtotal);
                cmd.Parameters.AddWithValue("@cliente", objeto.Cliente);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())

                    {
                        resultado.TipoError = Convert.ToInt32(reader["TipoError"]);
                        resultado.Mensaje = reader["Mensaje"].ToString();


                    }
                }
            }
            return resultado;
        }


        /// <summary>
        ///Actualiza un compra
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public async Task<RespuestaDB> UpdateCompra(Compra objeto)
        {
            var resultado = new RespuestaDB();

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("sp_actualizar", con);
                cmd.Parameters.AddWithValue("@id", objeto.Id);
                cmd.Parameters.AddWithValue("@producto", objeto.Producto);
                cmd.Parameters.AddWithValue("@cantidad", objeto.Cantidad);
                cmd.Parameters.AddWithValue("@precio", objeto.Precio);
                cmd.Parameters.AddWithValue("@total", objeto.Total);
                cmd.Parameters.AddWithValue("@subtotal", objeto.Subtotal);
                cmd.Parameters.AddWithValue("@cliente", objeto.Cliente);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())

                    {
                        resultado.TipoError = Convert.ToInt32(reader["TipoError"]);
                        resultado.Mensaje = reader["Mensaje"].ToString();


                    }
                }
            }
            return resultado;
        }

        /// <summary>
        /// Elimina una compra
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RespuestaDB> DeleteCompra(int id)
        {
            var resultado = new RespuestaDB();

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("sp_eliminar", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())

                    {
                        resultado.TipoError = Convert.ToInt32(reader["TipoError"]);
                        resultado.Mensaje = reader["Mensaje"].ToString();


                    }
                }
            }
            return resultado;
        }
    }
}