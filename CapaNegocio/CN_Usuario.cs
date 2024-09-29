using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();

        public List<Usuario> listar()
        {
            return objcd_usuario.listar();
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validaciones para los campos obligatorios
            if (string.IsNullOrEmpty(obj.Documento))
            {
                Mensaje = "El campo Documento es obligatorio.";
            }
            else if (string.IsNullOrEmpty(obj.NombreCompleto))
            {
                Mensaje = "El campo Nombre Completo es obligatorio.";
            }
            else if (string.IsNullOrEmpty(obj.Correo))
            {
                Mensaje = "El campo Correo es obligatorio.";
            }
            else if (string.IsNullOrEmpty(obj.Clave))
            {
                Mensaje = "El campo Clave es obligatorio.";
            }
            else if (obj.oRol == null || obj.oRol.IdRol == 0)
            {
                Mensaje = "Debe seleccionar un Rol válido.";
            }
            //else if (!IsValidEmail(obj.Correo))
            //{
            //    Mensaje = "El formato del Correo no es válido.";
            //}

            // Si hay mensaje de error, devolver 0
            if (!string.IsNullOrEmpty(Mensaje))
            {
                return 0;
            }

            // Si todo está bien, llamar a la capa de datos
            return objcd_usuario.Registrar(obj, out Mensaje);
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Validaciones para los campos obligatorios
            if (string.IsNullOrEmpty(obj.Documento))
            {
                Mensaje = "El campo Documento es obligatorio.";
            }
            else if (string.IsNullOrEmpty(obj.NombreCompleto))
            {
                Mensaje = "El campo Nombre Completo es obligatorio.";
            }
            else if (string.IsNullOrEmpty(obj.Correo))
            {
                Mensaje = "El campo Correo es obligatorio.";
            }
            else if (string.IsNullOrEmpty(obj.Clave))
            {
                Mensaje = "El campo Clave es obligatorio.";
            }
            else if (obj.oRol == null || obj.oRol.IdRol == 0)
            {
                Mensaje = "Debe seleccionar un Rol válido.";
            }
            //else if (!IsValidEmail(obj.Correo))
            //{
            //    Mensaje = "El formato del Correo no es válido.";
            //}

            // Si hay mensaje de error, devolver false
            if (!string.IsNullOrEmpty(Mensaje))
            {
                return false;
            }

            // Si todo está bien, llamar a la capa de datos
            return objcd_usuario.Editar(obj, out Mensaje);
        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }

        // Método auxiliar para validar el formato del correo electrónico
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
