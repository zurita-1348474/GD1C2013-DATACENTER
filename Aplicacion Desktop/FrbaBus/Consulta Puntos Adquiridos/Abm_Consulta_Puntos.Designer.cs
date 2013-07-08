namespace FrbaBus.Consulta_Puntos_Adquiridos
{
    partial class Abm_Consulta_Puntos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.consultarDni = new System.Windows.Forms.Button();
            this.labelDni = new System.Windows.Forms.Label();
            this.textBoxDni = new System.Windows.Forms.TextBox();
            this.labelTotalPuntos = new System.Windows.Forms.Label();
            this.labelResultadoPuntos = new System.Windows.Forms.Label();
            this.labelPuntosDetallados = new System.Windows.Forms.Label();
            this.labelCanjesRealizados = new System.Windows.Forms.Label();
            this.dataGridViewPuntosDetallados = new System.Windows.Forms.DataGridView();
            this.dataGridViewCanjesRealizados = new System.Windows.Forms.DataGridView();
            this.Premio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puntos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPuntosDetallados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCanjesRealizados)).BeginInit();
            this.SuspendLayout();
            // 
            // consultarDni
            // 
            this.consultarDni.Location = new System.Drawing.Point(274, 28);
            this.consultarDni.Name = "consultarDni";
            this.consultarDni.Size = new System.Drawing.Size(75, 23);
            this.consultarDni.TabIndex = 0;
            this.consultarDni.Text = "Consultar";
            this.consultarDni.UseVisualStyleBackColor = true;
            this.consultarDni.Click += new System.EventHandler(this.consultarDni_Click);
            // 
            // labelDni
            // 
            this.labelDni.AutoSize = true;
            this.labelDni.Location = new System.Drawing.Point(28, 28);
            this.labelDni.Name = "labelDni";
            this.labelDni.Size = new System.Drawing.Size(98, 13);
            this.labelDni.TabIndex = 1;
            this.labelDni.Text = "Ingrese n° de DNI: ";
            // 
            // textBoxDni
            // 
            this.textBoxDni.Location = new System.Drawing.Point(132, 28);
            this.textBoxDni.Name = "textBoxDni";
            this.textBoxDni.Size = new System.Drawing.Size(100, 20);
            this.textBoxDni.TabIndex = 2;
            // 
            // labelTotalPuntos
            // 
            this.labelTotalPuntos.AutoSize = true;
            this.labelTotalPuntos.Location = new System.Drawing.Point(31, 62);
            this.labelTotalPuntos.Name = "labelTotalPuntos";
            this.labelTotalPuntos.Size = new System.Drawing.Size(107, 13);
            this.labelTotalPuntos.TabIndex = 3;
            this.labelTotalPuntos.Text = "Puntos Acumulados: ";
            // 
            // labelResultadoPuntos
            // 
            this.labelResultadoPuntos.AutoSize = true;
            this.labelResultadoPuntos.Location = new System.Drawing.Point(177, 62);
            this.labelResultadoPuntos.Name = "labelResultadoPuntos";
            this.labelResultadoPuntos.Size = new System.Drawing.Size(0, 13);
            this.labelResultadoPuntos.TabIndex = 4;
            // 
            // labelPuntosDetallados
            // 
            this.labelPuntosDetallados.AutoSize = true;
            this.labelPuntosDetallados.Location = new System.Drawing.Point(13, 104);
            this.labelPuntosDetallados.Name = "labelPuntosDetallados";
            this.labelPuntosDetallados.Size = new System.Drawing.Size(93, 13);
            this.labelPuntosDetallados.TabIndex = 5;
            this.labelPuntosDetallados.Text = "Puntos Detallados";
            // 
            // labelCanjesRealizados
            // 
            this.labelCanjesRealizados.AutoSize = true;
            this.labelCanjesRealizados.Location = new System.Drawing.Point(247, 104);
            this.labelCanjesRealizados.Name = "labelCanjesRealizados";
            this.labelCanjesRealizados.Size = new System.Drawing.Size(94, 13);
            this.labelCanjesRealizados.TabIndex = 6;
            this.labelCanjesRealizados.Text = "Canjes Realizados";
            // 
            // dataGridViewPuntosDetallados
            // 
            this.dataGridViewPuntosDetallados.AllowUserToAddRows = false;
            this.dataGridViewPuntosDetallados.AllowUserToDeleteRows = false;
            this.dataGridViewPuntosDetallados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPuntosDetallados.Location = new System.Drawing.Point(10, 125);
            this.dataGridViewPuntosDetallados.Name = "dataGridViewPuntosDetallados";
            this.dataGridViewPuntosDetallados.ReadOnly = true;
            this.dataGridViewPuntosDetallados.Size = new System.Drawing.Size(220, 150);
            this.dataGridViewPuntosDetallados.TabIndex = 7;
            // 
            // dataGridViewCanjesRealizados
            // 
            this.dataGridViewCanjesRealizados.AllowUserToAddRows = false;
            this.dataGridViewCanjesRealizados.AllowUserToDeleteRows = false;
            this.dataGridViewCanjesRealizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCanjesRealizados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Premio,
            this.Puntos,
            this.Fecha,
            this.Cantidad});
            this.dataGridViewCanjesRealizados.Location = new System.Drawing.Point(244, 125);
            this.dataGridViewCanjesRealizados.Name = "dataGridViewCanjesRealizados";
            this.dataGridViewCanjesRealizados.ReadOnly = true;
            this.dataGridViewCanjesRealizados.Size = new System.Drawing.Size(226, 150);
            this.dataGridViewCanjesRealizados.TabIndex = 8;
            // 
            // Premio
            // 
            this.Premio.Frozen = true;
            this.Premio.HeaderText = "Premio";
            this.Premio.Name = "Premio";
            this.Premio.ReadOnly = true;
            // 
            // Puntos
            // 
            this.Puntos.Frozen = true;
            this.Puntos.HeaderText = "Puntos";
            this.Puntos.Name = "Puntos";
            this.Puntos.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.Frozen = true;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.Frozen = true;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Abm_Consulta_Puntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 289);
            this.Controls.Add(this.dataGridViewCanjesRealizados);
            this.Controls.Add(this.dataGridViewPuntosDetallados);
            this.Controls.Add(this.labelCanjesRealizados);
            this.Controls.Add(this.labelPuntosDetallados);
            this.Controls.Add(this.labelResultadoPuntos);
            this.Controls.Add(this.labelTotalPuntos);
            this.Controls.Add(this.textBoxDni);
            this.Controls.Add(this.labelDni);
            this.Controls.Add(this.consultarDni);
            this.Name = "Abm_Consulta_Puntos";
            this.Text = "Consulta de Puntos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPuntosDetallados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCanjesRealizados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button consultarDni;
        private System.Windows.Forms.Label labelDni;
        private System.Windows.Forms.TextBox textBoxDni;
        private System.Windows.Forms.Label labelTotalPuntos;
        private System.Windows.Forms.Label labelResultadoPuntos;
        private System.Windows.Forms.Label labelPuntosDetallados;
        private System.Windows.Forms.Label labelCanjesRealizados;
        private System.Windows.Forms.DataGridView dataGridViewPuntosDetallados;
        private System.Windows.Forms.DataGridView dataGridViewCanjesRealizados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Premio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puntos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
    }
}