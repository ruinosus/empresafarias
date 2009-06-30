using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace Repositorio.interfaces
{
    /// <summary>
    /// Interface que representa os metodos de acesso ao Historico dos Dependentes.
    /// </summary>
    public interface IRepositorioHistoricoDependente
    {
        /// <summary>
        /// Metodo responsavel por inserir um HistoricoDependente.
        /// </summary>
        /// <param name="historicoDependente">Objeto do tipo HistoricoDependente a ser inserido</param>
        /// <param name="TitularId">Id do Titular do HistoricoDependente.</param>
        /// <returns>retorna o HistoricoDependente inserido.</returns>
        HistoricoDependente Inserir(HistoricoDependente historicoDependente, int TitularId);
        
        /// <summary>
        /// Metodo responsavel por consultar um HistoricoDependente.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um HistoricoDependente com o Id informado.</returns>
        HistoricoDependente Consultar(int id);
        
        /// <summary>
        /// Metodo responsavel por consultar todos os HistoricosDependente cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os HistoricosDependente cadastrados.</returns>
        List<HistoricoDependente> Consultar();

        /// <summary>
        /// Metodo responsavel por consultar uma lista contendo todos os HistoricosDependente do Dependente Informado.
        /// </summary>
        /// <param name="dependente">Objeto do tipo Dependente a ser pesquisado.</param>
        /// <returns>retorna uma lista contendo todos os HistoricosDependente do Dependente Informado.</returns>
        List<HistoricoDependente> Consultar(Dependente dependente);
    }
}
