namespace GUI
{
    partial class frmRelatorioTitular
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
            this.crwRelatorioTitular = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crwRelatorioTitular
            // 
            this.crwRelatorioTitular.ActiveViewIndex = -1;
            this.crwRelatorioTitular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crwRelatorioTitular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crwRelatorioTitular.Location = new System.Drawing.Point(0, 0);
            this.crwRelatorioTitular.Name = "crwRelatorioTitular";
            this.crwRelatorioTitular.SelectionFormula = "";
            this.crwRelatorioTitular.Size = new System.Drawing.Size(732, 520);
            this.crwRelatorioTitular.TabIndex = 0;
            this.crwRelatorioTitular.ViewTimeSelectionFormula = "";
            this.crwRelatorioTitular.Load += new System.EventHandler(this.crwRelatorioTitular_Load);
            // 
            // frmRelatorioTitular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 520);
            this.Controls.Add(this.crwRelatorioTitular);
            this.Name = "frmRelatorioTitular";
            this.Text = "frmRelatorioTitular";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crwRelatorioTitular;
    }
}