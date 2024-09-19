using System.Windows;
using AdaptableMgmtWPF.Login.Manager.RegistrationMethods;
using AdaptableMgmtWPF.Login;


namespace AdaptableMgmtWPF
{

    public partial class WinRegister2 : Window
    {

        bool master;

        public WinRegister2()
        {
            InitializeComponent();
        
        }

        public WinRegister2(bool master)
        {
            InitializeComponent();
            this.master = master;
        }


        // Aqui um novo usuário é registrado com os dados fornecidos, instanciando uma classe pré desenhada. 
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {


            string login = loginTextbox.Text;
            string password = passwordBox.Password;

            // Caso seja master
            if (master)
            {
                SignUpUser signUpUser = new SignUpUser(login, password, master);
                (bool userExist, bool registerWorks) result = signUpUser.SignUpManager();

                if (result.userExist)
                {
                    MessageBox.Show("Nome de usuário já existe. Escolha outro.");
                }

                else if (result.registerWorks)
                {
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }

            else
            {
                SignUpUser signUpUser =  new SignUpUser(login, password);
                (bool userExist, bool registerWorks) result = signUpUser.SignUp();


                if (result.userExist)
                {
                    MessageBox.Show("Nome de usuário já existe. Escolha outro.");
                }

                else if (result.registerWorks)
                {
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
        }

    }
}
