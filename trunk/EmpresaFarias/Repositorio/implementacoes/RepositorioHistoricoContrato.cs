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
    /// Classe responsavel por implementar a IRepositorioHistoricoContrato.
    /// </summary>
    public class RepositorioHistoricoContrato : IRepositorioHistoricoContrato
    {
        #region Sql Tabela HistoricoContrato

        private static String QUERY_INSERT = "INSERT INTO HistoricoContrato (DataInicio,Status,TitularId,PlanoId,ContratoId,DataAlteracao,UsuarioId,Descricao) VALUES (@DataInicio,@Status,@TitularId,@PlanoId,@ContratoId,@DataAlteracao,@UsuarioId,@Descricao)";
        private static String QUERY_SELECT_ID = "SELECT Id,DataInicio,Status,TitularId,PlanoId,ContratoId,DataAlteracao,UsuarioId,Descricao FROM HistoricoContrato WHERE Id = @Id";
        private static String QUERY_SELECT_ALL = "SELECT Id,DataInicio,Status,TitularId,PlanoId,ContratoId,DataAlteracao,UsuarioId,Descricao FROM HistoricoContrato";
        private static String QUERY_MAX_ID = "SELECT MAX(Id) Id FROM  HistoricoContrato";
        private static String QUERY_SELECT_CONTRATO = "SELECT Id,DataInicio,Status,TitularId,PlanoId,ContratoId,DataAlteracao,UsuarioId,Descricao FROM HistoricoContrato WHERE ContratoId=@ContratoId";
        

        #endregion

        #region Membros de IRepositorioHistoricoContrato

        /// <summary>
        /// Metodo responsavel por inserir um HistoricoContrato.
        /// </summary>
        /// <param name="historicoContrato">Objeto do tipo HistoricoContrato a ser inserido</param>
        /// <returns>retorna o HistoricoContrato inserido.</returns>        
        public HistoricoContrato Inserir(HistoricoContrato historicoContrato)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_INSERT, conexao);
                comando.Parameters.AddWithValue("@DataInicio", historicoContrato.ContratoHistorico.DataInicio);
                comando.Parameters.AddWithValue("@PlanoId", historicoContrato.ContratoHistorico.Plano.Id);
                comando.Parameters.AddWithValue("@Status", (int)historicoContrato.ContratoHistorico.Status);
                comando.Parameters.AddWithValue("@TitularId", historicoContrato.ContratoHistorico.TitularId);
                comando.Parameters.AddWithValue("@ContratoId", historicoContrato.Contrato.Id);
                comando.Parameters.AddWithValue("@DataAlteracao", historicoContrato.DataAlteracao);
                comando.Parameters.AddWithValue("@UsuarioId", historicoContrato.Usuario.Id);
                comando.Parameters.AddWithValue("@Descricao", historicoContrato.Descricao);
                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();
                //historicoContrato.ContratoHistorico.Id = this.ObterMaximoId();
            }
            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
            return historicoContrato;
        }
        
        /// <summary>
        /// Metodo responsavel por consultar um HistoricoContrato.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um HistoricoContrato com o Id informado.</returns>
        public HistoricoContrato Consultar(int id)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            HistoricoContrato historicoContrato = null;
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_ID, conexao);
                SqlDataReader resultado;
                comando.Parameters.AddWithValue("@Id", id);
                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();
                if (resultado.HasRows)
                {
                    historicoContrato = this.CriarHistoricoContrato(resultado);
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

            return historicoContrato;
        }

        /// <summary>
        /// Metodo responsavel por consultar todos os HistoricosContrato cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os HistoricosContrato cadastrados.</returns>
        public List<HistoricoContrato> Consultar()
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<HistoricoContrato> historicos = new List<HistoricoContrato>();
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_ALL, conexao);
                SqlDataReader resultado;
                conexao.Open();

                resultado = comando.ExecuteReader();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        historicos.Add(this.CriarHistoricoContrato(resultado));
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

            return historicos;
        }

        /// <summary>
        /// Metodo responsavel por consultar uma lista contendo todos os HistoricosContrato do Contrato Informado.
        /// </summary>
        /// <param name="contrato">Objeto do tipo Contrato a ser pesquisado.</param>
        /// <returns>retorna uma lista contendo todos os HistoricosContrato do Contrato Informado.</returns>
        public List<HistoricoContrato> Consultar(Contrato contrato)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<HistoricoContrato> historicos = new List<HistoricoContrato>();
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_CONTRATO, conexao);
                comando.Parameters.AddWithValue("@ContratoId",contrato.Id);
                SqlDataReader resultado;
                conexao.Open();

                resultado = comando.ExecuteReader();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        historicos.Add(this.CriarHistoricoContrato(resultado));
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

            return historicos;
        }

        /// <summary>
        /// Devolve o numero do maior Id inserido;
        /// </summary>
        /// <returns>valor do maior id</returns>
        private int ObterMaximoId()
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            int id = 0;
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_MAX_ID, conexao);
                SqlDataReader resultado;
                conexao.Open();

                resultado = comando.ExecuteReader();
                resultado.Read();
                if (resultado.HasRows)
                {
                    if (resultado["Id"] != DBNull.Value)
                    {
                        id = Convert.ToInt32(resultado["Id"]);
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

            return id;
        }

        #endregion

        /// <summary>
        /// Metodo para montar um HistoricoContrato recebendo um SqlDataReader como parametro.
        /// </summary>
        /// <param name="resultado">SqlDataReader</param>
        /// <returns>Retorna um HistoricoContrato</returns>
        private HistoricoContrato CriarHistoricoContrato(SqlDataReader resultado)
        {
            HistoricoContrato historicoContrato = new HistoricoContrato();

            if (resultado["Id"] != DBNull.Value)
            {
                historicoContrato.ContratoHistorico.Id = Convert.ToInt32(resultado["Id"]);
            }
            if (resultado["DataInicio"] != DBNull.Value)
            {
                historicoContrato.ContratoHistorico.DataInicio = Convert.ToDateTime(resultado["DataInicio"]);
            }
            if (resultado["PlanoId"] != DBNull.Value)
            {
                historicoContrato.ContratoHistorico.Plano.Id = Convert.ToInt32(resultado["PlanoId"]);
            }
            if (resultado["Status"] != DBNull.Value)
            {
                historicoContrato.ContratoHistorico.Status = (StatusControle)Convert.ToInt32(resultado["Status"]);
            }

            if (resultado["ContratoId"] != DBNull.Value)
            {
                historicoContrato.Contrato.Id = Convert.ToInt32(resultado["ContratoId"]);
            }
            if (resultado["TitularId"] != DBNull.Value)
            {
                historicoContrato.Contrato.TitularId = Convert.ToInt32(resultado["TitularId"]);
            }
            if (resultado["DataAlteracao"] != DBNull.Value)
            {
                historicoContrato.DataAlteracao = Convert.ToDateTime(resultado["DataAlteracao"]);
            }
            if (resultado["UsuarioId"] != DBNull.Value)
            {
                historicoContrato.Usuario.Id = Convert.ToInt32(resultado["UsuarioId"]);
            }
            if (resultado["Descricao"] != DBNull.Value)
            {
                historicoContrato.Descricao = Convert.ToString(resultado["Descricao"]);
            }
            return historicoContrato;
        }
    }
}
