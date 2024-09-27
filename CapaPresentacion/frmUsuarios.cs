using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Utilidades;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            // Agregar opciones de estado
            CBEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            CBEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            CBEstado.DisplayMember = "Texto";
            CBEstado.ValueMember = "Valor";
            CBEstado.SelectedIndex = 0; // Esto está bien porque siempre hay 2 opciones de estado

            // Listar los roles y agregarlos al ComboBox
            List<Rol> listaRol = new CN_Rol().listar();

            if (listaRol.Count > 0) // Asegurarte de que la lista tiene elementos
            {
                foreach (Rol item in listaRol)
                {
                    CBRol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
                }

                CBRol.DisplayMember = "Texto";
                CBRol.ValueMember = "Valor";
                CBRol.SelectedIndex = 0; // Establecer el índice seleccionado solo si hay roles
            }
            else
            {
                MessageBox.Show("No se encontraron roles en la base de datos.");
            }
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "BtnSeleccionar" )
                {
                    CBBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            CBBusqueda.DisplayMember = "Texto";
            CBBusqueda.ValueMember = "Valor";
            CBBusqueda.SelectedIndex = 0;
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            dgvdata.Rows.Add(new object[] {"",TBId.Text, TBDocumento.Text, TBNombreCompleto.Text, TBCorreo.Text, TBClave.Text, 
                ((OpcionCombo)CBRol.SelectedItem).Valor.ToString(),
                ((OpcionCombo)CBRol.SelectedItem).Texto.ToString(),
                ((OpcionCombo)CBEstado.SelectedItem).Valor.ToString(),
                ((OpcionCombo)CBEstado.SelectedItem).Texto.ToString()
            });

            Limpiar();

        }
        private void Limpiar()
        {
            TBId.Text = "0";
            TBDocumento.Text = "";
            TBNombreCompleto.Text = "";
            TBCorreo.Text = "";
            TBClave.Text = "";
            TBConfirmarClave.Text = "";
            CBRol.SelectedIndex = 0;
            CBEstado.SelectedIndex = 0;
        }
    }
}
