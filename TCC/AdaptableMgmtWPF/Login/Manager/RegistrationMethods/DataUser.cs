using MySql.Data.MySqlClient;
using AdaptableMgmtWPF.Login.ConnectionFactory;

/*
    Classe DataUser:
    Esta classe é responsável pelo registro de dados de usuários e gerentes no banco de dados MySQL. Ela armazena informações detalhadas do colaborador e contém métodos para inserir esses dados no banco.

    - Atributos:
        - firstName: Armazena o primeiro nome do usuário.
        - lastName: Armazena o sobrenome do usuário.
        - salary: Armazena o salário do usuário (tipo double).
        - phone: Armazena o número de telefone do usuário.
        - addressLine1: Armazena a primeira linha do endereço do usuário.
        - addressLine2: Armazena a segunda linha do endereço do usuário.
        - city: Armazena a cidade do usuário.
        - state: Armazena o estado do usuário.
        - postalCode: Armazena o código postal do usuário.
        - cpf: Armazena o CPF do usuário.
        - userId: Campo estático interno que armazena o ID do usuário registrado.

    - Construtor:
        - DataUser(string firstName, string lastName, double salary, string phone, string addressLine1, string addressLine2, string city, string state, string postalCode, string cpf):
          Inicializa a classe com todas as informações pessoais e de contato do usuário, além do CPF e salário.

    - Métodos:
        - RegisterManagerData():
            Este método insere um novo gerente na tabela `collaborator` no banco de dados. Os dados do gerente são armazenados nos respectivos campos (`first_name`, `last_name`, `salary`, `phone_number`, `cpf`, `address_line1`, `address_line2`, `city`, `state`, `postal_code`) e o campo `acces_manager` é definido como TRUE.
            Ele retorna `true` se o cadastro for bem-sucedido, ou `false` se ocorrer um erro durante a execução da query ou na conexão.

        - RegisterDataUser():
            Semelhante ao método `RegisterManagerData`, este método insere um novo usuário (não gerente) na tabela `collaborator`. A única diferença é que o campo `acces_manager` não é incluído.
            Ele também retorna `true` se a inserção for realizada com sucesso e `false` em caso de erro.

    Observações:
        - Ambos os métodos fazem uso da classe `ConnectionBuild` para abrir a conexão com o banco de dados.
        - Após a inserção dos dados no método `RegisterDataUser`, o ID gerado pelo banco de dados é recuperado por meio de `LastInsertedId` e pode ser usado posteriormente.
*/


namespace AdaptableMgmtWPF.Login.Manager.RegistrationMethods
{
    public class DataUser
    {
        // Declaração inicial de variáveis
        string firstName;
        string lastName;
        double salary;
        string phone;
        string addressLine1;
        string addressLine2;
        string city;
        string state;
        string postalCode;
        string cpf;
        internal static long userId;

        public DataUser(string firstName, string lastName, double salary, string phone, string addressLine1, string addressLine2, string city, string state, string postalCode, string cpf)
        { 
           this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
            this.phone = phone;
            this.addressLine1 = addressLine1;
            this.addressLine2 = addressLine2;
            this.city = city;
            this.state = state;
            this.postalCode = postalCode;
            this.cpf = cpf;
        }


        public bool RegisterManagerData()
        {

            try
            {


                // Instanciação da classe ConnectionBuild e uso do método Start()
                ConnectionBuild connectionBuild = new ConnectionBuild();
                MySqlConnection connection = connectionBuild.Start();

                string sql = "INSERT INTO collaborator (first_name, last_name, salary, phone_number, cpf, address_line1, address_line2, city, state, postal_code, acces_manager) " +
                                 "VALUES (@firstName, @lastName, @salary, @phone, @cpf, @addressLine1, @addressLine2, @city, @state, @postalCode, @acces_manager)";

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@firstName", this.firstName);
                cmd.Parameters.AddWithValue("@lastName", this.lastName);
                cmd.Parameters.AddWithValue("@salary", this.salary);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@addressLine1", this.addressLine1);
                cmd.Parameters.AddWithValue("@addressLine2", this.addressLine2);
                cmd.Parameters.AddWithValue("@city", this.city);
                cmd.Parameters.AddWithValue("@state", this.state);
                cmd.Parameters.AddWithValue("@postalCode", this.postalCode);
                cmd.Parameters.AddWithValue("@cpf", this.cpf);

                // A única diferença é que muda o valor "acces_manager" para true
                cmd.Parameters.AddWithValue("@acces_manager", true);

                cmd.ExecuteNonQuery();


                connection.Close();



                return true; //deu tudo na medida

            }

            catch
            {

                return false; //deu algum bo de conversão ou conexão

            }
        }
            
               
          
        


        public bool RegisterDataUser()
        {


            try
            {


                // Instanciação da classe ConnectionBuild e uso do método Start()
                ConnectionBuild connectionBuild = new ConnectionBuild();
                MySqlConnection connection = connectionBuild.Start();

                string sql = "INSERT INTO collaborator (first_name, last_name, salary, phone_number, cpf, address_line1, address_line2, city, state, postal_code) " +
                                 "VALUES (@firstName, @lastName, @salary, @phone, @cpf, @addressLine1, @addressLine2, @city, @state, @postalCode)";

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@firstName", this.firstName);
                cmd.Parameters.AddWithValue("@lastName", this.lastName);
                cmd.Parameters.AddWithValue("@salary", this.salary);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@addressLine1", this.addressLine1);
                cmd.Parameters.AddWithValue("@addressLine2", this.addressLine2);
                cmd.Parameters.AddWithValue("@city", this.city);
                cmd.Parameters.AddWithValue("@state", this.state);
                cmd.Parameters.AddWithValue("@postalCode", this.postalCode);
                cmd.Parameters.AddWithValue("@cpf", this.cpf);

                cmd.ExecuteNonQuery();


                connection.Close();

                // Recupera o user_id gerado
                long userId = cmd.LastInsertedId;



                return true; //deu tudo na medida

            }

            catch {
            
                return false; //deu algum bo de conversão ou conexão
            
            }
        }


    }

}
