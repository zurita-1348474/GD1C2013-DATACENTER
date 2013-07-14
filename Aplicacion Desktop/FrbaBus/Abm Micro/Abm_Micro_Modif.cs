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
    public partial class Abm_Micro_Modif : Form
    {
        private funciones funciones;

        public Abm_Micro_Modif()
        {
            InitializeComponent();
            this.funciones = new funciones();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            /*
                FALTA HACER UN CONTROL PARA SABER SI EL MICRO NO ESTÁ YA EN REPARACIÓN PARA
                LAS FECHAS QUE SE INGRESARON RECIENTEMENTE. SERÍA UN ERROR Y NO SE DEBERÍA
                PERMITIR QUE CONTINUE CON LA OPERACIÓN
            */
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

            for (i = 0; i < 3; i++)
            {
                if (Char.IsDigit(caracter.ElementAt(i)))
                {
                    MessageBox.Show("Patente ingresada incorrecta. Se espera que sea de tipo LLLNNN");
                    return;
                }
            }
            for (i = 3; i < 6; i++)
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

            if (dateTimePickerFechaReingreso.Value < dateTimePickerFechaBajaTemporaria.Value)
            {
                MessageBox.Show("ERROR: La fecha de baja no puede ser anterior a la de reingreso.");
                return;
            }
            
            //Chequea si existen viajes ya asignados a ese micro

            //preparar patente para poder registrar nuevo micro
            string primerPartePatente = textBoxPatente.Text.Substring(0, 3);
            string segundaPartePatente = textBoxPatente.Text.Substring(3, 3);
            string nroPatente = primerPartePatente + "-" + segundaPartePatente;

            //consulta a ejecutar para saber si existen viajes asociados al micro
            string query1 = "SELECT count(*) FROM DATACENTER.Viaje where viaj_mic_patente='" + nroPatente + "'";

            //instanciamos obj de la clase connection y le enviamos la query para que la ejecute
            connection connect1 = new connection();
            DataTable cantViajes = connect1.execute_query(query1);

            //consulta a ejecutar para agregar nuevo registro por micro fuera de servicio (en EstadoMicro)
            string query2 = "INSERT INTO DATACENTER.EstadoMicro(est_mic_patente,est_fecha_fuera_serv,est_fecha_reingreso) VALUES ('"
                            + nroPatente + "','" + dateTimePickerFechaBajaTemporaria.Value.ToString("yyyy/MM/dd") + "','" + dateTimePickerFechaReingreso.Value.ToString("yyyy/MM/dd") + "') and";

            //instanciamos obj de la clase connection y le enviamos la query para que la ejecute
            connection connect2 = new connection();
            connect2.execute_query(query2);


            if (Convert.ToInt32(cantViajes.Rows[0].ItemArray[0].ToString()) == 0)
            {
                MessageBox.Show("La operación se ha realizado con éxito.");
                textBoxPatente.Clear();
                return;
            }
            else
            {
                // Direcciona a formulario de OPERACIÓN POR CONCRETAR ya que tenía viajes asociados
                Abm_Micro_OpPorConcretar form_OpPorConcretar = new Abm_Micro_OpPorConcretar();
                form_OpPorConcretar.pasaPatente(nroPatente, dateTimePickerFechaBajaTemporaria, dateTimePickerFechaReingreso);
                form_OpPorConcretar.ShowDialog();
            }
        }
    }
}
