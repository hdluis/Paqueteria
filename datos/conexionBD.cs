using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datos
{
    public class conexionBD
    {
        public MySqlConnection Conexion = new MySqlConnection(); //objeto
        public bool abrirBD()
        {
            try
            {
                Conexion.ConnectionString = "server=localhost;user id=mysqluser;password=mysqluser1234; database=dbfirma";
                Conexion.Open();
                return true;
            }
            catch { return false; }
        }

        public bool cerrarBD()
        {
            try
            {
                Conexion.Close();
                return true;
            }
            catch { return false; }
        }
    }
}
