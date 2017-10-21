namespace Agencia
{
    partial class frmControlVentanas
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.frmCatalogos1 = new Agencia.frmCatalogos();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.frmCatalogos1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(927, 617);
            this.panel1.TabIndex = 0;
            // 
            // frmCatalogos1
            // 
            this.frmCatalogos1.Location = new System.Drawing.Point(0, 0);
            this.frmCatalogos1.Name = "frmCatalogos1";
            this.frmCatalogos1.Size = new System.Drawing.Size(927, 617);
            this.frmCatalogos1.TabIndex = 0;
            this.frmCatalogos1.Load += new System.EventHandler(this.frmCatalogos1_Load);
            // 
            // frmControlVentanas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "frmControlVentanas";
            this.Size = new System.Drawing.Size(927, 617);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private frmCatalogos frmCatalogos1;
    }
}
