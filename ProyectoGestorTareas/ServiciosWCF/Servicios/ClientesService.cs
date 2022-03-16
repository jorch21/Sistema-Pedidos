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
    public class ClientesService 
    {
        SqlConnection cn = new SqlConnection("server=.;database=SistemaPedidos;integrated security=SSPI");
        public DataSet LISTA_CLIENTES()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTARCLIENTE", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "LISTA");
            return ds;
        }
        public DataSet LISTA_DISTRITOS()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTARDISTRITOS", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "DISTRITO");
            return ds;
        }
        public void NUEVO_CLIENTE(Cliente objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_INSERTARCLIENTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NOM_CLI", SqlDbType.VarChar).Value = objP.nomcliente;
            cmd.Parameters.Add("@DNI_CLI", SqlDbType.Char).Value = objP.dnicliente;
            cmd.Parameters.Add("@TEL_CLI", SqlDbType.Char).Value = objP.telefono;
            cmd.Parameters.Add("@MAIL_CLI", SqlDbType.VarChar).Value = objP.correo;
            cmd.Parameters.Add("@DIR_CLI", SqlDbType.VarChar).Value = objP.direccion;
            cmd.Parameters.Add("@COD_DIS", SqlDbType.Int).Value = objP.iddistrito;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var mensaje = "Error mensaje: " + e.Message;
            }
        }
        public void ACTULIZA_CLIENTE(Cliente objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_MODIFICARCLIENTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IDE_CLI", SqlDbType.Int).Value = objP.idcliente;
            cmd.Parameters.Add("@NOM_CLI", SqlDbType.VarChar).Value = objP.nomcliente;
            cmd.Parameters.Add("@DNI_CLI", SqlDbType.Char).Value = objP.dnicliente;
            cmd.Parameters.Add("@TEL_CLI", SqlDbType.Char).Value = objP.telefono;
            cmd.Parameters.Add("@MAIL_CLI", SqlDbType.VarChar).Value = objP.correo;
            cmd.Parameters.Add("@DIR_CLI", SqlDbType.VarChar).Value = objP.direccion;
            cmd.Parameters.Add("@COD_DIS", SqlDbType.Int).Value = objP.iddistrito;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var mensaje = "Error mensaje: " + e.Message;
            }
        }
        public void ELIMINA_CLIENTE(Cliente objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCLIENTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IDE_CLI", SqlDbType.Int).Value = objP.idcliente;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var mensaje = "Error mensaje: " + e.Message;
            }
        }
        public DataSet BUSCAR_CLIENTE(string nombre)
        {
            cn.Open();
            string sql = "SELECT * FROM CLIENTES WHERE DNI_CLI LIKE '%' + @DNI_CLI + '%'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@DNI_CLI", nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "NOMBRE");

            return ds;
        }
    }
}