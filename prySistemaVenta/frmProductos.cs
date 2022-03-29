using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySistemaVenta
{
    public partial class frmProductos : Form
    {
        clsProductos p = new clsProductos();
        int id;
        public frmProductos()
        {
            InitializeComponent();
            p.AbrirConexion();
            p.Consultar();
            dgvTableProductos.DataSource = p.Tabla;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!this.esVacio())
            {
                try
                {
                    p.nombre = txtNombre.Text;
                    p.precio = float.Parse(txtPrecio.Text);
                    p.numExistencia = int.Parse(txtNumExistencia.Text);
                    p.descripcion = txtDescripcion.Text;
                    p.Agregar();
                    p.Consultar();
                    dgvTableProductos.DataSource = p.Tabla;
                    this.LimpiarCajaTxt();
                }
                catch (Exception err)
                {

                    MessageBox.Show("Datos no validos  ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay datos ingresados   ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!this.esVacio())
            {
                try
                {
                    p.id = id;
                    p.nombre = txtNombre.Text;
                    p.precio = float.Parse(txtPrecio.Text);
                    p.numExistencia = int.Parse(txtNumExistencia.Text);
                    p.descripcion = txtDescripcion.Text;
                    p.Actualizar();
                    p.Consultar();
                    dgvTableProductos.DataSource = p.Tabla;
                    this.LimpiarCajaTxt();
                }

                catch (Exception err)
                {
                    MessageBox.Show("Datos no validos  ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
            else
            {
                MessageBox.Show("No hay datos ingresados   ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            p.id = id;
            p.Eliminar();
            p.Consultar();
            p.id = 0;
            dgvTableProductos.DataSource = p.Tabla;
        }




        private void dgvTableProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dgvTableProductos.Rows[dgvTableProductos.CurrentRow.Index].Cells[0].Value.ToString());
            txtNombre.Text = dgvTableProductos.Rows[dgvTableProductos.CurrentRow.Index].Cells[1].Value.ToString();
            txtPrecio.Text = dgvTableProductos.Rows[dgvTableProductos.CurrentRow.Index].Cells[2].Value.ToString();
            cbCategoria.Text = dgvTableProductos.Rows[dgvTableProductos.CurrentRow.Index].Cells[3].Value.ToString();
            txtNumExistencia.Text = dgvTableProductos.Rows[dgvTableProductos.CurrentRow.Index].Cells[4].Value.ToString();
            cbMarcas.Text = dgvTableProductos.Rows[dgvTableProductos.CurrentRow.Index].Cells[5].Value.ToString();
            txtDescripcion.Text = dgvTableProductos.Rows[dgvTableProductos.CurrentRow.Index].Cells[6].Value.ToString();
        }



        private void LimpiarCajaTxt()
        {

            txtNombre.Text = "";
            cbCategoria.Text = "";
            txtPrecio.Text = "";
            txtDescripcion.Text = "";
            txtNumExistencia.Text = "";
            cbMarcas.Text = "";
            id = 0;
        }

       

        private Boolean esVacio()
        {
            Boolean valor = false;
            if (txtNombre.Text.Equals(""))
            {
                valor = true;
            }
            else if (txtPrecio.Text.Equals(""))
            {
                valor = true;
            }
            else if (cbCategoria.Text.Equals(""))
            {
                valor = true;
            }
            else if (txtPrecio.Text.Equals(""))
            {
                valor = true;
            }

            return valor;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarCajaTxt();
        }


        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategoria.SelectedIndex == 0) { p.categoria = 1; }
            else if (cbCategoria.SelectedIndex == 1) { p.categoria = 2; }
            else if (cbCategoria.SelectedIndex == 2) { p.categoria = 3; }
            else if (cbCategoria.SelectedIndex == 3) { p.categoria = 4; }
            else if (cbCategoria.SelectedIndex == 4) { p.categoria = 5; }
            else if (cbCategoria.SelectedIndex == 5) { p.categoria = 6; }
            else if (cbCategoria.SelectedIndex == 6) { p.categoria = 7; }
            else if (cbCategoria.SelectedIndex == 7) { p.categoria = 8; }
            else if (cbCategoria.SelectedIndex == 8) { p.categoria = 9; }
        }


        private void cbMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMarcas.SelectedIndex == 0) { p.marca = 1; }
            else if (cbMarcas.SelectedIndex == 1) { p.marca = 2; }
            else if (cbMarcas.SelectedIndex == 2) { p.marca = 3; }
            else if (cbMarcas.SelectedIndex == 3) { p.marca = 4; }
            else if (cbMarcas.SelectedIndex == 4) { p.marca = 5; }
            else if (cbMarcas.SelectedIndex == 5) { p.marca = 6; }
            else if (cbMarcas.SelectedIndex == 6) { p.marca = 7; }
            else if (cbMarcas.SelectedIndex == 7) { p.marca = 8; }
            else if (cbMarcas.SelectedIndex == 8) { p.marca = 9; }
            else if (cbMarcas.SelectedIndex == 9) { p.marca = 10; }
            else if (cbMarcas.SelectedIndex == 10) { p.marca = 11; }
            else if (cbMarcas.SelectedIndex == 11) { p.marca = 12; }
            else if (cbMarcas.SelectedIndex == 12) { p.marca = 13; }
            else if (cbMarcas.SelectedIndex == 13) { p.marca = 14; }
            else if (cbMarcas.SelectedIndex == 14) { p.marca = 15; }
            else if (cbMarcas.SelectedIndex == 15) { p.marca = 16; }
            else if (cbMarcas.SelectedIndex == 16) { p.marca = 17; }
        }

        

        private void txtBuscarProd_Enter(object sender, EventArgs e)
        {
            if (txtBuscarProd.Text == "Nombre del producto")
            {
                txtBuscarProd.Text = "";
                txtBuscarProd.ForeColor = Color.Black;
            }
        }

        private void txtBuscarProd_Leave(object sender, EventArgs e)
        {
            if (txtBuscarProd.Text == "")
            {
                txtBuscarProd.Text = "Nombre del producto";
                txtBuscarProd.ForeColor = Color.Gray;
            }

        }

        private void txtBuscarProd_KeyUp(object sender, KeyEventArgs e)
        {
            p.nombre = txtBuscarProd.Text;
            p.Buscar();
            dgvTableProductos.DataSource = p.Tabla;
        }
    }
}