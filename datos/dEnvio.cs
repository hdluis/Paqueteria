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
   public  class dEnvio : conexionBD
    {
        public int GuardarEnvio(eEnvio Envio)
        {
            int retorno;
            if (abrirBD())
            {
                MySqlCommand comando = new MySqlCommand("guardar_envio", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //parametros de entrada
                MySqlParameter prmPeso = comando.Parameters.Add("parpeso", MySqlDbType.Double);
                prmPeso.Value = Envio.peso;
                MySqlParameter prmCosto = comando.Parameters.Add(new MySqlParameter("parcosto", MySqlDbType.Decimal));
                prmCosto.Value = Envio.costo;
                MySqlParameter prmDesc = comando.Parameters.Add(new MySqlParameter("pardescripcion", MySqlDbType.VarChar,45));
                prmDesc.Value = Envio.descripcion;
                MySqlParameter prmFecha = comando.Parameters.Add(new MySqlParameter("parfecha", MySqlDbType.VarChar, 45));
                prmFecha.Value = Envio.fecha;
                MySqlParameter prmDir = comando.Parameters.Add(new MySqlParameter("pardireccion", MySqlDbType.VarChar, 45));
                prmDir.Value = Envio.direccion;
                MySqlParameter prmCliente = comando.Parameters.Add(new MySqlParameter("parcliente", MySqlDbType.Int32));
                prmCliente.Value = Envio.cliente;
                MySqlParameter prmAgencia = comando.Parameters.Add(new MySqlParameter("paragencia", MySqlDbType.Int32));
                prmAgencia.Value = Envio.agencia;
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

        public DataTable getEnvios()
        {
            DataTable tblResultado = new DataTable();
            if (abrirBD())
            {
                try
                {
                    MySqlDataAdapter adaptador = new MySqlDataAdapter("get_all_envios", Conexion);
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adaptador.Fill(tblResultado);
                }
                catch
                {
                    return tblResultado;
                }
                finally
                {
                    cerrarBD();
                }
            }
            return tblResultado;
        }
    }
}
