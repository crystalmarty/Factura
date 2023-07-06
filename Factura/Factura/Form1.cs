using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factura
{
    public partial class Form1 : Form

    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cod;
            string nom;
            float precio;

            cod = cmbProducto.SelectedIndex;
            nom = cmbProducto.SelectedItem.ToString();
            precio = cmbProducto.SelectedIndex;

            switch (cod)
            {
                case 0: lblCódigo.Text = "0011"; break;
                case 1: lblCódigo.Text = "0022"; break;
                default: lblCódigo.Text = "0033"; break;
            }
            switch (nom)
            {
                case "Tostada":
                    lblNombre.Text = "Tostada";
                    break;
                case "Sabrita":
                    lblNombre.Text = "Sabrita";
                    break;
                default:
                    lblNombre.Text = "Jugo";
                    break;
            }

            switch (precio)
            {
                case 0: lblPrecio.Text = "150"; break;
                case 1: lblPrecio.Text = "120"; break;
                default: lblPrecio.Text = "140"; break;
            }

        }
        public void obtenerTotal()
        {
            float costot = 0;
            int contador = 0;

            contador = dgvLista.RowCount;

            for (int i = 0; i < contador; i++)
            {
                costot += float.Parse(dgvLista.Rows[i].Cells[4].Value.ToString());
            }

            lblTotalapagar.Text = costot.ToString();
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            float efectivo = (float.Parse(txtEfectivo.Text));
            float totalAPagar = float.Parse(lblTotalapagar.Text);
            try
            {
                lblDevolución.Text = totalAPagar.ToString();
            }
            catch { }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow file = new DataGridViewRow();
            file.CreateCells(dgvLista);
            float precio = (float.Parse(lblPrecio.Text));
            precio = precio * float.Parse(txtCantidad.Text);

            file.Cells[0].Value = lblCódigo.Text;
            file.Cells[1].Value = lblNombre.Text;
            file.Cells[2].Value = lblPrecio.Text;
            file.Cells[3].Value = txtCantidad.Text;
            file.Cells[4].Value = precio;

            dgvLista.Rows.Add(file);

            lblCódigo.Text = lblNombre.Text = lblPrecio.Text = txtCantidad.Text = "";
            obtenerTotal();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult rppta = MessageBox.Show("¿Desea eliminar producto?",
                    "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rppta == DialogResult.Yes)
                {
                    dgvLista.Rows.Remove(dgvLista.CurrentRow);
                }
            }
            catch { }
            obtenerTotal();
        }
    }
}

