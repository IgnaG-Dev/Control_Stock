using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            TBDni.Text = "";
            TBClave.Text = "";

            this.Show();
        }

        private void BIngresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CN_Usuario().listar();

            Usuario oUsuario = new CN_Usuario().listar().Where(u => u.Documento == TBDni.Text && u.Clave == TBClave.Text).FirstOrDefault();

            if (oUsuario != null)
            {
                Inicio form = new Inicio(oUsuario);

                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("No se encontro el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
    }
}
