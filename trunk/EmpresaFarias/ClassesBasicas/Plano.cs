using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    /// <summary>
    /// Classe que representa um Plano.
    /// </summary>
    public class Plano
    {
        private int id;
        /// <summary>
        /// Propriedade relacionada ao Id do Plano.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nome;
        /// <summary>
        /// Propriedade relacionada ao Nome do Plano.
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private decimal valorPadrao;
        /// <summary>
        /// Propriedade relacionada ao Valor Padrão do Plano.
        /// </summary>
        public decimal ValorPadrao
        {
            get { return valorPadrao; }
            set { valorPadrao = value; }
        }

        private string descricao;
        /// <summary>
        /// Propriedade relacionada a Descricao do Plano.
        /// </summary>
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
