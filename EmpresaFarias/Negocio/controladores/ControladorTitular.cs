using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using ClassesBasicas;

namespace Negocio.controladores
{
    /// <summary>
    /// Classe Reponsavel por todas as regras de Negocio do Titular.
    /// </summary>
    public class ControladorTitular
    {
        private ControladorDependente contDependente;
        private ControladorContrato contContrato;
        private ControladorCidadeEstado contCidadeEstado;
        private IRepositorioTitular repTitular;
        

        /// <summary>
        /// Construtor da Classe ControladorTitular
        /// </summary>
        /// <param name="repTitular">Recebe um objeto que implemente IRepositorioTitular.</param>
        /// <param name="contContrato">>Recebe um objeto do tipo ControladorContrato.</param>
        /// <param name="contDependente">>Recebe um objeto do tipo ControladorDependente.</param>
        /// <param name="contCidadeEstado">>Recebe um objeto do tipo ControladorCidadeEstado.</param>
        public ControladorTitular(IRepositorioTitular repTitular,
                                  ControladorContrato contContrato,
                                  ControladorDependente contDependente,
                                  ControladorCidadeEstado contCidadeEstado) 
        {
            this.contContrato = contContrato;
            this.contDependente = contDependente;
            this.contCidadeEstado = contCidadeEstado;
            this.repTitular = repTitular;
        }
        /// <summary>
        /// Metodo responsavel por inserir um Titular.
        /// </summary>
        /// <param name="titular">Objeto do tipo Titular a ser inserido</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo.</exception>
        public void Inserir(Titular titular)
        {
            if (titular == null)
                throw new ExcecaoNegocio("Valor Inválido.");
            this.repTitular.Inserir(titular);
        }
        /// <summary>
        /// Metodo responsavel por alterar um Titular.
        /// </summary>
        /// <param name="dependente">Objeto do tipo Titular a ser alterado</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo ou o Titular não seja encontrado.</exception>
        public void Alterar(Titular titular)
        {
            if (this.Consultar(titular.Id) != null && titular != null)
                this.repTitular.Alterar(titular);
            else
                throw new ExcecaoNegocio("Titular não existente.");
        }
        /// <summary>
        /// Metodo responsavel por remover um Titular.
        /// </summary>
        /// <param name="id">Id do Titular a ser removido.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o Titular não seja encontrado.</exception>
        public void Remover(int id)
        {
            if (this.Consultar(id) != null)
                this.repTitular.Remover(id);
            else
                throw new ExcecaoNegocio("Titular não existente.");
        }
        /// <summary>
        /// Metodo responsavel por consultar um Titular.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Titular com o Id informado.</returns>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o Titular não seja encontrado.</exception>
        public Titular Consultar(int id)
        {
            Titular titular = this.repTitular.Consultar(id);

            if (titular == null)
                throw new ExcecaoNegocio("Titular não existente.");
            return this.MontarTitular(titular);
        }
        /// <summary>
        /// Metodo responsavel por consultar todos os Titulares cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Titulares cadastrados.</returns>
        public List<Titular> Consultar()
        {
            List<Titular> titulares = this.repTitular.Consultar();

            for (int i = 0; i < titulares.Count; i++)
            {
                titulares[i] = this.MontarTitular(titulares[i]);
            }

            return titulares;
        }
        /// <summary>
        /// Metodo responsavel por montar um Titular juntamente com sues Dependentes e seus Contratos.
        /// </summary>
        /// <param name="titular">Titular a ser montado.</param>
        /// <returns>Titular contendo todos os seus Dependentes e seus Contratos.</returns>
        private Titular MontarTitular(Titular titular)
        {
            titular.Dependentes = this.contDependente.Consultar(titular);
            titular.Contratos = this.contContrato.Consultar(titular);
            titular.CidadeNaturalidade = this.contCidadeEstado.Consultar(titular.CidadeNaturalidade.Id);
            titular.Endereco.Cidade = this.contCidadeEstado.Consultar(titular.Endereco.Cidade.Id);
            return titular;
        }
    }
}
