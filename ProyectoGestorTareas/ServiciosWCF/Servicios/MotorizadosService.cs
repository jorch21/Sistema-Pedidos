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
    public class MotorizadosService 
    {
        SqlConnection cn = new SqlConnection("server=.;database=SistemaPedidos;integrated security=SSPI");
        public DataSet LISTA_MOTORIZADOS()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTARPERSONALENTREGA", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "LISTA");
            return ds;
        }
        public DataSet LISTA_DISPONIBLES()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTARPERSONALENTREGADISPONIBLE", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "DISPONIBLE");
            return ds;
        }
        public void NUEVO_MOTORIZADO(Motorizado objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_INSERTARPERSONALENTREGA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NOM_MOT", SqlDbType.VarChar).Value = objP.nombremot;
            cmd.Parameters.Add("@DNI_MOT", SqlDbType.Char).Value = objP.dnimot;
            cmd.Parameters.Add("@NRO_LIC", SqlDbType.Char).Value = objP.nrolicencia;
            cmd.Parameters.Add("@TIPO_LIC", SqlDbType.VarChar).Value = objP.tipolicencia;
            cmd.Parameters.Add("@TIP_VEH", SqlDbType.VarChar).Value = objP.tipovehiculo;
            cmd.Parameters.Add("@MAT_VEH", SqlDbType.VarChar).Value = objP.matricula;
            cmd.Parameters.Add("@MOD_VEH", SqlDbType.VarChar).Value = objP.modelo;
            cmd.Parameters.Add("@MAR_VEH", SqlDbType.VarChar).Value = objP.marca;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var mensaje = "Error mensaje: " + e.Message;
            }
        }
        public void ACTULIZA_MOTORIZADO(Motorizado objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_MODIFICARPERSONALENTREGA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IDE_MOT", SqlDbType.Int).Value = objP.idmotorizado;
            cmd.Parameters.Add("@NOM_MOT", SqlDbType.VarChar).Value = objP.nombremot;
            cmd.Parameters.Add("@DNI_MOT", SqlDbType.Char).Value = objP.dnimot;
            cmd.Parameters.Add("@NRO_LIC", SqlDbType.Char).Value = objP.nrolicencia;
            cmd.Parameters.Add("@TIPO_LIC", SqlDbType.VarChar).Value = objP.tipolicencia;
            cmd.Parameters.Add("@TIP_VEH", SqlDbType.VarChar).Value = objP.tipovehiculo;
            cmd.Parameters.Add("@MAT_VEH", SqlDbType.VarChar).Value = objP.matricula;
            cmd.Parameters.Add("@MOD_VEH", SqlDbType.VarChar).Value = objP.modelo;
            cmd.Parameters.Add("@MAR_VEH", SqlDbType.VarChar).Value = objP.marca;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var mensaje = "Error mensaje: " + e.Message;
            }
        }
        public void ELIMINA_MOTORIZADO(Motorizado objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_ELIMINARPERSONALENTREGA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
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