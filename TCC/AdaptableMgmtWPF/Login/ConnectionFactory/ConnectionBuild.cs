using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace AdaptableMgmtWPF.Login.ConnectionFactory
{
    public class ConnectionBuild
    {

        public MySqlConnection Start() {

            //Máquina local Gabriel:
            string connectionString = "Server=localhost;Port=3305;Database=adaptablemgmtdb;User Id=root;Password=1011007Grb#;";

            //Máquina local Eduardo:
            //string connectionString = "Server=localhost;Port=3305;Database=adaptablemgmtdb;User Id=root;Password=1011007Grb#;";

            //Máquina local Daniel:
            //string connectionString = "Server=localhost;Port=3305;Database=adaptablemgmtdb;User Id=root;Password=1011007Grb#;";


            //Etec
            //string connectionString = "Server=127.0.0.1;Port=3306;Database=adaptablemgmtdb;User Id=alunos;Password=etec;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            
                connection.Open();
                return connection;
        }




    }
}
