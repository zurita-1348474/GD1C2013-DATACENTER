using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaBus.Abm_Rol;

namespace FrbaBus
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void rolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Rol_Alta alta_rol = new Abm_Rol_Alta();
            alta_rol.ShowDialog();
        }


    }
}
