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
    public partial class frmPedidos : Form
    {
        PedidosClient servicioPedidos = new PedidosClient();
        Pedido objPe = new Pedido();
        public static frmPedidos fp;
        public frmPedidos()
        {
            InitializeComponent();
            frmPedidos.fp = this;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmBuscarMenu fbm = new frmBuscarMenu();
            AddOwnedForm(fbm);
            fbm.ShowDialog();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmBuscarCliente fbc = new frmBuscarCliente();
            AddOwnedForm(fbc);
            fbc.ShowDialog();
        }
        public void listarPedidos()
        {
            dgPedidos.DataSource = servicioPedidos.LISTAPEDIDOS().Tables["LISTA"];
        }
        void limpiar()
        {
            txtCantidad.Clear();
            txtIdCliente.Clear();
            txtIdMenu.Clear();
            txtNombreCliente.Clear();
            txtNombreMenu.Clear();
            txtPrecioMenu.Clear();
        }
        private void frmPedidos_Load(object sender, EventArgs e)
        {
            listarPedidos();
            txtIdUsuario.Text = frmLogin.idUsuario.ToString();
            txtNombreUsuario.Text = frmLogin.nombreUsuario;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtIdMenu.Text.Equals("")||txtIdCliente.Text.Equals(""))
            {
                frmError.confirmacionForm("Complete campos!");
            }
            else
            {
                if (txtCantidad.Text.Equals(""))
                {
                    frmError.confirmacionForm("Ingrese Cantidad");
                    txtCantidad.Focus();
                }
                else
                {
                    int cantped = int.Parse(txtCantidad.Text);
                    float preciomenu = float.Parse(txtPrecioMenu.Text);
                    float subtotalped = cantped * preciomenu;
                    float igvped = (18 * subtotalped) / 100;
                    float totalped = subtotalped + igvped;
                    objPe.idplato = int.Parse(txtIdMenu.Text);
                    objPe.idcliente = int.Parse(txtIdCliente.Text);
                    objPe.cantidad = int.Parse(txtCantidad.Text);
                    objPe.igv = igvped;
                    objPe.totalpedido = totalped;
                    objPe.idusuario = int.Parse(txtIdUsuario.Text);
                    objPe.subtotal = subtotalped;
                    servicioPedidos.NUEVOPEDIDO(objPe);
                    frmSucces.confirmacionForm("Se registro Pedido");
                    limpiar();
                    txtCantidad.Focus();
                    listarPedidos();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgPedidos.SelectedRows.Count > 0)
            {
                objPe.idpedido = int.Parse(dgPedidos.CurrentRow.Cells[0].Value.ToString());
                servicioPedidos.ELIMINAPEDIDO(objPe);
                frmSucces.confirmacionForm("Pedido Eliminado");
                listarPedidos();
            }
            else
            {
                frmError.confirmacionForm("Seleccione una fila");
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            frmAsignaciones fa = new frmAsignaciones();
            fa.ShowDialog();
        }

        private void btnProgreso_Click(object sender, EventArgs e)
        {
            frmHistorial fh = new frmHistorial();
            fh.ShowDialog();
        }
    }
}
