using System;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmDetalleCompra : Form
    {
        public frmDetalleCompra()
        {
            InitializeComponent();
        }

        // Validación para el campo de búsqueda (Número de documento)
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (ValidarBusqueda())
            {
                // Lógica para buscar el detalle de la compra
                MessageBox.Show("Búsqueda exitosa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Limpiar el campo de búsqueda
        private void btnborrar_Click(object sender, EventArgs e)
        {
            txtbusqueda.Clear();
            txtbusqueda.Focus();
        }

        // Descargar la compra en PDF
        private void btndescargar_Click(object sender, EventArgs e)
        {
            if (ValidarDescarga())
            {
                // Lógica para descargar el PDF
                MessageBox.Show("Descarga en PDF completada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Método para validar la búsqueda
        private bool ValidarBusqueda()
        {
            if (string.IsNullOrWhiteSpace(txtbusqueda.Text))
            {
                MessageBox.Show("El número de documento de búsqueda es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbusqueda.Focus();
                return false;
            }
            return true;
        }

        // Método para validar antes de descargar el PDF
        private bool ValidarDescarga()
        {
            StringBuilder sbErrores = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtdocproveedor.Text))
            {
                sbErrores.AppendLine("El documento del proveedor es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(txtnombreproveedor.Text))
            {
                sbErrores.AppendLine("El nombre del proveedor es obligatorio.");
            }
            if (dgvdata.Rows.Count == 0)
            {
                sbErrores.AppendLine("No hay productos registrados en esta compra.");
            }

            if (sbErrores.Length > 0)
            {
                MessageBox.Show(sbErrores.ToString(), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
