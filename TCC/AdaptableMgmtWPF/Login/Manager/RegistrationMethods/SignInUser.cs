using MySql.Data.MySqlClient;
using AdaptableMgmtWPF.Login.ConnectionFactory;



using System;
using System.Windows;

namespace AdaptableMgmtWPF.Login.Manager.RegistrationMethods
{
    public class SignInUser
    {
        private string login;
        private string password;
        private bool isManager;

        public SignInUser(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public (bool login, bool ismanager) AuthenticateUser()
        {
            //Instanciação da classe ConnectionBuild utilização do método Start() 
            ConnectionBuild connectionBuild = new ConnectionBuild();
            MySqlConnection connection = connectionBuild.Start();


            // Verifica se o usuário e a senha existem na tabela
            string query = "SELECT COUNT(*) FROM login WHERE login_user = @login_user AND password_user = @password_user";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            // Define os parâmetros para o comando
            cmd.Parameters.AddWithValue("@login_user", login);
            cmd.Parameters.AddWithValue("@password_user", password);

            // Executa o comando para verificar o número de registros
            int userCount = Convert.ToInt32(cmd.ExecuteScalar());

            // Verifica o nível de acesso
            string queryAccess = "SELECT acces_manager FROM login WHERE login_user = @login_user AND password_user = @password_user";
            MySqlCommand command = new MySqlCommand(queryAccess, connection);

            // Define os parâmetros para o comando de acesso
            command.Parameters.AddWithValue("@login_user", login);
            command.Parameters.AddWithValue("@password_user", password);

            // Executa o comando para verificar se o usuário é um gerente
            bool isManager = Convert.ToBoolean(command.ExecuteScalar());

            // Fecha a conexão
            connection.Close();

            if (userCount > 0)
                {   if (isManager)
                    {
                     return (true, isManager);

                }
                    return (true, false); ; // Login bem-sucedido
                }
                else
                {
                return (false, false);// Nome de usuário ou senha incorretos
            }
            
        }
    }
}

