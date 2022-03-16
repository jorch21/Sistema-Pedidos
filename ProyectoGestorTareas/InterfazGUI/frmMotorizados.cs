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
    public partial class frmMotorizados : Form
    {
        MotorizadosClient servicioMotorizados = new MotorizadosClient();
        public static frmMotorizados fm;
        public frmMotorizados()
        {
            InitializeComponent();
            frmMotorizados.fm = this;
        }

        public void listarMotorizados()
        {
            dgMotorizados.DataSource = servicioMotorizados.LISTAMOTORIZADOS().Tables["LISTA"];
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMotorizados_Load(object sender, EventArgs e)
        {
            listarMotorizados();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmDatosMotorizado fdm = new frmDatosMotorizado();
            fdm.btnModificar.Enabled = false;
            fdm.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmDatosMotorizado fdm = new frmDatosMotorizado();
            if (dgMotorizados.SelectedRows.Count > 0)
            {
                fdm.txtIdMotorizado.Text = dgMotorizados.CurrentRow.Cells[0].Value.ToString();
                fdm.txtNombres.Text = dgMotorizados.CurrentRow.Cells[2].Value.ToString();
                fdm.txtDNI.Text = dgMotorizados.CurrentRow.Cells[3].Value.ToString();
                fdm.txtLicencia.Text = dgMotorizados.CurrentRow.Cells[4].Value.ToString();
                fdm.txtTipoLicencia.Text = dgMotorizados.CurrentRow.Cells[5].Value.ToString();
                fdm.txtVehiculo.Text = dgMotorizados.CurrentRow.Cells[6].Value.ToString();
                fdm.txtMatricula.Text = dgMotorizados.CurrentRow.Cells[7].Value.ToString();
                fdm.txtModelo.Text = dgMotorizados.CurrentRow.Cells[8].Value.ToString();
                fdm.txtMarca.Text = dgMotorizados.CurrentRow.Cells[9].Value.ToString();
                fdm.btnGuardar.Enabled = false;
                fdm.ShowDialog();
            }
            else
            {
                frmError.confirmacionForm("Seleccione una fila");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Motorizado objM = new Motorizado();
            if (dgMotorizados.SelectedRows.Count > 0)
            {
                objM.idmotorizado = int.Parse(dgMotorizados.CurrentRow.Cells[0].Value.ToString());
                servicioMotorizados.ELIMINAMOTORIZADO(objM);
                frmSucces.confirmacionForm("Eliminacion Correcta");
                listarMotorizados();
            }
            else
            {
                frmError.confirmacionForm("Seleccione una fila");
            }
        }
    }
}
