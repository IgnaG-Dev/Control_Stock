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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        // Validación antes de guardar
        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                // Aquí puedes agregar la lógica de guardado, por ahora solo muestra mensaje de éxito
                MessageBox.Show("Categoría guardada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Validación antes de limpiar el formulario
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas limpiar el formulario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarFormulario();
            }
        }

        // Validación antes de eliminar
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "0")
            {
                if (MessageBox.Show("¿Estás seguro de que deseas eliminar esta categoría?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // Aquí puedes agregar la lógica para eliminar la categoría
                    MessageBox.Show("Categoría eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna categoría para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para validar los campos del formulario
        private bool ValidarFormulario()
        {
            StringBuilder sbErrores = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtdescripcion.Text))
            {
                sbErrores.AppendLine("La descripción es un campo obligatorio.");
            }

            if (cboestado.SelectedIndex == -1)
            {
                sbErrores.AppendLine("Debes seleccionar un estado.");
            }

            if (sbErrores.Length > 0)
            {
                MessageBox.Show(sbErrores.ToString(), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Método para limpiar los controles del formulario
        private void LimpiarFormulario()
        {
            txtdescripcion.Text = "";
            cboestado.SelectedIndex = -1;  // Reiniciar el estado
            txtid.Text = "0";  // Reiniciar el ID
            txtindice.Text = "-1";  // Reiniciar el índice
        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {
            // Aquí puedes agregar validaciones adicionales si lo deseas
        }

        private void cboestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aquí puedes agregar alguna lógica si cambia el estado seleccionado
        }

        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lógica si es necesario manejar la búsqueda por campos
        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            // Lógica si es necesario realizar búsqueda en tiempo real
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // Lógica de búsqueda si es necesario
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";  // Limpiar el campo de búsqueda
            cbobusqueda.SelectedIndex = -1;  // Reiniciar el combo box de búsqueda
        }
    }
}
