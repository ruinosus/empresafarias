using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
