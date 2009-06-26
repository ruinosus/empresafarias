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
    /// Classe responsavel por implementar a IRepositorioTitular.
    /// </summary>
    public class RepositorioTitular : IRepositorioTitular
    {
        #region Sql Tabela Titular

        private static String QUERY_INSERT = "INSERT INTO Titular (Nome,DataNascimento,Sexo,EstadoCivil,Cpf,Logradouro,Numero,Complemento,Bairro,Cep,CidadeEnderecoId,CidadeNaturalidadeId,TelefoneResidencial,TelefoneCelular,Rg,DataExpedicao,OrgaoExpeditor,Status) VALUES (@Nome,@DataNascimento,@Sexo,@EstadoCivil,@Cpf,@Logradouro,@Numero,@Complemento,@Bairro,@Cep,@CidadeEnderecoId,@CidadeNaturalidadeId,@TelefoneResidencial,@TelefoneCelular,@Rg,@DataExpedicao,@OrgaoExpeditor,@Status)";
        private static String QUERY_UPDATE = "UPDATE Titular SET Nome = @Nome,DataNascimento = @DataNascimento,Sexo = @Sexo,EstadoCivil = @EstadoCivil,Cpf = @Cpf,Logradouro = @Logradouro,Numero = @Numero,Complemento = @Complemento,Bairro = @Bairro,Cep = @Cep,CidadeEnderecoId = @CidadeEnderecoId,CidadeNaturalidadeId = @CidadeNaturalidadeId,TelefoneResidencial = @TelefoneResidencial,TelefoneCelular = @TelefoneCelular,Rg = @Rg,DataExpedicao = @DataExpedicao,OrgaoExpeditor = @OrgaoExpeditor,Status = @Status WHERE Id = @Id";
        private static String QUERY_DELETE = "DELETE FROM Titular WHERE Id = @Id";
        private static String QUERY_SELECT_ID = "SELECT Id,Nome,DataNascimento,Sexo,EstadoCivil,Cpf,Logradouro,Numero,Complemento,Bairro,Cep,CidadeEnderecoId,CidadeNaturalidadeId,TelefoneResidencial,TelefoneCelular,Rg,DataExpedicao,OrgaoExpeditor,Status FROM Titular WHERE Id = @Id";
        private static String QUERY_SELECT_ALL = "SELECT Id,Nome,DataNascimento,Sexo,EstadoCivil,Cpf,Logradouro,Numero,Complemento,Bairro,Cep,CidadeEnderecoId,CidadeNaturalidadeId,TelefoneResidencial,TelefoneCelular,Rg,DataExpedicao,OrgaoExpeditor,Status FROM Titular";

        #endregion

        #region Membros de IRepositorioTitular
        /// <summary>
        /// Metodo responsavel por inserir um Titular.
        /// </summary>
        /// <param name="titular">Objeto do tipo Titular a ser inserido</param>
        public void Inserir(Titular titular)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_INSERT, conexao);
                comando.Parameters.AddWithValue("@Nome", titular.Nome);
                comando.Parameters.AddWithValue("@CidadeNaturalidadeId", titular.CidadeNaturalidade.Id);
                comando.Parameters.AddWithValue("@Cpf", titular.Cpf);
                comando.Parameters.AddWithValue("@DataNascimento", titular.DataNascimento);
                comando.Parameters.AddWithValue("@Bairro", titular.Endereco.Bairro);
                comando.Parameters.AddWithValue("@Cep", titular.Endereco.Cep);
                comando.Parameters.AddWithValue("@CidadeEnderecoId", titular.Endereco.Cidade.Id);
                comando.Parameters.AddWithValue("@Complemento", titular.Endereco.Complemento);
                comando.Parameters.AddWithValue("@Logradouro", titular.Endereco.Logradouro);
                comando.Parameters.AddWithValue("@Numero", titular.Endereco.Numero);
                comando.Parameters.AddWithValue("@EstadoCivil", titular.EstadoCivil);
                comando.Parameters.AddWithValue("@Rg", titular.Rg.Numero);
                comando.Parameters.AddWithValue("@DataExpedicao", titular.Rg.DataExpedicao);
                comando.Parameters.AddWithValue("@OrgaoExpeditor", titular.Rg.OrgaoExpeditor);
                comando.Parameters.AddWithValue("@Sexo", titular.Sexo);
                comando.Parameters.AddWithValue("@Status", titular.Status);
                comando.Parameters.AddWithValue("@TelefoneCelular", titular.TelefoneCelular);
                comando.Parameters.AddWithValue("@TelefoneResidencial", titular.TelefoneResidencial);
                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
        }
        /// <summary>
        /// Metodo responsavel por alterar um Titular.
        /// </summary>
        /// <param name="dependente">Objeto do tipo Titular a ser alterado</param>
        public void Alterar(Titular titular)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_UPDATE, conexao);
                comando.Parameters.AddWithValue("@Id", titular.Id);
                comando.Parameters.AddWithValue("@Nome", titular.Nome);
                comando.Parameters.AddWithValue("@CidadeNaturalidadeId", titular.CidadeNaturalidade.Id);
                comando.Parameters.AddWithValue("@Cpf", titular.Cpf);
                comando.Parameters.AddWithValue("@DataNascimento", titular.DataNascimento);
                comando.Parameters.AddWithValue("@Bairro", titular.Endereco.Bairro);
                comando.Parameters.AddWithValue("@Cep", titular.Endereco.Cep);
                comando.Parameters.AddWithValue("@CidadeEnderecoId", titular.Endereco.Cidade.Id);
                comando.Parameters.AddWithValue("@Complemento", titular.Endereco.Complemento);
                comando.Parameters.AddWithValue("@Logradouro", titular.Endereco.Logradouro);
                comando.Parameters.AddWithValue("@Numero", titular.Endereco.Numero);
                comando.Parameters.AddWithValue("@EstadoCivil", titular.EstadoCivil);
                comando.Parameters.AddWithValue("@Rg", titular.Rg.Numero);
                comando.Parameters.AddWithValue("@DataExpedicao", titular.Rg.DataExpedicao);
                comando.Parameters.AddWithValue("@OrgaoExpeditor", titular.Rg.OrgaoExpeditor);
                comando.Parameters.AddWithValue("@Sexo", titular.Sexo);
                comando.Parameters.AddWithValue("@Status", titular.Status);
                comando.Parameters.AddWithValue("@TelefoneCelular", titular.TelefoneCelular);
                comando.Parameters.AddWithValue("@TelefoneResidencial", titular.TelefoneResidencial);
                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            }
        }
        /// <summary>
        /// Metodo responsavel por remover um Titular.
        /// </summary>
        /// <param name="id">Id do Titular a ser removido.</param>
        public void Remover(int id)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();

            try
            {
                SqlCommand comando = new SqlCommand(QUERY_DELETE, conexao);
                comando.Parameters.AddWithValue("@Id", id);
                conexao.Open();
                int regitrosAfetados = comando.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new ErroBanco(e.Message);
            }
            finally
            {
                banco.FecharConexao(conexao);
            } 
        }
        /// <summary>
        /// Metodo responsavel por consultar um Titular.
        /// </summary>
        /// <param name="id">Id a ser consultado.</param>
        /// <returns>retorna um Titular com o Id informado.</returns>
        public Titular Consultar(int id)
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            Titular titular = null;
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
                    titular = this.CriarTitular(resultado);
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

            return titular;
        }
        /// <summary>
        /// Metodo responsavel por consultar todos os Titulares cadastrados.
        /// </summary>
        /// <returns>retorna uma Lista com todos os Titulares cadastrados.</returns>
        public List<Titular> Consultar()
        {
            UtilBD banco = new UtilBD();
            SqlConnection conexao = banco.ObterConexao();
            List<Titular> titulares = new List<Titular>();
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
                        titulares.Add(this.CriarTitular(resultado));
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

            return titulares;
        }

        #endregion

        /// <summary>
        /// Metodo para montar um Titular recebendo um SqlDataReader como parametro.
        /// </summary>
        /// <param name="resultado">SqlDataReader</param>
        /// <returns>Retorna uma Titular</returns>
        private Titular CriarTitular(SqlDataReader resultado)
        {
            Titular titular = new Titular();

            if (resultado["Id"] != DBNull.Value)
            {
                titular.Id = Convert.ToInt32(resultado["Id"]);
            }
            if (resultado["DataNascimento"] != DBNull.Value)
            {
                titular.DataNascimento = Convert.ToDateTime(resultado["DataNascimento"]);
            }
            if (resultado["Nome"] != DBNull.Value)
            {
                titular.Nome = Convert.ToString(resultado["Nome"]);
            }
            if (resultado["EstadoCivil"] != DBNull.Value)
            {
                titular.EstadoCivil = Convert.ToString(resultado["EstadoCivil"]);
            }
            if (resultado["Status"] != DBNull.Value)
            {
                titular.Status = Convert.ToString(resultado["Status"]);
            }
            if (resultado["Cpf"] != DBNull.Value)
            {
                titular.Cpf = Convert.ToString(resultado["Cpf"]);
            }
            if (resultado["CidadeNaturalidadeId"] != DBNull.Value)
            {
                titular.CidadeNaturalidade.Id = Convert.ToInt32(resultado["CidadeNaturalidadeId"]);
            }
            if (resultado["Rg"] != DBNull.Value)
            {
                titular.Rg.Numero = Convert.ToString(resultado["Rg"]);
            }
            if (resultado["DataExpedicao"] != DBNull.Value)
            {
                titular.Rg.DataExpedicao = Convert.ToDateTime(resultado["DataExpedicao"]);
            }
            if (resultado["OrgaoExpeditor"] != DBNull.Value)
            {
                titular.Rg.OrgaoExpeditor = Convert.ToString(resultado["OrgaoExpeditor"]);
            }
            if (resultado["Sexo"] != DBNull.Value)
            {
                titular.Sexo = Convert.ToChar(resultado["Sexo"]);
            }
            if (resultado["TelefoneCelular"] != DBNull.Value)
            {
                titular.TelefoneCelular = Convert.ToString(resultado["TelefoneCelular"]);
            }
            if (resultado["TelefoneResidencial"] != DBNull.Value)
            {
                titular.TelefoneResidencial = Convert.ToString(resultado["TelefoneResidencial"]);
            }
            if (resultado["Logradouro"] != DBNull.Value)
            {
                titular.Endereco.Logradouro = Convert.ToString(resultado["Logradouro"]);
            }
            if (resultado["Bairro"] != DBNull.Value)
            {
                titular.Endereco.Bairro = Convert.ToString(resultado["Bairro"]);
            }
            if (resultado["Cep"] != DBNull.Value)
            {
                titular.Endereco.Cep = Convert.ToString(resultado["Cep"]);
            }
            if (resultado["CidadeEnderecoId"] != DBNull.Value)
            {
                titular.Endereco.Cidade.Id = Convert.ToInt32(resultado["CidadeEnderecoId"]);
            }
            if (resultado["Complemento"] != DBNull.Value)
            {
                titular.Endereco.Complemento = Convert.ToString(resultado["Complemento"]);
            }
            if (resultado["Numero"] != DBNull.Value)
            {
                titular.Endereco.Numero = Convert.ToString(resultado["Numero"]);
            }


            return titular;
        }
    }
}
