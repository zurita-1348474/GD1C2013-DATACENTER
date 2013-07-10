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
    public partial class Abm_Micro_Alta : Form
    {
        private funciones funciones;

        public Abm_Micro_Alta()
        {
            InitializeComponent();
            this.funciones = new funciones();    
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (textBoxPatente.Text == "")
            {
                MessageBox.Show("Debe ingresar una Patente");
                return;
            }
            if(funciones.existePatente(textBoxPatente.Text))
            {
                MessageBox.Show("La patente ingresada ya existe en la Base de Datos");
                return;
            }
        }
    }
}
