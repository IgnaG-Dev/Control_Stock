using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
        }

        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            // Validación de que el documento del cliente no esté vacío
            if (string.IsNullOrWhiteSpace(txtdocumentocliente.Text))
            {
                MessageBox.Show("Por favor ingrese el número de documento del cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulación de cliente encontrado (puedes añadir la lógica de búsqueda real)
            txtnombrecliente.Text = "Cliente Ejemplo"; // Cliente ficticio
            MessageBox.Show("Cliente encontrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            // Validación de que el código de producto no esté vacío
            if (string.IsNullOrWhiteSpace(txtcodproducto.Text))
            {
                MessageBox.Show("Por favor ingrese el código del producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulación de búsqueda del producto (puedes añadir la lógica de búsqueda real)
            txtproducto.Text = "Producto Ejemplo";  // Producto ficticio para presentación
            txtprecio.Text = "100";  // Precio ficticio
            txtstock.Text = "50";  // Stock ficticio
        }

        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            // Validación para asegurarse de que haya datos de producto y cantidad válida
            if (string.IsNullOrWhiteSpace(txtproducto.Text))
            {
                MessageBox.Show("Seleccione un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtcantidad.Value <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Agregar datos al DataGridView (ejemplo)
            dgvdata.Rows.Add(txtidproducto.Text, txtproducto.Text, txtprecio.Text, txtcantidad.Value, Convert.ToDecimal(txtprecio.Text) * txtcantidad.Value);
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                total += Convert.ToDecimal(row.Cells["SubTotal"].Value);
            }
            txttotalpagar.Text = total.ToString();
        }

        private void btncrearventa_Click(object sender, EventArgs e)
        {
            // Validación de pago
            if (string.IsNullOrWhiteSpace(txtpagocon.Text))
            {
                MessageBox.Show("Ingrese el monto con el que va a pagar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToDecimal(txtpagocon.Text) < Convert.ToDecimal(txttotalpagar.Text))
            {
                MessageBox.Show("El pago no puede ser menor que el total a pagar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calcular cambio
            decimal pagoCon = Convert.ToDecimal(txtpagocon.Text);
            decimal totalPagar = Convert.ToDecimal(txttotalpagar.Text);
            txtcambio.Text = (pagoCon - totalPagar).ToString();

            // Simulación de venta exitosa
            MessageBox.Show("Venta creada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
