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
    public interface IClientes
    {
        [OperationContract]
        DataSet LISTACLIENTES();
        [OperationContract]
        DataSet LISTADISTRITOS();
        [OperationContract]
        void NUEVOCLIENTE(Cliente objP);
        [OperationContract]
        void ACTUALIZACLIENTE(Cliente objP);
        [OperationContract]
        void ELIMINACLIENTE(Cliente objP);
        [OperationContract]
        DataSet BUSCARCLIENTE(string nombre);
    }
    [DataContract]
    public class Cliente
    {
        private int _idcliente;
        private string _nomcliente;
        private string _dnicliente;
        private string _telefono;
        private string _correo;
        private string _direccion;
        private int _iddistrito;

        [DataMember]
        public int idcliente { get { return _idcliente; } set { _idcliente = value; } }
        [DataMember]
        public string nomcliente { get { return _nomcliente; } set { _nomcliente = value; } }
        [DataMember]
        public string dnicliente { get { return _dnicliente; } set { _dnicliente = value; } }
        [DataMember]
        public string telefono { get { return _telefono; } set { _telefono = value; } }
        [DataMember]
        public string correo { get { return _correo; } set { _correo = value; } }
        [DataMember]
        public string direccion { get { return _direccion; } set { _direccion = value; } }
        [DataMember]
        public int iddistrito { get { return _iddistrito; } set { _iddistrito = value; } }
    }
}
