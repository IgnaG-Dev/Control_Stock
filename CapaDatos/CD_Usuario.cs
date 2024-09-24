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
                    
                    string query = "select IdUsuario, Documento, NombreCompleto, Correo, Clave, Estado from usuario";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
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
                                Estado = Convert.ToBoolean(rdr["Estado"])
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
