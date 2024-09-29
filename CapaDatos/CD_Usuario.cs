using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public List<Usuario> listar()
        {
          
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.IdUsuario, u.Documento, u.NombreCompleto, u.Correo, u.Clave, u.Estado, r.IdRol, r.Descripcion from usuario u");
                    query.AppendLine("inner join rol r on r.IdRol = u.IdRol");
                    
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                   
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                                Documento = rdr["Documento"].ToString(),
                                NombreCompleto = rdr["NombreCompleto"].ToString(),
                                Correo = rdr["Correo"].ToString(),
                                Clave = rdr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(rdr["Estado"]),
                                oRol = new Rol() { IdRol = Convert.ToInt32(rdr["IdRol"]), Descripcion = rdr["Descripcion"].ToString() },
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    lista = new List<Usuario>();
                }
            }

    
            return lista;
        }
    }
}
