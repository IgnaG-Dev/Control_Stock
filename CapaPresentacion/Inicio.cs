using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modal;
using CapaPresentacion.Modales;
using FontAwesome.Sharp;
using System.Data.SqlClient;


namespace CapaPresentacion
{
    public partial class Inicio : Form
    {

        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;


        public Inicio(Usuario objusuario = null)
        {
            if (objusuario == null)
                usuarioActual = new Usuario() { NombreCompleto = "ADMIN PREDEFINIDO", IdUsuario = 1 };
            else
                usuarioActual = objusuario;

            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new CN_Permiso().listar(usuarioActual.IdUsuario);

            foreach (IconMenuItem iconmenu in menu.Items)
            {

                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);

                if (encontrado == false)
                {
                    iconmenu.Visible = false;
                }

            }



            lblusuario.Text = usuarioActual.NombreCompleto;
        }


        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {

            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.SteelBlue;

            contenedor.Controls.Add(formulario);
            formulario.Show();


        }


        private void menuusuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuarios());
        }

        private void submenucategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmCategoria());
        }

        private void submenuproducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmProducto());
        }

        private void submenuregistrarventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmVentas(usuarioActual));
        }

        private void submenuverdetalleventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmDetalleVenta());
        }

        private void submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new frmCompras(usuarioActual));
        }

        private void submenutverdetallecompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new frmDetalleCompra());
        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes());
        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProveedores());
        }



        private void submenunegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmNegocio());
        }

        private void submenureportecompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menureportes, new frmReporteCompras());
        }

        private void submenureporteventas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menureportes, new frmReporteVentas());
        }

        private void menuacercade_Click(object sender, EventArgs e)
        {
            mdAcercade md = new mdAcercade();
            md.ShowDialog();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            // Confirmación del usuario antes de iniciar el backup
            var resultado = MessageBox.Show("¿Está seguro de que desea crear una copia de seguridad de la base de datos?",
                                            "Confirmar Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // Define la cadena de conexión a tu base de datos
                    string connectionString = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;

                    // Obtén la fecha actual en el formato deseado (AAA-MM-DD)
                    string fechaHoy = DateTime.Now.ToString("yyyy-MM-dd");

                    // Define la ruta de backup con la fecha actual en el nombre del archivo
                    string rutaBackup = $@"C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup\DBVENTAS_{fechaHoy}.bak";

                    // Define la consulta de respaldo
                    string consulta = $"BACKUP DATABASE [DBVENTAS] TO DISK = N'{rutaBackup}' " +
                                      "WITH NOFORMAT, NOINIT, NAME = N'DBVENTAS-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10;";

                    // Ejecuta la consulta en SQL Server
                    using (SqlConnection conexion = new SqlConnection(connectionString))
                    {
                        conexion.Open();
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            comando.ExecuteNonQuery();
                        }
                    }

                    // Mensaje de éxito con la ubicación del archivo
                    MessageBox.Show($"Backup realizado con éxito. El archivo se guardó en: {rutaBackup}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    MessageBox.Show("Error al realizar el backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Mensaje si el usuario decide cancelar el backup
                MessageBox.Show("Operación de backup cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuinformes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmInformes());
        }
    }
}