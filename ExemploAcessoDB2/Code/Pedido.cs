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

namespace ExemploAcessoDB2.Forms.Pedidos
{
    class Pedido
    {
        #region Atributos

        private const string connectionString = "Server=localhost;User=root;Password=sql$user;Database=dbteste;";

        #endregion

        #region Propriedades
        public bool HasError { get; set; } = false;

        public string MsgError { get; set; } = string.Empty;

        public int Id_cli { get; set; } = 0;

        public int Id_pedido { get; set; } = 0;

        #endregion

        #region Metodo

        public DataTable Listar()
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
                command.CommandText = "SELECT * FROM tbpedidos ORDER BY Id_pedido;";

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

        public void Inserir()
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
                command.CommandText = "INSERT INTO tbpedidos (Id_pedido, Id_cliente) VALUES (null, @Id_cliente); SELECT LAST_INSERT_ID();";

                command.Parameters.Add("@Id_cliente", MySqlDbType.Int32).Value = Id_cli;

                object objIdentity = command.ExecuteScalar();
                if (objIdentity != null)
                    if (int.TryParse(objIdentity.ToString(), out int pIdPedido))
                        Id_pedido = pIdPedido;
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
                command.CommandText = "UPDATE tbpedidos SET Id_cliente = @Id_cliente WHERE Id_pedido = @Id_pedido;";

                command.Parameters.Add("@Id_pedido", MySqlDbType.Int32).Value = Id_pedido;
                command.Parameters.Add("@Id_cliente", MySqlDbType.Int32).Value = Id_cli;

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

        public void Remover()
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
                command.CommandText = "DELETE FROM tbpedidos WHERE Id_pedido = @Id_pedido;";

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
                command.CommandText = "SELECT Id_pedido, Id_cliente FROM tbpedidos WHERE Id_pedido = @Id_pedido;";

                command.Parameters.Add("@Id_pedido", MySqlDbType.Int32).Value = pId;

                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    int i = 0;

                    Id_pedido = dataReader.IsDBNull(i) ? 0 : dataReader.GetInt32(i); i++;
                    Id_cli = dataReader.IsDBNull(i) ? 0 : dataReader.GetInt32(i); i++;
                }
                else
                {
                    Id_pedido = 0;
                    Id_cli = 0;
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
                command.CommandText = "SELECT Id_pedido FROM tbcliente WHERE Id_pedido = @Id_pedido;";

                command.Parameters.Add("@Id_pedido", MySqlDbType.Int32).Value = pId;

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

        public DataTable ListarPorIdPedido(int pid)
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
                    "SELECT                    " +
                    "    pd.Id_pedido,         " +
                    "    pd.Id_cliente,        " +
                    "    cl.Nome               " +
                    "FROM tbpedidos pd         " +
                    "INNER JOIN tbcliente cl   " +
                    "ON pd.Id_cliente = cl.Id  " +
                    "WHERE Id_pedido LIKE @Id OR @Id = 0 " +
                    "ORDER BY Id_pedido ";

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
                    "SELECT  " +
                    "    pd.Id_pedido,         " +
                    "    pd.Id_cliente,        " +
                    "    cl.Nome               " + 
                    "FROM tbpedidos pd         " +
                    "INNER JOIN tbcliente cl   " +
                    "ON pd.Id_cliente = cl.Id  " +
                    "WHERE Id_cliente LIKE @Id OR @Id = 0 " +
                    "ORDER BY Id_cliente";

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



        #endregion
    }
}
