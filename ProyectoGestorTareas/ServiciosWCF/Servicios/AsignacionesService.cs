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
    public class AsignacionesService
    {
        SqlConnection cn = new SqlConnection("server=.;database=SistemaPedidos;integrated security=SSPI");
        public DataSet LISTA_DE_ASIGNACIONES()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTARASIGNACIONES", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "LISTA");
            return ds;
        }
        public DataSet LISTA_DE_ASIGNACIONES_PENDIENTES()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTARASIGNACIONESPENDIENTES", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "ASIGNACION");
            return ds;
        }
        public void AGREGAR_ASIGNACION(Asignacion objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_INSERTARASIGNACION", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IDE_PED", SqlDbType.Int).Value = objP.idpedido;
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