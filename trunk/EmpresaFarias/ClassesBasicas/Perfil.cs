using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    /// <summary>
    /// Classe responsável pelo Perfil que um Usuario poderá ter.
    /// </summary>
    public class Perfil
    {
        private int id;
        /// <summary>
        /// Propriedade relacionada ao Id do Perfil.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string descricao;
        /// <summary>
        /// Propriedade relacionada a Descricao do Perfil.
        /// </summary>
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        private List<int> tags;
        /// <summary>
        /// Propriedade relacionada com as Tags do Perfil.
        /// </summary>
        public List<int> Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        /// <summary>
        /// Construtor padrão do Perfil que inicializa as Tags.
        /// </summary>
        public Perfil()
        {
            this.tags = new List<int>();
        }
    }
}
