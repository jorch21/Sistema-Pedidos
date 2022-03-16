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
    public partial class frmClientes : Form
    {
        ClientesClient servicioClientes = new ClientesClient();
        public static frmClientes fc;
        public frmClientes()
        {
            InitializeComponent();
            frmClientes.fc = this;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmDatosCliente fdc = new frmDatosCliente();
            fdc.btnModificar.Enabled = false;
            fdc.ShowDialog();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            listarClientes();
        }

        public void listarClientes()
        {
            dgClientes.DataSource = servicioClientes.LISTACLIENTES().Tables["LISTA"];
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmDatosCliente fdc = new frmDatosCliente();
            if (dgClientes.SelectedRows.Count > 0)
            {
                fdc.txtIdCliente.Text = dgClientes.CurrentRow.Cells[0].Value.ToString();
                fdc.txtNombre.Text = dgClientes.CurrentRow.Cells[2].Value.ToString();
                fdc.txtDNI.Text = dgClientes.CurrentRow.Cells[3].Value.ToString();
                fdc.txtTelefono.Text = dgClientes.CurrentRow.Cells[4].Value.ToString();
                fdc.txtCorreo.Text = dgClientes.CurrentRow.Cells[5].Value.ToString();
                fdc.txtDireccion.Text = dgClientes.CurrentRow.Cells[7].Value.ToString();
                fdc.cboDistritos.Text = dgClientes.CurrentRow.Cells[8].Value.ToString();
                fdc.btnGuardar.Enabled = false;
                fdc.ShowDialog();
            }
            else
            {
                frmError.confirmacionForm("Seleccione una fila");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente objC = new Cliente();
            if (dgClientes.SelectedRows.Count > 0)
            {
                objC.idcliente = int.Parse(dgClientes.CurrentRow.Cells[0].Value.ToString());
                servicioClientes.ELIMINACLIENTE(objC);
                frmSucces.confirmacionForm("Eliminacion Correcta");
                listarClientes();
            }
            else
            {
                frmError.confirmacionForm("Seleccione una fila");
            }
        }
    }
}
