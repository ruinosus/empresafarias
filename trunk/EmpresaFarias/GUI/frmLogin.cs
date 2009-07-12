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
    public partial class frmLogin : Form
    {
        Fachada fachada = Fachada.Instance;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                fachada.Usuario = fachada.ControladorUsuario.Consultar(txtLogin.Text, txtSenha.Text);
                this.Close();
            }
            catch (ExcecaoNegocio ex)
            {
                tlMensagem.ToolTipTitle = "Erro!";
                tlMensagem.Show(ex.Message, txtLogin);
            }
            catch (Exception exc)
            {
                tlMensagem.ToolTipTitle = "Erro!";
                tlMensagem.Show(exc.Message, txtLogin);
            }

        }
    }
}
