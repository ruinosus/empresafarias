using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocio.controladores;
using Repositorio.interfaces;
using Repositorio.implementacoes;
using ClassesBasicas;

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

        private ControladorUsuario controladorUsuario;

        /// <summary>
        ///  Propriedade apenas de retorno do Controlador de Usuario.
        /// </summary>
        public ControladorUsuario ControladorUsuario
        {
            get { return controladorUsuario; }
        }

        private Usuario usuario;

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        /// <summary>
        /// Metodo para inicializar os Construtores.
        /// </summary>
        private void InitControladores()
        {
            //Controlador de Usuario
            IRepositorioPerfil repPerfil = new RepositorioPerfil();
            IRepositorioUsuario repUsuario = new RepositorioUsuario();
            this.controladorUsuario = new ControladorUsuario(repUsuario, repPerfil);
            //Controlador Cidade e Estado
            IRepositorioCidadeEstado repCidadeEstado = new RepositorioCidadeEstado();
            this.controladorCidadeEstado = new ControladorCidadeEstado(repCidadeEstado);
            //Controlador Plano
            IRepositorioPlano repPlano = new RepositorioPlano();
            this.controladorPlano = new ControladorPlano(repPlano);
            //Controlador Parcela
            IRepositorioHistoricoParcela repHistoricoParcela = new RepositorioHistoricoParcela();
            IRepositorioParcela repParcela = new RepositorioParcela();
            this.controladorParcela = new ControladorParcela(repParcela, repHistoricoParcela,controladorUsuario);
            //Controlador Contrato
            IRepositorioContrato repContrato = new RepositorioContrato();
            IRepositorioHistoricoContrato repHistoricoContrato = new RepositorioHistoricoContrato();
            this.controladorContrato = new ControladorContrato(repContrato, controladorParcela, controladorPlano, repHistoricoContrato,controladorUsuario);
            //Controlador Dependente
            IRepositorioDependente repDependente = new RepositorioDependente();
            IRepositorioHistoricoDependente repHistoricoDependente = new RepositorioHistoricoDependente();
            this.controladorDependente = new ControladorDependente(repDependente, repHistoricoDependente,controladorUsuario);
            //Controlador Titular
            IRepositorioTitular repTitular = new RepositorioTitular();
            IRepositorioHistoricoTitular repHistoricoTitular = new RepositorioHistoricoTitular();
            this.controladorTitular = new ControladorTitular(repTitular, this.controladorContrato, this.controladorDependente, this.controladorCidadeEstado,repHistoricoTitular,controladorUsuario);
        }
    }
}
