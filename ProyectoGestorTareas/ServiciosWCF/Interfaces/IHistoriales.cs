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
    public interface IHistoriales
    {
        [OperationContract]
        DataSet LISTAHISTORIAL();
        [OperationContract]
        void AGREGARHISTORIAL(Historial objP);
    }
    [DataContract]
    public class Historial
    {
        private int _idpedido;
        private int _idmotorizado;
        private string _nota;
        [DataMember]
        public int idpedido { get { return _idpedido; } set { _idpedido = value; } }
        [DataMember]
        public int idmotorizado { get { return _idmotorizado; } set { _idmotorizado = value; } }
        [DataMember]
        public string nota { get { return _nota; } set { _nota = value; } }
    }
}
