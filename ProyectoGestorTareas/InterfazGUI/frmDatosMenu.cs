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
    public partial class frmDatosMenu : Form
    {
        MenusClient servicioMenus = new MenusClient();
        Plato objM = new Plato();
        public frmDatosMenu()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDatosCliente_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text.Equals("") || txtPrecio.Text.Equals(""))
            {
                frmError.confirmacionForm("Hay campos vacios");
            }
            else
            {
                objM.nombremenu = txtNombre.Text;
                objM.preciomenu = float.Parse(txtPrecio.Text);
                servicioMenus.NUEVOMENU(objM);
                frmSucces.confirmacionForm("Se guardo el registro");
                frmMenus.fmn.listaMenus();
                limpiar();
                this.Hide();
            }
        }

        void limpiar()
        {
            txtIdMenu.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objM.idmenu = int.Parse(txtIdMenu.Text);
            objM.nombremenu = txtNombre.Text;
            objM.preciomenu = float.Parse(txtPrecio.Text);
            servicioMenus.ACTUALIZAMENU(objM);
            frmSucces.confirmacionForm("Edicion Correcta");
            frmMenus.fmn.listaMenus();
            limpiar();
            this.Hide();
        }
    }
}
