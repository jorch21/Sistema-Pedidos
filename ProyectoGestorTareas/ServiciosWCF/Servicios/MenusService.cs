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
    public class MenusService 
    {
        SqlConnection cn = new SqlConnection("server=.;database=SistemaPedidos;integrated security=SSPI");
        public DataSet LISTA_MENUS()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTARPLATOS", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "LISTA");
            return ds;
        }
        public void NUEVO_MENU(Plato objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_INSERTARPLATO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NOM_PLA", SqlDbType.VarChar).Value = objP.nombremenu;
            cmd.Parameters.Add("@PRE_PLA", SqlDbType.Float).Value = objP.preciomenu;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var mensaje = "Error mensaje: " + e.Message;
            }
        }
        public void ACTULIZA_MENU(Plato objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_MODIFICARPLATO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IDE_PLA", SqlDbType.Int).Value = objP.idmenu;
            cmd.Parameters.Add("@NOM_PLA", SqlDbType.VarChar).Value = objP.nombremenu;
            cmd.Parameters.Add("@PRE_PLA", SqlDbType.Float).Value = objP.preciomenu;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var mensaje = "Error mensaje: " + e.Message;
            }
        }
        public void ELIMINA_MENU(Plato objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_ELIMINARPLATO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IDE_PLA", SqlDbType.Int).Value = objP.idmenu;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var mensaje = "Error mensaje: " + e.Message;
            }
        }
        public DataSet BUSCAR_MENU(string nombre)
        {
            cn.Open();
            string sql = "SELECT * FROM PLATOS WHERE NOM_PLA LIKE '%' + @NOM_PLA + '%'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@NOM_PLA", nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds,"NOMBRE");

            return ds;
        }
    }
}