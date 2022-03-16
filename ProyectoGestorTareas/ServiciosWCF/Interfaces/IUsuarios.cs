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
     public interface IUsuarios
    {
        [OperationContract]
        bool Login(string user, string pass);
        [OperationContract]
        DataSet LISTAUSUARIOS();
        [OperationContract]
        DataSet LISTAROLES();
        [OperationContract]
        void NUEVOUSUARIO(Usuario objP);
        [OperationContract]
        void ACTUALIZAUSUARIO(Usuario objP);
        [OperationContract]
        void ELIMINAUSUARIO(Usuario objP);
        [OperationContract]
        DataTable obtenerUsuario(Usuario objP);
    }

    [DataContract]
    public class Usuario
    {
        private int _idusuario;
        private int _idrol;
        private string _nombrerol;
        private string _nomusuario;
        private string _dniusuario;
        private string _correo;
        private string _clave;
        [DataMember]
        public int idusuario { get { return _idusuario; } set { _idusuario = value; } }
        [DataMember]
        public int idrol { get { return _idrol; } set { _idrol = value; } }
        [DataMember]
        public string nombrerol { get { return _nombrerol; } set { _nombrerol = value; } }
        [DataMember]
        public string nomusuario { get { return _nomusuario; } set { _nomusuario = value; } }
        [DataMember]
        public string dniusuario { get { return _dniusuario; } set { _dniusuario = value; } }
        [DataMember]
        public string correo { get { return _correo; } set { _correo = value; } }
        [DataMember]
        public string clave { get { return _clave; } set { _clave = value; } }
    }
}
