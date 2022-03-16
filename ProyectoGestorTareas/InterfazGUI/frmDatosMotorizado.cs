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
    public partial class frmDatosMotorizado : Form
    {
        MotorizadosClient servicioMotorizados = new MotorizadosClient();
        Motorizado objM = new Motorizado();
        public frmDatosMotorizado()
        {
            InitializeComponent();
        }

        void limpiar()
        {
            txtDNI.Clear();
            txtIdMotorizado.Clear();
            txtLicencia.Clear();
            txtMarca.Clear();
            txtMatricula.Clear();
            txtModelo.Clear();
            txtNombres.Clear();
            txtTipoLicencia.Clear();
            txtVehiculo.Clear();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text.Equals("") || txtDNI.Text.Equals("") || txtLicencia.Text.Equals("") || txtTipoLicencia.Text.Equals(""))
            {
                frmError.confirmacionForm("Hay campos vacios");
            }
            else
            {
                objM.nombremot = txtNombres.Text;
                objM.dnimot = txtDNI.Text;
                objM.nrolicencia = txtLicencia.Text;
                objM.tipolicencia = txtTipoLicencia.Text;
                objM.tipovehiculo = txtVehiculo.Text;
                objM.matricula = txtMatricula.Text;
                objM.modelo = txtModelo.Text;
                objM.marca = txtMarca.Text;
                servicioMotorizados.NUEVOMOTORIZADO(objM);
                frmSucces.confirmacionForm("Se guardo el registro");
                frmMotorizados.fm.listarMotorizados();
                limpiar();
                this.Hide();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objM.idmotorizado = int.Parse(txtIdMotorizado.Text);
            objM.nombremot = txtNombres.Text;
            objM.dnimot = txtDNI.Text;
            objM.nrolicencia = txtLicencia.Text;
            objM.tipolicencia = txtTipoLicencia.Text;
            objM.tipovehiculo = txtVehiculo.Text;
            objM.matricula = txtMatricula.Text;
            objM.modelo = txtModelo.Text;
            objM.marca = txtMarca.Text;
            servicioMotorizados.ACTUALIZAMOTORIZADO(objM);
            frmSucces.confirmacionForm("Edicion exitosa");
            frmMotorizados.fm.listarMotorizados();
            limpiar();
            this.Hide();
        }
    }
}
