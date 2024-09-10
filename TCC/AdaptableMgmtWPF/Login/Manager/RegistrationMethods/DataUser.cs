using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using AdaptableMgmtWPF.Login.ConnectionFactory;



namespace AdaptableMgmtWPF.Login.Manager.RegistrationMethods
{
    public class DataUser
    {
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
        bool master;
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

        public DataUser(string firstName, string lastName, double salary, string phone, string addressLine1, string addressLine2, string city, string state, string postalCode, string cpf, bool master)
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
            this.master = master;
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
