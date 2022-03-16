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
    public partial class frmDatosUsuario : Form
    {
        UsuariosClient servicioUsuarios = new UsuariosClient();
        //frmUsuarios fu = new frmUsuarios();
        Usuario objU = new Usuario();
        public frmDatosUsuario()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text.Equals("") || txtDNI.Text.Equals("") || txtCorreo.Text.Equals(""))
            {
                frmError.confirmacionForm("Hay campos vacios");
            }
            else
            {
                objU.idrol = int.Parse(cboRol.SelectedValue.ToString());
                objU.nomusuario = txtNombres.Text;
                objU.dniusuario = txtDNI.Text;
                objU.correo = txtCorreo.Text;
                servicioUsuarios.NUEVOUSUARIO(objU);
                frmSucces.confirmacionForm("Usuario registrado");
                frmUsuarios.fu.listarUsuarios();
                limpiar();
                this.Hide();
            }
                    
        }

        private void frmDatosUsuario_Load(object sender, EventArgs e)
        {
            cboRol.DataSource = servicioUsuarios.LISTAROLES().Tables["ROL"];
            cboRol.DisplayMember = "NOM_ROL";
            cboRol.ValueMember = "COD_ROL";
        }
        void limpiar()
        {
            cboRol.SelectedIndex = -1;
            txtCorreo.Clear();
            txtDNI.Clear();
            txtNombres.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objU.idusuario = int.Parse(txtIdUsuario.Text);
            objU.idrol = int.Parse(cboRol.SelectedValue.ToString());
            objU.nomusuario = txtNombres.Text;
            objU.dniusuario = txtDNI.Text;
            objU.correo = txtCorreo.Text;
            servicioUsuarios.ACTUALIZAUSUARIO(objU);
            frmSucces.confirmacionForm("Edición Correcta");
            frmUsuarios.fu.listarUsuarios();
            limpiar();
            this.Hide();
        }
    }
}
