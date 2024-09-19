using MySql.Data.MySqlClient;
using AdaptableMgmtWPF.Login.ConnectionFactory;
using System;

/*
    Classe SignInUser:
    Esta classe é responsável pela autenticação de usuários no sistema. Ela verifica as credenciais de login e senha fornecidas e determina se o usuário é um gerente ou um usuário comum.

    - Atributos:
        - login: Armazena o nome de usuário inserido.
        - password: Armazena a senha inserida.

    - Construtor:
        - SignInUser(string login, string password):
          Inicializa a classe com o nome de usuário e senha que serão verificados.

    - Métodos:
        - AuthenticateUser():
            Este método autentica o usuário no sistema, verificando se as credenciais fornecidas existem no banco de dados. Além disso, ele verifica o nível de acesso do usuário (se é gerente ou não).
            
            Funcionamento:
            1. Conecta ao banco de dados usando a classe `ConnectionBuild` e o método `Start()`.
            2. Executa uma query que conta o número de registros na tabela `login` onde o nome de usuário e a senha correspondem aos fornecidos.
            3. Executa uma segunda query para verificar se o campo `acces_manager` está definido como TRUE, indicando que o usuário é um gerente.
            4. Se as credenciais forem válidas, o método retorna uma tupla com dois valores:
                - `true` indicando que o login foi bem-sucedido.
                - `true` ou `false` indicando se o usuário é gerente (TRUE) ou não (FALSE).
            5. Se as credenciais forem inválidas, o método retorna `(false, false)`.

    - Retorno:
        - `(bool login, bool ismanager)`:
            - `login`: Indica se o login foi bem-sucedido.
            - `ismanager`: Indica se o usuário é um gerente (TRUE) ou não (FALSE).
*/


namespace AdaptableMgmtWPF.Login.Manager.RegistrationMethods
{
    public class SignInUser
    {
        private string login;
        private string password;

        // Construtor da classe
        public SignInUser(string login, string password)
        {
            this.login = login;
            this.password = password;
        }


        // Método com retorno do tipo de login e se o login é válido
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

