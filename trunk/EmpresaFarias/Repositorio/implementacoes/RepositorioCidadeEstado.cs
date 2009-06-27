using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio.interfaces;
using ClassesBasicas;
using System.Data.SqlClient;
using Excecoes;

namespace Repositorio.implementacoes
{
    /// <summary>
    /// Classe responsavel por implementar a IRepositorioCidadeEstado.
    /// </summary>
    public class RepositorioCidadeEstado : IRepositorioCidadeEstado
    {
        #region Sql Tabela Cidade e Estado

        private static String QUERY_SELECT_ESTADO = "SELECT Id, Nome, Sigla  FROM Estados";
        private static String QUERY_SELECT_CIDADE = "SELECT c.Id CidadeId,c.Nome NomeCidade,e.Id EstadoId,e.Nome NomeEstado,e.Sigla SiglaEstado FROM Cidades c inner join Estados e on c.EstadoId = e.Id where e.Id = @Id";
        private static String QUERY_SELECT_CIDADE_ESTADO = "SELECT c.Id CidadeId,c.Nome NomeCidade,e.Id EstadoId,e.Nome NomeEstado,e.Sigla SiglaEstado FROM Cidades c inner join Estados e on c.EstadoId = e.Id where c.Id = @Id";

        #endregion

        #region Membros de IRepositorioCidadeEstado
        /// <summary>
        /// Metodo responsavel por retornar todos os Estados cadastrados.
        /// </summary>
        /// <returns>Lista com todos os Estados cadastrados.</returns>
        public List<Estado> Consultar()
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<Estado> estados = new List<Estado>();
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_ESTADO, conexao);
                SqlDataReader resultado;
                conexao.Open();

                resultado = comando.ExecuteReader();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        Estado estado = new Estado();

                        if (resultado["Id"] != DBNull.Value)
                        {
                            estado.Id = Convert.ToInt32(resultado["Id"]);
                        }
                        if (resultado["Nome"] != DBNull.Value)
                        {
                            estado.Nome = Convert.ToString(resultado["Nome"]);
                        }
                        if (resultado["Sigla"] != DBNull.Value)
                        {
                            estado.Sigla = Convert.ToString(resultado["Sigla"]);
                        }

                        estados.Add(estado);
                    }
                }
                resultado.Close();
            }

            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return estados;
        }
        /// <summary>
        /// Metodo responsavel por retornar todas as Cidades do Estado informado.
        /// </summary>
        /// <param name="estado">Estado para pesquisa. </param>
        /// <returns>Lista com todas as Cidades do Estado informado.</returns>
        public List<Cidade> Consultar(Estado estado)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<Cidade> cidades = new List<Cidade>();
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_CIDADE, conexao);
                SqlDataReader resultado;
                comando.Parameters.AddWithValue("@Id", estado.Id);
                conexao.Open();

                resultado = comando.ExecuteReader();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {

                        cidades.Add(this.CriarCidade(resultado));
                    }
                }
                resultado.Close();
            }

            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return cidades;
        }
        /// <summary>
        /// Metodo responsavel por retornar uma Cidade com o Id informado.
        /// </summary>
        /// <param name="Id">Id da Cidade a ser pesquisada.</param>
        /// <returns>Objeto do tipo Cidade com o Id informado</returns>
        public Cidade Consultar(int id)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            Cidade cidade = null;
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_CIDADE_ESTADO, conexao);
                SqlDataReader resultado;
                comando.Parameters.AddWithValue("@Id", id);
                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();
                if (resultado.HasRows)
                {
                    cidade = this.CriarCidade(resultado);
                }

                resultado.Close();
            }

            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }

            return cidade;
        }

        #endregion
        
        /// <summary>
        /// Metodo para montar uma Cidade recebendo um SqlDataReader como parametro.
        /// </summary>
        /// <param name="resultado">SqlDataReader</param>
        /// <returns>Retorna uma Cidade</returns>
        private Cidade CriarCidade(SqlDataReader resultado)
        {
            Cidade cidade = new Cidade();

            if (resultado["CidadeId"] != DBNull.Value)
            {
                cidade.Id = Convert.ToInt32(resultado["CidadeId"]);
            }
            if (resultado["NomeCidade"] != DBNull.Value)
            {
                cidade.Nome = Convert.ToString(resultado["NomeCidade"]);
            }
            if (resultado["EstadoId"] != DBNull.Value)
            {
                cidade.Estado.Id = Convert.ToInt32(resultado["EstadoId"]);
            }
            if (resultado["NomeEstado"] != DBNull.Value)
            {
                cidade.Estado.Nome = Convert.ToString(resultado["NomeEstado"]);
            }
            if (resultado["SiglaEstado"] != DBNull.Value)
            {
                cidade.Estado.Sigla = Convert.ToString(resultado["SiglaEstado"]);
            }
            return cidade;
        }
    }
}
