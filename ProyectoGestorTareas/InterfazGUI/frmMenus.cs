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
    public partial class frmMenus : Form
    {
        MenusClient servicioMenus = new MenusClient();
        public static frmMenus fmn;
        public frmMenus()
        {
            InitializeComponent();
            frmMenus.fmn = this;
        }

        public void listaMenus()
        {
            dgMenus.DataSource = servicioMenus.LISTAMENUS().Tables["LISTA"];
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMenus_Load(object sender, EventArgs e)
        {
            listaMenus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmDatosMenu fdp = new frmDatosMenu();
            fdp.btnModificar.Enabled = false;
            fdp.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmDatosMenu fdp = new frmDatosMenu();
            if (dgMenus.SelectedRows.Count > 0)
            {
                fdp.txtIdMenu.Text = dgMenus.CurrentRow.Cells[0].Value.ToString();
                fdp.txtNombre.Text = dgMenus.CurrentRow.Cells[2].Value.ToString();
                fdp.txtPrecio.Text = dgMenus.CurrentRow.Cells[3].Value.ToString();
                fdp.btnGuardar.Enabled = false;
                fdp.ShowDialog();
            }
            else
            {
                frmError.confirmacionForm("Seleccione una fila");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Plato objM = new Plato();
            if (dgMenus.SelectedRows.Count > 0)
            {
                objM.idmenu = int.Parse(dgMenus.CurrentRow.Cells[0].Value.ToString());
                servicioMenus.ELIMINAMENU(objM);
                frmSucces.confirmacionForm("Eliminacion Correcta");
                listaMenus();
            }
            else
            {
                frmError.confirmacionForm("Seleccione una fila");
            }
        }
    }
}
