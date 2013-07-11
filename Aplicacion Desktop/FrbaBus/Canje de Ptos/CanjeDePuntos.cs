using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Canje_de_Ptos
{
    public partial class CanjeDePuntos : Form
    {
        funciones func = new funciones();

        public CanjeDePuntos()
        {
            InitializeComponent();
        }

        private void CanjeDePuntos_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dniCliente.Text == "")
            {
                MessageBox.Show("ERROR: Debe ingresar un DNI de Cliente");
                return;
            }

            //consulta a ejecutar para mostrar todas los premios cargados en la tabla
            string query1 = "SELECT isnull(cli_puntos_acum,0) FROM DATACENTER.Cliente where " + dniCliente.Text + "=cli_dni";

            //instanciamos obj de la clase connection y le enviamos la query para que la ejecute
            connection connect = new connection();
            DataTable ptos_acum = connect.execute_query(query1);

            //consulta a ejecutar para mostrar todas los premios cargados en la tabla
            string query2 = "SELECT prem_nombre as Premio, prem_costo_puntos as Puntos FROM DATACENTER.Premio where " + ptos_acum.Rows[0].ItemArray[0].ToString() + ">=prem_costo_puntos";
         
            //instanciamos obj de la clase connection y le enviamos la query para que la ejecute
            connection connect2 = new connection();
            DataTable tabla_premio = connect.execute_query(query2);
            this.Premio.DataPropertyName = tabla_premio.Columns[0].ToString();
            this.Puntos.DataPropertyName = tabla_premio.Columns[1].ToString();
            this.tablaPremios.DataSource = tabla_premio;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int i;
            int puntosConsumidos = 0;
            for (i = 0; i < tablaPremios.RowCount; i++)
            {
                if (tablaPremios.Rows[i].Cells[0].Selected == true)
                {
                    MessageBox.Show("cantidad");
                
                    MessageBox.Show("cantidad" + tablaPremios.Rows[i].Cells[1].ToString());
                    
                    if (tablaPremios.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        //DataGridViewRow row = tablaPremios.Rows[i];
                        int convertidos = 0;
                            //Convert.ToInt16(tablaPremios.Rows[i].Cells[1].Value);
                        MessageBox.Show("CONVERTIDOS"+convertidos.ToString());
                                           
                        //puntosConsumidos = puntosConsumidos + ((int)(tablaPremios.Rows[i].Cells[1].Value) * Convert.ToInt16(tablaPremios.Rows[i].Cells[3].Value));
                    }
                    else
                    {
                         MessageBox.Show("ERROR: Ingrese cantidad de premio/s a canjear");
                         return;
                    }
                }
            }
            //consulta a ejecutar para mostrar todas los premios cargados en la tabla
            string query1 = "SELECT cli_puntos_acum FROM DATACENTER.Cliente where " + dniCliente.Text.ToString() + "=cli_dni";

            //instanciamos obj de la clase connection y le enviamos la query para que la ejecute
            connection connect1 = new connection();
            DataTable puntosAcumulados = connect1.execute_query(query1);
            MessageBox.Show("Puntos Consumidos "+puntosConsumidos.ToString());

            if (puntosConsumidos <=  Convert.ToInt16(puntosAcumulados.Rows[0].ItemArray[0]))
            {
                int puntosTotAcum = (Convert.ToInt16(puntosAcumulados.Rows[0].ItemArray[0]) - puntosConsumidos);
                //consulta a ejecutar para mostrar todas los premios cargados en la tabla
                string query2 = "UPDATE DATACENTER.Cliente set cli_puntos_acum=" + puntosTotAcum.ToString() + " where " + dniCliente.Text.ToString() + "=cli_dni";

                //instanciamos obj de la clase connection y le enviamos la query para que la ejecute
                connection connect2 = new connection();
                connect2.execute_query(query2);
                MessageBox.Show("El canje se ha realizado con éxito.");
                return;
            }
            else
            {
                MessageBox.Show("ERROR: No tiene los suficientes puntos para realizar el canje");
                return;
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Vuelve a la pantallita de AMBS para el Administrador
        }
    }
}
