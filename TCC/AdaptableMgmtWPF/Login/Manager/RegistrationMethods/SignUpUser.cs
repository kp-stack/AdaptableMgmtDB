using System;
using System.Windows;
using MySql.Data.MySqlClient;
using AdaptableMgmtWPF.Login.ConnectionFactory;

namespace AdaptableMgmtWPF.Login.Manager.RegistrationMethods
{
    class SignUpUser
    {
        private string login;
        private string password;
        bool master;

        public SignUpUser(string login, string password)
        {
            this.login = login;
            this.password = password;
            SignUp(login, password);
        }


        public SignUpUser(string login, string password, bool master)
        {
            this.login = login;
            this.password = password;
            this.master = master;
            SignUpManager(login, password);
        }

        // Inserção de um novo usuário
        public void SignUp(string login, string password)
        {
            // Instanciação da classe ConnectionBuild e uso do método Start()
            ConnectionBuild connectionBuild = new ConnectionBuild();
            MySqlConnection connection = connectionBuild.Start();

            // Verifica se o nome de usuário já existe
            string checkUserQuery = "SELECT COUNT(*) FROM login WHERE login_user = @login_user";
            MySqlCommand checkCmd = new MySqlCommand(checkUserQuery, connection);
            checkCmd.Parameters.AddWithValue("@login_user", login);

            int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (userExists > 0)
            {
                MessageBox.Show("Nome de usuário já existe. Escolha outro.");
            }
            else
            {
                // Inserção do novo usuário
                string insertQuery = "INSERT INTO login (login_user, password_user) VALUES (@login_user, @password_user)";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@login_user", login);
                insertCmd.Parameters.AddWithValue("@password_user", password);

                insertCmd.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso!");
            }

            connection.Close();
        }

        // Inserção de um novo gerente
        public void SignUpManager(string login, string password)
        {
            // Instanciação da classe ConnectionBuild e uso do método Start()
            ConnectionBuild connectionBuild = new ConnectionBuild();
            MySqlConnection connection = connectionBuild.Start();

            // Verifica se o nome de usuário já existe
            string checkUserQuery = "SELECT COUNT(*) FROM login WHERE login_user = @login_user";
            MySqlCommand checkCmd = new MySqlCommand(checkUserQuery, connection);
            checkCmd.Parameters.AddWithValue("@login_user", login);

            int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (userExists > 0)
            {
                MessageBox.Show("Nome de usuário já existe. Escolha outro.");
            }
            else
            {
                // Inserção do novo gerente
                string insertQuery = "INSERT INTO login (login_user, password_user, acces_manager) VALUES (@login_user, @password_user, TRUE)";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@login_user", login);
                insertCmd.Parameters.AddWithValue("@password_user", password);

                insertCmd.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso!");
            }

            connection.Close();
        }
    }
}
