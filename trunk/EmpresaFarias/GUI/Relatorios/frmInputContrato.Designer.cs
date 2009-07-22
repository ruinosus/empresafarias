namespace GUI.Relatorios
{
    partial class frmInputContrato
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
            this.txtContrato = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGerarContrato = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtContrato
            // 
            this.txtContrato.Location = new System.Drawing.Point(12, 61);
            this.txtContrato.Name = "txtContrato";
            this.txtContrato.Size = new System.Drawing.Size(169, 20);
            this.txtContrato.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Digite o nº do Contrato do Titular desejado";
            // 
            // btnGerarContrato
            // 
            this.btnGerarContrato.Image = global::GUI.Properties.Resources.invoice_48x48;
            this.btnGerarContrato.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGerarContrato.Location = new System.Drawing.Point(187, 36);
            this.btnGerarContrato.Name = "btnGerarContrato";
            this.btnGerarContrato.Size = new System.Drawing.Size(144, 68);
            this.btnGerarContrato.TabIndex = 1;
            this.btnGerarContrato.Text = "Gerar Contrato";
            this.btnGerarContrato.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGerarContrato.UseVisualStyleBackColor = true;
            this.btnGerarContrato.Click += new System.EventHandler(this.btnGerarContrato_Click);
            // 
            // frmInputContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 111);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContrato);
            this.Controls.Add(this.btnGerarContrato);
            this.Name = "frmInputContrato";
            this.Text = "frmInputContrato";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGerarContrato;
        private System.Windows.Forms.TextBox txtContrato;
        private System.Windows.Forms.Label label1;
    }
}