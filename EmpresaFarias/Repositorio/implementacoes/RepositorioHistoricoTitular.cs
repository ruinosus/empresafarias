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
    /// Classe responsavel por implementar a IRepositorioHistoricoTitular.
    /// </summary>
    public class RepositorioHistoricoTitular : IRepositorioHistoricoTitular
    {
        #region Sql Tabela HistoricoTitular

        private static String QUERY_INSERT = "INSERT INTO HistoricoTitular (Nome,Religiao,DataNascimento,Sexo,EstadoCivil,Cpf,Logradouro,Numero,Complemento,Bairro,Cep,CidadeEnderecoId,CidadeNaturalidadeId,TelefoneResidencial,TelefoneCelular,Rg,DataExpedicao,OrgaoExpeditor,Status,TitularId,DataAlteracao,UsuarioId,Descricao) VALUES (@Nome,@Religiao,@DataNascimento,@Sexo,@EstadoCivil,@Cpf,@Logradouro,@Numero,@Complemento,@Bairro,@Cep,@CidadeEnderecoId,@CidadeNaturalidadeId,@TelefoneResidencial,@TelefoneCelular,@Rg,@DataExpedicao,@OrgaoExpeditor,@Status,@TitularId,@DataAlteracao,@UsuarioId,@Descricao)";
        private static String QUERY_SELECT_ID = "SELECT Id,Nome,Religiao,DataNascimento,Sexo,EstadoCivil,Cpf,Logradouro,Numero,Complemento,Bairro,Cep,CidadeEnderecoId,CidadeNaturalidadeId,TelefoneResidencial,TelefoneCelular,Rg,DataExpedicao,OrgaoExpeditor,Status,TitularId,DataAlteracao,UsuarioId,Descricao FROM HistoricoTitular WHERE Id = @Id";
        private static String QUERY_SELECT_ALL = "SELECT Id,Nome,Religiao,DataNascimento,Sexo,EstadoCivil,Cpf,Logradouro,Numero,Complemento,Bairro,Cep,CidadeEnderecoId,CidadeNaturalidadeId,TelefoneResidencial,TelefoneCelular,Rg,DataExpedicao,OrgaoExpeditor,Status,TitularId,DataAlteracao,UsuarioId,Descricao FROM HistoricoTitular";
        private static String QUERY_MAX_ID = "SELECT MAX(Id) Id FROM HistoricoTitular";
        private static String QUERY_SELECT_TITULAR = "SELECT Id,Nome,Religiao,DataNascimento,Sexo,EstadoCivil,Cpf,Logradouro,Numero,Complemento,Bairro,Cep,CidadeEnderecoId,CidadeNaturalidadeId,TelefoneResidencial,TelefoneCelular,Rg,DataExpedicao,OrgaoExpeditor,Status,TitularId,DataAlteracao,UsuarioId,Descricao FROM HistoricoTitular WHERE TitularId=@TitulatId";
        
        #endregion

        #region Membros de IRepositorioHistoricoTitular

        /// <summary>
        /// Metodo responsavel por inserir um HistoricoTitular.
        /// </summary>
        /// <param name="historicoTitular">Objeto do tipo HistoricoTitular a ser inserido</param>
        /// <returns>retorna o HistoricoTitular inserido.</returns>
        public HistoricoTitular Inserir(HistoricoTitular historicoTitular)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_INSERT, conexao);
                comando.Parameters.AddWithValue("@Nome", historicoTitular.TitularHistorico.Nome);
                comando.Parameters.AddWithValue("@Religiao", historicoTitular.TitularHistorico.Religiao);
                comando.Parameters.AddWithValue("@CidadeNaturalidadeId", historicoTitular.TitularHistorico.CidadeNaturalidade.Id);
                comando.Parameters.AddWithValue("@Cpf", historicoTitular.TitularHistorico.Cpf);
                comando.Parameters.AddWithValue("@DataNascimento", historicoTitular.TitularHistorico.DataNascimento);
                comando.Parameters.AddWithValue("@Bairro", historicoTitular.TitularHistorico.Endereco.Bairro);
                comando.Parameters.AddWithValue("@Cep", historicoTitular.TitularHistorico.Endereco.Cep);
                comando.Parameters.AddWithValue("@CidadeEnderecoId", historicoTitular.TitularHistorico.Endereco.Cidade.Id);
                comando.Parameters.AddWithValue("@Complemento", historicoTitular.TitularHistorico.Endereco.Complemento);
                comando.Parameters.AddWithValue("@Logradouro", historicoTitular.TitularHistorico.Endereco.Logradouro);
                comando.Parameters.AddWithValue("@Numero", historicoTitular.TitularHistorico.Endereco.Numero);
                comando.Parameters.AddWithValue("@EstadoCivil", historicoTitular.TitularHistorico.EstadoCivil);
                comando.Parameters.AddWithValue("@Rg", historicoTitular.TitularHistorico.Rg.Numero);
                comando.Parameters.AddWithValue("@DataExpedicao", historicoTitular.TitularHistorico.Rg.DataExpedicao);
                comando.Parameters.AddWithValue("@OrgaoExpeditor", historicoTitular.TitularHistorico.Rg.OrgaoExpeditor);
                comando.Parameters.AddWithValue("@Sexo", historicoTitular.TitularHistorico.Sexo);
                comando.Parameters.AddWithValue("@Status", (int)historicoTitular.TitularHistorico.Status);
                comando.Parameters.AddWithValue("@TelefoneCelular", historicoTitular.TitularHistorico.TelefoneCelular);
                comando.Parameters.AddWithValue("@TelefoneResidencial", historicoTitular.TitularHistorico.TelefoneResidencial);
                comando.Parameters.AddWithValue("@TitularId", historicoTitular.Titular.Id);
                comando.Parameters.AddWithValue("@DataAlteracao", historicoTitular.DataAlteracao);
                comando.Parameters.AddWithValue("@UsuarioId", historicoTitular.Usuario.Id);
                comando.Parameters.AddWithValue("@Descricao", historicoTitular.Descricao);
                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();
               // historicoTitular.TitularHistorico.Id = this.ObterMaximoId();
            }
            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
            return historicoTitular;
        }

        /// <summary>
        /// Metodo responsavel por consultar um HistoricoTitular.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um HistoricoTitular com o Id informado.</returns>
        public HistoricoTitular Consultar(int id)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            HistoricoTitular historicoTitular = null;
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
                    historicoTitular = this.CriarHistoricoTitular(resultado);
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

            return historicoTitular;
        }

        /// <summary>
        /// Metodo responsavel por consultar todos os HistoricosTitular cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os HistoricosTitular cadastrados.</returns>
        public List<HistoricoTitular> Consultar()
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<HistoricoTitular> historicos = new List<HistoricoTitular>();
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
                        historicos.Add(this.CriarHistoricoTitular(resultado));
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

        /// <summary>
        /// Metodo responsavel por consultar uma lista contendo todos os HistoricosParcela do Titular Informado.
        /// </summary>
        /// <param name="titular">Objeto do tipo Titular a ser pesquisado.</param>
        /// <returns>retorna uma lista contendo todos os HistoricosDependente da Titular Informada.</returns>
        public List<HistoricoTitular> Consultar(Titular titular)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<HistoricoTitular> historicos = new List<HistoricoTitular>();
            try
            {
                SqlCommand comando = new SqlCommand(QUERY_SELECT_TITULAR, conexao);
                comando.Parameters.AddWithValue("@TitularId", titular.Id);
                SqlDataReader resultado;
                conexao.Open();

                resultado = comando.ExecuteReader();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        historicos.Add(this.CriarHistoricoTitular(resultado));
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

        #endregion

        /// <summary>
        /// Metodo para montar um HistoricoTitular recebendo um SqlDataReader como parametro.
        /// </summary>
        /// <param name="resultado">SqlDataReader</param>
        /// <returns>Retorna uma HistoricoTitular</returns>
        private HistoricoTitular CriarHistoricoTitular(SqlDataReader resultado)
        {
            HistoricoTitular historicoTitular = new HistoricoTitular();

            if (resultado["Id"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Id = Convert.ToInt32(resultado["Id"]);
            }
            if (resultado["DataNascimento"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.DataNascimento = Convert.ToDateTime(resultado["DataNascimento"]);
            }
            if (resultado["Nome"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Nome = Convert.ToString(resultado["Nome"]);
            }
            if (resultado["Religiao"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Religiao = Convert.ToString(resultado["Religiao"]);
            }
            if (resultado["EstadoCivil"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.EstadoCivil = Convert.ToString(resultado["EstadoCivil"]);
            }
            if (resultado["Status"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Status = (StatusControle)Convert.ToInt32(resultado["Status"]);
            }
            if (resultado["Cpf"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Cpf = Convert.ToString(resultado["Cpf"]);
            }
            if (resultado["CidadeNaturalidadeId"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.CidadeNaturalidade.Id = Convert.ToInt32(resultado["CidadeNaturalidadeId"]);
            }
            if (resultado["Rg"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Rg.Numero = Convert.ToString(resultado["Rg"]);
            }
            if (resultado["DataExpedicao"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Rg.DataExpedicao = Convert.ToDateTime(resultado["DataExpedicao"]);
            }
            if (resultado["OrgaoExpeditor"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Rg.OrgaoExpeditor = Convert.ToString(resultado["OrgaoExpeditor"]);
            }
            if (resultado["Sexo"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Sexo = Convert.ToChar(resultado["Sexo"]);
            }
            if (resultado["TelefoneCelular"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.TelefoneCelular = Convert.ToString(resultado["TelefoneCelular"]);
            }
            if (resultado["TelefoneResidencial"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.TelefoneResidencial = Convert.ToString(resultado["TelefoneResidencial"]);
            }
            if (resultado["Logradouro"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Endereco.Logradouro = Convert.ToString(resultado["Logradouro"]);
            }
            if (resultado["Bairro"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Endereco.Bairro = Convert.ToString(resultado["Bairro"]);
            }
            if (resultado["Cep"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Endereco.Cep = Convert.ToString(resultado["Cep"]);
            }
            if (resultado["CidadeEnderecoId"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Endereco.Cidade.Id = Convert.ToInt32(resultado["CidadeEnderecoId"]);
            }
            if (resultado["Complemento"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Endereco.Complemento = Convert.ToString(resultado["Complemento"]);
            }
            if (resultado["Numero"] != DBNull.Value)
            {
                historicoTitular.TitularHistorico.Endereco.Numero = Convert.ToString(resultado["Numero"]);
            }

            if (resultado["TitularId"] != DBNull.Value)
            {
                historicoTitular.Titular.Id = Convert.ToInt32(resultado["TitularId"]);
            }
            if (resultado["DataAlteracao"] != DBNull.Value)
            {
                historicoTitular.DataAlteracao = Convert.ToDateTime(resultado["DataAlteracao"]);
            }
            if (resultado["UsuarioId"] != DBNull.Value)
            {
                historicoTitular.Usuario.Id = Convert.ToInt32(resultado["UsuarioId"]);
            }
            if (resultado["Descricao"] != DBNull.Value)
            {
                historicoTitular.Descricao = Convert.ToString(resultado["Descricao"]);
            }


            return historicoTitular;
        }
    }
}
