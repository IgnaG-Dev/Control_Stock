using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objcd_Cliente = new CD_Cliente();

        public List<Cliente> Listar()
        {
            return objcd_Cliente.Listar();
        }

        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(obj.Documento))
            {
                Mensaje += "Es necesario el documento del Cliente\n";
            }

            if (string.IsNullOrWhiteSpace(obj.NombreCompleto))
            {
                Mensaje += "Es necesario el nombre completo del Cliente\n";
            }

            if (string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje += "Es necesario el correo del Cliente\n";
            }

            if (string.IsNullOrWhiteSpace(obj.Direccion))
            {
                Mensaje += "Es necesario la dirección del Cliente\n";
            }

            if (!obj.FechaNacimiento.HasValue)
            {
                Mensaje += "Es necesario la fecha de nacimiento del Cliente\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Cliente.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(obj.Documento))
            {
                Mensaje += "Es necesario el documento del Cliente\n";
            }

            if (string.IsNullOrWhiteSpace(obj.NombreCompleto))
            {
                Mensaje += "Es necesario el nombre completo del Cliente\n";
            }

            if (string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje += "Es necesario el correo del Cliente\n";
            }

            if (string.IsNullOrWhiteSpace(obj.Direccion))
            {
                Mensaje += "Es necesario la dirección del Cliente\n";
            }

            if (!obj.FechaNacimiento.HasValue)
            {
                Mensaje += "Es necesario la fecha de nacimiento del Cliente\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Cliente.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            return objcd_Cliente.Eliminar(obj, out Mensaje);
        }
    }
}
