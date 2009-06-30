using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassesBasicas
{
    /// <summary>
    /// Classe que representa um Usuario que poderá acessar o Sistema.
    /// </summary>
    public class Usuario
    {
        private int id;
        /// <summary>
        /// Propriedade relacionada ao Id do Usuario.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String login;
        /// <summary>
        /// Propriedade relacionada ao Login do Usuario.
        /// </summary>
        public String Login
        {
            get { return login; }
            set { login = value; }
        }
        private String senha;
        /// <summary>
        /// Propriedade relacionada a Senha do Usuario.
        /// </summary>
        public String Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        private String nome;
        /// <summary>
        /// Propriedade relacionada ao Nome do Usuario.
        /// </summary>
        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private List<Perfil> perfis;
        /// <summary>
        /// Propriedade relacionada aos Perfis do Usuario.
        /// </summary>
        public List<Perfil> Perfis
        {
            get { return perfis; }
            set { perfis = value; }
        }

        /// <summary>
        /// Construtor padrão do Usuario, inicializando os Perfis.
        /// </summary>
        public Usuario()
        {
            this.perfis = new List<Perfil>();
        }

        /// <summary>
        /// Metodo responsavel por habilitar os Componentes de acordo com o perfil do Usuario.
        /// </summary>
        /// <param name="o">Objeto que sera validado de acordo com o Pefil do Usuario.</param>
        public void HabilitarComponentes(Object o)
        {
            #region Form
            if (o is Form)
            {
                Form formulario = o as Form;
                for (int i = 0; i < formulario.Controls.Count; i++)
                {

                    if (formulario.Controls[i].Tag != null)
                    {
                        int tag = Convert.ToInt32(formulario.Controls[i].Tag);
                        if (this.VerificarTag(tag))
                        {
                            formulario.Controls[i].Visible = true;
                            formulario.Controls[i].Enabled = true;
                        }
                        else
                        {
                            formulario.Controls[i].Visible = false;
                            formulario.Controls[i].Enabled = false;
                        }
                    }
                }

            } 
            #endregion

            #region MenusStrip
            if (o is MenuStrip)
            {
                MenuStrip menu = o as MenuStrip;
              
                for (int i = 0; i < menu.Items.Count; i++)
                {
  
                    if (menu.Items[i].Tag != null)
                    {
                        int tag = Convert.ToInt32(menu.Items[i].Tag);
                        //ToolStripItem tsm = menu.GetNextItem(menu.Items[i], ArrowDirection.Down);
                                              
                        if (this.VerificarTag(tag))
                        {
                            menu.Items[i].Visible = true;
                            menu.Items[i].Enabled = true;
                            HabilitarMenu((ToolStripMenuItem)menu.Items[i]);
                        }
                        else
                        {
                            menu.Items[i].Visible = false;
                            menu.Items[i].Enabled = false;
                        }
                    }
                }

            } 
            #endregion            

        }

        /// <summary>
        /// Metodo responsavel por verificar dentro dos Perfis do Usuario se Exisite a Tag informada.
        /// </summary>
        /// <param name="tag">Tag a ser verificada.</param>
        /// <returns>Verdadeiro caso a Tag seja encontrada.</returns>
        private bool VerificarTag(int tag)
        {            
            for (int j = 0; j < this.perfis.Count; j++)
            {
                for (int i = 0; i < this.perfis[j].Tags.Count; i++)
                {
                    if (perfis[j].Tags[i] == tag)
                        return true;
                }
            }

            return false;
        }

        private void HabilitarMenu(ToolStripMenuItem menuItem)
        {

            ToolStripMenuItem item = menuItem;

            for (int i = 0; i < item.DropDownItems.Count; i++)
            {
                ToolStripMenuItem sub = (ToolStripMenuItem)item.DropDownItems[i];
                if (sub.DropDownItems.Count > 0)
                {
                    this.HabilitarMenu(sub);
                }
                if (item.DropDownItems[i].Tag != null)
                {
                    int tag = Convert.ToInt32(item.DropDownItems[i].Tag);
                    if (this.VerificarTag(tag))
                    {
                        item.DropDownItems[i].Visible = true;
                        item.DropDownItems[i].Enabled = true;
                    }
                    else
                    {
                        item.DropDownItems[i].Visible = false;
                        item.DropDownItems[i].Enabled = false;
                    }
                }
            }
        }
    }
}
