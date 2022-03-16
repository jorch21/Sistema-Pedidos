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
    public interface IAsignaciones
    {
        [OperationContract]
        DataSet LISTADEASIGNACIONES();
        [OperationContract]
        DataSet LISTADEASIGNACIONESPENDIENTES();
        [OperationContract]
        void AGREGARASIGNACION(Asignacion objP);
    }
    [DataContract]
    public class Asignacion
    {
        private int _idpedido;
        private int _idmotorizado;
        [DataMember]
        public int idpedido { get { return _idpedido; } set { _idpedido = value; } }
        [DataMember]
        public int idmotorizado { get { return _idmotorizado; } set { _idmotorizado = value; } }
    }
}
