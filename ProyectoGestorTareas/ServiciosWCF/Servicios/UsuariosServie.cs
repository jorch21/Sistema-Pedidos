using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServiciosWCF.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace ServiciosWCF.Servicios
{
    public class UsuariosService
    {
        Usuario usuario = new Usuario();
        SqlConnection cn = new SqlConnection("server=.;database=SistemaPedidos;integrated security=SSPI");
        public bool Login_User(string user, string pass)
        {
            //string sql = "SELECT * FROM USUARIOS WHERE MAIL_USU = @user and PASS_USU = @pass";
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_LOGIN", cn);
            cmd.Parameters.AddWithValue("@MAIL_USU", user);
            cmd.Parameters.AddWithValue("@PASS_USU", pass);
            //cmd.CommandType = CommandType.Text;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
                return false;
        }
        public DataSet LISTA_USUARIOS()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTARUSUARIOS", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "LISTA");
            return ds;
        }
        public DataSet LISTA_ROLES()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_LISTARROLES", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "ROL");
            return ds;
        }
        public void NUEVO_USUARIO(Usuario objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_INSERTARUSUARIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@COD_ROL", SqlDbType.Int).Value = objP.idrol;
            cmd.Parameters.Add("@NOM_USU", SqlDbType.VarChar).Value = objP.nomusuario;
            cmd.Parameters.Add("@DNI_USU", SqlDbType.Char).Value = objP.dniusuario;
            cmd.Parameters.Add("@MAIL_USU", SqlDbType.VarChar).Value = objP.correo;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var mensaje = "Error mensaje: " + e.Message;
            }
        }
        public void ACTUALIZA_USUARIO(Usuario objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_MODIFICARUSUARIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IDE_USU", SqlDbType.Int).Value = objP.idusuario;
            cmd.Parameters.Add("@COD_ROL", SqlDbType.Int).Value = objP.idrol;
            cmd.Parameters.Add("@NOM_USU", SqlDbType.VarChar).Value = objP.nomusuario;
            cmd.Parameters.Add("@DNI_USU", SqlDbType.Char).Value = objP.dniusuario;
            cmd.Parameters.Add("@MAIL_USU", SqlDbType.VarChar).Value = objP.correo;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var mensaje = "Error mensaje: " + e.Message;
            }
        }
        public void ELIMINA_USUARIO(Usuario objP)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IDE_USU", SqlDbType.Int).Value = objP.idusuario;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var mensaje = "Error mensaje: " + e.Message;
            }
        }

        public DataTable obtener_Usuario(Usuario objP)
        {
            SqlCommand cmd = new SqlCommand("SP_LOGIN",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MAIL_USU", objP.correo);
            cmd.Parameters.AddWithValue("@PASS_USU", objP.clave);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("usuarios");
            da.Fill(dt);
            return dt;
        }

    }
}