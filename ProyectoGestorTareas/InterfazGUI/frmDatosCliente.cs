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
    public partial class frmDatosCliente : Form
    {
        ClientesClient servicioClientes = new ClientesClient();
        Cliente objC = new Cliente();
        public frmDatosCliente()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDatosCliente_Load(object sender, EventArgs e)
        {
            cboDistritos.DataSource = servicioClientes.LISTADISTRITOS().Tables["DISTRITO"];
            cboDistritos.DisplayMember = "NOM_DIS";
            cboDistritos.ValueMember = "COD_DIS";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals("") || txtDNI.Text.Equals("") || txtCorreo.Text.Equals("") || txtTelefono.Text.Equals(""))
            {
                frmError.confirmacionForm("Hay campos vacios");
            }
            else
            {
                objC.nomcliente = txtNombre.Text;
                objC.dnicliente = txtDNI.Text;
                objC.telefono = txtTelefono.Text;
                objC.correo = txtCorreo.Text;
                objC.direccion = txtDireccion.Text;
                objC.iddistrito = int.Parse(cboDistritos.SelectedValue.ToString());
                servicioClientes.NUEVOCLIENTE(objC);
                frmSucces.confirmacionForm("Se guardo el registro");
                frmClientes.fc.listarClientes();
                limpiar();
                this.Hide();
            }
        }

        void limpiar()
        {
            txtNombre.Clear();
            txtDNI.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            cboDistritos.SelectedIndex = -1;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objC.idcliente = int.Parse(txtIdCliente.Text);
            objC.nomcliente = txtNombre.Text;
            objC.dnicliente = txtDNI.Text;
            objC.telefono = txtTelefono.Text;
            objC.correo = txtCorreo.Text;
            objC.direccion = txtDireccion.Text;
            objC.iddistrito = int.Parse(cboDistritos.SelectedValue.ToString());
            servicioClientes.ACTUALIZACLIENTE(objC);
            frmSucces.confirmacionForm("Edición Correcta");
            frmClientes.fc.listarClientes();
            limpiar();
            this.Hide();
        }
    }
}
