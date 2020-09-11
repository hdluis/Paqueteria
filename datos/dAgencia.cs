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
   public  class dAgencia : conexionBD
    {
        public DataTable getAgencias()
        {
            DataTable tblResultado = new DataTable();
            if (abrirBD())
            {
                try
                {
                    MySqlDataAdapter adaptador = new MySqlDataAdapter("get_all_agencias", Conexion);
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
