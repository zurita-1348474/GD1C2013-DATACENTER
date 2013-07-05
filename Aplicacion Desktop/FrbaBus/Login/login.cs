using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaBus.Login
{
    public partial class login : Form
    {
        /*-------ATRIBUTOS------------------*/
        int cant_fallidas = 0;
        stored_procedures procedure = new stored_procedures();
        /*----------------------------------*/
        public login()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            /*-----Controlamos que no halla textBoxs en blanco*/

            if (this.username_textbox.Text == "" | this.passw_textbox.Text == "")
            {
                MessageBox.Show("Error: los campos NO pueden estar vacio");
                this.username_textbox.Text = "";
                this.passw_textbox.Text = "";
                return;
            }

            /*------------------------------------------------*/
            //el administrador ingreso usuario y contraseña 
            connection conexion = new connection();

            DataTable administrador = conexion.execute_query("SELECT adm_username, adm_password, adm_cant_intentos FROM DATACENTER.Administrador WHERE adm_username= " + "'" + username_textbox.Text + "'");
            if (administrador.Rows.Count == 1)
            {
                //existe el usuario sino no me devolveria filas el select; entonces evaluamos la cant_intentos

                if (administrador.Rows[0].ItemArray[2].ToString() == "3")
                {
                    MessageBox.Show("USUARIO INHABILITADO");
                    this.username_textbox.Text = "";
                    this.passw_textbox.Text = "";
                    return;
                }
                
                //evaluamos si esta bien la contraseña

                if (passw_textbox.Text == administrador.Rows[0].ItemArray[1].ToString())
                {
                    //Row[n] siendo n nro de fila; itemArray[n] siendo n el nro de columna de la fila siendo n>=0

                    //limpiamos cant_intentos
                    cant_fallidas = 0;
                    DataTable retorno_update = procedure.update_cant_intentos_fallidos(username_textbox.Text, cant_fallidas);

                    //abrimos el formulario de administradores
                    FormAdmin form_admin = new FormAdmin();
                    form_admin.ShowDialog();

                    
                  
                }
                else
                {
                    cant_fallidas++;
                    //Se debe actualizar el campo adm_cant_intentos de la base de datos
                    DataTable retorno_update = procedure.update_cant_intentos_fallidos(username_textbox.Text, cant_fallidas);
                    //si cant_fallidas es igual a 3 se bloquea el usuario (TRIGGER (?)
                    
                   
                    MessageBox.Show("El nombre de usuario o la contraseña introducidos no son correctos");
                    
                }
            }
            else
            { //NO EXISTE EL USERNAME entonces NO podemos descontar cant_intentos_fallidos

                MessageBox.Show("El nombre de usuario o la contraseña introducidos no son correctos");
                
            }
            
            this.username_textbox.Text = "";
            this.passw_textbox.Text = "";
            return;
        }

    }
}
