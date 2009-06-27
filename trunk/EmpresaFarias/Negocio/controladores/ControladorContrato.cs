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
    public class ControladorContrato
    {

         private ControladorParcela contParcela;
         private ControladorPlano contPlano;
         private IRepositorioContrato repContrato;
        /// <summary>
        /// Construtor da Classe ControladorContrato
        /// </summary>
        /// <param name="repContrato">Recebe um objeto que implemente IRepositorioContrato.</param>
        /// <param name="contParcela">Recebe um objeto do tipo ControladorParcela.</param>
        /// <param name="contPlano">Recebe um objeto do tipo ControladorPlano.</param>
        public ControladorContrato(IRepositorioContrato repContrato,
                                   ControladorParcela contParcela,
                                   ControladorPlano contPlano) 
        {
            this.contParcela = contParcela;
            this.contPlano = contPlano;
            this.repContrato = repContrato;
        }
        /// <summary>
        /// Metodo responsavel por inserir um Contrato.
        /// </summary>
        /// <param name="contrato">Objeto do tipo Contrato a ser inserido</param>
        /// <param name="TitularId">Id do Titular do Contrato.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo.</exception>
        /// <returns>retorna o Contrato inserido.</returns>  
        public Contrato Inserir(Contrato contrato, int TitularId)
        {
            if (contrato == null)
                throw new ExcecaoNegocio("Valor Inválido.");

            if(this.Consultar(contrato.Id)!=null)
                throw new ExcecaoNegocio("Número de Contrato já Informado.");

             return  this.repContrato.Inserir(contrato, TitularId);
        }
        /// <summary>
        /// Metodo responsavel por alterar um Contrato.
        /// </summary>
        /// <param name="contrato">Objeto do tipo Contrato a ser alterado</param>
        /// <param name="TitularId">Id do Titular do Contrato.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo ou o Contrato não seja encontrado.</exception>
        public void Alterar(Contrato contrato, int TitularId)
        {
            if (this.Consultar(contrato.Id) != null && contrato != null)
                this.repContrato.Alterar(contrato, TitularId);
            else
                throw new ExcecaoNegocio("Contrato não existente.");
        }
        /// <summary>
        /// Metodo responsavel por remover um Contrato.
        /// </summary>
        /// <param name="id">Id do Contrato a ser removido.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o Contrato não seja encontrado.</exception>
        public void Remover(int id)
        {
            if (this.Consultar(id) != null)
                this.repContrato.Remover(id);
            else
                throw new ExcecaoNegocio("Contrato não existente.");
        }
        /// <summary>
        /// Metodo responsavel por consultar um Contrato.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Contrato com o Id informado.</returns>
        public Contrato Consultar(int id)
        {
            Contrato contrato = this.repContrato.Consultar(id);    
            
            if (contrato == null)
                throw new ExcecaoNegocio("Contrato não existente.");
            return this.MontarContrato(contrato);
        }
        /// <summary>
        /// Metodo responsavel por consultar todos os Contratos cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Contratos cadastrados.</returns>
        public List<Contrato> Consultar()
        {
            List<Contrato> contratos = this.repContrato.Consultar();

            for (int i = 0; i < contratos.Count; i++ )
            {
                contratos[i] = this.MontarContrato(contratos[i]);
            }

            return contratos;
        }
        /// <summary>
        /// Metodo responsavel por consultar os Contratos de um Titular.
        /// </summary>
        /// <param name="titular">Titular a ser utilizado como pesquisa.</param>
        /// <returns>retorna uma Lista com todas os Contratos encontrados do Titular informado.</returns>
        public List<Contrato> Consultar(Titular titular)
        {
            List<Contrato> contratos = this.repContrato.Consultar(titular);

            for (int i = 0; i < contratos.Count; i++)
            {
                contratos[i] = this.MontarContrato(contratos[i]);
            }

            return contratos;
        }
        /// <summary>
        /// Metodo responsavel por montar um Contrato juntamente com suas Parcelas e o seu Plano.
        /// </summary>
        /// <param name="contrato">Contrato a ser montado.</param>
        /// <returns>Contrato contendo todas as suas Parcelas e o seu Plano.</returns>
        private Contrato MontarContrato(Contrato contrato)
        {
            contrato.Parcelas = this.contParcela.Consultar(contrato);
            contrato.Plano = this.contPlano.Consultar(contrato.Plano.Id);
            return contrato;
        }

    }
}
