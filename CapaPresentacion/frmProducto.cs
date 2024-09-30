using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        // Método para validar los campos antes de guardar
        private bool ValidarCampos()
        {
            // Validar que el campo código no esté vacío
            if (string.IsNullOrWhiteSpace(txtcodigo.Text))
            {
                MessageBox.Show("El campo 'Código' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcodigo.Focus();
                return false;
            }

            // Validar que el campo nombre no esté vacío
            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                MessageBox.Show("El campo 'Nombre' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnombre.Focus();
                return false;
            }

            // Validar que el campo categoría esté seleccionado
            if (cbocategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbocategoria.Focus();
                return false;
            }

            // Validar que el campo estado esté seleccionado
            if (cboestado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un estado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboestado.Focus();
                return false;
            }

            return true;
        }

        // Evento para el botón Guardar
        private void btnguardar_Click(object sender, EventArgs e)
        {
            // Llamar al método de validación antes de proceder
            if (ValidarCampos())
            {
                // Código para guardar el producto (simulación sin conexión a BD)
                MessageBox.Show("Producto guardado correctamente (Simulado).", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Evento para el botón Limpiar
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos del formulario
            txtcodigo.Clear();
            txtnombre.Clear();
            txtdescripcion.Clear();
            cbocategoria.SelectedIndex = -1;
            cboestado.SelectedIndex = -1;
        }
    }
}
