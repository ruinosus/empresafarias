using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using ClassesBasicas;

namespace GUI
{
    public partial class frmCadUsuario : Form
    {
        Fachada fachada = Fachada.Instance;
        Status status = Status.Inativo;
        Usuario usuario;
        Usuario usuarioAtual;
        List<Usuario> usuarios;
        List<Perfil> perfisExistentes;
        List<Perfil> perfisUsuario;

        public frmCadUsuario()
        {
            InitializeComponent();
        }

        private void HabilitaSalvar()
        {
            if (status != Status.Alteracao)
            {
                btnSalvar.Enabled = (txtNome.Text.Trim() != "") &&
                                    (txtSenha.Text.Trim() != "") &&
                                    (txtConfirmarSenha.Text.Equals(txtSenha.Text)) &&
                                    txtLogin.Text != String.Empty &&
                                    !fachada.ControladorUsuario.Consultar(txtLogin.Text);
            }
            else
            {
                btnSalvar.Enabled = (txtNome.Text.Trim() != "") &&
                                    (txtSenha.Text.Trim() != "") &&
                                    (txtConfirmarSenha.Text.Equals(txtSenha.Text));
            }

        }

        private void AdicionarPerfil()
        {
            btnAdicionarPerfil.Enabled = cmbPerfil.Items.Count > 0;

        }

        private void RemoverPerfil()
        {
            btnRemoverPerfil.Enabled = (lstPerfilUsuario.Items.Count > 0) && lstPerfilUsuario.SelectedIndex > -1;

        }

        private void CarregarPerfilUsuario()
        {
            //lstLocalidades.Items.Clear();
            lstPerfilUsuario.DataSource = perfisUsuario;
            lstPerfilUsuario.DisplayMember = "Descricao";
            lstPerfilUsuario.ValueMember = "Id";
        }

        private void LimparPerfilUsuario()
        {
            lstPerfilUsuario.DataSource = null;
            lstPerfilUsuario.Items.Clear();
            //lstLocalidades.DisplayMember = "Nome";
            //lstLocalidades.ValueMember = "Codigo";

        }

        private void AjustarBotoes()
        {
            AjustarEdits();
            switch (status)
            {
                case Status.Inativo:
                    {
                        btnAnterior.Enabled = false;
                        btnCancelar.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnNovo.Enabled = true;
                        btnPrimeiro.Enabled = false;
                        btnProximo.Enabled = false;
                        btnUltimo.Enabled = false;
                        btnExcluir.Enabled = false;
                        btnAlterar.Enabled = false;
                        btnVerificarLogin.Enabled = false;
                        btnAdicionarPerfil.Enabled = false;
                        btnRemoverPerfil.Enabled = false;

                        break;
                    }
                case Status.Alteracao:
                    {
                        //btnAdicionarPerfil.Enabled = false;
                        //btnRemoverPerfil.Enabled = false;
                        btnAnterior.Enabled = false;
                        btnCancelar.Enabled = true;
                        //btnSalvar.Enabled = true;
                        btnNovo.Enabled = false;
                        btnPrimeiro.Enabled = false;
                        btnProximo.Enabled = false;
                        btnUltimo.Enabled = false;
                        btnExcluir.Enabled = false;
                        btnAlterar.Enabled = false;
                       // btnVerificarLogin.Enabled = true;
                        break;
                    }
                case Status.Inclusao:
                    {
                        //btnAdicionarPerfil.Enabled = false;
                        //btnRemoverPerfil.Enabled = false;
                        btnAnterior.Enabled = false;
                        btnCancelar.Enabled = true;
                        //btnSalvar.Enabled = true;
                        btnNovo.Enabled = false;
                        btnPrimeiro.Enabled = false;
                        btnProximo.Enabled = false;
                        btnUltimo.Enabled = false;
                        btnExcluir.Enabled = false;
                        btnAlterar.Enabled = false;
                        //btnVerificarLogin.Enabled = true;
                        break;
                    }
                case Status.Navegacao:
                    {
                        btnAdicionarPerfil.Enabled = false;
                        btnRemoverPerfil.Enabled = false;
                        btnAnterior.Enabled = bsUsuario.Position > 0;
                        btnCancelar.Enabled = false;
                        //btnSalvar.Enabled = false;
                        btnNovo.Enabled = true;
                        btnPrimeiro.Enabled = bsUsuario.Position > 0;
                        btnProximo.Enabled = bsUsuario.Position + 1 < bsUsuario.Count;
                        btnUltimo.Enabled = bsUsuario.Position + 1 < bsUsuario.Count;

                        btnExcluir.Enabled = bsUsuario.Count > 0;
                        btnAlterar.Enabled = bsUsuario.Count > 0;
                        btnVerificarLogin.Enabled = false;
                        break;
                    }                    
            }
            

        }

        private void AjustarEdits()
        {
            //Consultando todos os usuarios cadastrados.
            usuarios = fachada.ControladorUsuario.Consultar();
            bsUsuario.DataSource = usuarios;
            //Carregando os Perfis disponiveis.
            perfisExistentes = fachada.ControladorUsuario.ConsultarPerfil();
            if (perfisExistentes.Count > 0)
            {
                cmbPerfil.DataSource = perfisExistentes;
                cmbPerfil.DisplayMember = "Descricao";
                cmbPerfil.ValueMember = "Id";
            }
            switch (status)
            {
                case Status.Inativo:
                    {
                        txtConfirmarSenha.ReadOnly = true;
                        txtLogin.ReadOnly = true;
                        txtNome.ReadOnly = true;
                        txtSenha.ReadOnly = true;

                        lstPerfilUsuario.Enabled = false;
                        cmbPerfil.Enabled = false;
                        //cmbPerfil.Items.Clear();
                        LimparPerfilUsuario();
                        perfisUsuario = null;

                        break;
                    }
                case Status.Alteracao:
                    {
                        txtConfirmarSenha.ReadOnly = false;
                        txtLogin.ReadOnly = true;
                        txtNome.ReadOnly = false;
                        txtSenha.ReadOnly = false;

                        lstPerfilUsuario.Enabled = true;
                        cmbPerfil.Enabled = true;
                        if (perfisUsuario.Count > 0)
                        {
                            LimparPerfilUsuario();
                            CarregarPerfilUsuario();
                        }
                        break;
                    }
                case Status.Inclusao:
                    {
                        txtConfirmarSenha.ReadOnly = false;
                        txtLogin.ReadOnly = false;
                        txtNome.ReadOnly = false;
                        txtSenha.ReadOnly = false;
                        txtConfirmarSenha.Clear();
                        txtLogin.Clear();
                        txtNome.Clear();
                        txtSenha.Clear();

                        lstPerfilUsuario.Enabled = true;
                        cmbPerfil.Enabled = true;
                        //AjustaLista();
                        perfisUsuario = new List<Perfil>();

                        LimparPerfilUsuario();
                        break;
                    }
                case Status.Navegacao:
                    {
                        txtConfirmarSenha.Clear();
                        txtLogin.Clear();
                        txtNome.Clear();
                        txtSenha.Clear();
                        txtConfirmarSenha.ReadOnly = true;
                        txtLogin.ReadOnly = true;
                        txtNome.ReadOnly = true;
                        txtSenha.ReadOnly = true;

                        lstPerfilUsuario.Enabled = false;
                        cmbPerfil.Enabled = false;
                        if (usuarios.Count > 0)
                        {
                            usuarioAtual = (Usuario)usuarios[bsUsuario.Position];

                            txtLogin.Text = usuarioAtual.Login;
                            txtNome.Text = usuarioAtual.Nome;
                            txtSenha.Text = usuarioAtual.Senha;
                            txtConfirmarSenha.Text = usuarioAtual.Senha;
                            if(usuarioAtual.Perfis.Count > 0)
                            {
                                perfisUsuario = usuarioAtual.Perfis;
                                CarregarPerfilUsuario();
                            }
                            else
                            {
                                perfisUsuario = new List<Perfil>();
                                LimparPerfilUsuario();
                            }
                            
                        }
                        
                        
                        break;
                    }
            }

        }

        private void frmCadUsuario_Load(object sender, EventArgs e)
        {
            if (fachada.ControladorUsuario.Consultar().Count > 0)
            {
                status = Status.Navegacao;
            }
            else
            {
                status = Status.Inativo;
            }
            usuario = fachada.Usuario;
            AjustarBotoes();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            status = Status.Inclusao;

            AjustarBotoes();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                switch (status)
                {
                    case Status.Inclusao:
                        {
                            Usuario u = new Usuario();
                            u.Nome = txtNome.Text;
                            u.Senha = txtSenha.Text;
                            u.Login = txtLogin.Text;
                            if (lstPerfilUsuario.Items.Count > 0)
                            {
                                for (int i = 0; i < lstPerfilUsuario.Items.Count; i++)
                                {
                                    u.Perfis.Add((Perfil)lstPerfilUsuario.Items[i]);
                                }
                            }
                            fachada.ControladorUsuario.Inserir(u);
                            status = Status.Navegacao;
                            AjustarBotoes();
                            break;
                        }
                    case Status.Alteracao:
                        {
                            //Usuario u = new Usuario();
                            usuarioAtual.Nome = txtNome.Text;
                            usuarioAtual.Senha = txtSenha.Text;
                            usuarioAtual.Login = txtLogin.Text;
                            usuarioAtual.Perfis.Clear();
                            if (lstPerfilUsuario.Items.Count > 0)
                            {
                                for (int i = 0; i < lstPerfilUsuario.Items.Count; i++)
                                {
                                    usuarioAtual.Perfis.Add((Perfil)lstPerfilUsuario.Items[i]);
                                }
                            }
                            fachada.ControladorUsuario.Alterar(usuarioAtual);
                            status = Status.Navegacao;
                            AjustarBotoes();
                            break;
                        }

                
                }
                
            }
            catch (ExcecaoNegocio ex)
            {
                tlMensagem.ToolTipTitle = "Erro!";
                tlMensagem.Show(ex.Message,txtNome);
            }
            catch (Exception exc)
            {
                tlMensagem.ToolTipTitle = "Erro!";
                tlMensagem.Show(exc.Message, txtNome);
            }

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            status = Status.Navegacao;
            AjustarBotoes();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            status = Status.Alteracao;
            AjustarBotoes();
            HabilitaSalvar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Tem certeza que deseja remover?", "Confirmação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (d.ToString() == "Yes")
            {
                usuarioAtual.Status = StatusUsuario.Inativo;
                fachada.ControladorUsuario.Alterar(usuarioAtual);
                System.Windows.Forms.MessageBox.Show("Usuario Removido com sucesso.");
                status = Status.Navegacao;
                AjustarBotoes();
            } 
            
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            status = Status.Navegacao;
            bsUsuario.MoveFirst();
            AjustarBotoes();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            status = Status.Navegacao;
            bsUsuario.MovePrevious();
            AjustarBotoes();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            status = Status.Navegacao;
            bsUsuario.MoveNext();
            AjustarBotoes();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            status = Status.Navegacao;
            bsUsuario.MoveLast();
            AjustarBotoes();
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            btnVerificarLogin.Enabled = txtLogin.Text.Trim() != "";
            btnVerificarLogin.Text = "Verificar";
            btnSalvar.Enabled = false;
        }

        private void btnVerificarLogin_Click(object sender, EventArgs e)
        {
            if (!fachada.ControladorUsuario.Consultar(txtLogin.Text))
            {
                btnVerificarLogin.Enabled = false;
                btnVerificarLogin.Text = "Login Válido";
            }
            else
            {
                tlMensagem.ToolTipTitle = "Valor Inválido";
                tlMensagem.Show("Login já encontrado no sistema, informe outro.", txtLogin);
                txtLogin.Focus();
            }
            HabilitaSalvar();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            HabilitaSalvar();
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            HabilitaSalvar();
        }

        private void txtConfirmarSenha_TextChanged(object sender, EventArgs e)
        {
            HabilitaSalvar();
        }

        private void btnAdicionarPerfil_Click(object sender, EventArgs e)
        {
            bool achou = false;

            for (int i = 0; i < lstPerfilUsuario.Items.Count; i++)
            {
                if (((Perfil)lstPerfilUsuario.Items[i]).Id == ((Perfil)cmbPerfil.Items[cmbPerfil.SelectedIndex]).Id)
                {
                    achou = true;
                }
            }


            if (achou == false)
            {
                perfisUsuario.Add((Perfil)cmbPerfil.Items[cmbPerfil.SelectedIndex]);
                LimparPerfilUsuario();
                CarregarPerfilUsuario();
                AdicionarPerfil();
                RemoverPerfil();
            }
            else
            {
                tlMensagem.ToolTipTitle = "Valor já informado";
                tlMensagem.Show("Perfil já adicionado a lista", lstPerfilUsuario);
            }
        }

        private void btnRemoverPerfil_Click(object sender, EventArgs e)
        {
            perfisUsuario.RemoveAt(lstPerfilUsuario.SelectedIndex);
            LimparPerfilUsuario();
            CarregarPerfilUsuario();
            AdicionarPerfil();
            RemoverPerfil();
        }

        private void lstPerfilUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdicionarPerfil();
            RemoverPerfil();
        }

        private void cmbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdicionarPerfil();
            RemoverPerfil();
        }

        private void frmCadUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            fachada.Usuario = usuarioAtual;
        }

       
    }
}
