using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesBasicas;

namespace Repositorio.interfaces
{
    /// <summary>
    /// Interface que representa os metodos de acesso a dados do Contrato.
    /// </summary>
    public interface IRepositorioContrato
    {
        /// <summary>
        /// Metodo responsavel por inserir um Contrato.
        /// </summary>
        /// <param name="contrato">Objeto do tipo Contrato a ser inserido</param>
        /// <param name="TitularId">Id do Titular do Contrato.</param>
        /// <returns>retorna o Contrato inserido.</returns>
        Contrato Inserir(Contrato contrato, int TitularId);
        /// <summary>
        /// Metodo responsavel por alterar um Contrato.
        /// </summary>
        /// <param name="contrato">Objeto do tipo Contrato a ser alterado</param>
        /// <param name="TitularId">Id do Titular do Contrato.</param>
        void Alterar(Contrato contrato, int TitularId);
        /// <summary>
        /// Metodo responsavel por remover um Contrato.
        /// </summary>
        /// <param name="id">Id do Contrato a ser removido.</param>
        void Remover(int id);
        /// <summary>
        /// Metodo responsavel por consultar um Contrato.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Contrato com o Id informado.</returns>
        Contrato Consultar(int id);
        /// <summary>
        /// Metodo responsavel por consultar todos os Contratos cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Contratos cadastrados.</returns>
        List<Contrato> Consultar();
        /// <summary>
        /// Metodo responsavel por consultar os Contratos de um Titular.
        /// </summary>
        /// <param name="titular">Titular a ser utilizado como pesquisa.</param>
        /// <returns>retorna uma Lista com todas os Contratos encontrados do Titular informado.</returns>
        List<Contrato> Consultar(Titular titular);
    }
}
