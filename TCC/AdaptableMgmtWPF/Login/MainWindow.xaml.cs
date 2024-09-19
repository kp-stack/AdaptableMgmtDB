//Aqui está presente o principal objetivo do projeto: A organização de um código modular. Utilizando como principio o uso de diretivas possivelmente reutilizáveis para facilitar a manutebilidade do sistema
//Também estando presente o framework necessário para a utilização do banco de dados


using MySql.Data.MySqlClient;
using System;
using System.Windows;
using AdaptableMgmtWPF.Login.Manager.RegistrationMethods;
using AdaptableMgmtWPF.Program;
using AdaptableMgmtWPF.Login.Manager;


//Aqui Namespace está de acordo com a diretiva da pasta
namespace AdaptableMgmtWPF.Login
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        //Neste método privado é realizado o Sign in do Usuário. Sendo realizada a chamada de outra classe, de diretiva:   AdaptableMgmtWPF.Login.Manager.RegistrationMethods 
        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = loginUser.Text;
            string password = labelPassword.Password;



            //está condicional indica se é ou não user_master
            if (login == "leopoldo.batista" && password == "1011007Grb#")
            {

                bool master = true;
                WinRegister winRegister = new WinRegister(master);
                winRegister.Show();
                this.Close();
            }


            //Classes de verificação de login e senha
            else
            {

                // Aqui é feita a instanciação da classe SignInUser com 2 parametros
                SignInUser signInUser = new SignInUser(login, password);

                // Aqui está presente o retorno do método AuthenticateUser  (se o usuário existe). sendo em tupla.
                (bool login, bool isManager) result = signInUser.AuthenticateUser();


                // Lógica do retorno obtido
                if (result.login)
                {
                    if (result.isManager)
                    {
                        WinManager winManager = new WinManager();
                        winManager.Show();
                        this.Close();
                    }
                    else
                    {
                        WinHomeScreen homeScreen = new WinHomeScreen();
                        homeScreen.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nome de usuário ou senha incorretos.");
                }
            }

        }


        //Este método é responsável por sair do programa
        private void buttonOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();          
        }
    }
}
