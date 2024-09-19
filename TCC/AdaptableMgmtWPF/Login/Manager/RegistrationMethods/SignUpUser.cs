using System;
using System.Windows;
using MySql.Data.MySqlClient;
using AdaptableMgmtWPF.Login.ConnectionFactory;
using System.Data;

/*
    Classe SignUpUser:
    Esta classe é responsável pelo cadastro de usuários e gerentes no banco de dados MySQL. Ela contém os seguintes membros:

    - Atributos:
        - login: Armazena o nome de usuário.
        - password: Armazena a senha do usuário.
        - master: Booleano opcional que indica se o usuário é mestre (não utilizado diretamente na classe).
        - UserId: Propriedade estática que armazena o ID do usuário registrado.

    - Construtores:
        - SignUpUser(string login, string password): Inicializa a classe com o login e a senha do usuário.
        - SignUpUser(string login, string password, bool master): Inicializa a classe com login, senha e define se é um usuário mestre.

    - Métodos:
        - SignUp():
            Este método faz a verificação se o nome de usuário já existe no banco de dados. Caso já exista, ele retorna uma tupla `(true, false)`, indicando que o usuário já está cadastrado e que a inserção não foi realizada. 
            Caso o nome de usuário não exista, ele faz a inserção do novo usuário na tabela `login` com os campos `user_id`, `login_user` e `password_user`, retornando `(false, true)` para indicar que o cadastro foi bem-sucedido.

        - SignUpManager():
            Semelhante ao método `SignUp`, este método verifica se o nome de usuário já existe no banco de dados. 
            Se o usuário não existir, ele insere um novo gerente na tabela `login`, com os campos `login_user`, `password_user`, e define `acces_manager` como TRUE. Caso o usuário já exista, ele retorna uma tupla `(true, false)`.

    Observações:
        - A classe utiliza a classe `ConnectionBuild` para criar a conexão com o banco de dados.
        - No método `SignUp`, o `user_id` é recuperado como `LastInsertedId` e atribuído à propriedade estática `UserId` da classe `SignUpUser`.
*/

namespace AdaptableMgmtWPF.Login.Manager.RegistrationMethods
{
    class SignUpUser
    {
        private string login;
        private string password;
        bool master;
        public static long UserId { get; set; }


        public SignUpUser(string login, string password)
        {
            this.login = login;
            this.password = password;
        }


        public SignUpUser(string login, string password, bool master)
        {
            this.login = login;
            this.password = password;
            this.master = master;
        }


        // Inserção de um novo usuário
        public (bool userExist, bool registerWorks) SignUp()
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
                connection.Close();
                return (true, false);
                
            }
            else
            {
                // Inserção do novo usuário
                string insertQuery = "INSERT INTO login (user_id,login_user, password_user) VALUES (@user_id, @login_user, @password_user)";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);

                  // Recupera o user_id gerado
                 long userId = insertCmd.LastInsertedId;

                SignUpUser.UserId = DataUser.userId;

                insertCmd.Parameters.AddWithValue("@user_id", userId);
                insertCmd.Parameters.AddWithValue("@login_user", login);
                insertCmd.Parameters.AddWithValue("@password_user", password);

                insertCmd.ExecuteNonQuery();

                connection.Close();
                return (false, true);
            }

            
        }

        // Inserção de um novo gerente
        public (bool userExist, bool registerWorks) SignUpManager()
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
                connection.Close();
                return (true, false);

            }
            else
            {
                // Inserção do novo gerente
                string insertQuery = "INSERT INTO login (login_user, password_user, acces_manager) VALUES (@login_user, @password_user, TRUE)";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@login_user", login);
                insertCmd.Parameters.AddWithValue("@password_user", password);

                insertCmd.ExecuteNonQuery();

                connection.Close();
                return (false, true);
            }

            
        }
    }
}
