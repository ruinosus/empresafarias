using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using ClassesBasicas;

namespace Negocio.controladores
{
    /// <summary>
    /// Classe Reponsavel por todas as regras de Negocio do Contrato.
    /// </summary>
    public class ControladorCidadeEstado
    {
        private IRepositorioCidadeEstado repCidadeEstado;
        /// <summary>
        /// Construtor da Classe ControladorCidadeEstado
        /// </summary>
        /// <param name="repCidadeEstado">Recebe um objeto que implemente IRepositorioCidadeEstado.</param>
        public ControladorCidadeEstado(IRepositorioCidadeEstado repCidadeEstado) 
        {
            this.repCidadeEstado = repCidadeEstado;	
        }
        /// <summary>
        /// Metodo responsavel por retornar todos os Estados cadastrados.
        /// </summary>
        /// <returns>Lista com todos os Estados cadastrados.</returns>
        public List<Estado> Consultar()
        {
            return this.repCidadeEstado.Consultar();
        }
        /// <summary>
        /// Metodo responsavel por retornar todas as Cidades do Estado informado.
        /// </summary>
        /// <param name="estado">Estado para pesquisa. </param>
        /// <returns>Lista com todas as Cidades do Estado informado.</returns>
        public List<Cidade> Consultar(Estado estado)
        {
            return this.repCidadeEstado.Consultar(estado);
        }

        /// <summary>
        /// Metodo responsavel por retornar uma Cidade com o id informado.
        /// </summary>
        /// <param name="id">Id da Cidade a ser pesquisada.</param>
        /// <returns>Objeto do tipo Cidade com o id informado</returns>
        public Cidade Consultar(int id)
        {
            return this.repCidadeEstado.Consultar(id);
        }
    }
}
