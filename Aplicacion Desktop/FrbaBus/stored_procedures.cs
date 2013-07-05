using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FrbaBus
{
    class stored_procedures
    {
        /*clase que tiene metodos que hacen de interfaz con los stored procedures que estan en la BD sql server*/
        
        //atributo
        connection connect = new connection();

        public DataTable update_cant_intentos_fallidos(string username, int cant_intentos)
        {
            
            string query = "EXECUTE DATACENTER.update_cant_intentos_fallidos "+
                           "'"+username+"',"+
                           cant_intentos.ToString();
            
            DataTable retorno_update = connect.execute_query(query);
            
            return retorno_update;
        }
        
    }
}
