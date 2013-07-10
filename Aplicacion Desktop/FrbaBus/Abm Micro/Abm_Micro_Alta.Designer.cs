namespace FrbaBus.Abm_Micro
{
    partial class Abm_Micro_Alta
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
            this.textBoxPatente = new System.Windows.Forms.TextBox();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.labelPatente = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPatente
            // 
            this.textBoxPatente.Location = new System.Drawing.Point(123, 12);
            this.textBoxPatente.Name = "textBoxPatente";
            this.textBoxPatente.Size = new System.Drawing.Size(100, 20);
            this.textBoxPatente.TabIndex = 0;
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(26, 223);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 1;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // labelPatente
            // 
            this.labelPatente.AutoSize = true;
            this.labelPatente.Location = new System.Drawing.Point(12, 15);
            this.labelPatente.Name = "labelPatente";
            this.labelPatente.Size = new System.Drawing.Size(91, 13);
            this.labelPatente.TabIndex = 2;
            this.labelPatente.Text = "Ingresar Patente: ";
            // 
            // Abm_Micro_Alta
            // 
            this.AcceptButton = this.buttonAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.labelPatente);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.textBoxPatente);
            this.Name = "Abm_Micro_Alta";
            this.Text = "Alta de Micro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPatente;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Label labelPatente;
    }
}