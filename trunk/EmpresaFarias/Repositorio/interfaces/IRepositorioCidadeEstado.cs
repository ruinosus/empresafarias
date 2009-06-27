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
    public interface IRepositorioCidadeEstado
    {
        /// <summary>
        /// Metodo responsavel por retornar todos os Estados cadastrados.
        /// </summary>
        /// <returns>Lista com todos os Estados cadastrados.</returns>
        List<Estado> Consultar();
        /// <summary>
        /// Metodo responsavel por retornar todas as Cidades do Estado informado.
        /// </summary>
        /// <param name="estado">Estado para pesquisa. </param>
        /// <returns>Lista com todas as Cidades do Estado informado.</returns>
        List<Cidade> Consultar(Estado estado);
        /// <summary>
        /// Metodo responsavel por retornar uma Cidade com o id informado.
        /// </summary>
        /// <param name="id">Id da Cidade a ser pesquisada.</param>
        /// <returns>Objeto do tipo Cidade com o Id informado</returns>
        Cidade Consultar(int id);
    }
}
