using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Abm_Micro
{
    public partial class Abm_Micro_OpPorConcretar : Form
    {
        private string patenteConGuion;
        private DateTimePicker fechaFueraServ;
        private DateTimePicker fechaReing;

        public Abm_Micro_OpPorConcretar()
        {
            InitializeComponent();
        }

        internal void pasaPatente(String patenteMicro, DateTimePicker fechaFueraServicio, DateTimePicker fechaReingreso)
        {
            patenteConGuion = patenteMicro;
            fechaFueraServ = fechaFueraServicio;
            fechaReing = fechaReingreso;
        }

        private void buttonSustituir_Click(object sender, EventArgs e)
        {
            //consulta a ejecutar para conocer las características del micro que se quiere dar de baja
            string query1 = "SELECT mic_marc_id, mic_serv_id, mic_cant_butacas, mic_cant_kg_disponibles, mic_modelo FROM DATACENTER.Micro where mic_patente='" + patenteConGuion +"'";

            //instanciamos obj de la clase connection y le enviamos la query para que la ejecute
            connection connect1 = new connection();
            DataTable caracteristicasMicro = connect1.execute_query(query1);

            //consulta a ejecutar para conocer las características del micro que se quiere dar de baja
            string query2 = "SELECT top 1 mic_patente FROM DATACENTER.Micro where mic_patente<>'" + patenteConGuion 
                            + "' and mic_marc_id="+caracteristicasMicro.Rows[0].ItemArray[0].ToString()+" and mic_serv_id="
                            +caracteristicasMicro.Rows[0].ItemArray[1].ToString()+" and mic_cant_butacas>="+caracteristicasMicro.Rows[0].ItemArray[2].ToString();

            //instanciamos obj de la clase connection y le enviamos la query para que la ejecute
            connection connect2 = new connection();
            DataTable microReemplazante = connect2.execute_query(query2);

            if (microReemplazante.Rows.Count == 0)
            {
                //Ingreso nuevo micro que cumpla las mismas características debido que no existe uno que lo reemplace en la BD

                // Direcciona a formulario de ingreso de nuevo micro con similares características
                Patente_Alta form_PatenteAlta = new Patente_Alta();
                form_PatenteAlta.pasaCaracteristicas(caracteristicasMicro, patenteConGuion, fechaFueraServ, fechaReing);
                form_PatenteAlta.ShowDialog();
            
            }
            else
            {
                //Reemplazo el micro en aquellos viajes que debían darse dentro del rango de tiempo que está fuera de servicio

                //consulta a ejecutar para localizar los viajes que tenía asignados el micro anterior y actualizarles el nuevo valor
                string query3;
                if (fechaReing == null)
                {
                    query3 = "UPDATE DATACENTER.Viaje SET viaj_mic_patente='" + microReemplazante.Rows[0].ItemArray[0].ToString() + "' WHERE viaj_mic_patente='" + patenteConGuion + "' and (viaj_fecha_salida>='" + fechaFueraServ.Value.ToString("yyyy/MM/dd") + "' or viaj_fecha_lleg_estimada>='" + fechaFueraServ.Value.ToString("yyyy/MM/dd") + "')";
                }
                else
                {
                    query3 = "UPDATE DATACENTER.Viaje SET viaj_mic_patente='" + microReemplazante.Rows[0].ItemArray[0].ToString() + "' WHERE viaj_mic_patente='" + patenteConGuion + "' and ((viaj_fecha_salida>='" + fechaFueraServ.Value.ToString("yyyy/MM/dd") + "' and viaj_fecha_salida<='" + fechaReing.Value.ToString("yyyy/MM/dd") + "') or (viaj_fecha_lleg_estimada>='" + fechaFueraServ.Value.ToString("yyyy/MM/dd") + "' and viaj_fecha_lleg_estimada<='" + fechaReing.Value.ToString("yyyy/MM/dd") + "'))";
                }

                //instanciamos obj de la clase connection y le enviamos la query para que la ejecute
                connection connect3 = new connection();
                connect3.execute_query(query3);

                MessageBox.Show("La asignación de micro nuevo a los viajes se ha realizado con éxito.");

                this.Close();

            }
        }
    }
}
