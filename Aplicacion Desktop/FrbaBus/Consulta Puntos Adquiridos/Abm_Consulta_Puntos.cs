using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Consulta_Puntos_Adquiridos
{
    public partial class Abm_Consulta_Puntos : Form
    {
        public Abm_Consulta_Puntos()
        {
            InitializeComponent();
        }

        private void consultarDni_Click(object sender, EventArgs e)
        {
            if (textBoxDni.Text == "")
            {
                MessageBox.Show("Debe Ingresar un DNI ");
                return;
            }
            //buscamos Patron
            string query = "SELECT isnull(Cli_puntos_Acum,0) FROM DATACENTER.Cliente WHERE cli_Dni = " + textBoxDni.Text;
            connection connect = new connection();
            DataTable tabla_puntos = connect.execute_query(query);
            
            if (!this.existeDni(tabla_puntos))
            {
                MessageBox.Show("DNI inexistente en la Base de Datos");
                return;
            }            
            this.labelResultadoPuntos.Text = tabla_puntos.Rows[0].ItemArray.ElementAt(0).ToString();
            //Lleno la tabla de canjes 
            string query2 = "SELECT	prem_nombre AS 'Premio', prem_costo_Puntos AS 'Puntos Gastados', canj_fecha AS 'Fecha', canj_cant_retirada AS 'Cantidad Retirada' FROM DATACENTER.Canje join DATACENTER.Premio on canj_prem_Id = prem_Id WHERE canj_cli_Dni = " + textBoxDni.Text;
            DataTable tabla_canje = connect.execute_query(query2);
            
            this.Premio.DataPropertyName = tabla_canje.Columns[0].ToString();
            this.Puntos.DataPropertyName = tabla_canje.Columns[1].ToString();
            this.Fecha.DataPropertyName = tabla_canje.Columns[2].ToString();
            this.Cantidad.DataPropertyName = tabla_canje.Columns[3].ToString();
            this.dataGridViewCanjesRealizados.DataSource = tabla_canje;
           
        }

        private bool existeDni(DataTable tabla_puntos)
        {   
            return tabla_puntos.Rows.Count > 0;
        }
    }
}
