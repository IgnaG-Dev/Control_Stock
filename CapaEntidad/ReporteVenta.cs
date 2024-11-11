using System;

namespace CapaEntidad
{
    public class ReporteVenta
    {
        // Información general de la venta
        public string FechaRegistro { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string MontoTotal { get; set; }
        public string UsuarioRegistro { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public string PrecioVenta { get; set; }
        public string Cantidad { get; set; }
        public string SubTotal { get; set; }


        // Constructor para inicializar datos generales de la venta
        public ReporteVenta() { }
    }
}
