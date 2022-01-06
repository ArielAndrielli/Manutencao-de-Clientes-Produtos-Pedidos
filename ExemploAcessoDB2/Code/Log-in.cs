using ExemploAcessoDB2.Forms.Pedidos;
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

namespace ExemploAcessoDB2.Login
{
    class Log_in
    {

        #region Atributos

        private const string connectionString = "Server=localhost;User=root;Password=sql$user;Database=dbteste;";

        #endregion

        #region Propriedades

        public bool HasError { get; set; } = false;
        public string MsgError { get; set; } = string.Empty;

        public int Id { get; set; } = 0;
        public string Nome { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        #endregion

        #region Métodos

        public void Cadastrar()
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
                command.CommandText = "INSERT INTO tblogin (Id, Nome, Senha) VALUES (null, @Nome, @Senha);";

                command.Parameters.Add("@Nome", MySqlDbType.String).Value = Nome;
                command.Parameters.Add("@Senha", MySqlDbType.String).Value = Senha;

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

        public bool VerificarCadastro(string CadNome, string CadSenha)
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
                command.CommandText = "SELECT Nome, Senha FROM tblogin WHERE Nome = @Nome AND Senha = @Senha;";

                command.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = CadNome;
                command.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = CadSenha;

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

        #endregion
    }
}
