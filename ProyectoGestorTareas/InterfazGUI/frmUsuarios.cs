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
    public partial class frmUsuarios : Form
    {
        UsuariosClient servicioUsuario = new UsuariosClient();
        public static frmUsuarios fu;
        public frmUsuarios()
        {
            InitializeComponent();
            frmUsuarios.fu = this;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            //limpiar();
            listarUsuarios();
        }
        public void listarUsuarios()
        {
            dgUsuarios.DataSource = servicioUsuario.LISTAUSUARIOS().Tables["LISTA"];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmDatosUsuario fdu = new frmDatosUsuario();
            fdu.btnModificar.Enabled = false;
            fdu.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmDatosUsuario fdu = new frmDatosUsuario();
            if (dgUsuarios.SelectedRows.Count > 0)
            {
                fdu.txtIdUsuario.Text = dgUsuarios.CurrentRow.Cells[0].Value.ToString();
                fdu.cboRol.Text = dgUsuarios.CurrentRow.Cells[2].Value.ToString();
                fdu.txtNombres.Text = dgUsuarios.CurrentRow.Cells[3].Value.ToString();
                fdu.txtDNI.Text = dgUsuarios.CurrentRow.Cells[4].Value.ToString();
                fdu.txtCorreo.Text = dgUsuarios.CurrentRow.Cells[5].Value.ToString();
                fdu.btnGuardar.Enabled = false;
                fdu.Show();
            }
            else
            {
                frmError.confirmacionForm("Seleccione una fila");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Usuario objU = new Usuario();
            if (dgUsuarios.SelectedRows.Count > 0)
            {
                objU.idusuario = int.Parse(dgUsuarios.CurrentRow.Cells[0].Value.ToString());
                servicioUsuario.ELIMINAUSUARIO(objU);
                frmSucces.confirmacionForm("Eliminacion Correcta");
                listarUsuarios();
            }
            else
            {
                frmError.confirmacionForm("Seleccione una fila");
            }
        }
    }
}
