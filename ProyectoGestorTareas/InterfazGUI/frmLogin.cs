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
    public partial class frmLogin : Form
    {
        UsuariosClient servicio = new UsuariosClient();
        Usuario usuario = new Usuario();
        public static string nombreUsuario;
        public static string nombreRol;
        public static int idUsuario;
        public frmLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.Silver;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.Silver;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void bntLogin_Click(object sender, EventArgs e)
        {
            iniciarSesion();
        }
        public void iniciarSesion()
        {
            if (txtUser.Text != "Usuario")
            {
                if (txtPass.Text != "Contraseña")
                {
                    DataTable dt = new DataTable();
                    usuario.correo = txtUser.Text;
                    usuario.clave = txtPass.Text;

                    dt = servicio.obtenerUsuario(usuario);
                    if (dt.Rows.Count > 0)
                    {
                        frmSucces.confirmacionForm("Bienvenido " + dt.Rows[0][3].ToString());
                        idUsuario = int.Parse(dt.Rows[0][0].ToString());
                        nombreUsuario = dt.Rows[0][3].ToString();
                        nombreRol = dt.Rows[0][2].ToString();
                        frmPrincipal principal = new frmPrincipal();
                        principal.Show();
                        principal.FormClosed += cerrarSesion;
                        this.Hide();
                    }
                    else
                    {
                        frmError.confirmacionForm("Usuario/Contraseña Errado");
                        txtPass.Text = "Contraseña";
                        txtUser.Focus();
                    }
                }
                else frmError.confirmacionForm("Ingrese Contraseña");
            }
            else frmError.confirmacionForm("Ingrese Usuario");
        }
        private void cerrarSesion(object sender, FormClosedEventArgs e)
        {
            txtPass.Text = "Contraseña";
            txtPass.UseSystemPasswordChar = false;
            txtUser.Text="Usuario";
            this.Show();
           // txtUser.Focus();
        }
        private void checkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPass.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }
    }
}
