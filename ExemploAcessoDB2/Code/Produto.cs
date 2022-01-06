using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ExemploAcessoDB2
{
    public class Produto
    {
        #region Atributos

        private const string connectionString = "Server=localhost;User=root;Password=sql$user;Database=dbteste;";

        #endregion

        #region Propriedades

        public bool HasError { get; set; } = false;
        public string MsgError { get; set; } = string.Empty;

        public int Id_prod { get; set; } = 0;
        public string Nome_prod { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;

        #endregion

        #region Metodos

        public DataTable ListarProd(string pNome)
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;
            MySqlDataAdapter dataAdapter = null;

            DataTable result = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM tbproduto ORDER BY Id_produto;";

                command.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = pNome;

                dataAdapter = new MySqlDataAdapter(command);
                result = new DataTable();
                dataAdapter.Fill(result);
            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();

                if (dataAdapter != null)
                    dataAdapter.Dispose();
            }

            return result;
        }

        public void IncluirP()
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO tbproduto (Id_produto, nome_produto, descricao) VALUES (null, @nome_produto, @descricao);";

                command.Parameters.Add("@nome_produto", MySqlDbType.VarChar).Value = Nome_prod;
                command.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = Desc;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();
            }
        }

        public void AlterarP()
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = "UPDATE tbproduto SET nome_produto = @nome_produto, descricao = @descricao WHERE Id_produto = @Id_produto;";
                command.Parameters.Add("@Id_produto", MySqlDbType.Int32).Value = Id_prod;
                command.Parameters.Add("@nome_produto", MySqlDbType.VarChar).Value = Nome_prod;
                command.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = Desc;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();
            }
        }

        public void ExcluirP()
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM tbproduto WHERE Id_produto = @Id_produto;";

                command.Parameters.Add("@Id_produto", MySqlDbType.Int32).Value = Id_prod;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();
            }
        }

        public void SelecionarP(int pId)
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;
            MySqlDataReader dataReader = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = "SELECT Id_produto, nome_produto, descricao FROM tbproduto WHERE Id_produto = @Id_produto;";

                command.Parameters.Add("@Id_produto", MySqlDbType.Int32).Value = pId;

                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    int i = 0;

                    Id_prod = dataReader.IsDBNull(i) ? 0 : dataReader.GetInt32(i); i++;
                    Nome_prod = dataReader.IsDBNull(i) ? string.Empty : dataReader.GetString(i); i++;
                    Desc = dataReader.IsDBNull(i) ? string.Empty : dataReader.GetString(i); i++;
                }
                else
                {
                    Id_prod = 0;
                    Nome_prod = string.Empty;
                    Desc = string.Empty;
                }
            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();
            }
        }

        public bool ChecarId(int pId)
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;
            MySqlDataReader dataReader = null;

            bool result = false;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = "SELECT Id_produto FROM tbproduto WHERE Id_produto = @Id_produto AND Id_produto <> @Id_produto;";

                command.Parameters.Add("@Id_produto", MySqlDbType.Int32).Value = pId;

                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();
            }

            return result;
        }

        public DataTable ListarPorNome(string pnome)
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;
            MySqlDataAdapter dataAdapter = null;

            DataTable result = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM tbproduto WHERE nome_produto LIKE @Nome ORDER BY Id_produto";

                command.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = pnome;


                dataAdapter = new MySqlDataAdapter(command);
                result = new DataTable();
                dataAdapter.Fill(result);
            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();

                if (dataAdapter != null)
                    dataAdapter.Dispose();
            }

            return result;
        }

        public DataTable ListarPorId(int pid)
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;
            MySqlDataAdapter dataAdapter = null;

            DataTable result = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM tbproduto WHERE Id_produto LIKE @Id OR @Id = 0 ORDER BY Id_produto";

                command.Parameters.Add("@Id", MySqlDbType.Int32).Value = pid;


                dataAdapter = new MySqlDataAdapter(command);
                result = new DataTable();
                dataAdapter.Fill(result);
            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();

                if (dataAdapter != null)
                    dataAdapter.Dispose();
            }

            return result;
        }

        public DataTable ListarPorDesc(string pdesc)
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;
            MySqlDataAdapter dataAdapter = null;

            DataTable result = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM tbproduto WHERE descricao LIKE @Desc ORDER BY Id_produto";

                command.Parameters.Add("@Desc", MySqlDbType.VarChar).Value = pdesc;


                dataAdapter = new MySqlDataAdapter(command);
                result = new DataTable();
                dataAdapter.Fill(result);
            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();

                if (dataAdapter != null)
                    dataAdapter.Dispose();
            }

            return result;
        }




        /*public DataTable SelectId(int idcbb)
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;
            MySqlDataAdapter dataAdapter = null;

            DataTable resultid = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM tbproduto WHERE Id_produto LIKE @ID ORDER BY Id_produto;";

                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = idcbb;

                dataAdapter = new MySqlDataAdapter(command);
                resultid = new DataTable();
                dataAdapter.Fill(resultid);
            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();

                if (dataAdapter != null)
                    dataAdapter.Dispose();
            }
            return resultid;

        }*/

        /*public DataTable SelectDesc(string desccbb)
        {
            HasError = false;
            MsgError = string.Empty;

            MySqlConnection connection = null;
            MySqlCommand command = null;
            MySqlDataAdapter dataAdapter = null;

            DataTable result = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM tbproduto WHERE descricao LIKE @Desc ORDER BY descricao;";

                command.Parameters.Add("@Desc", MySqlDbType.VarChar).Value = desccbb;

                dataAdapter = new MySqlDataAdapter(command);
                result = new DataTable();
                dataAdapter.Fill(result);
            }
            catch (Exception ex)
            {
                HasError = true;
                MsgError = ex.Message;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();

                if (command != null)
                    command.Dispose();

                if (dataAdapter != null)
                    dataAdapter.Dispose();
            }
            return result;

        }*/


        #endregion
    }
}