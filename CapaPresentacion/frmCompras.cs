using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCompras : Form
    {
        public frmCompras()
        {
            InitializeComponent();
        }

        // Validación antes de agregar el producto
        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            if (ValidarProducto())
            {
                // Lógica para agregar producto a la lista (dgvdata)
                MessageBox.Show("Producto agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Validación antes de registrar la compra
        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (ValidarCompra())
            {
                // Lógica para registrar la compra
                MessageBox.Show("Compra registrada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Método para validar el producto antes de agregarlo
        private bool ValidarProducto()
        {
            StringBuilder sbErrores = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtcodproducto.Text))
            {
                sbErrores.AppendLine("El código de producto es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(txtproducto.Text))
            {
                sbErrores.AppendLine("El nombre del producto es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(txtpreciocompra.Text) || !decimal.TryParse(txtpreciocompra.Text, out _))
            {
                sbErrores.AppendLine("El precio de compra es obligatorio y debe ser un número válido.");
            }
            if (txtcantidad.Value <= 0)
            {
                sbErrores.AppendLine("La cantidad debe ser mayor a cero.");
            }

            if (sbErrores.Length > 0)
            {
                MessageBox.Show(sbErrores.ToString(), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Método para validar la compra antes de registrarla
        private bool ValidarCompra()
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
            if (cbotipodocumento.SelectedIndex == -1)
            {
                sbErrores.AppendLine("Debes seleccionar un tipo de documento.");
            }
            if (dgvdata.Rows.Count == 0)
            {
                sbErrores.AppendLine("Debes agregar al menos un producto a la compra.");
            }

            if (sbErrores.Length > 0)
            {
                MessageBox.Show(sbErrores.ToString(), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Eventos de cambio de texto o valor
        private void txtfecha_TextChanged(object sender, EventArgs e) { }
        private void cbotipodocumento_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtdocproveedor_TextChanged(object sender, EventArgs e) { }
        private void txtnombreproveedor_TextChanged(object sender, EventArgs e) { }
        private void txtcodproducto_TextChanged(object sender, EventArgs e) { }
        private void txtproducto_TextChanged(object sender, EventArgs e) { }
        private void txtpreciocompra_TextChanged(object sender, EventArgs e) { }
        private void txtprecioventa_TextChanged(object sender, EventArgs e) { }
        private void txtcantidad_ValueChanged(object sender, EventArgs e) { }
        private void txttotalpagar_TextChanged(object sender, EventArgs e) { }
    }
}
