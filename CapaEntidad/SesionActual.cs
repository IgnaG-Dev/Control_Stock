using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class SesionActual
    {
        private static SesionActual _instancia;
        public Usuario Usuario { get; private set; }

        private SesionActual(Usuario usuario)
        {
            Usuario = usuario;
        }

        public static void IniciarSesion(Usuario usuario)
        {
            _instancia = new SesionActual(usuario);
        }

        public static SesionActual Instancia
        {
            get
            {
                if (_instancia == null)
                    throw new Exception("No hay ninguna sesión iniciada.");

                return _instancia;
            }
        }

        public static void CerrarSesion()
        {
            _instancia = null;
        }
    }
}
