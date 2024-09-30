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
                if (columna.Visible == true && columna.Name != "BtnSeleccionar")
                {
                    CBBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }

            }
            CBBusqueda.DisplayMember = "Texto";
            CBBusqueda.ValueMember = "Valor";
            CBBusqueda.SelectedIndex = 0;

            //MOSTRAR TODOS LOS USUARIOS
            List<Usuario> listaUsuarios = new CN_Usuario().listar();

            foreach (Usuario item in listaUsuarios)
            {
                dgvdata.Rows.Add(new object[] {"",item.IdUsuario, item.Documento, item.NombreCompleto, item.Correo, item.Clave,
                item.oRol.IdRol,
                item.oRol.Descripcion,
                item.Estado == true ? 1 : 0,
                item.Estado == true ? "Activo" : "No Activo"
                });
            }
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Usuario objusuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(TBId.Text),
                Documento = TBDocumento.Text,
                NombreCompleto = TBNombreCompleto.Text,
                Correo = TBCorreo.Text,
                Clave = TBClave.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)CBRol.SelectedItem).Valor)} ,
                Estado = Convert.ToInt32(((OpcionCombo)CBEstado.SelectedItem).Valor) == 1 ? true : false,
            };

            if (objusuario.IdUsuario == 0)
            {
                int idusuariogenerado = new CN_Usuario().Registrar(objusuario, out mensaje);

                if (idusuariogenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {"",idusuariogenerado, TBDocumento.Text, TBNombreCompleto.Text, TBCorreo.Text, TBClave.Text,
                    ((OpcionCombo)CBRol.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)CBRol.SelectedItem).Texto.ToString(),
                    ((OpcionCombo)CBEstado.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)CBEstado.SelectedItem).Texto.ToString()
                    });
                    Limpiar();

                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new CN_Usuario().Editar(objusuario, out mensaje);

                if(resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(TBIndice.Text)];
                    row.Cells["Id"].Value = TBId.Text;
                    row.Cells["Documento"].Value = TBId.Text;
                    row.Cells["NombreCompleto"].Value = TBNombreCompleto.Text;
                    row.Cells["Correo"].Value = TBCorreo.Text;
                    row.Cells["Clave"].Value = TBClave.Text;
                    row.Cells["IdRol"].Value = ((OpcionCombo)CBRol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((OpcionCombo)CBRol.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)CBEstado.SelectedItem).Valor.ToString();
                    row.Cells["Documento"].Value = ((OpcionCombo)CBEstado.SelectedItem).Texto.ToString();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }
        private void Limpiar()
        {
            TBIndice.Text = "-1";
            TBId.Text = "0";
            TBDocumento.Text = "";
            TBNombreCompleto.Text = "";
            TBCorreo.Text = "";
            TBClave.Text = "";
            TBConfirmarClave.Text = "";
            CBRol.SelectedIndex = 0;
            CBEstado.SelectedIndex = 0;

            TBDocumento.Select();
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Obtener las dimensiones de la imagen original
                var originalWidth = Properties.Resources.icons8_comprobado_48.Width;
                var originalHeight = Properties.Resources.icons8_comprobado_48.Height;

                // Obtener las dimensiones de la celda
                var cellWidth = e.CellBounds.Width;
                var cellHeight = e.CellBounds.Height;

                // Escalar el icono si es más grande que la celda
                var scaleFactor = Math.Min((float)cellWidth / originalWidth, (float)cellHeight / originalHeight);
                var newWidth = (int)(originalWidth * scaleFactor);
                var newHeight = (int)(originalHeight * scaleFactor);

                // Calcular la posición centrada
                var x = e.CellBounds.Left + (e.CellBounds.Width - newWidth) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - newHeight) / 2;

                // Dibujar la imagen redimensionada
                e.Graphics.DrawImage(Properties.Resources.icons8_comprobado_48, new Rectangle(x, y, newWidth, newHeight));

                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "BtnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    TBIndice.Text = indice.ToString();
                    TBId.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    TBDocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    TBNombreCompleto.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    TBCorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    TBClave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();  // Corrige el nombre de la columna a "Clave"
                    TBConfirmarClave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString(); // Corrige el nombre de la columna a "Clave"
                    CBRol.SelectedValue = dgvdata.Rows[indice].Cells["IdRol"].Value;
                    CBEstado.SelectedValue = dgvdata.Rows[indice].Cells["EstadoValor"].Value;

                    foreach (OpcionCombo oc in CBRol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_combo = CBRol.Items.IndexOf(oc);
                            CBRol.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                    foreach (OpcionCombo oc in CBEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = CBEstado.Items.IndexOf(oc);
                            CBEstado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(TBId.Text) != 0){
                if (MessageBox.Show("¿Desea eliminar el usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Usuario objusuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(TBId.Text),
                    };
                    bool respuesta = new CN_Usuario().Eliminar(objusuario, out mensaje);

                    if (respuesta) 
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(TBId.Text));  
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
