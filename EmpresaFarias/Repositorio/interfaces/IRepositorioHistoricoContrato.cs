using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace Repositorio.interfaces
{
    /// <summary>
    /// Interface que representa os metodos de acesso ao Historico dos Contratos.
    /// </summary>
    public interface IRepositorioHistoricoContrato
    {
        /// <summary>
        /// Metodo responsavel por inserir um HistoricoContrato.
        /// </summary>
        /// <param name="historicoContrato">Objeto do tipo HistoricoContrato a ser inserido</param>
        /// <returns>retorna o HistoricoContrato inserido.</returns>
        HistoricoContrato Inserir(HistoricoContrato historicoContrato);

        /// <summary>
        /// Metodo responsavel por consultar um HistoricoContrato.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um HistoricoContrato com o Id informado.</returns>
        HistoricoContrato Consultar(int id);

        /// <summary>
        /// Metodo responsavel por consultar todos os HistoricosContrato cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os HistoricosContrato cadastrados.</returns>
        List<HistoricoContrato> Consultar();

        /// <summary>
        /// Metodo responsavel por consultar uma lista contendo todos os HistoricosContrato do Contrato Informado.
        /// </summary>
        /// <param name="contrato">Objeto do tipo Contrato a ser pesquisado.</param>
        /// <returns>retorna uma lista contendo todos os HistoricosContrato do Contrato Informado.</returns>
        List<HistoricoContrato> Consultar(Contrato contrato);
    }
}
