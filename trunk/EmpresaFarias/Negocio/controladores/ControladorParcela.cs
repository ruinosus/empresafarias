using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using ClassesBasicas;

namespace Negocio.controladores
{
    /// <summary>
    /// Classe Reponsavel por todas as regras de Negocio da Parcela.
    /// </summary>
    public class ControladorParcela
    {
        private IRepositorioParcela repParcela;
        private IRepositorioHistoricoParcela repHistoricoParcela;
        private ControladorUsuario contUsuario;

        /// <summary>
        /// Construtor da Classe ControladorParcela
        /// </summary>
        /// <param name="repParcela">Recebe um objeto que implemente IRepositorioParcela.</param>
        /// <param name="repHistoricoParcela">Recebe um objeto que implemente IRepositorioHistoricoParcela.</param>
        /// <param name="contUsuario">Recebe um objeto do Tipo ControladorUsuario.</param>
        public ControladorParcela(IRepositorioParcela repParcela,
                                  IRepositorioHistoricoParcela repHistoricoParcela,
                                  ControladorUsuario contUsuario) 
        {
            this.repParcela = repParcela;
            this.repHistoricoParcela = repHistoricoParcela;
            this.contUsuario = contUsuario;
        }

        /// <summary>
        /// Metodo responsavel por inserir uma Parcela.
        /// </summary>
        /// <param name="parcela">Objeto do tipo Parcela a ser inserido</param>
        /// <param name="ContratoId">Id do Contrato da Parcela.</param>
        /// <param name="usuario">Usuario que inserio a Parcela.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo.</exception>
        /// <returns>retorna o Parcela inserido.</returns>
        public Parcela Inserir(Parcela parcela, Usuario usuario)
        {
            if (parcela == null)
                throw new ExcecaoNegocio("Valor Inválido.");
            Parcela p = this.repParcela.Inserir(parcela);

            HistoricoParcela hp = new HistoricoParcela();
            hp.DataAlteracao = new DateTime();
            hp.DataAlteracao = DateTime.Now;
            hp.Usuario = usuario;
            hp.Descricao = "Inserido";
            hp.ParcelaHistorico = p;
            hp.Parcela = p;

            this.InserirHistorico(hp);
            return p;
        }

        /// <summary>
        /// Metodo responsavel por alterar uma Parcela.
        /// </summary>
        /// <param name="plano">Objeto do tipo Parcela a ser alterado</param>
        /// <param name="ContratoId">Id do Contrato da Parcela.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo ou a Parcela não seja encontrada.</exception>
        public void Alterar(Parcela parcela,Usuario usuario)
        {
            Parcela parcelaAntiga =this.Consultar(parcela.Id);
            if ( parcelaAntiga!= null && parcela != null)
                this.repParcela.Alterar(parcela);
            else
                throw new ExcecaoNegocio("Parcela não existente.");

            HistoricoParcela hp = new HistoricoParcela();
            hp.DataAlteracao = new DateTime();

            string descricao="Alterado\n";
            if (parcelaAntiga.Valor != parcela.Valor)
            {
                descricao += "Valor\n";
            }
            if (parcelaAntiga.Status != parcela.Status)
            {
                descricao += "Status\n";
            }
            if (parcelaAntiga.NumeroParcela != parcela.NumeroParcela)
            {
                descricao += "Numero da Parcela\n";
            }
            if (parcelaAntiga.DataVencimento != parcela.DataVencimento)
            {
                descricao += "Data de Vencimento\n";
            }
            if (parcelaAntiga.DataPagamento != parcela.DataPagamento)
            {
                descricao += "Data de Pagamento\n";
            }
            hp.DataAlteracao = DateTime.Now;
            hp.Usuario = usuario;
            hp.Descricao = descricao;
            hp.ParcelaHistorico = parcela;
            hp.Parcela = parcela;

            this.InserirHistorico(hp);
        }

        /// <summary>
        /// Metodo responsavel por remover uma Parcela.
        /// </summary>
        /// <param name="id">Id do Parcela a ser removida.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso a Parcela não seja encontrada.</exception>
        public void Remover(int id)
        {
            if (this.Consultar(id) != null)
                this.repParcela.Remover(id);
            else
                throw new ExcecaoNegocio("Parcela não existente.");
        }

        /// <summary>
        /// Metodo responsavel por consultar uma Parcela.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna uma Parcela com o Id informado.</returns>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso a Parcela não seja encontrada.</exception>
        public Parcela Consultar(int id)
        {
            Parcela parcela = this.repParcela.Consultar(id);
            if (parcela == null)
                throw new ExcecaoNegocio("Parcela não existente.");
            return parcela;
        }

        /// <summary>
        /// Metodo responsavel por consultar todas as Parcelas cadastradas.
        /// </summary>
        /// <returns>retorna uma Lista com todas as Parcelas cadastradas.</returns>
        public List<Parcela> Consultar()
        {
            return this.repParcela.Consultar();
        }

        /// <summary>
        /// Metodo responsavel por consultar as Parcelas de um Contrato.
        /// </summary>
        /// <param name="contrato">Contrato a ser utilizado como pesquisa.</param>
        /// <returns>retorna uma Lista com todas as Parcelas encontradas do Contrato informado.</returns>
        public List<Parcela> Consultar(Contrato contrato)
        {
            return this.repParcela.Consultar(contrato);
        }

        /// <summary>
        /// Metodo responsavel por inserir um Historico da Parcela.
        /// </summary>
        /// <param name="historicoParcela">Objeto do tipo HistoricoParcela a ser inserido</param>
        /// <param name="ContratoId">Id do Contrato do Historico da Parcela.</param>
        /// <returns>retorna o HistoricoParcela inserido.</returns>
        private HistoricoParcela InserirHistorico(HistoricoParcela historicoParcela)
        {
            return this.repHistoricoParcela.Inserir(historicoParcela);
        }

        /// <summary>
        /// Metodo responsavel por consultar uma Parcela.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um HistoricoParcela com o Id informado.</returns>
        public HistoricoParcela ConsultarHistorico(int id)
        {
            return this.MontarHistoricoParcela(this.repHistoricoParcela.Consultar(id));
        }

        /// <summary>
        /// Metodo responsavel por consultar todas as Parcelas cadastradas.
        /// </summary>
        /// <returns>retorna uma Lista com todos os HistoricosParcelas cadastradas.</returns>
        public List<HistoricoParcela> ConsultarHistorico()
        {
            List<HistoricoParcela> historicos = this.repHistoricoParcela.Consultar();

            for (int i = 0; i < historicos.Count; i++)
            {
                historicos[i] = this.MontarHistoricoParcela(historicos[i]);
            }

            return historicos;
        }

        /// <summary>
        /// Metodo responsavel por montar um HistoricoParcela.
        /// </summary>
        /// <param name="historicoTitular">HistoricoParcela a ser montado.</param>
        /// <returns>HistoricoParcela.</returns>
        private HistoricoParcela MontarHistoricoParcela(HistoricoParcela historicoParcela)
        {
            historicoParcela.Parcela = this.Consultar(historicoParcela.Parcela.Id);
            return historicoParcela;
        } 
    }
}
