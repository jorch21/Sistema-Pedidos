using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazGUI
{
    public partial class frmSucces : Form
    {
        public frmSucces(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
        }

        public static void confirmacionForm(string mensaje)
        {
            frmSucces frm = new frmSucces(mensaje);
            frm.ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
