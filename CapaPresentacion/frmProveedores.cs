using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        // Método para validar los campos antes de guardar
        private bool ValidarCampos()
        {
            // Validar que el campo Documento no esté vacío
            if (string.IsNullOrWhiteSpace(txtdocumento.Text))
            {
                MessageBox.Show("El campo 'Nro Documento' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdocumento.Focus();
                return false;
            }

            // Validar que el campo Razón Social no esté vacío
            if (string.IsNullOrWhiteSpace(txtrazonsocial.Text))
            {
                MessageBox.Show("El campo 'Razón Social' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtrazonsocial.Focus();
                return false;
            }

            // Validar que el campo Correo no esté vacío
            if (string.IsNullOrWhiteSpace(txtcorreo.Text))
            {
                MessageBox.Show("El campo 'Correo' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcorreo.Focus();
                return false;
            }

            // Validar que el campo Teléfono no esté vacío
            if (string.IsNullOrWhiteSpace(txttelefono.Text))
            {
                MessageBox.Show("El campo 'Teléfono' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttelefono.Focus();
                return false;
            }

            // Validar que el campo Estado esté seleccionado
            if (cboestado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un estado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboestado.Focus();
                return false;
            }

            return true;
        }

        // Evento del botón Guardar
        private void btnguardar_Click(object sender, EventArgs e)
        {
            // Llamar al método de validación antes de proceder
            if (ValidarCampos())
            {
                // Mostrar mensaje de guardado exitoso (Simulación)
                MessageBox.Show("Proveedor guardado correctamente (Simulado).", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Evento del botón Limpiar
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos del formulario
            txtdocumento.Clear();
            txtrazonsocial.Clear();
            txtcorreo.Clear();
            txttelefono.Clear();
            cboestado.SelectedIndex = -1;
        }

        // Evento del botón Buscar (simulación)
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Buscar Proveedor (Simulación).", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento del botón Limpiar Buscador
        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Clear();
            cbobusqueda.SelectedIndex = -1;
        }
    }
}
