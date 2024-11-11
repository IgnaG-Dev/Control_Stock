using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CapaPresentacion
{
    public partial class frmInformes : Form
    {
        private readonly CN_Venta ventaNegocio = new CN_Venta();
        private readonly CN_Compra compraNegocio = new CN_Compra();

        public frmInformes()
        {
            InitializeComponent();
            this.Load += frmInformes_Load;
        }

        private void frmInformes_Load(object sender, EventArgs e)
        {
            CargarChartDia();
            CargarChartMes();
            CargarChartAnio();
            CargarChartTopProductos();
        }

        private void CargarChartDia()
        {
            decimal montoTotalDiaVentas = ventaNegocio.ObtenerMontoTotalDelDia();
            decimal montoTotalDiaCompras = compraNegocio.ObtenerMontoTotalDelDia();
            decimal diferencia = montoTotalDiaVentas - montoTotalDiaCompras;

            chartDia.Series.Clear();
            chartDia.Titles.Clear();
            chartDia.Titles.Add("Monto Total de Ventas y Compras del Día");

            Series serieDiaVentas = new Series("Ventas del Día")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = System.Drawing.Color.Blue
            };
            serieDiaVentas.Points.AddY(montoTotalDiaVentas);
            chartDia.Series.Add(serieDiaVentas);

            Series serieDiaCompras = new Series("Compras del Día")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = System.Drawing.Color.Orange
            };
            serieDiaCompras.Points.AddY(montoTotalDiaCompras);
            chartDia.Series.Add(serieDiaCompras);

            // Muestra la diferencia en el gráfico
            chartDia.Titles.Add($"Diferencia (Ganancias): {diferencia:C}");
        }

        private void CargarChartMes()
        {
            decimal montoTotalMesVentas = ventaNegocio.ObtenerMontoTotalDelMes();
            decimal montoTotalMesCompras = compraNegocio.ObtenerMontoTotalDelMes();
            decimal diferencia = montoTotalMesVentas - montoTotalMesCompras;

            chartMes.Series.Clear();
            chartMes.Titles.Clear();
            chartMes.Titles.Add("Monto Total de Ventas y Compras del Mes");

            Series serieMesVentas = new Series("Ventas del Mes")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true,
                Color = System.Drawing.Color.Blue
            };
            serieMesVentas.Points.AddY(montoTotalMesVentas);
            chartMes.Series.Add(serieMesVentas);

            Series serieMesCompras = new Series("Compras del Mes")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true,
                Color = System.Drawing.Color.Orange
            };
            serieMesCompras.Points.AddY(montoTotalMesCompras);
            chartMes.Series.Add(serieMesCompras);

            // Muestra la diferencia en el gráfico
            chartMes.Titles.Add($"Diferencia (Ganancias): {diferencia:C}");
        }

        private void CargarChartAnio()
        {
            decimal montoTotalAnioVentas = ventaNegocio.ObtenerMontoTotalDelAño();
            decimal montoTotalAnioCompras = compraNegocio.ObtenerMontoTotalDelAño();
            decimal diferencia = montoTotalAnioVentas - montoTotalAnioCompras;

            chartAnio.Series.Clear();
            chartAnio.Titles.Clear();
            chartAnio.Titles.Add("Monto Total de Ventas y Compras del Año");

            Series serieAnioVentas = new Series("Ventas del Año")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = System.Drawing.Color.Blue
            };
            serieAnioVentas.Points.AddY(montoTotalAnioVentas);
            chartAnio.Series.Add(serieAnioVentas);

            Series serieAnioCompras = new Series("Compras del Año")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = System.Drawing.Color.Orange
            };
            serieAnioCompras.Points.AddY(montoTotalAnioCompras);
            chartAnio.Series.Add(serieAnioCompras);

            // Muestra la diferencia en el gráfico
            chartAnio.Titles.Add($"Diferencia (Ganancias): {diferencia:C}");
        }

        private void CargarChartTopProductos()
        {
            List<Producto_Reporte> topProductos = ventaNegocio.ObtenerTopProductosVendidos();

            chartTopProductos.Series.Clear();
            chartTopProductos.ChartAreas[0].AxisX.Title = "Productos";
            chartTopProductos.ChartAreas[0].AxisY.Title = "Cantidad Vendida";

            Series series = new Series("Top 5 Productos Más Vendidos")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true
            };

            foreach (var producto in topProductos)
            {
                series.Points.AddXY(producto.NombreProducto, producto.CantidadVendida);
            }

            chartTopProductos.Series.Add(series);
            chartTopProductos.Titles.Clear();
            chartTopProductos.Titles.Add("Top 5 de Productos Más Vendidos");
        }

        private void chartTopProductos_Click(object sender, EventArgs e)
        {

        }
    }
}
