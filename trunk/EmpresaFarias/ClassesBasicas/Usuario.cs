using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassesBasicas
{
    public enum Status
    {
        Inativo = 1,
        Inclusao,
        Alteracao,
        Navegacao
    }
    public enum StatusUsuario
    {
        Ativo = 1,
        Inativo
    }
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

        private StatusUsuario status;

        /// <summary>
        /// Propriedade relacionada ao Status do Usuario.
        /// </summary>
        public StatusUsuario Status
        {
            get { return status; }
            set { status = value; }
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

                    if (formulario.Controls[i].Tag != null && !formulario.Controls[i].Tag.Equals(""))
                    {
                        int tag = Convert.ToInt32(formulario.Controls[i].Tag);
                        if (this.VerificarTag(tag))
                        {
                            formulario.Controls[i].Visible = true;
                            //formulario.Controls[i].Enabled = true;
                        }
                        else
                        {
                            formulario.Controls[i].Visible = false;
                            //formulario.Controls[i].Enabled = false;
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
                    List<ToolStripMenuItem> l = new List<ToolStripMenuItem>();
                    if (menu.Items[i].Tag != null && !menu.Items[i].Tag.Equals(""))
                    {
                       
                        l.Add((ToolStripMenuItem)menu.Items[i]);
                        int tag = Convert.ToInt32(menu.Items[i].Tag);

                        if (this.VerificarTag(tag))
                        {
                            menu.Items[i].Visible = true;
                            //menu.Items[i].Enabled = true;

                            HabilitarMenu(l);
                        }
                        else
                        {
                            menu.Items[i].Visible = false;
                           // menu.Items[i].Enabled = false;
                        }
                    }
                    else
                    {
                        l.Add((ToolStripMenuItem)menu.Items[i]);
                        HabilitarMenu(l);

                    }
                }

            } 
            #endregion            

            #region TabControl
            if (o is TabControl)
            {
                TabControl tab = o as TabControl;

                for (int i = 0; i < tab.TabPages.Count; i++)
                {
                    if (tab.TabPages[i].Tag != null && !tab.TabPages[i].Tag.Equals(""))
                    {                       
                        int tag = Convert.ToInt32(tab.TabPages[i].Tag);
                        if (this.VerificarTag(tag))
                        {
                            tab.TabPages[i].Visible = true;
                            //tab.TabPages[i].Enabled = true;                                
                        }
                        else
                        {
                            tab.TabPages[i].Visible = false;
                           // tab.TabPages[i].Enabled = false;
                        }  
                    }
                    HabilitarTab(tab.TabPages[i]); 
                }

            }
            #endregion

            #region Panel
            if (o is Panel)
            {
                Panel panel = o as Panel;

                for (int i = 0; i < panel.Controls.Count; i++)
                {
                    if (panel.Controls[i].Tag != null && !panel.Controls[i].Tag.Equals(""))
                    {
                        int tag = Convert.ToInt32(panel.Controls[i].Tag);
                        if (this.VerificarTag(tag))
                        {
                            panel.Controls[i].Visible = true;
                           // panel.Controls[i].Enabled = true;
                        }
                        else
                        {
                            panel.Controls[i].Visible = false;
                            //panel.Controls[i].Enabled = false;
                        }
                    }
                    //HabilitarTab(panel.TabPages[i]);
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

        /// <summary>
        /// Metodo responsavel por Habilitar um item de um Menu de acordo com o Perfil do Usuario.
        /// </summary>
        /// <param name="menuItem">Lista contendo os itens a serem verificados.</param>
        private void HabilitarMenu(List<ToolStripMenuItem> menuItem)
        {
            List<ToolStripMenuItem> l = new List<ToolStripMenuItem>();

            for (int j = 0; j < menuItem.Count; j++)
            {
                ToolStripMenuItem item = menuItem[j];

                for (int i = 0; i < item.DropDownItems.Count; i++)
                {
                    if (item.DropDownItems[i].Tag!=null &&!item.DropDownItems[i].Tag.Equals(""))
                    {
                        int tag = Convert.ToInt32(item.DropDownItems[i].Tag);
                        if (this.VerificarTag(tag))
                        {
                            item.DropDownItems[i].Visible = true;
                            //item.DropDownItems[i].Enabled = true;

                            ToolStripMenuItem sub = (ToolStripMenuItem)item.DropDownItems[i];
                            if (sub.DropDownItems.Count > 0)
                            {
                                l.Add(sub);
                            }
                        }
                        else
                        {
                            item.DropDownItems[i].Visible = false;
                            //item.DropDownItems[i].Enabled = false;
                        }
                    }
                } 
            }
            if(l.Count > 0)
            {
                this.HabilitarMenu(l);
            }
            
        }

        /// <summary>
        /// Metodo responsavel por Habilitar os componentes dentro um uma TabPage.
        /// </summary>
        /// <param name="tab">tab a ser verificada.</param>
        private void HabilitarTab(TabPage tab)
        {
            for (int i = 0; i < tab.Controls.Count; i++)
            {

                if (tab.Controls[i].Tag!=null && !tab.Controls[i].Tag.Equals(""))
                {
                    int tag = Convert.ToInt32(tab.Controls[i].Tag);
                    if (this.VerificarTag(tag))
                    {
                        tab.Controls[i].Visible = true;
                       // tab.Controls[i].Enabled = true;
                    }
                    else
                    {
                        tab.Controls[i].Visible = false;
                      //  tab.Controls[i].Enabled = false;
                    }
                }
            }

        }

        public override string ToString()
        {
            return "Nome: " + this.nome;
        }
    }
}
