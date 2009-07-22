using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    
    /// <summary>
    /// Classe que representa uma Parcela de um Contrato.
    /// </summary>
    public class Parcela
    {
        private int id;
        /// <summary>
        /// Propriedade relacionada ao Id da Parcela.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int contratoId;
        /// <summary>
        /// Propriedade relacionada ao Id do Contrato.
        /// </summary>
        public int ContratoId
        {
            get { return contratoId; }
            set { contratoId = value; }
        }


        private DateTime dataPagamento;
        /// <summary>
        /// Propriedade relacionada a Data de Pagamento da Parcela.
        /// </summary>
        public DateTime DataPagamento
        {
            get { return dataPagamento; }
            set { dataPagamento = value; }
        }

        private DateTime dataVencimento;
        /// <summary>
        /// Propriedade relacionada a Data de Vencimento da Parcela.
        /// </summary>
        public DateTime DataVencimento
        {
            get { return dataVencimento; }
            set { dataVencimento = value; }
        }

        private decimal valor;
        /// <summary>
        /// Propriedade relacionada ao Valor da Parcela.
        /// </summary>
        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private int numeroParcela;
        /// <summary>
        /// Propriedade relacionada ao Numero da Parcela;
        /// </summary>
        public int NumeroParcela
        {
            get { return numeroParcela; }
            set { numeroParcela = value; }
        }

        private StatusControle status;
        /// <summary>
        /// Propriedade relacionada ao Status da Parcela.
        /// </summary>
        public StatusControle Status
        {
            get { return status; }
            set { status = value; }
        }

        public override bool Equals(object obj)
        {
            bool resultado = false;

            if (obj is Parcela)
            {
                Parcela d = obj as Parcela;
                if (d.Id == this.id)
                    resultado = true;
            }
            return resultado;
        }

    }
}
