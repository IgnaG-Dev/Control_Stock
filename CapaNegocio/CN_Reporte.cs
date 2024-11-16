using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Reporte
    {
        private CD_Reporte objcd_reporte = new CD_Reporte();

        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            return objcd_reporte.Compra(fechainicio, fechafin, idproveedor);
        }

        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            // Obtener el reporte de ventas general sin detalle de productos
            return objcd_reporte.Venta(fechainicio, fechafin);
        }
    }
}
