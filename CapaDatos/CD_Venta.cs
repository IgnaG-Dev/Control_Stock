using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Venta
    {

        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {

                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from VENTA");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    idcorrelativo = 0;
                }
            }
            return idcorrelativo;
        }

        public bool RestarStock(int idproducto, int cantidad)
        {
            bool respuesta = true;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update producto set stock = stock - @cantidad where idproducto = @idproducto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;

        }


        public bool SumarStock(int idproducto, int cantidad)
        {
            bool respuesta = true;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update producto set stock = stock + @cantidad where idproducto = @idproducto");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;

        }



        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarVenta", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("DocumentoCliente", obj.DocumentoCliente);
                    cmd.Parameters.AddWithValue("NombreCliente", obj.NombreCliente);
                    cmd.Parameters.AddWithValue("MontoPago", obj.MontoPago);
                    cmd.Parameters.AddWithValue("MontoCambio", obj.MontoCambio);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleVenta", DetalleVenta);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }

            return Respuesta;
        }


        public Venta ObtenerVenta(string numero)
        {

            Venta obj = new Venta();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select v.IdVenta,u.NombreCompleto,");
                    query.AppendLine("v.DocumentoCliente,v.NombreCliente,");
                    query.AppendLine("v.TipoDocumento,v.NumeroDocumento,");
                    query.AppendLine("v.MontoPago,v.MontoCambio,v.MontoTotal,");
                    query.AppendLine("convert(char(10),v.FechaRegistro,103)[FechaRegistro]");
                    query.AppendLine("from VENTA v");
                    query.AppendLine("inner join USUARIO u on u.IdUsuario = v.IdUsuario");
                    query.AppendLine("where v.NumeroDocumento = @numero");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            obj = new Venta()
                            {
                                IdVenta = int.Parse(dr["IdVenta"].ToString()),
                                oUsuario = new Usuario() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoPago = Convert.ToDecimal(dr["MontoPago"].ToString()),
                                MontoCambio = Convert.ToDecimal(dr["MontoCambio"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }

                }
                catch
                {
                    obj = new Venta();
                }

            }
            return obj;

        }


        public List<Detalle_Venta> ObtenerDetalleVenta(int idVenta)
        {
            List<Detalle_Venta> oLista = new List<Detalle_Venta>();

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.Nombre,dv.PrecioVenta,dv.Cantidad,dv.SubTotal from DETALLE_VENTA dv");
                    query.AppendLine("inner join PRODUCTO p on p.IdProducto = dv.IdProducto");
                    query.AppendLine(" where dv.IdVenta = @idventa");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idventa", idVenta);
                    cmd.CommandType = System.Data.CommandType.Text;


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Detalle_Venta()
                            {
                                oProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"].ToString()),
                            });
                        }
                    }

                }
                catch
                {
                    oLista = new List<Detalle_Venta>();
                }
            }
            return oLista;
        }

        public decimal ObtenerMontoTotalDelDia()
        {
            decimal montoTotalDelDia = 0;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                oconexion.Open();
                SqlCommand cmd = new SqlCommand(@"
                    SELECT SUM(MontoTotal) AS MontoTotalDelDia
                    FROM VENTA
                    WHERE YEAR(FechaRegistro) = YEAR(GETDATE())
                      AND MONTH(FechaRegistro) = MONTH(GETDATE())
                      AND DAY(FechaRegistro) = DAY(GETDATE());
                ", oconexion);

                object result = cmd.ExecuteScalar();
                montoTotalDelDia = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
            }
            return montoTotalDelDia;
        }

        public decimal ObtenerMontoTotalDelMes()
        {
            decimal montoTotalDelMes = 0;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                oconexion.Open();
                SqlCommand cmd = new SqlCommand(@"
                    SELECT SUM(MontoTotal) AS MontoTotalDelMes
                    FROM VENTA
                    WHERE YEAR(FechaRegistro) = YEAR(GETDATE())
                      AND MONTH(FechaRegistro) = MONTH(GETDATE());
                ", oconexion);

                object result = cmd.ExecuteScalar();
                montoTotalDelMes = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
            }
            return montoTotalDelMes;
        }

        public decimal ObtenerMontoTotalDelAño()
        {
            decimal montoTotalDelAño = 0;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                oconexion.Open();
                SqlCommand cmd = new SqlCommand(@"
                    SELECT SUM(MontoTotal) AS MontoTotalDelAño
                    FROM VENTA
                    WHERE YEAR(FechaRegistro) = YEAR(GETDATE());
                ", oconexion);

                object result = cmd.ExecuteScalar();
                montoTotalDelAño = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
            }
            return montoTotalDelAño;
        }

        public List<Producto_Reporte> ObtenerTopProductosVendidos()
        {
            List<Producto_Reporte> lista = new List<Producto_Reporte>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    oconexion.Open();
                    SqlCommand cmd = new SqlCommand(@"
                        SELECT TOP 5 p.Nombre AS NombreProducto, SUM(dv.Cantidad) AS CantidadVendida
                        FROM DETALLE_VENTA dv
                        INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto
                        GROUP BY p.Nombre
                        ORDER BY CantidadVendida DESC;", oconexion);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto_Reporte
                            {
                                NombreProducto = dr["NombreProducto"].ToString(),
                                CantidadVendida = Convert.ToInt32(dr["CantidadVendida"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores si es necesario
                    lista = new List<Producto_Reporte>();
                }
            }
            return lista;
        }

    }
}