using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datos
{
    public class dUsuario : conexionBD
    {
        public int verificarUsuario(eUsuario usuario)
        {
            int retorno;
            if (abrirBD())
            {
                MySqlCommand comando = new MySqlCommand("proc_login", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //parametros de entrada
                MySqlParameter prmCodigo = comando.Parameters.Add("parusername", MySqlDbType.VarChar, 25);
                prmCodigo.Value = usuario.username;
                MySqlParameter prmKey = comando.Parameters.Add(new MySqlParameter("parpassword", MySqlDbType.VarChar, 25));
                prmKey.Value = usuario.password; 
                //parametros de salida
                comando.Parameters.Add(new MySqlParameter("parretorno", MySqlDbType.Int32, 15));
                comando.Parameters["parretorno"].Direction = ParameterDirection.Output;
                comando.Parameters.Add(new MySqlParameter("parmensaje", MySqlDbType.VarChar, 150));
                comando.Parameters["parmensaje"].Direction = ParameterDirection.Output;
          
                try
                {
                    comando.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    retorno = Convert.ToInt32(ex.HResult);

                    return retorno;
                }
                finally
                {
                    cerrarBD();
                }
                retorno = Convert.ToInt32(comando.Parameters["parretorno"].Value.ToString());                
     
              
            }

            else
            {
                // parametros de salida                
               retorno = -10000;
                             
            }
            return retorno;
        }

        public int guardarUsuarios(eNuevoUsuario us)
        {
            int retorno;
            if (abrirBD())
            {
                MySqlCommand comando = new MySqlCommand("guardar_usuario", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //parametros de entrada
                MySqlParameter prmUserName = comando.Parameters.Add("parusername", MySqlDbType.VarChar, 25);
                prmUserName.Value = us.username;
                MySqlParameter prmNombre = comando.Parameters.Add("parnombre", MySqlDbType.VarChar, 45);
                prmNombre.Value = us.nombre;
                MySqlParameter prmPass = comando.Parameters.Add("parpassword", MySqlDbType.VarChar, 45);
                prmPass.Value = us.password;
                MySqlParameter prmRol = comando.Parameters.Add("parrol", MySqlDbType.Int32);
                prmRol.Value = us.rol;
                MySqlParameter prmClave = comando.Parameters.Add("parclave", MySqlDbType.Int32);
                prmClave.Value = us.clave;

                //parametros de salida
                comando.Parameters.Add(new MySqlParameter("parretorno", MySqlDbType.Int32, 15));
                comando.Parameters["parretorno"].Direction = ParameterDirection.Output;


                try
                {
                    comando.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    retorno = Convert.ToInt32(ex.HResult);

                    return retorno;
                }
                finally
                {
                    cerrarBD();
                }
                retorno = Convert.ToInt32(comando.Parameters["parretorno"].Value.ToString());


            }

            else
            {
                // parametros de salida                
                retorno = -10000;

            }
            return retorno;
        }
    }
}
