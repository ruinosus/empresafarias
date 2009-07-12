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
         private IRepositorioHistoricoContrato repHistoricoContrato;
         private ControladorUsuario contUsuario;

        /// <summary>
        /// Construtor da Classe ControladorContrato
        /// </summary>
        /// <param name="repContrato">Recebe um objeto que implemente IRepositorioContrato.</param>
        /// <param name="contParcela">Recebe um objeto do tipo ControladorParcela.</param>
        /// <param name="contPlano">Recebe um objeto do tipo ControladorPlano.</param>
        /// <param name="repHistoricoContrato">Recebe um objeto ue implemente IRepositorioHistoricoContrato.</param>
        /// <param name="contUsuario">Recebe um objeto do Tipo ControladorUsuario.</param>
        public ControladorContrato(IRepositorioContrato repContrato,
                                   ControladorParcela contParcela,
                                   ControladorPlano contPlano,
                                   IRepositorioHistoricoContrato repHistoricoContrato,
                                   ControladorUsuario contUsuario)
        {
            this.contParcela = contParcela;
            this.contPlano = contPlano;
            this.repContrato = repContrato;
            this.repHistoricoContrato = repHistoricoContrato;
            this.contUsuario = contUsuario;

        }

        /// <summary>
        /// Metodo responsavel por inserir um Contrato.
        /// </summary>
        /// <param name="contrato">Objeto do tipo Contrato a ser inserido</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo.</exception>
        /// <returns>retorna o Contrato inserido.</returns>  
        public Contrato Inserir(Contrato contrato, Usuario usuario)
        {
            if (contrato == null)
                throw new ExcecaoNegocio("Valor Inválido.");

            if(this.Consultar(contrato.Id)!=null)
                throw new ExcecaoNegocio("Número de Contrato já Informado.");

             Contrato c = this.repContrato.Inserir(contrato);

             HistoricoContrato hc = new HistoricoContrato();
             hc.DataAlteracao = new DateTime();
             hc.DataAlteracao = DateTime.Now;
             hc.Usuario = usuario;
             hc.Descricao = "Inserido";
             hc.ContratoHistorico = c;
             hc.Contrato = c;

             this.InserirHistorico(hc);
            return c;
        }

        /// <summary>
        /// Metodo responsavel por alterar um Contrato.
        /// </summary>
        /// <param name="contrato">Objeto do tipo Contrato a ser alterado</param>
        /// <param name="TitularId">Id do Titular do Contrato.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o objeto seja nulo ou o Contrato não seja encontrado.</exception>
        public void Alterar(Contrato contrato, Usuario usuario)
        {
            Contrato contratoAntigo = this.Consultar(contrato.Id);
            if (contratoAntigo != null && contrato != null)
                this.repContrato.Alterar(contrato);
            else
                throw new ExcecaoNegocio("Contrato não existente.");
            HistoricoContrato hc = new HistoricoContrato();
            hc.DataAlteracao = new DateTime();
            hc.DataAlteracao = DateTime.Now;
            hc.Usuario = usuario;
            string descricao = "Alterado\n";

            if (contratoAntigo.DataInicio != contrato.DataInicio)
            {
                descricao += "Data de inicio\n";
            }
            if (contratoAntigo.Parcelas.Count != contrato.Parcelas.Count)
            {
                descricao += "Parcelas\n";
            }
            if (contratoAntigo.Plano.Id != contrato.Plano.Id)
            {
                descricao += "Plano\n";
            }
            if (contratoAntigo.Status != contrato.Status)
            {
                descricao += "Status\n";
            }

            hc.Descricao = descricao;
            hc.ContratoHistorico = contrato;
            hc.Contrato = contrato;

            this.InserirHistorico(hc);

        }

        /// <summary>
        /// Metodo responsavel por remover um Contrato.
        /// </summary>
        /// <param name="id">Id do Contrato a ser removido.</param>
        /// <exception cref="ExecaoNegocio">Lançara a ExecaoNegocio caso o Contrato não seja encontrado.</exception>
        /// 
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
            
            //if (contrato == null)
            //    throw new ExcecaoNegocio("Contrato não existente.");
            if (contrato != null)
                return this.MontarContrato(contrato);
            else
                return null;
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

        /// <summary>
        /// Metodo responsavel por inserir um HistoricoContrato.
        /// </summary>
        /// <param name="historicoContrato">Objeto do tipo HistoricoContrato a ser inserido</param>
        /// <param name="TitularId">Id do Titular do HistoricoContrato.</param>
        /// <returns>retorna o HistoricoContrato inserido.</returns>
        public HistoricoContrato InserirHistorico(HistoricoContrato historicoContrato)
        {
            return this.repHistoricoContrato.Inserir(historicoContrato);
        }

        /// <summary>
        /// Metodo responsavel por consultar um HistoricoContrato.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um HistoricoContrato com o Id informado.</returns>
        public HistoricoContrato ConsultarHistorico(int id)
        {
            return this.repHistoricoContrato.Consultar(id);
        }

        /// <summary>
        /// Metodo responsavel por consultar todos os HistoricosContrato cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os HistoricosContrato cadastrados.</returns>
        public List<HistoricoContrato> ConsultarHistorico()
        {
            return this.repHistoricoContrato.Consultar();
        }

        /// <summary>
        /// Metodo responsavel por consultar uma lista contendo todos os HistoricosContrato do Contrato Informado.
        /// </summary>
        /// <param name="contrato">Objeto do tipo Contrato a ser pesquisado.</param>
        /// <returns>retorna uma lista contendo todos os HistoricosContrato do Contrato Informado.</returns>
        public List<HistoricoContrato> ConsultarHistorico(Contrato contrato)
        {
            return this.repHistoricoContrato.Consultar(contrato);
        }

    }
}
