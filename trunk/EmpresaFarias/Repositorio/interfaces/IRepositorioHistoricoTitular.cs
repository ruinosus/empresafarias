using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace Repositorio.interfaces
{
    /// <summary>
    /// Interface que representa os metodos de acesso ao Historico dos Titulares.
    /// </summary>
    public interface IRepositorioHistoricoTitular
    {
        /// <summary>
        /// Metodo responsavel por inserir um HistoricoTitular.
        /// </summary>
        /// <param name="historicoTitular">Objeto do tipo HistoricoTitular a ser inserido</param>
        /// <returns>retorna o HistoricoTitular inserido.</returns>
        HistoricoTitular Inserir(HistoricoTitular historicoTitular);

        /// <summary>
        /// Metodo responsavel por consultar um HistoricoTitular.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um HistoricoTitular com o Id informado.</returns>
        HistoricoTitular Consultar(int id);

        /// <summary>
        /// Metodo responsavel por consultar todos os HistoricosTitular cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os HistoricosTitular cadastrados.</returns>
        List<HistoricoTitular> Consultar();

        /// <summary>
        /// Metodo responsavel por consultar uma lista contendo todos os HistoricosParcela do Titular Informado.
        /// </summary>
        /// <param name="titular">Objeto do tipo Titular a ser pesquisado.</param>
        /// <returns>retorna uma lista contendo todos os HistoricosDependente da Titular Informada.</returns>
        List<HistoricoTitular> Consultar(Titular titular);
    }
}
