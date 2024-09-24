using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> listar(int idusuario)
        {

            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT p.IdRol, p.NombreMenu");
                    query.AppendLine("FROM PERMISO p");
                    query.AppendLine("INNER JOIN ROL r ON r.IdRol = p.IdRol");
                    query.AppendLine("INNER JOIN USUARIO u ON u.IdRol = r.IdRol");
                    query.AppendLine("WHERE u.IdUsuario = @idusuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idusuario", idusuario);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();


                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                oRol = new Rol() { IdRol = Convert.ToInt32(rdr["IdRol"]) },
                                NombreMenu = rdr["NombreMenu"].ToString(),
                            
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                    lista = new List<Permiso>();
                }
            }


            return lista;
        }
    }
}
