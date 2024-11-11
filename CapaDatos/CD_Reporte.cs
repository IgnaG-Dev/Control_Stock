using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaDatos
{
    public class CD_Reporte
    {
        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            List<ReporteCompra> lista = new List<ReporteCompra>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SET DATEFORMAT dmy;");
                    query.AppendLine("SELECT ");
                    query.AppendLine("    CONVERT(char(10), c.FechaRegistro, 103) AS FechaRegistro,");
                    query.AppendLine("    c.TipoDocumento,");
                    query.AppendLine("    c.NumeroDocumento,");
                    query.AppendLine("    c.MontoTotal,");
                    query.AppendLine("    u.NombreCompleto AS UsuarioRegistro,");
                    query.AppendLine("    pr.Documento AS DocumentoProveedor,");
                    query.AppendLine("    pr.RazonSocial");
                    query.AppendLine("FROM COMPRA c");
                    query.AppendLine("INNER JOIN USUARIO u ON u.IdUsuario = c.IdUsuario");
                    query.AppendLine("INNER JOIN PROVEEDOR pr ON pr.IdProveedor = c.IdProveedor");
                    query.AppendLine("WHERE CONVERT(date, c.FechaRegistro) BETWEEN @fechainicio AND @fechafin");
                    query.AppendLine("AND pr.IdProveedor = IIF(@idproveedor = 0, pr.IdProveedor, @idproveedor)");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@fechainicio", DateTime.ParseExact(fechainicio, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@fechafin", DateTime.ParseExact(fechafin, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@idproveedor", idproveedor);

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteCompra()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = dr["MontoTotal"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                DocumentoProveedor = dr["DocumentoProveedor"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<ReporteCompra>();
                }
            }

            return lista;
        }

        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Aseguramos el formato de fecha esperado por SQL Server
                    string query = @"
            SET DATEFORMAT dmy;  
            SELECT 
                CONVERT(char(10), v.FechaRegistro, 103) AS FechaRegistro,
                v.TipoDocumento,
                v.NumeroDocumento,
                v.MontoTotal,
                u.NombreCompleto AS UsuarioRegistro,
                v.DocumentoCliente,
                v.NombreCliente
            FROM VENTA v
            INNER JOIN USUARIO u ON u.IdUsuario = v.IdUsuario
            WHERE CONVERT(date, v.FechaRegistro) BETWEEN @fechainicio AND @fechafin";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@fechainicio", DateTime.ParseExact(fechainicio, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@fechafin", DateTime.ParseExact(fechafin, "dd/MM/yyyy", null));

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = dr["MontoTotal"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<ReporteVenta>();
                }
            }

            return lista;
        }


    }
}
