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
    public partial class frmBuscarCliente : Form
    {
        ClientesClient servicioCliente = new ClientesClient();
        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void listarClientes()
        {
            dgListaClientes.DataSource = servicioCliente.LISTACLIENTES().Tables["LISTA"];
        }

        private void frmBuscarMenu_Load(object sender, EventArgs e)
        {
            listarClientes();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgListaClientes.DataSource = servicioCliente.BUSCARCLIENTE(txtBuscar.Text).Tables["NOMBRE"];
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            frmPedidos fp = Owner as frmPedidos;
            if (dgListaClientes.SelectedRows.Count > 0)
            {
                fp.txtIdCliente.Text = dgListaClientes.CurrentRow.Cells[0].Value.ToString();
                fp.txtNombreCliente.Text = dgListaClientes.CurrentRow.Cells[2].Value.ToString();
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
