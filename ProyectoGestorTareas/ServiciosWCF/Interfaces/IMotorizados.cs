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
    public interface IMotorizados
    {
        [OperationContract]
        DataSet LISTAMOTORIZADOS();
        [OperationContract]
        void NUEVOMOTORIZADO(Motorizado objP);
        [OperationContract]
        void ACTUALIZAMOTORIZADO(Motorizado objP);
        [OperationContract]
        void ELIMINAMOTORIZADO(Motorizado objP);
        [OperationContract]
        DataSet LISTADISPONIBLES();
    }
    [DataContract]
    public class Motorizado
    {
        private int _idmotorizado;
        private string _nombremot;
        private string _dnimot;
        private string _nrolicencia;
        private string _tipolicencia;
        private string _tipovehiculo;
        private string _matricula;
        private string _modelo;
        private string _marca;

        [DataMember]
        public int idmotorizado { get { return _idmotorizado; } set { _idmotorizado = value; } }
        [DataMember]
        public string nombremot { get { return _nombremot; } set { _nombremot = value; } }
        [DataMember]
        public string dnimot { get { return _dnimot; } set { _dnimot = value; } }
        [DataMember]
        public string nrolicencia { get { return _nrolicencia; } set { _nrolicencia = value; } }
        [DataMember]
        public string tipolicencia { get { return _tipolicencia; } set { _tipolicencia = value; } }
        [DataMember]
        public string tipovehiculo { get { return _tipovehiculo; } set { _tipovehiculo = value; } }
        [DataMember]
        public string matricula { get { return _matricula; } set { _matricula = value; } }
        [DataMember]
        public string modelo { get { return _modelo; } set { _modelo = value; } }
        [DataMember]
        public string marca { get { return _marca; } set { _marca = value; } }
    }
}
