namespace GUI
{
    partial class frmPrincipal
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
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeTitularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deNovoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.outroToolStripMenuItem,
            this.deNovoToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(605, 24);
            this.menuPrincipal.TabIndex = 5;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logarToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // logarToolStripMenuItem
            // 
            this.logarToolStripMenuItem.Name = "logarToolStripMenuItem";
            this.logarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.logarToolStripMenuItem.Text = "Logar";
            this.logarToolStripMenuItem.Click += new System.EventHandler(this.logarToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // outroToolStripMenuItem
            // 
            this.outroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroDeUsuarioToolStripMenuItem,
            this.cadastroDeTitularToolStripMenuItem});
            this.outroToolStripMenuItem.Name = "outroToolStripMenuItem";
            this.outroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.outroToolStripMenuItem.Text = "Cadastro";
            // 
            // cadastroDeUsuarioToolStripMenuItem
            // 
            this.cadastroDeUsuarioToolStripMenuItem.Name = "cadastroDeUsuarioToolStripMenuItem";
            this.cadastroDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastroDeUsuarioToolStripMenuItem.Tag = "001";
            this.cadastroDeUsuarioToolStripMenuItem.Text = "Cadastro de Usuario";
            this.cadastroDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeUsuarioToolStripMenuItem_Click);
            // 
            // cadastroDeTitularToolStripMenuItem
            // 
            this.cadastroDeTitularToolStripMenuItem.Name = "cadastroDeTitularToolStripMenuItem";
            this.cadastroDeTitularToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastroDeTitularToolStripMenuItem.Text = "Cadastro de Titular";
            this.cadastroDeTitularToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeTitularToolStripMenuItem_Click);
            // 
            // deNovoToolStripMenuItem
            // 
            this.deNovoToolStripMenuItem.Name = "deNovoToolStripMenuItem";
            this.deNovoToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.deNovoToolStripMenuItem.Text = "Relatorio";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 264);
            this.Controls.Add(this.menuPrincipal);
            this.Name = "frmPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDeTitularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deNovoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;

    }
}

