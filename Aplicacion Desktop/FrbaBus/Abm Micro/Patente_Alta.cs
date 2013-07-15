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
    public partial class Patente_Alta : Form
    {
        private funciones funciones;
        private DataTable caractMicroNuevo;
        private string patenteAReemplazar;
        private DateTimePicker fechaFServ;
        private DateTimePicker fechaRein;

        public Patente_Alta()
        {
            InitializeComponent();
            this.funciones = new funciones();    
        }

        internal void pasaCaracteristicas(DataTable caractMicro, String patAReemplazar, DateTimePicker fechaFS, DateTimePicker fechaR)
        {
            caractMicroNuevo = caractMicro;
            patenteAReemplazar = patAReemplazar;
            fechaFServ = fechaFS;
            fechaRein = fechaR;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
               if (textBoxPatente.Text == "")
            {
                MessageBox.Show("Debe ingresar una Patente");
                return;
            }

            char[] caracter = textBoxPatente.Text.ToCharArray();
            int i;
            if (caracter.Length != 6)
            {
                MessageBox.Show("Patente ingresada incorrecta. Se espera que sea de tipo LLLNNN");
                return;
            }

            for (i = 0;i<3; i++)
            {
                if (Char.IsDigit(caracter.ElementAt(i)))
                {
                    MessageBox.Show("Patente ingresada incorrecta. Se espera que sea de tipo LLLNNN");
                    return;
                }
            }
            for (i=3; i < 6; i++)
            {
                if (Char.IsLetter(caracter.ElementAt(i)))
                {
                    MessageBox.Show("Patente ingresada incorrecta. Se espera que sea de tipo LLLNNN");
                    return;
                }
            }

            if (funciones.existePatente(textBoxPatente.Text))
            {
                MessageBox.Show("La patente ingresada ya existe en la Base de Datos");
                return;
            }

            //preparar patente para poder registrar nuevo micro
            string primerPartePatente = textBoxPatente.Text.Substring(0, 3);
            string segundaPartePatente = textBoxPatente.Text.Substring(3, 3);
            string nroPatente = primerPartePatente + "-" + segundaPartePatente;

            //consulta a ejecutar para registrar nuevo micro
            string query1 = "INSERT INTO DATACENTER.Micro(mic_patente, mic_marc_id, mic_serv_id, mic_cant_butacas, mic_cant_kg_disponibles, mic_modelo, mic_fecha_alta, mic_fecha_baja_def) VALUES ('" +
                            nroPatente + "','" + caractMicroNuevo.Rows[0].ItemArray[0].ToString() + "','" + caractMicroNuevo.Rows[0].ItemArray[1].ToString() + "','" + caractMicroNuevo.Rows[0].ItemArray[2].ToString() + "','" + caractMicroNuevo.Rows[0].ItemArray[3].ToString() + "','" + caractMicroNuevo.Rows[0].ItemArray[4].ToString() + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "',NULL)";
            connection connect1 = new connection();
            connect1.execute_query(query1);

            MessageBox.Show("El ingreso de Micro se ha realizado con éxito.");


            
            // Proceder al cambio de micro efectivo en los registros de los viajes que corresponda

            //consulta a ejecutar para localizar los viajes que tenía asignados el micro anterior y actualizarles el nuevo valor
            string query2;
            if (fechaRein == null)
            {
                query2 = "UPDATE DATACENTER.Viaje SET viaj_mic_patente='" + nroPatente + "' WHERE viaj_mic_patente='" + patenteAReemplazar + "' and (viaj_fecha_salida>='" + fechaFServ.Value.ToString("yyy/MM/dd") + "' or viaj_fecha_lleg_estimada>='" + fechaFServ.Value.ToString("yyyy/MM/dd") + "')";
            }
            else
            {
                query2 = "UPDATE DATACENTER.Viaje SET viaj_mic_patente='" + nroPatente + "' WHERE viaj_mic_patente='" + patenteAReemplazar + "' and ((viaj_fecha_salida>='" + fechaFServ.Value.ToString("yyy/MM/dd") + "' and viaj_fecha_salida<='" + fechaRein.Value.ToString("yyyy/MM/dd") + "') or (viaj_fecha_lleg_estimada>='" + fechaFServ.Value.ToString("yyyy/MM/dd") + "' and viaj_fecha_lleg_estimada<='" + fechaRein.Value.ToString("yyyy/MM/dd") + "'))";
            }
            connection connect2 = new connection();
            connect2.execute_query(query2);

            MessageBox.Show("La asignación de micro nuevo a los viajes se ha realizado con éxito.");
    
            this.Close();
        }
    }
}
