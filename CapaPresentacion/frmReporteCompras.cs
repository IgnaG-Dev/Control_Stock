using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmReporteCompras : Form
    {
        public frmReporteCompras()
        {
            InitializeComponent();
        }

        private void frmReporteCompras_Load(object sender, EventArgs e)
        {
            // Cargar lista de proveedores en ComboBox
            List<Proveedor> lista = new CN_Proveedor().Listar();

            cboproveedor.Items.Add(new OpcionCombo() { Valor = 0, Texto = "TODOS" });
            foreach (Proveedor item in lista)
            {
                cboproveedor.Items.Add(new OpcionCombo() { Valor = item.IdProveedor, Texto = item.RazonSocial });
            }
            cboproveedor.DisplayMember = "Texto";
            cboproveedor.ValueMember = "Valor";
            cboproveedor.SelectedIndex = 0;

            // Configuración de columnas de búsqueda
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;
        }

        private void btnbuscarresultado_Click(object sender, EventArgs e)
        {
            int idproveedor = Convert.ToInt32(((OpcionCombo)cboproveedor.SelectedItem).Valor.ToString());

            List<ReporteCompra> lista = new CN_Reporte().Compra(
                txtfechainicio.Value.ToString("dd/MM/yyyy"),
                txtfechafin.Value.ToString("dd/MM/yyyy"),
                idproveedor
            );

            dgvdata.Rows.Clear();

            // Solo se agregan las columnas necesarias hasta RazonSocial
            foreach (ReporteCompra rc in lista)
            {
                dgvdata.Rows.Add(new object[] {
                    rc.FechaRegistro,
                    rc.TipoDocumento,
                    rc.NumeroDocumento,
                    rc.MontoTotal,
                    rc.UsuarioRegistro,
                    rc.DocumentoProveedor,
                    rc.RazonSocial
                });
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

            // Solo se agregan las columnas hasta RazonSocial para exportación
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                dt.Columns.Add(columna.HeaderText, typeof(string));
            }

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Visible)
                {
                    dt.Rows.Add(new object[] {
                        row.Cells[0].Value?.ToString(),
                        row.Cells[1].Value?.ToString(),
                        row.Cells[2].Value?.ToString(),
                        row.Cells[3].Value?.ToString(),
                        row.Cells[4].Value?.ToString(),
                        row.Cells[5].Value?.ToString(),
                        row.Cells[6].Value?.ToString()
                    });
                }
            }

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("ReporteCompras_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
            savefile.Filter = "Excel Files | *.xlsx";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XLWorkbook wb = new XLWorkbook();
                    var hoja = wb.Worksheets.Add(dt, "Informe");
                    hoja.ColumnsUsed().AdjustToContents();
                    wb.SaveAs(savefile.FileName);
                    MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value?.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()) == true)
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnVerDetalles" && e.RowIndex >= 0)
            {
                // Obtener el número de documento de la compra seleccionada
                string numeroDocumento = dgvdata.Rows[e.RowIndex].Cells["NumeroDocumento"].Value.ToString();

                // Crear una instancia de frmDetalleCompra
                frmDetalleCompra detalleCompra = new frmDetalleCompra();

                // Llamar al método de búsqueda en frmDetalleCompra y pasar el número de documento
                detalleCompra.ObtenerDetallesCompra(numeroDocumento);

                // Mostrar el formulario de detalles
                detalleCompra.ShowDialog();
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
    }
}
