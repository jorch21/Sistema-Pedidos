using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfazGUI.ServiceReference1;

namespace InterfazGUI
{
    public partial class frmBuscarMenu : Form
    {
        MenusClient servicioMenu = new MenusClient();
        public frmBuscarMenu()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void listarPlatos()
        {
            dgListaMenus.DataSource = servicioMenu.LISTAMENUS().Tables["LISTA"];
        }

        private void frmBuscarMenu_Load(object sender, EventArgs e)
        {
            listarPlatos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgListaMenus.DataSource = servicioMenu.BUSCARMENU(txtBuscar.Text).Tables["NOMBRE"];
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            frmPedidos fp = Owner as frmPedidos;
            if (dgListaMenus.SelectedRows.Count > 0)
            {
                fp.txtIdMenu.Text = dgListaMenus.CurrentRow.Cells[0].Value.ToString();
                fp.txtNombreMenu.Text = dgListaMenus.CurrentRow.Cells[2].Value.ToString();
                fp.txtPrecioMenu.Text = dgListaMenus.CurrentRow.Cells[3].Value.ToString();
                this.Close();
            }
            else
            {
                frmError.confirmacionForm("Seleccione una fila");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
