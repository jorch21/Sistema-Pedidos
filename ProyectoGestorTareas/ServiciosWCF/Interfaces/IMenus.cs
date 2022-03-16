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
    public interface IMenus
    {
        [OperationContract]
        DataSet LISTAMENUS();
        [OperationContract]
        void NUEVOMENU(Plato objP);
        [OperationContract]
        void ACTUALIZAMENU(Plato objP);
        [OperationContract]
        void ELIMINAMENU(Plato objP);
        [OperationContract]
        DataSet BUSCARMENU(string nombre);
    }
    [DataContract]
    public class Plato
    {
        private int _idmenu;
        private string _nombremenu;
        private float _preciomenu;

        [DataMember]
        public int idmenu { get { return _idmenu; } set { _idmenu = value; } }
        [DataMember]
        public string nombremenu { get { return _nombremenu; } set { _nombremenu = value; } }
        [DataMember]
        public float preciomenu { get { return _preciomenu; } set { _preciomenu = value; } }
    }
}
