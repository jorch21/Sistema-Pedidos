using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace ServiciosWCF.Interfaces
{
    [ServiceContract]
    public interface IPedidos
    {
        [OperationContract]
        DataSet LISTAPEDIDOS();
        [OperationContract]
        DataSet LISTAPEDIDOSPENDIENTES();
        [OperationContract]
        void NUEVOPEDIDO(Pedido objP);
        [OperationContract]
        void ELIMINAPEDIDO(Pedido objP);
    }
    [DataContract]
    public class Pedido
    {
        private int _idpedido;
        private int _idplato;
        private int _idcliente;
        private int _cantidad;
        private float _igv;
        private float _totalpedido;
        private int _idusuario;
        private float _subtotal;

        [DataMember]
        public int idpedido { get { return _idpedido; } set { _idpedido = value; } }
        [DataMember]
        public int idplato { get { return _idplato; } set { _idplato = value; } }
        [DataMember]
        public int idcliente { get { return _idcliente; } set { _idcliente = value; } }
        [DataMember]
        public int cantidad { get { return _cantidad; } set { _cantidad = value; } }
        [DataMember]
        public float igv { get { return _igv; } set { _igv = value; } }
        [DataMember]
        public float totalpedido { get { return _totalpedido; } set { _totalpedido = value; } }
        [DataMember]
        public int idusuario { get { return _idusuario; } set { _idusuario = value; } }
        [DataMember]
        public float subtotal { get { return _subtotal; } set { _subtotal = value; } }
    }
}
