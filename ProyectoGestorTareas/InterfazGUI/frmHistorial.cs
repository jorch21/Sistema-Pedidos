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
    public partial class frmHistorial : Form
    {
        HistorialesClient servicioHistorial = new HistorialesClient();
        AsignacionesClient servicioAsignaciones = new AsignacionesClient();
        Historial objH = new Historial();
        public frmHistorial()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void listarAsingacionesPendientes()
        {
            dgAsignPend.DataSource = servicioAsignaciones.LISTADEASIGNACIONESPENDIENTES().Tables["ASIGNACION"];
        }
        public void limpiar()
        {
            txtIdPedido.Clear();
            txtIdMotorizado.Clear();
            txtNota.Clear();
        }
        private void frmBuscarMenu_Load(object sender, EventArgs e)
        {
            listarAsingacionesPendientes();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgAsignPend.SelectedRows.Count > 0)
            {
                txtIdPedido.Text = dgAsignPend.CurrentRow.Cells[0].Value.ToString();
                txtIdMotorizado.Text = dgAsignPend.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                frmError.confirmacionForm("Seleccione una fila");
            }
        }

        private void btnCerrarPedido_Click(object sender, EventArgs e)
        {
            if (txtNota.Text.Equals("") || txtIdPedido.Text.Equals("") || txtIdMotorizado.Text.Equals(""))
            {
                frmError.confirmacionForm("Hay campos vacios");
            }
            else
            {
                objH.idpedido =int.Parse(txtIdPedido.Text);
                objH.nota = txtNota.Text;
                objH.idmotorizado = int.Parse(txtIdMotorizado.Text);
                servicioHistorial.AGREGARHISTORIAL(objH);
                frmSucces.confirmacionForm("Pedido Cerrado");
                frmPedidos.fp.listarPedidos();
                limpiar();
                listarAsingacionesPendientes();
            }
        }
    }
}
