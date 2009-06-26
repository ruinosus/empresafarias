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
        /// <summary>
        /// Construtor da Classe ControladorParcela
        /// </summary>
        /// <param name="repParcela">Recebe um objeto que implemente IRepositorioParcela.</param>
        public ControladorParcela(IRepositorioParcela repParcela) 
        {
            this.repParcela = repParcela;	
        }

        /// <summary>
        /// Metodo responsavel por inserir uma Parcela.
        /// </summary>
        /// <param name="parcela">Objeto do tipo Parcela a ser inserido</param>
        /// <param name="ContratoId">Id do Contrato da Parcela.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo.</exception>
        public void Inserir(Parcela parcela, int ContratoId)
        {
            if (parcela == null)
                throw new ExcecaoNegocio("Valor Inválido.");
            this.repParcela.Inserir(parcela,ContratoId);
        }
        /// <summary>
        /// Metodo responsavel por alterar uma Parcela.
        /// </summary>
        /// <param name="plano">Objeto do tipo Parcela a ser alterado</param>
        /// <param name="ContratoId">Id do Contrato da Parcela.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo ou a Parcela não seja encontrada.</exception>
        public void Alterar(Parcela parcela, int ContratoId)
        {
            if (this.Consultar(parcela.Id) != null && parcela != null)
                this.repParcela.Alterar(parcela,ContratoId);
            else
                throw new ExcecaoNegocio("Parcela não existente.");
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
    }
}
