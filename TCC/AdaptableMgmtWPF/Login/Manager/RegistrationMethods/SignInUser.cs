using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace AdaptableMgmtWPF.Login.Manager.RegistrationMethods
{
    public class SignInUser
    {
        private string login;
        private string password;

        public SignInUser(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public bool AuthenticateUser()
        {
            string connectionString = "Server=localhost;Port=3305;Database=adaptablemgmtdb;User Id=root;Password=1011007Grb#;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Verifica se o usuário e a senha existem na tabela
                string query = "SELECT COUNT(*) FROM user WHERE login_user = @login_user AND password_user = @password_user";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@login_user", login);
                cmd.Parameters.AddWithValue("@password_user", password);

                int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                if (userCount > 0)
                {
                    return true; // Login bem-sucedido
                }
                else
                {
                    return false; // Nome de usuário ou senha incorretos
                }
            }
        }
    }
}

