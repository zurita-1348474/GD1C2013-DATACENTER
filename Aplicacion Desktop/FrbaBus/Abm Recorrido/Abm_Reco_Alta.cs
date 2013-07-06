using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Recorrido
{
    public partial class Abm_Reco_Alta : Form
    {
        public Abm_Reco_Alta()
        {
            InitializeComponent();
        }

        private void comboBoxCiuOrigen_Load(object sender, EventArgs e)
        {
            //consulta a ejecutar para mostrar todas las ciudades posibles a seleccionar en el comboBox
            string query = "SELECT ciu_nombre FROM DATACENTER.Ciudad";

            //instanciamos obj de la clase connection y le enviamos la query para que la ejecute
            connection conexion = new connection();
            DataTable tabla_origenes = conexion.execute_query(query);

            //el resultado de la query lo cargamos en un data table
            //DataSource es el origen de los datos en nuestro caso la tabla que alberga el resultado de la query
            comboBoxCiuOrigen.DataSource = tabla_origenes;

            //Displaymember es la columna de la tabla que se va a mostrar en nuestro caso hay una sola
            comboBoxCiuOrigen.DisplayMember = "ciu_nombre";

            //ValueMembermember es el valor que tiene el campo seleccionado en nuestro caso ponemos la PK
            comboBoxCiuOrigen.ValueMember = "ciu_nombre";

        }

        private void comboBoxCiuDestino_Load(object sender, EventArgs e)
        {
            string query = "SELECT ciu_nombre FROM DATACENTER.Ciudad";

            connection conexion = new connection();
            DataTable tabla_destinos = conexion.execute_query(query);

            comboBoxCiuDestino.DataSource = tabla_destinos;

            comboBoxCiuDestino.DisplayMember = "ciu_nombre";

            comboBoxCiuDestino.ValueMember = "ciu_nombre";

        }

        private void comboBoxTipoServ_Load(object sender, EventArgs e)
        {
            string query = "SELECT serv_tipo FROM DATACENTER.Servicio";

            connection conexion = new connection();
            DataTable tabla_servicios = conexion.execute_query(query);

            comboBoxTipoServ.DataSource = tabla_servicios;

            comboBoxTipoServ.DisplayMember = "serv_tipo";

            comboBoxTipoServ.ValueMember = "serv_tipo";

        }

        private void botonRefrescar_Click(object sender, EventArgs e)
        {
            textBoxCodReco.Clear();
            textBoxPrecioBaseEnco.Clear();
            textBoxPrecioBasePas.Clear();
            comboBoxCiuOrigen.ResetText();
            comboBoxCiuDestino.ResetText();
            comboBoxTipoServ.ResetText();
        }







    }
}
