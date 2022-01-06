using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAcessoDB2
{
    public class Cliente
    {
        //encapsulamento

        /*private string _Nome = string.Empty; // atributo privado

        public string Nome
        {
            get
            {
                return _Nome;
            }
            set
            {
                _Nome = value;
            }
        }*/

        #region Atributos

        private const string connectionString = "Server=localhost;User=root;Password=sql$user;Database=dbteste;";

        #endregion

        #region Propriedades

        public bool HasError { get; set; } = false;
        public string MsgError { get; set; } = string.Empty;

        public int Id { get; set; } = 0;
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;

        #endregion

        #region Metodos

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
                command.CommandText = "INSERT INTO tbcliente (Id, Nome, CPF) VALUES (null, @Nome, @CPF);";

                command.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = Nome;
                command.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = CPF;

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
                command.CommandText = "UPDATE tbcliente SET Nome = @Nome, CPF = @CPF WHERE Id = @Id;";

                command.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
                command.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = Nome;
                command.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = CPF;

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
                command.CommandText = "DELETE FROM tbcliente WHERE Id = @Id;";

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
                command.CommandText = "SELECT Id, Nome, CPF FROM tbcliente WHERE Id = @Id;";

                command.Parameters.Add("@Id", MySqlDbType.Int32).Value = pId;

                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    int i = 0;

                    Id = dataReader.IsDBNull(i) ? 0 : dataReader.GetInt32(i); i++;
                    Nome = dataReader.IsDBNull(i) ? string.Empty : dataReader.GetString(i); i++;
                    CPF = dataReader.IsDBNull(i) ? string.Empty : dataReader.GetString(i); i++;
                }
                else
                {
                    Id = 0;
                    Nome = string.Empty;
                    CPF = string.Empty;
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

        public bool ChecarCpf(int pId, string pCPF)
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
                command.CommandText = "SELECT CPF FROM tbcliente WHERE CPF = @CPF AND Id <> @Id;";

                command.Parameters.Add("@Id", MySqlDbType.Int32).Value = pId;
                command.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = pCPF;

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

        public static bool ValidaCPF(string vrCPF)

        {

            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "").Replace(",", "").Replace("_", "");

            if (valor.Length != 11)

                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;


            if (igual || valor == "12345678909")

                return false;


            int[] numeros = new int[11];


            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(

                  valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {

                if (numeros[9] != 0)

                    return false;

            }

            else if (numeros[9] != 11 - resultado)

                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {

                if (numeros[10] != 0)

                    return false;

            }

            else

                if (numeros[10] != 11 - resultado)

                return false;

            return true;

        }

        public DataTable Listar(string pTudo)
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
                command.CommandText = "SELECT * FROM tbcliente ORDER BY Id;";

                command.Parameters.Add("@Tudo", MySqlDbType.VarChar).Value = pTudo;

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
                command.CommandText = "SELECT * FROM tbcliente WHERE Nome LIKE @Nome ORDER BY Id";

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
                command.CommandText = "SELECT * FROM tbcliente WHERE Id LIKE @Id OR @Id = 0 ORDER BY Id";

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

        public DataTable ListarPorCpf(string pcpf)
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
                command.CommandText = "SELECT * FROM tbcliente WHERE CPF LIKE @Cpf ORDER BY Id";

                command.Parameters.Add("@Cpf", MySqlDbType.VarChar).Value = pcpf;


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

    }
}
        #endregion

