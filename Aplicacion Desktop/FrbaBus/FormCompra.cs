using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaBus.Login;

namespace FrbaBus
{
    public partial class FormCompra : Form
    {
        public FormCompra()
        {
            InitializeComponent();
        }

        private void acceder_button_Click(object sender, EventArgs e)
        {
            //cuando un administrador hace click en login se le abre la
            //pantalla de login
            login login = new login();
            login.ShowDialog();
        }

       

       


       
       


    }
}
