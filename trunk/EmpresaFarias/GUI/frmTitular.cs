using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassesBasicas;
using Negocio;

namespace GUI
{
    public partial class frmTitular : Form
    {
        Fachada fachada = Fachada.Instance;
        StatusBanco statusTitular = StatusBanco.Inativo;
        StatusBanco statusDependente = StatusBanco.Inativo;
        StatusBanco statusParcela = StatusBanco.Inativo;

        Usuario usuario;

        Titular titularAtual;
        List<Titular> titulares;

        //Dependente dependenteAtual;
        List<Dependente> dependentes;
        int DependenteAtualId = 0;

        //Parcela parcelaAtual;
        List<Parcela> parcelas;
        int ParcelaAtualId = 0;


        public frmTitular()
        {
            InitializeComponent();
        }

        private void AjustarEstadoEndereco()
        {

            try
            {
                cmbEstado.DataSource = fachada.ControladorCidadeEstado.Consultar();
                cmbEstado.DisplayMember = "Sigla";
                cmbEstado.ValueMember = "Id";
            }
            catch (ExcecaoNegocio en)
            {
                tlMensagem.ToolTipTitle = "Erro";
                tlMensagem.Show(en.Message, cmbEstado);
            }

            catch (Exception ex)
            {
                tlMensagem.ToolTipTitle = "Erro";
                tlMensagem.Show(ex.Message, cmbEstado);
            }
        }

        private void AjustarCidadeEndereco()
        {
            try
            {
                Estado estado = (Estado)cmbEstado.SelectedItem;
                cmbCidade.DataSource = fachada.ControladorCidadeEstado.Consultar(estado);
                cmbCidade.DisplayMember = "Nome";
                cmbCidade.ValueMember = "Id";
            }
            catch (ExcecaoNegocio en)
            {
                tlMensagem.ToolTipTitle = "Erro";
                tlMensagem.Show(en.Message, cmbCidade);
            }

            catch (Exception ex)
            {
                tlMensagem.ToolTipTitle = "Erro";
                tlMensagem.Show(ex.Message, cmbCidade);
            }
        }

        private void AjustarEstadoNaturalidade()
        {

            try
            {
                cmbEstadoNaturalidade.DataSource = fachada.ControladorCidadeEstado.Consultar();
                cmbEstadoNaturalidade.DisplayMember = "Sigla";
                cmbEstadoNaturalidade.ValueMember = "Id";
            }
            catch (ExcecaoNegocio en)
            {
                tlMensagem.ToolTipTitle = "Erro";
                tlMensagem.Show(en.Message, cmbEstadoNaturalidade);
            }

            catch (Exception ex)
            {
                tlMensagem.ToolTipTitle = "Erro";
                tlMensagem.Show(ex.Message, cmbEstadoNaturalidade);
            }
        }

        private void AjustarCidadeNaturalidade()
        {
            try
            {
                Estado estado = (Estado)cmbEstadoNaturalidade.SelectedItem;
                cmbCidadeNaturalidade.DataSource = fachada.ControladorCidadeEstado.Consultar(estado);
                cmbCidadeNaturalidade.DisplayMember = "Nome";
                cmbCidadeNaturalidade.ValueMember = "Id";
            }
            catch (ExcecaoNegocio en)
            {
                tlMensagem.ToolTipTitle = "Erro";
                tlMensagem.Show(en.Message, cmbCidadeNaturalidade);
            }

            catch (Exception ex)
            {
                tlMensagem.ToolTipTitle = "Erro";
                tlMensagem.Show(ex.Message, cmbCidadeNaturalidade);
            }
        }

        private void AjustarPlano()
        {
            try
            {
                cmbPlano.DataSource = fachada.ControladorPlano.Consultar();
                cmbPlano.DisplayMember = "Nome";
                cmbPlano.ValueMember = "Id";
            }
            catch (ExcecaoNegocio en)
            {
                tlMensagem.ToolTipTitle = "Erro";
                tlMensagem.Show(en.Message, cmbPlano);
            }

            catch (Exception ex)
            {
                tlMensagem.ToolTipTitle = "Erro";
                tlMensagem.Show(ex.Message, cmbPlano);
            }
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            AjustarCidadeEndereco();
        }

        private void cmbEstadoNaturalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            AjustarCidadeNaturalidade();
        }

        private void cmbParentesco_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbParentesco.SelectedIndex)
            {
                case 0:
                    {
                        cmbPercentualCobertura.SelectedIndex = 0;
                        break;
                    }

                case 3:
                    {
                        cmbPercentualCobertura.SelectedIndex = 0;
                        break;
                    }
                case 6:
                    {
                        cmbPercentualCobertura.SelectedIndex = 0;
                        break;
                    }
                case 8:
                    {
                        cmbPercentualCobertura.SelectedIndex = 0;
                        break;
                    }

                default:
                    {
                        cmbPercentualCobertura.SelectedIndex = 1;
                        break;
                    }
            }
        }

        private void HabilitarDependente()
        {
            btnAlterarDependente.Enabled = dgvDependentesCadastrados.CurrentRow != null && dgvDependentesCadastrados.CurrentRow.Index != -1 && dependentes.Count > 0;
            btnExcluirDependente.Enabled = dgvDependentesCadastrados.CurrentRow != null && dgvDependentesCadastrados.CurrentRow.Index != -1 && dependentes.Count > 0;

            if (dgvDependentesCadastrados.CurrentRow != null && dgvDependentesCadastrados.CurrentRow.Index > -1)
            {
                DependenteAtualId = Convert.ToInt32(dgvDependentesCadastrados.CurrentRow.Cells[0].Value);
                txtNomeDependente.Text = dgvDependentesCadastrados.CurrentRow.Cells[1].Value + "";
                cmbReligiaoDependente.Text = dgvDependentesCadastrados.CurrentRow.Cells[2].Value + "";
                dtpNascimentoDependente.Value = Convert.ToDateTime(dgvDependentesCadastrados.CurrentRow.Cells[3].Value + "");
                cmbParentesco.Text = dgvDependentesCadastrados.CurrentRow.Cells[4].Value + "";
                cmbPercentualCobertura.Text = dgvDependentesCadastrados.CurrentRow.Cells[5].Value + "";

            }

            HabilitarComponentesPorTags();
        }

        private void HabilitarParcela()
        {
            btnAlterarParcela.Enabled = dgvParcelas.CurrentRow != null && dgvParcelas.CurrentRow.Index != -1 && parcelas.Count > 0;
            btnExcluirDependente.Enabled = dgvParcelas.CurrentRow != null && dgvParcelas.CurrentRow.Index != -1 && parcelas.Count > 0;

            HabilitarComponentesPorTags();
        }

        /// <summary>
        /// Metodo responsavel por Habilitar os componentes de Acordo com as Tags do Usuario Logado.
        /// </summary>
        private void HabilitarComponentesPorTags()
        {
            fachada.Usuario.HabilitarComponentes(this);
            fachada.Usuario.HabilitarComponentes(tabTitular);
            fachada.Usuario.HabilitarComponentes(tabDependente);
            fachada.Usuario.HabilitarComponentes(tabPagamento);
        }

        private void CarregarDependentes()
        {
            //dgvDependentesCadastrados.ClearSelection();

            //dgvDependentesCadastrados.Enabled = false;
            dgvDependentesCadastrados.DataSource = null;
            var resultado = from d in dependentes
                            orderby d.Nome
                            select d;
            dgvDependentesCadastrados.DataSource = resultado.ToList();
            //dgvDependentesCadastrados.Refresh();

        }

        private void CarregarParcelas()
        {
            dgvParcelas.DataSource = null;
            dgvParcelas.DataSource = parcelas;
        }

        private void AjustarBotoesTitular()
        {
            AjustarEditsTitular();
            switch (statusTitular)
            {
                case StatusBanco.Inativo:
                    {
                        //Btn do Titular
                        btnAnterior.Enabled = false;
                        btnCancelar.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnNovo.Enabled = true;
                        btnPrimeiro.Enabled = false;
                        btnProximo.Enabled = false;
                        btnUltimo.Enabled = false;
                        btnExcluir.Enabled = false;
                        btnAlterar.Enabled = false;
                        btnBuscarContrato.Enabled = false;
                        tbcTitular.Controls.Remove(tabDependente);
                        tbcTitular.Controls.Remove(tabPagamento);
                        //tbcTitular.DDisablePage(TabPage6)

                        HabilitarComponentesPorTags();

                        break;
                    }
                case StatusBanco.Alteracao:
                    {

                        //Btn do Titular
                        btnAnterior.Enabled = false;
                        btnCancelar.Enabled = true;
                        btnSalvar.Enabled = true;
                        btnNovo.Enabled = false;
                        btnPrimeiro.Enabled = false;
                        btnProximo.Enabled = false;
                        btnUltimo.Enabled = false;
                        btnExcluir.Enabled = false;
                        btnAlterar.Enabled = false;
                        btnBuscarContrato.Enabled = false;
                        tbcTitular.Controls.Remove(tabDependente);
                        tbcTitular.Controls.Remove(tabPagamento);




                        break;
                    }
                case StatusBanco.Inclusao:
                    {
                        //btnAdicionarPerfil.Enabled = false;
                        //btnRemoverPerfil.Enabled = false;
                        btnAnterior.Enabled = false;
                        btnCancelar.Enabled = true;
                        btnSalvar.Enabled = true;
                        btnNovo.Enabled = false;
                        btnPrimeiro.Enabled = false;
                        btnProximo.Enabled = false;
                        btnUltimo.Enabled = false;
                        btnExcluir.Enabled = false;
                        btnAlterar.Enabled = false;
                        btnBuscarContrato.Enabled = false;
                        tbcTitular.Controls.Remove(tabDependente);
                        tbcTitular.Controls.Remove(tabPagamento);
                        //btnVerificarLogin.Enabled = true;
                        break;
                    }
                case StatusBanco.Navegacao:
                    {
                        tbcTitular.Controls.Remove(tabDependente);
                        tbcTitular.Controls.Remove(tabPagamento);
                        tbcTitular.Controls.Add(tabDependente);
                        tbcTitular.Controls.Add(tabPagamento);
                        //btnAdicionarPerfil.Enabled = false;
                        //btnRemoverPerfil.Enabled = false;
                        btnBuscarContrato.Enabled = true;
                        btnAnterior.Enabled = bsTitular.Position > 0;
                        btnCancelar.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnNovo.Enabled = true;
                        btnPrimeiro.Enabled = bsTitular.Position > 0;
                        btnProximo.Enabled = bsTitular.Position + 1 < bsTitular.Count;
                        btnUltimo.Enabled = bsTitular.Position + 1 < bsTitular.Count;

                        btnExcluir.Enabled = bsTitular.Count > 0;
                        btnAlterar.Enabled = bsTitular.Count > 0;
                        //btnVerificarLogin.Enabled = false;
                        AjustarBotoesDependente();
                        HabilitarComponentesPorTags();
                        break;
                    }
            }



        }

        private void AjustarEditsTitular()
        {
            //Consultando todos os titulares cadastrados.
            titulares = fachada.ControladorTitular.Consultar();
            bsTitular.DataSource = titulares;

            switch (statusTitular)
            {
                case StatusBanco.Inativo:
                    {
                        statusDependente = StatusBanco.Inativo;
                        AjustarBotoesDependente();
                        statusParcela = StatusBanco.Inativo;
                        AjustarBotoesParcela();

                        dtpExpedicao.Enabled = false;
                        dtpInicioContrato.Enabled = false;
                        dtpDataNascimentoTitular.Enabled = false;

                        rdbFeminino.Enabled = false;
                        rdbMasculino.Enabled = false;
                        cmbCidade.Enabled = false;
                        cmbCidadeNaturalidade.Enabled = false;
                        cmbEstado.Enabled = false;
                        cmbEstadoNaturalidade.Enabled = false;
                        cmbEstadoCivil.Enabled = false;
                        cmbPlano.Enabled = false;
                        cmbReligiaoTitular.Enabled = false;

                        txtNome.ReadOnly = true;
                        txtBairro.ReadOnly = true;
                        txtBuscarContrato.ReadOnly = true;
                        txtComplemento.ReadOnly = true;
                        txtLogradouro.ReadOnly = true;
                        txtNumero.ReadOnly = true;
                        txtNumeroContrato.ReadOnly = true;
                        mskOrgaoExpeditor.ReadOnly = true;
                        mskCep.ReadOnly = true;
                        mskCpf.ReadOnly = true;
                        mskRg.ReadOnly = true;
                        mskTelefoneCelular.ReadOnly = true;
                        mskTelefoneResidencial.ReadOnly = true;

                        txtNome.Clear();
                        txtBairro.Clear();
                        txtBuscarContrato.Clear();
                        txtComplemento.Clear();
                        txtLogradouro.Clear();
                        txtNumero.Clear();
                        txtNumeroContrato.Clear();
                        mskOrgaoExpeditor.Clear();
                        mskCep.Clear();
                        mskCpf.Clear();
                        mskRg.Clear();
                        mskTelefoneCelular.Clear();
                        mskTelefoneResidencial.Clear();

                        break;
                    }
                case StatusBanco.Alteracao:
                    {
                        statusDependente = StatusBanco.Inativo;
                        AjustarBotoesDependente();
                        statusParcela = StatusBanco.Inativo;
                        AjustarBotoesParcela();

                        dtpExpedicao.Enabled = true;
                        dtpInicioContrato.Enabled = true;
                        dtpDataNascimentoTitular.Enabled = true;

                        rdbFeminino.Enabled = true;
                        rdbMasculino.Enabled = true;
                        cmbCidade.Enabled = true;
                        cmbCidadeNaturalidade.Enabled = true;
                        cmbEstado.Enabled = true;
                        cmbEstadoNaturalidade.Enabled = true;
                        cmbEstadoCivil.Enabled = true;
                        cmbPlano.Enabled = true;
                        cmbReligiaoTitular.Enabled = true;

                        txtNome.ReadOnly = false;
                        txtBairro.ReadOnly = false;
                        txtBuscarContrato.ReadOnly = false;
                        txtComplemento.ReadOnly = false;
                        txtLogradouro.ReadOnly = false;
                        txtNumero.ReadOnly = false;
                        txtNumeroContrato.ReadOnly = true;
                        mskOrgaoExpeditor.ReadOnly = false;
                        mskCep.ReadOnly = false;
                        mskCpf.ReadOnly = false;
                        mskRg.ReadOnly = false;
                        mskTelefoneCelular.ReadOnly = false;
                        mskTelefoneResidencial.ReadOnly = false;

                        if (titularAtual.Dependentes.Count > 0)
                            dependentes = titularAtual.Dependentes;
                        else
                            dependentes = new List<Dependente>();


                        break;
                    }
                case StatusBanco.Inclusao:
                    {
                        statusDependente = StatusBanco.Inativo;
                        AjustarBotoesDependente();
                        statusParcela = StatusBanco.Inativo;
                        AjustarBotoesParcela();

                        dtpExpedicao.Enabled = true;
                        dtpInicioContrato.Enabled = true;
                        dtpDataNascimentoTitular.Enabled = true;

                        rdbFeminino.Enabled = true;
                        rdbMasculino.Enabled = true;
                        cmbCidade.Enabled = true;
                        cmbCidadeNaturalidade.Enabled = true;
                        cmbEstado.Enabled = true;
                        cmbEstadoNaturalidade.Enabled = true;
                        cmbEstadoCivil.Enabled = true;
                        cmbPlano.Enabled = true;
                        cmbReligiaoTitular.Enabled = true;

                        cmbEstadoCivil.SelectedIndex = 0;
                        cmbReligiaoTitular.SelectedIndex = 0;
                        txtNome.ReadOnly = false;
                        txtBairro.ReadOnly = false;
                        txtBuscarContrato.ReadOnly = false;
                        txtComplemento.ReadOnly = false;
                        txtLogradouro.ReadOnly = false;
                        txtNumero.ReadOnly = false;
                        txtNumeroContrato.ReadOnly = false;
                        mskOrgaoExpeditor.ReadOnly = false;
                        mskCep.ReadOnly = false;
                        mskCpf.ReadOnly = false;
                        mskRg.ReadOnly = false;
                        mskTelefoneCelular.ReadOnly = false;
                        mskTelefoneResidencial.ReadOnly = false;

                        txtNome.Clear();
                        txtBairro.Clear();
                        txtBuscarContrato.Clear();
                        txtComplemento.Clear();
                        txtLogradouro.Clear();
                        txtNumero.Clear();
                        txtNumeroContrato.Clear();
                        mskOrgaoExpeditor.Clear();
                        mskCep.Clear();
                        mskCpf.Clear();
                        mskRg.Clear();
                        mskTelefoneCelular.Clear();
                        mskTelefoneResidencial.Clear();

                        dependentes = new List<Dependente>();
                        break;
                    }
                case StatusBanco.Navegacao:
                    {
                        statusDependente = StatusBanco.Navegacao;
                        AjustarBotoesDependente();
                        statusParcela = StatusBanco.Navegacao;
                        AjustarBotoesParcela();

                        dtpExpedicao.Enabled = false;
                        dtpInicioContrato.Enabled = false;
                        dtpDataNascimentoTitular.Enabled = false;

                        rdbFeminino.Enabled = false;
                        rdbMasculino.Enabled = false;
                        cmbCidade.Enabled = false;
                        cmbCidadeNaturalidade.Enabled = false;
                        cmbEstado.Enabled = false;
                        cmbEstadoNaturalidade.Enabled = false;
                        cmbEstadoCivil.Enabled = false;
                        cmbPlano.Enabled = false;
                        cmbReligiaoTitular.Enabled = false;

                        txtNome.ReadOnly = true;
                        txtBairro.ReadOnly = true;
                        txtBuscarContrato.ReadOnly = true;
                        txtComplemento.ReadOnly = true;
                        txtLogradouro.ReadOnly = true;
                        txtNumero.ReadOnly = true;
                        txtNumeroContrato.ReadOnly = true;
                        mskOrgaoExpeditor.ReadOnly = true;
                        mskCep.ReadOnly = true;
                        mskCpf.ReadOnly = true;
                        mskRg.ReadOnly = true;
                        mskTelefoneCelular.ReadOnly = true;
                        mskTelefoneResidencial.ReadOnly = true;

                        txtNome.Clear();
                        txtBairro.Clear();
                        txtBuscarContrato.Clear();
                        txtComplemento.Clear();
                        txtLogradouro.Clear();
                        txtNumero.Clear();
                        txtNumeroContrato.Clear();
                        mskOrgaoExpeditor.Clear();
                        mskCep.Clear();
                        mskCpf.Clear();
                        mskRg.Clear();
                        mskTelefoneCelular.Clear();
                        mskTelefoneResidencial.Clear();

                        if (titulares.Count > 0)
                        {
                            titularAtual = (Titular)titulares[bsTitular.Position];
                            txtNome.Text = titularAtual.Nome;
                            txtBairro.Text = titularAtual.Endereco.Bairro;
                            txtComplemento.Text = titularAtual.Endereco.Complemento;
                            txtLogradouro.Text = titularAtual.Endereco.Logradouro;
                            txtNome.Text = titularAtual.Nome;
                            txtNumero.Text = titularAtual.Endereco.Numero;
                            mskCep.Text = titularAtual.Endereco.Cep;
                            mskCpf.Text = titularAtual.Cpf;
                            mskOrgaoExpeditor.Text = titularAtual.Rg.OrgaoExpeditor;
                            mskRg.Text = titularAtual.Rg.Numero;
                            mskTelefoneCelular.Text = titularAtual.TelefoneCelular;
                            mskTelefoneResidencial.Text = titularAtual.TelefoneResidencial;

                            if (titularAtual.Dependentes.Count > 0)
                            {
                                dependentes = titularAtual.Dependentes;
                                CarregarDependentes();

                            }
                            else
                            {
                                dependentes = new List<Dependente>();
                                dgvDependentesCadastrados.DataSource = null;
                            }


                            //if (titularAtual.Contratos.Count > 0)
                            //{
                            //    txtNumeroContrato.Text = titularAtual.Contratos[0].Id.ToString();
                            //    cmbParcela.SelectedValue = titularAtual.Contratos[0].Plano.Id;
                            //    dtpInicioContrato.Value = titularAtual.Contratos[0].DataInicio;
                            //}
                            dtpDataNascimentoTitular.Value = titularAtual.DataNascimento;

                            rdbFeminino.Checked = titularAtual.Sexo.Equals('F');
                            rdbMasculino.Checked = titularAtual.Sexo.Equals('M');
                            cmbEstadoCivil.Text = titularAtual.EstadoCivil;
                            cmbReligiaoTitular.Text = titularAtual.Religiao;
                            cmbEstado.SelectedValue = titularAtual.Endereco.Cidade.Estado.Id;
                            cmbCidade.SelectedValue = titularAtual.Endereco.Cidade.Id;

                            dtpExpedicao.Value = titularAtual.Rg.DataExpedicao;
                            cmbEstadoNaturalidade.SelectedValue = titularAtual.CidadeNaturalidade.Estado.Id;
                            cmbCidadeNaturalidade.SelectedValue = titularAtual.CidadeNaturalidade.Id;

                            if (titularAtual.Contratos.Count > 0)
                            {
                                txtNumeroContrato.Text = titularAtual.Contratos[0].Id.ToString();
                                cmbPlano.SelectedValue = titularAtual.Contratos[0].Plano.Id;
                                dtpInicioContrato.Value = titularAtual.Contratos[0].DataInicio;
                            }

                        }
                        break;
                    }
            }

        }

        private void AjustarBotoesDependente()
        {
            AjustarEditsDependente();

            switch (statusDependente)
            {
                case StatusBanco.Inativo:
                    {
                        //Btn do Dependente
                        btnAdicionarDependente.Enabled = false;
                        btnAlterarDependente.Enabled = false;
                        btnCancelarDependente.Enabled = false;
                        btnExcluirDependente.Enabled = false;
                        btnSalvarDependente.Enabled = false;
                        dgvDependentesCadastrados.Enabled = false;
                        HabilitarComponentesPorTags();
                        break;
                    }
                case StatusBanco.Alteracao:
                    {
                        //Btn do Dependente
                        btnAdicionarDependente.Enabled = false;
                        btnAlterarDependente.Enabled = false;
                        btnCancelarDependente.Enabled = true;
                        btnExcluirDependente.Enabled = false;
                        btnSalvarDependente.Enabled = true;
                        dgvDependentesCadastrados.Enabled = false;


                        break;
                    }
                case StatusBanco.Inclusao:
                    {
                        //Btn do Dependente
                        btnAdicionarDependente.Enabled = false;
                        btnAlterarDependente.Enabled = false;
                        btnCancelarDependente.Enabled = true;
                        btnExcluirDependente.Enabled = false;
                        btnSalvarDependente.Enabled = true;
                        dgvDependentesCadastrados.Enabled = false;
                        break;
                    }
                case StatusBanco.Navegacao:
                    {
                        //Btn do Dependente
                        btnSalvarDependente.Enabled = false;
                        btnAdicionarDependente.Enabled = true;
                        btnCancelarDependente.Enabled = false;
                        dgvDependentesCadastrados.Enabled = true;
                        HabilitarDependente();

                        HabilitarComponentesPorTags();

                        break;
                    }
            }


        }

        private void AjustarEditsDependente()
        {

            switch (statusDependente)
            {
                case StatusBanco.Inativo:
                    {
                        dtpNascimentoDependente.Enabled = false;

                        cmbParentesco.Enabled = false;
                        cmbPercentualCobertura.Enabled = false;
                        cmbReligiaoDependente.Enabled = false;

                        txtNomeDependente.ReadOnly = true;

                        txtNomeDependente.Clear();
                        HabilitarDependente();


                        break;
                    }
                case StatusBanco.Alteracao:
                    {
                        //Validar dependente
                        dtpNascimentoDependente.Enabled = true;

                        cmbParentesco.Enabled = true;
                        cmbPercentualCobertura.Enabled = true;
                        cmbReligiaoDependente.Enabled = true;

                        txtNomeDependente.ReadOnly = false;


                        break;
                    }
                case StatusBanco.Inclusao:
                    {
                        dtpNascimentoDependente.Enabled = true;

                        cmbParentesco.Enabled = true;
                        cmbPercentualCobertura.Enabled = true;
                        cmbReligiaoDependente.Enabled = true;

                        cmbParentesco.SelectedIndex = 0;

                        cmbReligiaoDependente.SelectedIndex = 0;

                        txtNomeDependente.ReadOnly = false;
                        txtNomeDependente.Clear();
                        break;
                    }
                case StatusBanco.Navegacao:
                    {
                        dtpNascimentoDependente.Enabled = false;

                        cmbParentesco.Enabled = false;
                        cmbPercentualCobertura.Enabled = false;
                        cmbReligiaoDependente.Enabled = false;

                        txtNomeDependente.ReadOnly = true;

                        txtNomeDependente.Clear();

                        dgvDependentesCadastrados.RefreshEdit();

                        if (dependentes != null)
                        {
                            lblInformacaoDependente.Text = "Quantidade de Dependentes cadastrados: " + dependentes.Count;
                            if (dependentes.Count > 12)
                                lblInformacaoDependente.ForeColor = System.Drawing.Color.Red;
                            else
                                lblInformacaoDependente.ForeColor = System.Drawing.Color.Black;
                        }



                        break;
                    }
            }

        }

        private void AjustarBotoesParcela()
        {
            AjustarEditsParcela();
            switch (statusParcela)
            {
                case StatusBanco.Inativo:
                    {
                        //Btn da Parcela
                        btnEfetuarPagamento.Enabled = false;
                        btnAlterarParcela.Enabled = false;
                        btnGerarParcelas.Enabled = false;
                        dgvParcelas.Enabled = false;
                        btnSalvarParcela.Enabled = false;
                        btnExcluirParcela.Enabled = false;
                        btnCancelarParcela.Enabled = false;

                        HabilitarComponentesPorTags();
                        break;
                    }
                case StatusBanco.Alteracao:
                    {
                        //Btn da Parcela
                        btnEfetuarPagamento.Enabled = false;
                        btnAlterarParcela.Enabled = false;
                        btnGerarParcelas.Enabled = false;
                        dgvParcelas.Enabled = false;
                        btnSalvarParcela.Enabled = true;
                        btnExcluirParcela.Enabled = false;
                        btnCancelarParcela.Enabled = true;
                        break;
                    }
                case StatusBanco.Inclusao:
                    {
                        //Btn da Parcela
                        btnEfetuarPagamento.Enabled = false;
                        btnAlterarParcela.Enabled = false;
                        btnGerarParcelas.Enabled = false;
                        dgvParcelas.Enabled = false;
                        btnSalvarParcela.Enabled = true;
                        btnExcluirParcela.Enabled = false;
                        btnCancelarParcela.Enabled = true;

                        break;
                    }
                case StatusBanco.Navegacao:
                    {
                        //Btn da Parcela
                        btnEfetuarPagamento.Enabled = false;
                        btnAlterarParcela.Enabled = false;
                        btnGerarParcelas.Enabled = true;
                        dgvParcelas.Enabled = true;
                        btnSalvarParcela.Enabled = false;
                        btnExcluirParcela.Enabled = false;
                        btnCancelarParcela.Enabled = false;
                        HabilitarParcela();
                        HabilitarComponentesPorTags();
                        break;
                    }
            }


        }

        private void AjustarEditsParcela()
        {
            switch (statusParcela)
            {
                case StatusBanco.Inativo:
                    {
                        dtpDataPagamento.Enabled = false;
                        dtpDataVencimento.Enabled = false;
                        

                        cmbParcela.Enabled = false;

                        txtValor.ReadOnly = true;

                        txtValor.Clear();


                        break;
                    }
                case StatusBanco.Alteracao:
                    {
                        dtpDataPagamento.Enabled = true;
                        dtpDataVencimento.Enabled = true;

                        cmbParcela.Enabled = true;

                        txtValor.ReadOnly = false;


                        break;
                    }
                case StatusBanco.Inclusao:
                    {
                        dtpDataPagamento.Enabled = true;
                        dtpDataVencimento.Enabled = true;

                        cmbParcela.Enabled = true;

                        txtValor.ReadOnly = false;
                        txtValor.Clear();
                        break;
                    }
                case StatusBanco.Navegacao:
                    {
                        dtpDataPagamento.Enabled = false;
                        dtpDataVencimento.Enabled = false;

                        cmbParcela.Enabled = false;

                        txtValor.ReadOnly = true;

                        txtValor.Clear();
                        break;
                    }
            }

        }

        private void frmTitular_Load(object sender, EventArgs e)
        {
            if (fachada.ControladorTitular.Consultar().Count > 0)
            {
                statusTitular = StatusBanco.Navegacao;
            }
            else
            {
                statusTitular = StatusBanco.Inativo;
            }
            AjustarEstadoEndereco();
            AjustarEstadoNaturalidade();
            AjustarPlano();
            usuario = fachada.Usuario;
            AjustarBotoesTitular();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            statusTitular = StatusBanco.Inclusao;

            AjustarBotoesTitular();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            statusTitular = StatusBanco.Alteracao;

            AjustarBotoesTitular();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                switch (statusTitular)
                {
                    case StatusBanco.Inclusao:
                        {
                            try
                            {
                                Titular t = new Titular();
                                t.CidadeNaturalidade = (Cidade)cmbCidadeNaturalidade.SelectedItem;
                                t.Cpf = mskCpf.Text;
                                t.DataNascimento = dtpDataNascimentoTitular.Value;
                                t.Endereco.Cidade = (Cidade)cmbCidade.SelectedItem;
                                t.Endereco.Bairro = txtBairro.Text;
                                t.Endereco.Cep = mskCep.Text;
                                t.Endereco.Complemento = txtComplemento.Text;
                                t.Endereco.Logradouro = txtLogradouro.Text;
                                t.Endereco.Numero = txtNumero.Text;
                                t.EstadoCivil = cmbEstadoCivil.Text;
                                t.Nome = txtNome.Text;
                                t.Religiao = cmbReligiaoTitular.Text;
                                t.Rg.Numero = mskRg.Text;
                                t.Rg.DataExpedicao = dtpExpedicao.Value;
                                t.Rg.OrgaoExpeditor = mskOrgaoExpeditor.Text;
                                if (rdbFeminino.Checked)
                                    t.Sexo = 'F';
                                else
                                    t.Sexo = 'M';
                                t.Status = StatusControle.Ativo;
                                t.TelefoneCelular = mskTelefoneCelular.Text;
                                t.TelefoneResidencial = mskTelefoneResidencial.Text;
                                t = fachada.ControladorTitular.Inserir(t, usuario);
                                //Inserindo o Contrato
                                Contrato c = new Contrato();
                                c.Id = Convert.ToInt32(txtNumeroContrato.Text);
                                c.DataInicio = dtpInicioContrato.Value;
                                c.Plano = (Plano)cmbPlano.SelectedItem;
                                //c.GerarParcelas(DateTime.Today, 12, c.Plano.ValorPadrao);
                                c.Status = StatusControle.Ativo;
                                c.TitularId = t.Id;
                                fachada.ControladorContrato.Inserir(c, usuario);

                                statusTitular = StatusBanco.Navegacao;

                                AjustarBotoesTitular();
                                bsTitular.MoveLast();
                                AjustarBotoesTitular();
                            }
                            catch (ExcecaoNegocio en)
                            {
                                tlMensagem.ToolTipTitle = "Erro";
                                tlMensagem.Show(en.Message, this);
                            }

                            catch (Exception ex)
                            {
                                tlMensagem.ToolTipTitle = "Erro";
                                tlMensagem.Show(ex.Message, this);
                            }

                            break;
                        }
                    case StatusBanco.Alteracao:
                        {
                            //Alterando o Titular
                            titularAtual.CidadeNaturalidade = (Cidade)cmbCidadeNaturalidade.SelectedItem;
                            titularAtual.Cpf = mskCpf.Text;
                            titularAtual.DataNascimento = dtpDataNascimentoTitular.Value;
                            titularAtual.Endereco.Cidade = (Cidade)cmbCidade.SelectedItem;
                            titularAtual.Endereco.Bairro = txtBairro.Text;
                            titularAtual.Endereco.Cep = mskCep.Text;
                            titularAtual.Endereco.Complemento = txtComplemento.Text;
                            titularAtual.Endereco.Logradouro = txtLogradouro.Text;
                            titularAtual.Endereco.Numero = txtNumero.Text;
                            titularAtual.EstadoCivil = cmbEstadoCivil.Text;
                            titularAtual.Nome = txtNome.Text;
                            titularAtual.Religiao = cmbReligiaoTitular.Text;
                            titularAtual.Rg.Numero = mskRg.Text;
                            titularAtual.Rg.DataExpedicao = dtpExpedicao.Value;
                            titularAtual.Rg.OrgaoExpeditor = mskOrgaoExpeditor.Text;
                            if (rdbFeminino.Checked)
                                titularAtual.Sexo = 'F';
                            else
                                titularAtual.Sexo = 'M';
                            titularAtual.Status = StatusControle.Ativo;
                            titularAtual.TelefoneCelular = mskTelefoneCelular.Text;
                            titularAtual.TelefoneResidencial = mskTelefoneResidencial.Text;
                            fachada.ControladorTitular.Alterar(titularAtual, usuario);

                            //Alterando o Contrato
                            titularAtual.Contratos[0].Id = Convert.ToInt32(txtNumeroContrato.Text);
                            titularAtual.Contratos[0].DataInicio = dtpInicioContrato.Value;
                            titularAtual.Contratos[0].Plano = (Plano)cmbPlano.SelectedItem;
                            //c.GerarParcelas(DateTime.Today, 12, c.Plano.ValorPadrao);
                            titularAtual.Contratos[0].Status = StatusControle.Ativo;
                            titularAtual.Contratos[0].TitularId = titularAtual.Id;
                            fachada.ControladorContrato.Alterar(titularAtual.Contratos[0], usuario);

                            statusTitular = StatusBanco.Navegacao;
                            AjustarBotoesTitular();
                            break;
                        }


                }

            }
            catch (ExcecaoNegocio ex)
            {
                tlMensagem.ToolTipTitle = "Erro!";
                tlMensagem.Show(ex.Message, txtNome);
            }
            catch (Exception exc)
            {
                tlMensagem.ToolTipTitle = "Erro!";
                tlMensagem.Show(exc.Message, txtNome);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            statusTitular = StatusBanco.Navegacao;

            AjustarBotoesTitular();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            statusTitular = StatusBanco.Navegacao;

            AjustarBotoesTitular();
        }

        private void btnAdicionarDependente_Click(object sender, EventArgs e)
        {
            statusDependente = StatusBanco.Inclusao;

            AjustarBotoesDependente();
        }

        private void btnAlterarDependente_Click(object sender, EventArgs e)
        {
            statusDependente = StatusBanco.Alteracao;

            AjustarBotoesDependente();
        }

        private void btnSalvarDependente_Click(object sender, EventArgs e)
        {
            try
            {

                switch (statusDependente)
                {
                    case StatusBanco.Inclusao:
                        {
                            if (!titularAtual.ValidarDependente(cmbParentesco.Text))
                                throw new ExcecaoNegocio("Grau de Parentesco Invalido");


                            Dependente d = new Dependente();
                            d.Nome = txtNomeDependente.Text;
                            d.Parentesco = cmbParentesco.Text;
                            d.PercentualCobertura = Convert.ToInt32(cmbPercentualCobertura.Text);
                            d.Religiao = cmbReligiaoDependente.Text;
                            d.DataNascimento = dtpNascimentoDependente.Value;
                            d.Status = StatusControle.Ativo;
                            d.TitularId = titularAtual.Id;
                            d = fachada.ControladorDependente.Inserir(d, usuario);
                            statusDependente = StatusBanco.Navegacao;
                            dependentes.Add(d);
                            titularAtual.Dependentes.Add(d);
                            CarregarDependentes();

                            AjustarBotoesDependente();
                            break;
                        }
                    case StatusBanco.Alteracao:
                        {
                            if (!titularAtual.ValidarDependente(cmbParentesco.Text))
                                throw new ExcecaoNegocio("Grau de Parentesco Invalido");

                            Dependente d = new Dependente();
                            d.Id = DependenteAtualId;
                            d.Nome = txtNomeDependente.Text;
                            d.Parentesco = cmbParentesco.Text;
                            d.PercentualCobertura = Convert.ToInt32(cmbPercentualCobertura.Text);
                            d.Religiao = cmbReligiaoDependente.Text;
                            d.DataNascimento = dtpNascimentoDependente.Value;
                            d.Status = StatusControle.Ativo;
                            d.TitularId = titularAtual.Id;
                            fachada.ControladorDependente.Alterar(d, usuario);


                            statusDependente = StatusBanco.Navegacao;
                            dependentes.Remove(d);
                            dependentes.Add(d);

                            titularAtual.Dependentes.Remove(d);
                            titularAtual.Dependentes.Add(d);
                            CarregarDependentes();
                            AjustarBotoesDependente();
                            break;
                        }


                }

            }
            catch (ExcecaoNegocio ex)
            {
                tlMensagem.ToolTipTitle = "Erro!";
                tlMensagem.Show(ex.Message, txtNome);
            }
            catch (Exception exc)
            {
                tlMensagem.ToolTipTitle = "Erro!";
                tlMensagem.Show(exc.Message, txtNome);
            }
        }

        private void btnCancelarDependente_Click(object sender, EventArgs e)
        {
            statusDependente = StatusBanco.Navegacao;

            AjustarBotoesDependente();
        }

        private void btnExcluirDependente_Click(object sender, EventArgs e)
        {
            statusDependente = StatusBanco.Navegacao;

            AjustarBotoesDependente();
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            statusTitular = StatusBanco.Navegacao;
            //statusDependente = Status.Inativo;
            //statusParcela = Status.Inativo;
            bsTitular.MoveFirst();
            AjustarBotoesTitular();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            statusTitular = StatusBanco.Navegacao;
            //statusDependente = Status.Inativo;
            //statusParcela = Status.Inativo;
            bsTitular.MovePrevious();
            AjustarBotoesTitular();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            statusTitular = StatusBanco.Navegacao;
            //statusDependente = Status.Inativo;
            //statusParcela = Status.Inativo;
            bsTitular.MoveNext();
            AjustarBotoesTitular();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            statusTitular = StatusBanco.Navegacao;
            //statusDependente = Status.Inativo;
            //statusParcela = Status.Inativo;
            bsTitular.MoveLast();
            AjustarBotoesTitular();
        }

        private void dgvDependentesCadastrados_SelectionChanged(object sender, EventArgs e)
        {
            HabilitarDependente();
        }

        private void btnGerarParcelas_Click(object sender, EventArgs e)
        {

        }


    }
}
