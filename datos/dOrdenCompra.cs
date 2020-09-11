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
    public class dOrdenCompra : conexionBD
    {
        public int guardarOrdenCompra(ordencompra orden)
        {
            int retorno;
            if (abrirBD())
            {
                MySqlCommand comando = new MySqlCommand("guardar_orden_compra", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //parametros de entrada
                MySqlParameter prmProducto = comando.Parameters.Add("parproducto", MySqlDbType.VarChar, 45);
                prmProducto.Value = orden.producto;
                MySqlParameter prmFecha = comando.Parameters.Add("parfecha", MySqlDbType.DateTime);
                prmFecha.Value = orden.fecha;
                MySqlParameter prmProveedor = comando.Parameters.Add("parproveedor", MySqlDbType.VarChar, 45);
                prmProveedor.Value = orden.proveedor;
                MySqlParameter prmTotal = comando.Parameters.Add("partotal", MySqlDbType.Int32);
                prmTotal.Value = orden.total;

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

        public int firmarOrdenCompra(ordencompra orden)
        {
            int retorno;
            if (abrirBD())
            {
                MySqlCommand comando = new MySqlCommand("firmar_orden_compra", Conexion);
                comando.CommandType = CommandType.StoredProcedure;
                //parametros de entrada
                MySqlParameter prmCodigo = comando.Parameters.Add("parcodigo", MySqlDbType.Int32);
                prmCodigo.Value = orden.codigo;
                MySqlParameter prmAutorizador = comando.Parameters.Add("parautorizador", MySqlDbType.VarChar, 45);
                prmAutorizador.Value = orden.autorizador;

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

        public DataTable getMostrarFirmados()
        {
            DataTable tblResultado = new DataTable();
            if (abrirBD())
            {
                try
                {
                    MySqlDataAdapter adaptador = new MySqlDataAdapter("get_mostrar_firmados", Conexion);
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

        public DataTable getMostrarNoFirmados()
        {
            DataTable tblResultado = new DataTable();
            if (abrirBD())
            {
                try
                {
                    MySqlDataAdapter adaptador = new MySqlDataAdapter("get_mostrar_nofirmado", Conexion);
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
                prmUserName.Value = us.nombre;
                MySqlParameter prmPass = comando.Parameters.Add("parassword", MySqlDbType.VarChar, 45);
                prmPass.Value = us.nombre;
                MySqlParameter prmRol = comando.Parameters.Add("parrol", MySqlDbType.Int32);
                prmRol.Value = us.rol;

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
