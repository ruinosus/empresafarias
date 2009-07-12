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
    public class Fachada : Singleton<Fachada>
    {
        //private static Fachada instancia;

        ///// <summary>
        ///// Construtor padrão da Fachada, inicializando os Construtores.
        ///// </summary>
        //private Fachada()
        //{
        //    InitControladores();
        //    this.usuario = new Usuario();
        //}

        ///// <summary>
        ///// Metodo estatico responsavel por obter uma Instancia do Objeto Fachada
        ///// Implementando o metodo Singleton.
        ///// </summary>
        ///// <returns>Retorna um Objeto do tipo Fachada</returns>
        //public static Fachada ObterInstancia()
        //{
        //    if (instancia == null)
        //    {
        //        instancia = new Fachada();
        //    }
        //    return instancia;
        //}       

        private ControladorPlano controladorPlano;

        /// <summary>
        ///  Propriedade apenas de retorno do Controlador de Plano.
        /// </summary>
        public ControladorPlano ControladorPlano
        {
            get
            {
                if (this.controladorPlano == null)
                    InitControladores();
                return controladorPlano;
            }
        }

        private ControladorCidadeEstado controladorCidadeEstado;

        /// <summary>
        ///  Propriedade apenas de retorno do Controlador de Cidade e Estado.
        /// </summary>
        public ControladorCidadeEstado ControladorCidadeEstado
        {
            get
            {
                if (this.controladorCidadeEstado == null)
                    InitControladores();
                return controladorCidadeEstado;
            }
        }

        private ControladorContrato controladorContrato;

        /// <summary>
        ///  Propriedade apenas de retorno do Controlador de Contrato.
        /// </summary>
        public ControladorContrato ControladorContrato
        {
            get
            {
                if (this.controladorContrato == null)
                    InitControladores();
                return controladorContrato;
            }
        }

        private ControladorDependente controladorDependente;

        /// <summary>
        ///  Propriedade apenas de retorno do Controlador de Dependente.
        /// </summary>
        public ControladorDependente ControladorDependente
        {
            get
            {
                if (this.controladorDependente == null)
                    InitControladores();
                return controladorDependente;
            }
        }

        private ControladorParcela controladorParcela;

        /// <summary>
        ///  Propriedade apenas de retorno do Controlador de Parcela.
        /// </summary>
        public ControladorParcela ControladorParcela
        {
            get
            {
                if (this.controladorParcela == null)
                    InitControladores();
                return controladorParcela;
            }
        }

        private ControladorTitular controladorTitular;

        /// <summary>
        ///  Propriedade apenas de retorno do Controlador de Titular.
        /// </summary>
        public ControladorTitular ControladorTitular
        {
            get
            {
                if (this.controladorTitular == null)
                    InitControladores();
                return controladorTitular;
            }
        }

        private ControladorUsuario controladorUsuario;

        /// <summary>
        ///  Propriedade apenas de retorno do Controlador de Usuario.
        /// </summary>
        public ControladorUsuario ControladorUsuario
        {
            get
            {
                if (this.controladorUsuario == null)
                    InitControladores();
                return controladorUsuario;
            }
        }

        private Usuario usuario;

        public Usuario Usuario
        {
            get
            {
                if (this.usuario == null)
                    this.usuario = new Usuario();
                return usuario;

            }
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
            this.controladorParcela = new ControladorParcela(repParcela, repHistoricoParcela, controladorUsuario);
            //Controlador Contrato
            IRepositorioContrato repContrato = new RepositorioContrato();
            IRepositorioHistoricoContrato repHistoricoContrato = new RepositorioHistoricoContrato();
            this.controladorContrato = new ControladorContrato(repContrato, controladorParcela, controladorPlano, repHistoricoContrato, controladorUsuario);
            //Controlador Dependente
            IRepositorioDependente repDependente = new RepositorioDependente();
            IRepositorioHistoricoDependente repHistoricoDependente = new RepositorioHistoricoDependente();
            this.controladorDependente = new ControladorDependente(repDependente, repHistoricoDependente, controladorUsuario);
            //Controlador Titular
            IRepositorioTitular repTitular = new RepositorioTitular();
            IRepositorioHistoricoTitular repHistoricoTitular = new RepositorioHistoricoTitular();
            this.controladorTitular = new ControladorTitular(repTitular, this.controladorContrato, this.controladorDependente, this.controladorCidadeEstado, repHistoricoTitular, controladorUsuario);
        }

        /// <summary>
        /// Consulta todos os Objetos do Tipo informado.
        /// </summary>
        /// <typeparam name="T">Tipo do Objeto a ser retornado.</typeparam>
        /// <returns>Uma Lista com todos os Objetos encontrados daquele tipo.</returns>
        /// <example>
        /// List<Plano> list = new List<Plano>();
        /// Fachada fachada = Fachada.GetInstancia();
        /// list = fachada.Consultar<Plano>();
        /// </example>
        private List<T> Consultar<T>()
        {
            Type type = typeof(T);

            //Verifica se é do tipo Plano
            if (type == typeof(Plano))
            {
                return this.controladorPlano.Consultar() as List<T>;
            }

            //Verifica se é do tipo Estado
            if (type == typeof(Estado))
            {
                return this.controladorCidadeEstado.Consultar() as List<T>;
            }

            //Verifica se é do tipo Contrato
            if (type == typeof(Contrato))
            {
                return this.controladorContrato.Consultar() as List<T>;
            }

            //Verifica se é do tipo Dependente
            if (type == typeof(Dependente))
            {
                return this.controladorDependente.Consultar() as List<T>;
            }

            //Verifica se é do tipo Parcela
            if (type == typeof(Parcela))
            {
                return this.controladorParcela.Consultar() as List<T>;
            }

            //Verifica se é do tipo Titular
            if (type == typeof(Titular))
            {
                return this.controladorTitular.Consultar() as List<T>;
            }

            //Verifica se é do tipo Usuario
            if (type == typeof(Usuario))
            {
                return this.controladorUsuario.Consultar() as List<T>;
            }

            return new List<T>();

        }

        /// <summary>
        /// Insere um novo registro no Banco de Dados.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto genérico</typeparam>
        /// <param name="objeto">Objeto genérico contendo os valores para o INSERT</param>
        /// <returns>Id o Objeto Inserido no Banco</returns>
        /// <example>
        /// Usuario obj = new Usuario();
        /// obj.Nome = "nome";
        /// obj.Login = "login";
        /// obj.Senha = "senha";
        /// Fachada fachada = Fachada.Instance;
        /// obj = fachada.Inserir<Usuario>(obj);
        /// </example>
        private int Inserir<T>(T objeto)
        {
            Type type = typeof(T);

            //Verifica se é do tipo Plano
            if (objeto is Plano)
            {
                this.controladorPlano.Inserir(objeto as Plano);
                return 0;
            }
            //Verifica se é do tipo Contrato
            if (type == typeof(Contrato))
            {
                return this.controladorContrato.Inserir(objeto as Contrato, this.usuario).Id;
            }
            //Verifica se é do tipo Dependente
            if (type == typeof(Dependente))
            {
                return this.controladorDependente.Inserir(objeto as Dependente, this.usuario).Id;
            }
            //Verifica se é do tipo Parcela
            if (type == typeof(Parcela))
            {
                return this.controladorParcela.Inserir(objeto as Parcela, this.usuario).Id;
            }
            //Verifica se é do tipo Titular
            if (type == typeof(Titular))
            {
                return this.controladorTitular.Inserir(objeto as Titular, this.usuario).Id;
            }
            //Verifica se é do tipo Usuario
            if (type == typeof(Usuario))
            {
                this.controladorUsuario.Inserir(objeto as Usuario);
                return 0;
            }
            throw new Exception("Inclusão não realizada.");
        }

        /// <summary>
        /// Altera um registro no Banco de Dados.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto genérico</typeparam>
        /// <param name="objeto">Objeto genérico contendo os valores para o UPDATE</param>
        /// <returns>Id o Objeto Inserido no Banco</returns>
        /// <example>
        /// Usuario obj = new Usuario();
        /// obj.Nome = "novo nome";
        /// obj.Login = "novo login";
        /// obj.Senha = "novo senha";
        /// Fachada fachada = Fachada.Instance;
        /// obj = fachada.Alterar<Usuario>(obj);
        /// </example>
        private void Alterar<T>(T objeto)
        {
            Type type = typeof(T);

            //Verifica se é do tipo Plano
            if (objeto is Plano)
            {
                this.controladorPlano.Alterar(objeto as Plano);
            }
            //Verifica se é do tipo Contrato
            if (type == typeof(Contrato))
            {
                this.controladorContrato.Alterar(objeto as Contrato, this.usuario);
            }
            //Verifica se é do tipo Dependente
            if (type == typeof(Dependente))
            {
                this.controladorDependente.Alterar(objeto as Dependente, this.usuario);
            }
            //Verifica se é do tipo Parcela
            if (type == typeof(Parcela))
            {
                this.controladorParcela.Alterar(objeto as Parcela, this.usuario);
            }
            //Verifica se é do tipo Titular
            if (type == typeof(Titular))
            {
                this.controladorTitular.Alterar(objeto as Titular, this.usuario);
            }
            //Verifica se é do tipo Usuario
            if (type == typeof(Usuario))
            {
                this.controladorUsuario.Alterar(objeto as Usuario);
            }
            throw new Exception("Alteração não realizada.");
        }
    }
}
