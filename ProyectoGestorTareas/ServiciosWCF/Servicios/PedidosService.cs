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
    public class PedidosService 
    {
        SqlConnection cn = new SqlConnection("server=.;database=SistemaPedidos;integrated security=SSPI");
        public DataSet LISTA_PEDIDOS()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTARPEDIDOS", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "LISTA");
            return ds;
        }
        public DataSet LISTA_PEDIDOS_PENDIENTES()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTAPEDIDOSPENDIENTES", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "LISTA");
            return ds;
        }
        public void NUEVO_PEDIDO(Pedido objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_INSERTARPEDIDO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IDE_PLA", SqlDbType.Int).Value = objP.idplato;
            cmd.Parameters.Add("@IDE_CLI", SqlDbType.Int).Value = objP.idcliente;
            cmd.Parameters.Add("@CANT_PED", SqlDbType.Int).Value = objP.cantidad;
            cmd.Parameters.Add("@IGV_PED", SqlDbType.Float).Value = objP.igv;
            cmd.Parameters.Add("@TOT_PED", SqlDbType.Float).Value = objP.totalpedido;
            cmd.Parameters.Add("@IDE_USU", SqlDbType.Int).Value = objP.idusuario;
            cmd.Parameters.Add("@SBT_PED", SqlDbType.Float).Value = objP.subtotal;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var mensaje = "Error mensaje: " + e.Message;
            }
        }
        public void ELIMINA_PEDIDO(Pedido objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_ELIMINARPEDIDO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IDE_PED", SqlDbType.Int).Value = objP.idpedido;
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