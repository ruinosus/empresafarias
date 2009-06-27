using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace Repositorio.interfaces
{
    /// <summary>
    /// Interface que representa os metodos de acesso a dados das Cidades e dos Estados.
    /// </summary>
    public interface IRepositorioHistoricoParcela
    {
        /// <summary>
        /// Metodo responsavel por inserir um Historico da Parcela.
        /// </summary>
        /// <param name="historicoParcela">Objeto do tipo HistoricoParcela a ser inserido</param>
        /// <param name="ContratoId">Id do Contrato do Historico da Parcela.</param>
        /// <returns>retorna o HistoricoParcela inserido.</returns>
        HistoricoParcela Inserir(HistoricoParcela historicoParcela, int ContratoId);
        /// <summary>
        /// Metodo responsavel por consultar uma Parcela.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um HistoricoParcela com o Id informado.</returns>
        HistoricoParcela Consultar(int id);
        /// <summary>
        /// Metodo responsavel por consultar todas as Parcelas cadastradas.
        /// </summary>
        /// <returns>retorna uma Lista com todos os HistoricosParcelas cadastradas.</returns>
        List<HistoricoParcela> Consultar();
    }
}
