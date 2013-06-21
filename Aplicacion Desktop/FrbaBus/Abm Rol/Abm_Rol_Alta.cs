using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Rol
{
    public partial class Abm_Rol_Alta : Form
    {
        public Abm_Rol_Alta()
        {
            InitializeComponent();
        }

        private void list_funcionalidades_Load(object sender, EventArgs e)
        {
            //consulta a ejecutar para mostrar todas las funcionalidades cargadas en el checkedlistbox
            string query = "SELECT func_id, func_nombre FROM DATACENTER.Funcionalidad";

            //instanciamos obj de la clase connection y le enviamos la query para que la ejecute
            connection connect = new connection();
            DataTable tabla_func = connect.execute_query(query);

            //el resultado de la query lo cargamos en un data table
            //DataSource es el origen de los datos en nuestro caso la tabla que alberga el resultado de la query
            list_funcionalidades.DataSource = tabla_func;

            //Displaymember es la columna de la tabla que se va a mostrar en nuestro caso hay una sola
            list_funcionalidades.DisplayMember = "func_nombre";

            //ValueMembermember es el valor que tiene el campo seleccionado en nuestro caso ponemos la PK
            list_funcionalidades.ValueMember = "func_id";
        }

        private void list_funcionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void butt_Cleaning_Click(object sender, EventArgs e)
        {
            //refresca la pantalla
            this.name_rol.Text = "";
        }

      

      

 
    }
}
