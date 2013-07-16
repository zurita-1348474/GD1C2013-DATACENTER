using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Canc_Dev_de_Pas_Enc
{
    public partial class CancelDevol : Form
    {
        public CancelDevol()
        {
            InitializeComponent();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (textBoxNroCompra.Text == "")
            {
                MessageBox.Show("Debe ingresar un Nro de Compra");
                return;
            }

            if (textBoxCodPasEnc.Text == "")
            {
                MessageBox.Show("Debe ingresar el Código de un Pasaje o Encomienda.");
                return;
            }

            string tipoItem = comboBoxTipoItem.Text.ToString();
            if (tipoItem == "Encomienda")
                tipoItem = "Paquete";   //Asigno asi porque se relaciona más directo con TABLA PAQUETE

            
            //consulta a ejecutar para verificar que existe id de la compra
            string query1 = "select * from DATACENTER.Compra where comp_id=" + textBoxNroCompra.Text;
            connection connect1 = new connection();
            DataTable existeCompra = connect1.execute_query(query1);

            if (existeCompra.Rows.Count == 0)
            {
                MessageBox.Show("El Nro de Compra ingresado es incorrecto.");
                return;
            }

            
            if (tipoItem == "Paquete")
            {
                //consulta a ejecutar para verificar que existe el código de paquete
                string query2 = "select * from DATACENTER.Paquete where paq_comp_id=" + textBoxNroCompra.Text;
                connection connect2 = new connection();
                DataTable existePaquete = connect2.execute_query(query2);

                if (existePaquete.Rows.Count == 0)
                {
                    MessageBox.Show("El Código de Paquete ingresado es incorrecto.");
                    return;
                }

                //consulta a ejecutar para verificar que exista relación entre la compra y paquete
                string query3 = "select * from DATACENTER.Compra join DATACENTER.Paquete on paq_comp_id=comp_id where comp_id="+textBoxNroCompra.Text+" and paq_cod="+textBoxCodPasEnc.Text;
                connection connect3 = new connection();
                DataTable existeRelCompraPaquete = connect3.execute_query(query3);

                if (existeRelCompraPaquete.Rows.Count == 0)
                {
                    MessageBox.Show("El Nro de Compra no se vincula con el Código de la Encomienda.");
                    return;
                }

            }
            else
            {
                //consulta a ejecutar para verificar que existe el código de pasaje
                string query2 = "select * from DATACENTER.Pasaje where pas_compra_id=" + textBoxNroCompra.Text;
                connection connect2 = new connection();
                DataTable existePasaje = connect2.execute_query(query2);

                if (existePasaje.Rows.Count == 0)
                {
                    MessageBox.Show("El Código de Pasaje ingresado es incorrecto.");
                    return;
                }

                //consulta a ejecutar para verificar que exista relación entre la compra y pasaje
                string query3 = "select * from DATACENTER.Compra join DATACENTER.Pasaje on pas_compra_id=comp_id where comp_id=" + textBoxNroCompra.Text + " and paq_cod=" + textBoxCodPasEnc.Text;
                connection connect3 = new connection();
                DataTable existeRelCompraPasaje = connect3.execute_query(query3);

                if (existeRelCompraPasaje.Rows.Count == 0)
                {
                    MessageBox.Show("El Nro de Compra no se vincula con el Código de Pasaje.");
                    return;
                }

            }


            //consulta a ejecutar para verificar que esa devolución no haya sido solicitada anteriormente
            string query4 = "select * from DATACENTER.Devolucion where dev_comp_id="+textBoxNroCompra.Text+" and dev_tipo_devuelto='"+tipoItem+"' and dev_cod_PasPaq="+textBoxCodPasEnc.Text;
            connection connect4 = new connection();
            DataTable existeDevolucion = connect4.execute_query(query4);
            if (existeDevolucion.Rows[0].ItemArray[0].ToString() != null)
            {
                MessageBox.Show("ERROR: No se puede efectuar la devolución ya que fue gestionada anteriormente.");
                return;
            }

            //consulta a ejecutar para registrar nueva devolución
            string query5 = "exec DATACENTER.registraDevolucion '"+dateTimePickerCancDev.Value.ToString("yyyy/MM/dd")+"',"+textBoxNroCompra.Text+",'"+tipoItem+"',"+textBoxCodPasEnc.Text+",'"+textBoxMotivoDeCanc.Text+"'";
            connection connect5 = new connection();
            connect5.execute_query(query5);

            MessageBox.Show("La devolución se ha realizado con éxito.");
            
            //Limpiar campos
            this.textBoxNroCompra.Clear();
            this.textBoxCodPasEnc.Clear();
            this.textBoxMotivoDeCanc.Clear();

            return;

        }

        private void FormCancDev_Load(object sender, EventArgs e)
        {
            DataTable tablaItems = new DataTable();
            tablaItems.Columns.Add("tipo_item", typeof(string));

            DataRow filaItem1 = tablaItems.NewRow();
            filaItem1["tipo_item"] = "Pasaje";
            tablaItems.Rows.Add(filaItem1);
            DataRow filaItem2 = tablaItems.NewRow();
            filaItem2["tipo_item"] = "Encomienda";
            tablaItems.Rows.Add(filaItem2);
            comboBoxTipoItem.DataSource = tablaItems;
            comboBoxTipoItem.DisplayMember = "tipo_item";
            comboBoxTipoItem.ValueMember = "tipo_item";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxNumericos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
        }

    }
}
