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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductos VentanaProdcuto = new frmProductos();
            VentanaProdcuto.MdiParent = this;
            VentanaProdcuto.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
