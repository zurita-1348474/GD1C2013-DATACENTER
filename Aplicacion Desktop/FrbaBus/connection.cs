using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace FrbaBus
{
    class connection
    {
        public SqlConnection connector()
        {
            SqlConnection connect = new SqlConnection();
            try
            {
                connect.ConnectionString = get_string_connection();
                connect.Open(); //abrimos conexion
                MessageBox.Show("Conectado");

            }
            catch (SqlException ex) //Capturamos algun error que pudo darse al querer conectarse
            {
                MessageBox.Show("Error al conectar con la base datos--" + ex.Message);

            }
            return connect;

        }

        public string get_string_connection()
        {
            string string_connect = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD1C2013;User ID=gd; PASSWORD=gd2013"; //va el @ porque sino tira un warning escape sequences con @se ignora
            return string_connect;
        }

        public DataTable execute_query(string query)
        {
            //creamos Data_Adapter que es un adaptador/interfaz que nos permite interactuar entre 
            //nuestra base_local dataset/datatable y la la base de datos del sql server
            //el data_adapter se encargara de llevar a cabo las consultas a la DB sql_Server

            SqlDataAdapter data_adapter = new SqlDataAdapter(query, this.get_string_connection());
            
            //volcamos la informacion resultado de ejecutar la consulta en un data table
            DataTable tabla=new DataTable();
            //tabla.Locale = System.Globalization.CultureInfo.InvariantCulture;
            data_adapter.Fill(tabla);
            return tabla;
            
        }



        

    }


}
