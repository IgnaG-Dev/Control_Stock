using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; // Necesario para las validaciones de correo
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            // Inicializa los valores de los ComboBoxes
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;
        }

        // Valida que los campos obligatorios estén completos
        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtdocumento.Text))
            {
                MessageBox.Show("Debe ingresar un número de documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtnombrecompleto.Text))
            {
                MessageBox.Show("Debe ingresar un nombre completo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtcorreo.Text) || !EsCorreoValido(txtcorreo.Text))
            {
                MessageBox.Show("Debe ingresar un correo electrónico válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txttelefono.Text))
            {
                MessageBox.Show("Debe ingresar un número de teléfono.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Valida el formato del correo electrónico
        private bool EsCorreoValido(string correo)
        {
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patronCorreo);
        }

        // Botón Guardar (aún no realiza acciones definitivas, solo validaciones)
        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                MessageBox.Show("Validaciones correctas. Aún no se guarda nada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Botón Eliminar (solo validaciones por ahora)
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text) || txtid.Text == "0")
            {
                MessageBox.Show("Debe seleccionar un cliente para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Validaciones correctas. Aún no se elimina nada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Limpia los campos
        private void Limpiar()
        {
            txtid.Text = "0";
            txtdocumento.Text = "";
            txtnombrecompleto.Text = "";
            txtcorreo.Text = "";
            txttelefono.Text = "";
            cboestado.SelectedIndex = 0;
        }

        // Otras funciones como buscar, limpiar buscador, etc., pueden mantenerse en blanco hasta que las necesites
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // Solo validaciones, aún sin implementar
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
