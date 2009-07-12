using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace Repositorio.interfaces
{
    /// <summary>
    /// Interface que representa os metodos de acesso a dados da Parcela.
    /// </summary>
    public interface IRepositorioParcela
    {
        /// <summary>
        /// Metodo responsavel por inserir uma Parcela.
        /// </summary>
        /// <param name="parcela">Objeto do tipo Parcela a ser inserido</param>
        /// <returns>retorna o Parcela inserido.</returns>
        Parcela Inserir(Parcela parcela);
        /// <summary>
        /// Metodo responsavel por alterar uma Parcela.
        /// </summary>
        /// <param name="plano">Objeto do tipo Parcela a ser alterado</param>
        void Alterar(Parcela parcela);
        /// <summary>
        /// Metodo responsavel por remover uma Parcela.
        /// </summary>
        /// <param name="id">Id do Parcela a ser removida.</param>
        void Remover(int id);
        /// <summary>
        /// Metodo responsavel por consultar uma Parcela.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna uma Parcela com o Id informado.</returns>
        Parcela Consultar(int id);
        /// <summary>
        /// Metodo responsavel por consultar todas as Parcelas cadastradas.
        /// </summary>
        /// <returns>retorna uma Lista com todas as Parcelas cadastradas.</returns>
        List<Parcela> Consultar();
        /// <summary>
        /// Metodo responsavel por consultar as Parcelas de um Contrato.
        /// </summary>
        /// <param name="contrato">Contrato a ser utilizado como pesquisa.</param>
        /// <returns>retorna uma Lista com todas as Parcelas encontradas do Contrato informado.</returns>
        List<Parcela> Consultar(Contrato contrato); 
    }
}
