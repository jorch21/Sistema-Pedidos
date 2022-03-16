using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using InterfazGUI.ServiceReference1;

namespace InterfazGUI
{
    public partial class frmPrincipal : Form
    {
        //UsuariosClient servicioUsuarios = new UsuariosClient();
        Usuario usu = new Usuario();
        public frmPrincipal()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (panelLateral.Width == 200)
            {
                panelLateral.Width = 60;
            }
            else
            {
                panelLateral.Width = 200;
            }
        }
        private void datosUsuario()
        {
            if (frmLogin.nombreRol.Equals("ADMINISTRADOR"))
            {
                btnPedidos.Enabled = true;
                btnMenu.Enabled = true;
                btnClientes.Enabled = true;
                btnMotorizado.Enabled = true;
                btnUsuarios.Enabled = true;
                btnReportes.Enabled = true;

                lblUsuario.Text = frmLogin.nombreUsuario;
                lblRol.Text = frmLogin.nombreRol;
            }
            else if (frmLogin.nombreRol.Equals("EMPLEADO"))
            {
                btnPedidos.Enabled = true;
                btnMenu.Enabled = true;
                btnClientes.Enabled = true;
                btnMotorizado.Visible = false;
                btnUsuarios.Visible = false;
                btnReportes.Visible = false;

                lblUsuario.Text = frmLogin.nombreUsuario;
                lblRol.Text = frmLogin.nombreRol;
            }
        }
        private void iconcerrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new DialogResult();
            frmInformacion form = new frmInformacion();
            resultado = form.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        int LX, LY;

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1055,570);
            this.Location = new Point(LX, LY);
            iconrestaurar.Visible = false;
            iconmaximizar.Visible = true;
        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelFrontal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            LX = this.Location.X;
            LY = this.Location.Y;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.panelCuerpo.Controls.Count > 0)
                this.panelCuerpo.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelCuerpo.Controls.Add(fh);
            this.panelCuerpo.Tag = fh;
            fh.Show();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
                DialogResult resultado = new DialogResult();
                frmInformacion form = new frmInformacion();
                resultado = form.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    this.Close();
                }
        }

        private void btnMenus_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmMenus());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmClientes());
        }

        private void btnMotorizado_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmMotorizados());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmUsuarios());
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            datosUsuario();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmConsultas());
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmPedidos());
        }
        
    }
}
