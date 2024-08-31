using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdaptableMgmtWPF.Login.Manager.RegistrationMethods
{
    public class DataUser
    {
        string firstName;
        string lastName;
        double salary;
        long phone;
        string addressLine1;
        string addressLine2;
        string city;
        string state;
        string postalCode;
        string cpf;

        public DataUser(string firstName, string lastName, double salary, long phone, string addressLine1, string addressLine2, string city, string state, string postalCode, string cpf)
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

        public void RegisterDataUser(string firstName, string lastName, double salary, long phone, string addressLine1, string addressLine2, string city, string state, string postalCode, string cpf)
        {
            string connectionString = "Server=localhost;Port=3305;Database=adaptablemgmtdb;User Id=root;Password=1011007Grb#;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO collaborator (first_name, last_name, salary, phone_number, cpf, address_line1, address_line2, city, state, postal_code) " +
                             "VALUES (@firstName, @lastName, @salary, @phone, @cpf, @addressLine1, @addressLine2, @city, @state, @postalCode)";

                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@addressLine1", addressLine1);
                    cmd.Parameters.AddWithValue("@addressLine2", addressLine2);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@postalCode", postalCode);
                    cmd.Parameters.AddWithValue("@cpf", cpf);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
