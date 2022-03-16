using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ServiciosWCF.Interfaces;

namespace ServiciosWCF.Servicios
{
    public class HistorialesService
    {
        SqlConnection cn = new SqlConnection("server=.;database=SistemaPedidos;integrated security=SSPI");
        public DataSet LISTA_HISTORIAL()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTARHISTORIAL", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "LISTA");
            return ds;
        }
        public void AGREGAR_HISTORIAL(Historial objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_INSERTARHISTORIAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IDE_PED", SqlDbType.Int).Value = objP.idpedido;
            cmd.Parameters.Add("@NOTA_PED", SqlDbType.VarChar).Value = objP.nota;
            cmd.Parameters.Add("@IDE_MOT", SqlDbType.Int).Value = objP.idmotorizado;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var mensaje = "Error mensaje: " + e.Message;
            }
        }
    }
}