using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAcessoDB2.Code
{
    class PDP
    {

        #region Atributos

        private const string connectionString = "Server=localhost;User=root;Password=sql$user;Database=dbteste;";

        #endregion

        #region Propriedades

        public bool HasError { get; set; } = false;
        public string MsgError { get; set; } = string.Empty;

        public int Id { get; set; } = 0;
        public int Id_pedido { get; set; } = 0;
        public int Id_produto { get; set; } = 0;

        #endregion

        #region Métodos

        public void Incluir()
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
                command.CommandText = "INSERT INTO tbprodutosdopedido (Id, Id_pedido, Id_produto) VALUES (null, @Id_pedido, @Id_produto);";

                command.Parameters.Add("@Id_pedido", MySqlDbType.Int32).Value = Id_pedido;
                command.Parameters.Add("@Id_produto", MySqlDbType.Int32).Value = Id_produto;

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

        public void Alterar()
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
                command.CommandText = "UPDATE tbprodutosdopedido SET Id_produto = @Id_produto WHERE Id = @Id;";

                command.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
                command.Parameters.Add("@Id_pedido", MySqlDbType.Int32).Value = Id_pedido;
                command.Parameters.Add("@Id_produto", MySqlDbType.Int32).Value = Id_produto;

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

        public void Excluir()
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
                command.CommandText = "DELETE FROM tbprodutosdopedido WHERE Id = @Id;";

                command.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;

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

        public void ExcluirPorPedido()
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
                command.CommandText = "DELETE FROM tbprodutosdopedido WHERE Id_pedido = @Id_pedido;";

                command.Parameters.Add("@Id_pedido", MySqlDbType.Int32).Value = Id_pedido;

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

        public void Selecionar(int pId)
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
                command.CommandText = "SELECT Id, Id_pedido, Id_produto FROM tbprodutosdopedido WHERE Id = @Id;";

                command.Parameters.Add("@Id", MySqlDbType.Int32).Value = pId;

                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    int i = 0;

                    Id = dataReader.IsDBNull(i) ? 0 : dataReader.GetInt32(i); i++;
                    Id_pedido = dataReader.IsDBNull(i) ? 0 : dataReader.GetInt32(i); i++;
                    Id_produto = dataReader.IsDBNull(i) ? 0 : dataReader.GetInt32(i); i++;
                }
                else
                {
                    Id = 0;
                    Id_pedido = 0;
                    Id_produto = 0;
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
                command.CommandText = 
                    "SELECT                      " +
                    "    prp.Id,                 " +
                    "    prp.Id_pedido,          " +
                    "    prp.Id_produto,         " +
                    "    pr.nome_produto         " +
                    "FROM tbprodutosdopedido prp " +
                    "INNER JOIN tbproduto pr     " +
                    "ON prp.Id_produto = pr.Id_produto " +
                    "WHERE Id_pedido LIKE @Id OR @Id = 0 ORDER BY Id";

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

        public void InnerJoin()
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
                command.CommandText = "SELECT a1.Id_produto, a2.nome_produto FROM dbteste.tbprodutosdopedido a1 INNER JOIN dbteste.tbproduto a2 ON a1.Id_produto = a2.Id_produto;";

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
            }
        }

        #endregion

    }
}
