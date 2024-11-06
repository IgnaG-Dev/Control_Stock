using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Cliente
    {
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdCliente, Documento, NombreCompleto, Correo, Telefono, Estado, Direccion, FechaNacimiento from CLIENTE");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                Direccion = dr["Direccion"].ToString(),
                                FechaNacimiento = dr["FechaNacimiento"] != DBNull.Value ? Convert.ToDateTime(dr["FechaNacimiento"]) : (DateTime?)null
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<Cliente>();
                }
            }

            return lista;
        }

        public int Registrar(Cliente obj, out string Mensaje)
        {
            int idClientegenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("insert into CLIENTE (Documento, NombreCompleto, Correo, Telefono, Estado, Direccion, FechaNacimiento)");
                    query.AppendLine("values (@Documento, @NombreCompleto, @Correo, @Telefono, @Estado, @Direccion, @FechaNacimiento);");
                    query.AppendLine("select SCOPE_IDENTITY();");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", obj.FechaNacimiento.HasValue ? (object)obj.FechaNacimiento.Value : DBNull.Value);

                    oconexion.Open();
                    idClientegenerado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                idClientegenerado = 0;
                Mensaje = ex.Message;
            }

            return idClientegenerado;
        }

        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update CLIENTE set Documento = @Documento, NombreCompleto = @NombreCompleto,");
                    query.AppendLine("Correo = @Correo, Telefono = @Telefono, Estado = @Estado, Direccion = @Direccion,");
                    query.AppendLine("FechaNacimiento = @FechaNacimiento where IdCliente = @IdCliente");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@IdCliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("@Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", obj.FechaNacimiento.HasValue ? (object)obj.FechaNacimiento.Value : DBNull.Value);

                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("delete from CLIENTE where IdCliente = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", obj.IdCliente);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }
    }
}
