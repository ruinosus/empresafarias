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
        Fachada fachada = Fachada.ObterInstancia();
        public frmTitular()
        {
            InitializeComponent();
            AjustarEstadoEndereco();
            AjustarEstadoNaturalidade();
            AjustarPlano();
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
                //lblMensagem.Text = en.Message;
            }

            catch (Exception ex)
            {
                //lblMensagem.Text = ex.Message;
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
                //lblMensagem.Text = en.Message;
            }

            catch (Exception ex)
            {
                //lblMensagem.Text = ex.Message;
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
                //lblMensagem.Text = en.Message;
            }

            catch (Exception ex)
            {
                //lblMensagem.Text = ex.Message;
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
                //lblMensagem.Text = en.Message;
            }

            catch (Exception ex)
            {
                //lblMensagem.Text = ex.Message;
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
                //lblMensagem.Text = en.Message;
            }

            catch (Exception ex)
            {
                //lblMensagem.Text = ex.Message;
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
    }
}
