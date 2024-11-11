using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmReporteVentas : Form
    {
        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;
        }

        // Evento para capturar el clic en el botón de la columna "Ver Detalles"
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si la columna es la del botón "Ver Detalles"
            if (dgvdata.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Obtener el número de documento o ID de la venta de la fila seleccionada
                string numeroDocumento = dgvdata.Rows[e.RowIndex].Cells["NumeroDocumento"].Value.ToString();

                // Crear y mostrar el formulario de detalle de venta
                frmDetalleVenta detalleVentaForm = new frmDetalleVenta();

                // Cargar los datos de la venta en el formulario de detalles
                detalleVentaForm.CargarDatosVenta(numeroDocumento);

                // Mostrar el formulario de detalles
                detalleVentaForm.ShowDialog();
            }
        }


        private void dgvdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si la columna "Ver Detalles" fue clickeada
            if (e.ColumnIndex == dgvdata.Columns["VerDetalles"].Index && e.RowIndex >= 0)
            {
                // Obtiene el número de documento de la venta seleccionada
                string numeroDocumento = dgvdata.Rows[e.RowIndex].Cells["NumeroDocumento"].Value.ToString();

                // Crea una instancia del formulario frmDetalleVenta
                frmDetalleVenta frmDetalle = new frmDetalleVenta();

                // Llama al método para cargar datos en frmDetalleVenta
                frmDetalle.CargarDatosVenta(numeroDocumento);

                // Muestra el formulario frmDetalleVenta
                frmDetalle.ShowDialog();
            }
        }


        private void btnbuscarreporte_Click(object sender, EventArgs e)
        {
            // Obtener el rango de fechas en el formato esperado por el procedimiento almacenado (dd/MM/yyyy)
            string fechaInicio = txtfechainicio.Value.ToString("dd/MM/yyyy");
            string fechaFin = txtfechafin.Value.ToString("dd/MM/yyyy");

            // Llamar a la capa de negocio para obtener el reporte de ventas
            List<ReporteVenta> lista = new CN_Reporte().Venta(fechaInicio, fechaFin);

            // Limpiar el DataGridView antes de cargar nuevos datos
            dgvdata.Rows.Clear();

            // Agregar los datos obtenidos a dgvdata
            foreach (ReporteVenta rv in lista)
            {
                dgvdata.Rows.Add(new object[] {
                    rv.FechaRegistro,
                    rv.TipoDocumento,
                    rv.NumeroDocumento,
                    rv.MontoTotal,
                    rv.UsuarioRegistro,
                    rv.DocumentoCliente,
                    rv.NombreCliente
                });
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    row.Visible = row.Cells[columnaFiltro].Value.ToString()
                        .Trim().ToUpper()
                        .Contains(txtbusqueda.Text.Trim().ToUpper());
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay registros para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dt = new DataTable();

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                dt.Columns.Add(columna.HeaderText, typeof(string));
            }

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Visible)
                {
                    dt.Rows.Add(new object[] {
                        row.Cells[0].Value.ToString(),
                        row.Cells[1].Value.ToString(),
                        row.Cells[2].Value.ToString(),
                        row.Cells[3].Value.ToString(),
                        row.Cells[4].Value.ToString(),
                        row.Cells[5].Value.ToString(),
                        row.Cells[6].Value.ToString()
                    });
                }
            }

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = $"ReporteVentas_{DateTime.Now:ddMMyyyyHHmmss}.xlsx";
            savefile.Filter = "Excel Files | *.xlsx";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                    }
                    MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
