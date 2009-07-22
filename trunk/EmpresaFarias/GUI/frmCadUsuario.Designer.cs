namespace GUI
{
    partial class frmCadUsuario
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
            this.components = new System.ComponentModel.Container();
            this.stInformacaoGeral = new System.Windows.Forms.StatusStrip();
            this.lbInformacaoGeral = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlMensagem = new System.Windows.Forms.ToolTip(this.components);
            this.bsUsuario = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lbLocalizar = new System.Windows.Forms.ToolStripLabel();
            this.txtLocalizar = new System.Windows.Forms.ToolStripTextBox();
            this.tlPrincipal = new System.Windows.Forms.ToolStrip();
            this.btnNovo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAlterar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrimeiro = new System.Windows.Forms.ToolStripButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripButton();
            this.btnProximo = new System.Windows.Forms.ToolStripButton();
            this.btnUltimo = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tabUsuario = new System.Windows.Forms.TabPage();
            this.lblPerfilUsuario = new System.Windows.Forms.Label();
            this.lstPerfilUsuario = new System.Windows.Forms.ListBox();
            this.btnRemoverPerfil = new System.Windows.Forms.Button();
            this.btnAdicionarPerfil = new System.Windows.Forms.Button();
            this.lblPerfilDisponivel = new System.Windows.Forms.Label();
            this.cmbPerfil = new System.Windows.Forms.ComboBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtConfirmarSenha = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblConfirmarSenha = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.btnVerificarLogin = new System.Windows.Forms.Button();
            this.tbcUsuario = new System.Windows.Forms.TabControl();
            this.stInformacaoGeral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuario)).BeginInit();
            this.tlPrincipal.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabUsuario.SuspendLayout();
            this.tbcUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // stInformacaoGeral
            // 
            this.stInformacaoGeral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbInformacaoGeral});
            this.stInformacaoGeral.Location = new System.Drawing.Point(0, 321);
            this.stInformacaoGeral.Name = "stInformacaoGeral";
            this.stInformacaoGeral.Size = new System.Drawing.Size(433, 22);
            this.stInformacaoGeral.TabIndex = 140;
            // 
            // lbInformacaoGeral
            // 
            this.lbInformacaoGeral.Name = "lbInformacaoGeral";
            this.lbInformacaoGeral.Size = new System.Drawing.Size(68, 17);
            this.lbInformacaoGeral.Text = "informação";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 36);
            this.toolStripButton1.ToolTipText = "Clique aqui para incluir um novo empregado";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 36);
            this.toolStripButton2.ToolTipText = "Clique aqui para cancelar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 36);
            this.toolStripButton3.ToolTipText = "Clique aqui para alterar";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // lbLocalizar
            // 
            this.lbLocalizar.Name = "lbLocalizar";
            this.lbLocalizar.Size = new System.Drawing.Size(43, 36);
            this.lbLocalizar.Text = "Nome:";
            // 
            // txtLocalizar
            // 
            this.txtLocalizar.Name = "txtLocalizar";
            this.txtLocalizar.Size = new System.Drawing.Size(200, 39);
            this.txtLocalizar.ToolTipText = "Informe o nome ou parte dele para localiza-lo";
            // 
            // tlPrincipal
            // 
            this.tlPrincipal.Dock = System.Windows.Forms.DockStyle.None;
            this.tlPrincipal.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tlPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNovo,
            this.toolStripSeparator3,
            this.btnSalvar,
            this.btnCancelar,
            this.toolStripSeparator5,
            this.btnAlterar,
            this.btnExcluir,
            this.toolStripSeparator6});
            this.tlPrincipal.Location = new System.Drawing.Point(4, 9);
            this.tlPrincipal.Name = "tlPrincipal";
            this.tlPrincipal.Size = new System.Drawing.Size(304, 25);
            this.tlPrincipal.TabIndex = 141;
            this.tlPrincipal.Text = "toolStrip1";
            // 
            // btnNovo
            // 
            this.btnNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(40, 22);
            this.btnNovo.Tag = "101";
            this.btnNovo.Text = "Novo";
            this.btnNovo.ToolTipText = "Clique aqui para incluir um novo empregado";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSalvar
            // 
            this.btnSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(42, 22);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.ToolTipText = "Clique aqui para confirmar";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(57, 22);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ToolTipText = "Clique aqui para cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAlterar
            // 
            this.btnAlterar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(46, 22);
            this.btnAlterar.Tag = "201";
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.ToolTipText = "Clique aqui para alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(58, 22);
            this.btnExcluir.Tag = "301";
            this.btnExcluir.Text = "Remover";
            this.btnExcluir.ToolTipText = "Clique aqui para remover";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrimeiro
            // 
            this.btnPrimeiro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrimeiro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrimeiro.Name = "btnPrimeiro";
            this.btnPrimeiro.Size = new System.Drawing.Size(27, 22);
            this.btnPrimeiro.Text = "<<";
            this.btnPrimeiro.ToolTipText = "Vai para o proximo elemento";
            this.btnPrimeiro.Click += new System.EventHandler(this.btnPrimeiro_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(23, 22);
            this.btnAnterior.Text = "<";
            this.btnAnterior.ToolTipText = "Vai para o último elemento";
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnProximo
            // 
            this.btnProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnProximo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(23, 22);
            this.btnProximo.Text = ">";
            this.btnProximo.ToolTipText = "Vai para o elemento anterior";
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // btnUltimo
            // 
            this.btnUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(27, 22);
            this.btnUltimo.Text = ">>";
            this.btnUltimo.ToolTipText = "Vai para o primeiro elemento";
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrimeiro,
            this.btnAnterior,
            this.btnProximo,
            this.btnUltimo});
            this.toolStrip1.Location = new System.Drawing.Point(145, 273);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(112, 25);
            this.toolStrip1.TabIndex = 166;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tabUsuario
            // 
            this.tabUsuario.Controls.Add(this.lblPerfilUsuario);
            this.tabUsuario.Controls.Add(this.lstPerfilUsuario);
            this.tabUsuario.Controls.Add(this.btnRemoverPerfil);
            this.tabUsuario.Controls.Add(this.btnAdicionarPerfil);
            this.tabUsuario.Controls.Add(this.lblPerfilDisponivel);
            this.tabUsuario.Controls.Add(this.cmbPerfil);
            this.tabUsuario.Controls.Add(this.txtNome);
            this.tabUsuario.Controls.Add(this.txtConfirmarSenha);
            this.tabUsuario.Controls.Add(this.txtSenha);
            this.tabUsuario.Controls.Add(this.txtLogin);
            this.tabUsuario.Controls.Add(this.lblNome);
            this.tabUsuario.Controls.Add(this.lblConfirmarSenha);
            this.tabUsuario.Controls.Add(this.lblLogin);
            this.tabUsuario.Controls.Add(this.lblSenha);
            this.tabUsuario.Controls.Add(this.btnVerificarLogin);
            this.tabUsuario.Location = new System.Drawing.Point(4, 22);
            this.tabUsuario.Name = "tabUsuario";
            this.tabUsuario.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsuario.Size = new System.Drawing.Size(424, 197);
            this.tabUsuario.TabIndex = 0;
            this.tabUsuario.Text = "Usuario";
            this.tabUsuario.UseVisualStyleBackColor = true;
            // 
            // lblPerfilUsuario
            // 
            this.lblPerfilUsuario.AutoSize = true;
            this.lblPerfilUsuario.Location = new System.Drawing.Point(5, 114);
            this.lblPerfilUsuario.Name = "lblPerfilUsuario";
            this.lblPerfilUsuario.Size = new System.Drawing.Size(81, 13);
            this.lblPerfilUsuario.TabIndex = 15;
            this.lblPerfilUsuario.Text = "Perfis Utilizados";
            // 
            // lstPerfilUsuario
            // 
            this.lstPerfilUsuario.FormattingEnabled = true;
            this.lstPerfilUsuario.Location = new System.Drawing.Point(101, 114);
            this.lstPerfilUsuario.Name = "lstPerfilUsuario";
            this.lstPerfilUsuario.Size = new System.Drawing.Size(236, 69);
            this.lstPerfilUsuario.TabIndex = 14;
            this.lstPerfilUsuario.SelectedIndexChanged += new System.EventHandler(this.lstPerfilUsuario_SelectedIndexChanged);
            // 
            // btnRemoverPerfil
            // 
            this.btnRemoverPerfil.Location = new System.Drawing.Point(343, 112);
            this.btnRemoverPerfil.Name = "btnRemoverPerfil";
            this.btnRemoverPerfil.Size = new System.Drawing.Size(24, 23);
            this.btnRemoverPerfil.TabIndex = 13;
            this.btnRemoverPerfil.Text = "-";
            this.btnRemoverPerfil.UseVisualStyleBackColor = true;
            this.btnRemoverPerfil.Click += new System.EventHandler(this.btnRemoverPerfil_Click);
            // 
            // btnAdicionarPerfil
            // 
            this.btnAdicionarPerfil.Location = new System.Drawing.Point(342, 88);
            this.btnAdicionarPerfil.Name = "btnAdicionarPerfil";
            this.btnAdicionarPerfil.Size = new System.Drawing.Size(24, 23);
            this.btnAdicionarPerfil.TabIndex = 12;
            this.btnAdicionarPerfil.Text = "+";
            this.btnAdicionarPerfil.UseVisualStyleBackColor = true;
            this.btnAdicionarPerfil.Click += new System.EventHandler(this.btnAdicionarPerfil_Click);
            // 
            // lblPerfilDisponivel
            // 
            this.lblPerfilDisponivel.AutoSize = true;
            this.lblPerfilDisponivel.Location = new System.Drawing.Point(5, 93);
            this.lblPerfilDisponivel.Name = "lblPerfilDisponivel";
            this.lblPerfilDisponivel.Size = new System.Drawing.Size(90, 13);
            this.lblPerfilDisponivel.TabIndex = 11;
            this.lblPerfilDisponivel.Text = "Perfis Disponivies";
            // 
            // cmbPerfil
            // 
            this.cmbPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerfil.FormattingEnabled = true;
            this.cmbPerfil.Location = new System.Drawing.Point(101, 90);
            this.cmbPerfil.Name = "cmbPerfil";
            this.cmbPerfil.Size = new System.Drawing.Size(236, 21);
            this.cmbPerfil.TabIndex = 10;
            this.cmbPerfil.SelectedIndexChanged += new System.EventHandler(this.cmbPerfil_SelectedIndexChanged);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(44, 6);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(323, 20);
            this.txtNome.TabIndex = 0;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // txtConfirmarSenha
            // 
            this.txtConfirmarSenha.Location = new System.Drawing.Point(245, 59);
            this.txtConfirmarSenha.Name = "txtConfirmarSenha";
            this.txtConfirmarSenha.PasswordChar = '*';
            this.txtConfirmarSenha.Size = new System.Drawing.Size(121, 20);
            this.txtConfirmarSenha.TabIndex = 4;
            this.txtConfirmarSenha.TextChanged += new System.EventHandler(this.txtConfirmarSenha_TextChanged);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(44, 59);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(122, 20);
            this.txtSenha.TabIndex = 3;
            this.txtSenha.TextChanged += new System.EventHandler(this.txtSenha_TextChanged);
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(44, 33);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(240, 20);
            this.txtLogin.TabIndex = 1;
            this.txtLogin.TextChanged += new System.EventHandler(this.txtLogin_TextChanged);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(5, 9);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome";
            // 
            // lblConfirmarSenha
            // 
            this.lblConfirmarSenha.AutoSize = true;
            this.lblConfirmarSenha.Location = new System.Drawing.Point(181, 59);
            this.lblConfirmarSenha.Name = "lblConfirmarSenha";
            this.lblConfirmarSenha.Size = new System.Drawing.Size(48, 13);
            this.lblConfirmarSenha.TabIndex = 9;
            this.lblConfirmarSenha.Text = "Confirme";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(5, 35);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(33, 13);
            this.lblLogin.TabIndex = 4;
            this.lblLogin.Text = "Login";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(5, 59);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(38, 13);
            this.lblSenha.TabIndex = 7;
            this.lblSenha.Text = "Senha";
            // 
            // btnVerificarLogin
            // 
            this.btnVerificarLogin.Enabled = false;
            this.btnVerificarLogin.Location = new System.Drawing.Point(289, 32);
            this.btnVerificarLogin.Name = "btnVerificarLogin";
            this.btnVerificarLogin.Size = new System.Drawing.Size(77, 20);
            this.btnVerificarLogin.TabIndex = 2;
            this.btnVerificarLogin.Text = "Verificar";
            this.btnVerificarLogin.UseVisualStyleBackColor = true;
            this.btnVerificarLogin.Click += new System.EventHandler(this.btnVerificarLogin_Click);
            // 
            // tbcUsuario
            // 
            this.tbcUsuario.Controls.Add(this.tabUsuario);
            this.tbcUsuario.Location = new System.Drawing.Point(0, 47);
            this.tbcUsuario.Name = "tbcUsuario";
            this.tbcUsuario.SelectedIndex = 0;
            this.tbcUsuario.Size = new System.Drawing.Size(432, 223);
            this.tbcUsuario.TabIndex = 11;
            // 
            // frmCadUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 343);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tlPrincipal);
            this.Controls.Add(this.stInformacaoGeral);
            this.Controls.Add(this.tbcUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCadUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formulário de Cadastro de Usuário";
            this.Load += new System.EventHandler(this.frmCadUsuario_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCadUsuario_FormClosing);
            this.stInformacaoGeral.ResumeLayout(false);
            this.stInformacaoGeral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuario)).EndInit();
            this.tlPrincipal.ResumeLayout(false);
            this.tlPrincipal.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabUsuario.ResumeLayout(false);
            this.tabUsuario.PerformLayout();
            this.tbcUsuario.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stInformacaoGeral;
        private System.Windows.Forms.ToolStripStatusLabel lbInformacaoGeral;
        private System.Windows.Forms.ToolTip tlMensagem;
        private System.Windows.Forms.BindingSource bsUsuario;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lbLocalizar;
        private System.Windows.Forms.ToolStripTextBox txtLocalizar;
        private System.Windows.Forms.ToolStrip tlPrincipal;
        private System.Windows.Forms.ToolStripButton btnNovo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnAlterar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnPrimeiro;
        private System.Windows.Forms.ToolStripButton btnAnterior;
        private System.Windows.Forms.ToolStripButton btnProximo;
        private System.Windows.Forms.ToolStripButton btnUltimo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabPage tabUsuario;
        private System.Windows.Forms.Label lblPerfilUsuario;
        private System.Windows.Forms.ListBox lstPerfilUsuario;
        private System.Windows.Forms.Button btnRemoverPerfil;
        private System.Windows.Forms.Button btnAdicionarPerfil;
        private System.Windows.Forms.Label lblPerfilDisponivel;
        private System.Windows.Forms.ComboBox cmbPerfil;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtConfirmarSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblConfirmarSenha;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Button btnVerificarLogin;
        private System.Windows.Forms.TabControl tbcUsuario;
    }
}