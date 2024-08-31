using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdaptableMgmtWPF.Login.Manager.RegistrationMethods
{
     class SignUpUser
    {
        private string login;
        private string password;

        public SignUpUser(string login, string password) {

            this.login = login;
            this.password = password;

            SignUp(login, password);
               
        }
        


        public void SignUp(string login, string password)
        {
            string connectionString = "Server=localhost;Port=3305;Database=adaptablemgmtdb;User Id=root;Password=1011007Grb#;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Verifica se o nome de usuário já existe
                string checkUserQuery = "SELECT COUNT(*) FROM user WHERE login_user = @login_user";
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
                    string definicaoMaster = "INSERT INTO user (login_user, password_user) VALUES (@login_user, @password_user)";
                    MySqlCommand definicaoMasterINSERT = new MySqlCommand(definicaoMaster, connection);
                    definicaoMasterINSERT.Parameters.AddWithValue("@login_user", login);
                    definicaoMasterINSERT.Parameters.AddWithValue("@password_user", password);

                    definicaoMasterINSERT.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso!");
                }

                connection.Close();
            }

        }
    }
}
