using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocio.controladores;
using Repositorio.interfaces;
using Repositorio.implementacoes;

namespace Negocio
{
    /// <summary>
    /// Classe que representa a Fachada do sistema.
    /// </summary>
    public class Fachada
    {
        private static Fachada instancia;
        /// <summary>
        /// Construtor padrão da Fachada, inicializando os Construtores.
        /// </summary>
        private Fachada()
        {
            InitControladores();
        }
        /// <summary>
        /// Metodo estatico responsavel por obter uma Instancia do Objeto Fachada
        /// Implementando o metodo Singleton.
        /// </summary>
        /// <returns>Retorna um Objeto do tipo Fachada</returns>
        public static Fachada ObterInstancia()
        {
            if (instancia == null)
            {
                instancia = new Fachada();
            }
            return instancia;
        }

        private ControladorPlano controladorPlano;
        /// <summary>
        ///  Propriedade apenas de retorno do Controlador de Plano.
        /// </summary>
        public ControladorPlano ControladorPlano
        {
            get { return controladorPlano; }
        }

        private ControladorCidadeEstado controladorCidadeEstado;
        /// <summary>
        ///  Propriedade apenas de retorno do Controlador de Cidade e Estado.
        /// </summary>
        public ControladorCidadeEstado ControladorCidadeEstado
        {
            get { return controladorCidadeEstado; }
        }

        private ControladorContrato controladorContrato;
        /// <summary>
        ///  Propriedade apenas de retorno do Controlador de Contrato.
        /// </summary>
        public ControladorContrato ControladorContrato
        {
            get { return controladorContrato; }
        }

        private ControladorDependente controladorDependente;
        /// <summary>
        ///  Propriedade apenas de retorno do Controlador de Dependente.
        /// </summary>
        public ControladorDependente ControladorDependente
        {
            get { return controladorDependente; }
        }

        private ControladorParcela controladorParcela;
        /// <summary>
        ///  Propriedade apenas de retorno do Controlador de Parcela.
        /// </summary>
        public ControladorParcela ControladorParcela
        {
            get { return controladorParcela; }
        }

        private ControladorTitular controladorTitular;
        /// <summary>
        ///  Propriedade apenas de retorno do Controlador de Titular.
        /// </summary>
        public ControladorTitular ControladorTitular
        {
            get { return controladorTitular; }
        }

        /// <summary>
        /// Metodo para inicializar os Construtores.
        /// </summary>
        private void InitControladores()
        {
            //Controlador Cidade e Estado
            IRepositorioCidadeEstado repCidadeEstado = new RepositorioCidadeEstado();
            this.controladorCidadeEstado = new ControladorCidadeEstado(repCidadeEstado);
            //Controlador Plano
            IRepositorioPlano repPlano = new RepositorioPlano();
            this.controladorPlano = new ControladorPlano(repPlano);
            //Controlador Parcela
            IRepositorioHistoricoParcela repHistoricoParcela = new RepositorioHistoricoParcela();
            IRepositorioParcela repParcela = new RepositorioParcela();
            this.controladorParcela = new ControladorParcela(repParcela,repHistoricoParcela);
            //Controlador Contrato
            IRepositorioContrato repContrato = new RepositorioContrato();
            this.controladorContrato = new ControladorContrato(repContrato, controladorParcela, controladorPlano);
            //Controlador Dependente
            IRepositorioDependente repDependente = new RepositorioDependente();
            this.controladorDependente = new ControladorDependente(repDependente);
            //Controlador Titular
            IRepositorioTitular repTitular = new RepositorioTitular();
            this.controladorTitular = new ControladorTitular(repTitular, this.controladorContrato, this.controladorDependente, this.controladorCidadeEstado);
        }
    }
}
