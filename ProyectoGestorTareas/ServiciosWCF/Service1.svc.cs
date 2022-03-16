using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServiciosWCF.Interfaces;
using ServiciosWCF.Servicios;

namespace ServiciosWCF
{

     public class Service1 : IUsuarios, IClientes, IMotorizados,IMenus,IPedidos,IAsignaciones,IHistoriales
    {
        UsuariosService us = new UsuariosService();
        ClientesService cs = new ClientesService();
        MotorizadosService ms = new MotorizadosService();
        MenusService ps = new MenusService();
        PedidosService ped = new PedidosService();
        AsignacionesService asig = new AsignacionesService();
        HistorialesService hs = new HistorialesService();

        // ENTIDAD USUARIOS
        #region Usuarios
        public void ACTUALIZAUSUARIO(Usuario objP)
        {
            us.ACTUALIZA_USUARIO(objP);
        }
        public void ELIMINAUSUARIO(Usuario objP)
        {
            us.ELIMINA_USUARIO(objP);
        }
        public DataSet LISTAROLES()
        {
            return us.LISTA_ROLES();
        }
        public DataSet LISTAUSUARIOS()
        {
            return us.LISTA_USUARIOS();
        }
        public bool Login(string user, string pass)
        {
            return us.Login_User(user,pass);
        }
        public void NUEVOUSUARIO(Usuario objP)
        {
            us.NUEVO_USUARIO(objP);
        }
        public DataTable obtenerUsuario(Usuario objP)
        {
            return us.obtener_Usuario(objP);
        }
        #endregion

        // ENTIDAD CLIENTES
        #region Clientes
        public DataSet LISTACLIENTES()
        {
            return cs.LISTA_CLIENTES();
        }
        public DataSet LISTADISTRITOS()
        {
            return cs.LISTA_DISTRITOS();
        }
        public void NUEVOCLIENTE(Cliente objP)
        {
            cs.NUEVO_CLIENTE(objP);
        }
        public void ACTUALIZACLIENTE(Cliente objP)
        {
            cs.ACTULIZA_CLIENTE(objP);
        }
        public void ELIMINACLIENTE(Cliente objP)
        {
            cs.ELIMINA_CLIENTE(objP);
        }
        public DataSet BUSCARCLIENTE(string nombre)
        {
            return cs.BUSCAR_CLIENTE(nombre);
        }
        #endregion

        //ENTIDAD PERSONAL DE ENTREGA
        #region PERSONAL DE ENTREGA
        public DataSet LISTAMOTORIZADOS()
        {
            return ms.LISTA_MOTORIZADOS();
        }
        public DataSet LISTADISPONIBLES()
        {
            return ms.LISTA_DISPONIBLES();
        }
        public void NUEVOMOTORIZADO(Motorizado objP)
        {
            ms.NUEVO_MOTORIZADO(objP);
        }
        public void ACTUALIZAMOTORIZADO(Motorizado objP)
        {
            ms.ACTULIZA_MOTORIZADO(objP);
        }
        public void ELIMINAMOTORIZADO(Motorizado objP)
        {
            ms.ELIMINA_MOTORIZADO(objP);
        }
        #endregion

        //ENTIDAD PLATOS
        #region PLATOS
        public DataSet LISTAMENUS()
        {
            return ps.LISTA_MENUS();
        }
        public void NUEVOMENU(Plato objP)
        {
            ps.NUEVO_MENU(objP);
        }
        public void ACTUALIZAMENU(Plato objP)
        {
            ps.ACTULIZA_MENU(objP);
        }
        public void ELIMINAMENU(Plato objP)
        {
            ps.ELIMINA_MENU(objP);
        }
        public DataSet BUSCARMENU(string nombre)
        {
            return ps.BUSCAR_MENU(nombre);
        }
        #endregion

        //ENTIDAD PEDIDOS
        #region PEDIDOS
        public DataSet LISTAPEDIDOS()
        {
            return ped.LISTA_PEDIDOS();
        }
        public DataSet LISTAPEDIDOSPENDIENTES()
        {
            return ped.LISTA_PEDIDOS_PENDIENTES();
        }
        public void NUEVOPEDIDO(Pedido objP)
        {
            ped.NUEVO_PEDIDO(objP);
        }
        public void ELIMINAPEDIDO(Pedido objP)
        {
            ped.ELIMINA_PEDIDO(objP);
        }
        #endregion

        //ENTIDAD ASIGNACIONES
        #region ASIGNACIONES
        public DataSet LISTADEASIGNACIONES()
        {
            return asig.LISTA_DE_ASIGNACIONES();
        }
        public DataSet LISTADEASIGNACIONESPENDIENTES()
        {
            return asig.LISTA_DE_ASIGNACIONES_PENDIENTES();
        }
        public void AGREGARASIGNACION(Asignacion objP)
        {
            asig.AGREGAR_ASIGNACION(objP);
        }
        #endregion

        //ENTIDAD HISTORIAL
        #region HISTORIAL
        public DataSet LISTAHISTORIAL()
        {
            return hs.LISTA_HISTORIAL();
        }
        public void AGREGARHISTORIAL(Historial objP)
        {
            hs.AGREGAR_HISTORIAL(objP);
        }
        #endregion
    }
}
