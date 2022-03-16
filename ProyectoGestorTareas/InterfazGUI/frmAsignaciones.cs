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
    public partial class frmAsignaciones : Form
    {
        PedidosClient servicioPedidos = new PedidosClient();
        MotorizadosClient servicioMotorizados = new MotorizadosClient();
        AsignacionesClient servicioAsignaciones = new AsignacionesClient();
        Asignacion objA = new Asignacion();
        public frmAsignaciones()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void listarMotorizados()
        {
            cboMotorizados.DataSource = servicioMotorizados.LISTADISPONIBLES().Tables["DISPONIBLE"];
            cboMotorizados.DisplayMember = "NOMBRES";
            cboMotorizados.ValueMember = "CODIGO";
        }
        public void listarPedidosPendientes()
        {
            dgPedidosPend.DataSource = servicioPedidos.LISTAPEDIDOSPENDIENTES().Tables["LISTA"];
        }
        public void limpiarTabla()
        {
            dgAsignaciones.Rows.Clear();
        }
        private void frmBuscarMenu_Load(object sender, EventArgs e)
        {
            listarPedidosPendientes();
            listarMotorizados();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgPedidosPend.SelectedRows.Count > 0)
            {
                dgAsignaciones.Rows.Add(new string[]
                {
                    Convert.ToString(dgPedidosPend[0,dgPedidosPend.CurrentRow.Index].Value),
                    Convert.ToString(dgPedidosPend[1,dgPedidosPend.CurrentRow.Index].Value),
                    Convert.ToString(dgPedidosPend[5,dgPedidosPend.CurrentRow.Index].Value),
                    Convert.ToString(dgPedidosPend[7,dgPedidosPend.CurrentRow.Index].Value),
                    Convert.ToString(dgPedidosPend[10,dgPedidosPend.CurrentRow.Index].Value)
                });
            }
            else
            {
                frmError.confirmacionForm("Seleccione una fila");
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (dgAsignaciones.Rows.Count != 0)
            {
                objA.idpedido = int.Parse(dgAsignaciones.CurrentRow.Cells[0].Value.ToString());
                objA.idmotorizado = int.Parse(cboMotorizados.SelectedValue.ToString());
                servicioAsignaciones.AGREGARASIGNACION(objA);
                frmSucces.confirmacionForm("Asignacion correcta");
                limpiarTabla();
                frmPedidos.fp.listarPedidos();
                listarMotorizados();
                listarPedidosPendientes();
            }
            else
            {
                frmError.confirmacionForm("La tabla esta vacia");
            }
        }
    }
}
