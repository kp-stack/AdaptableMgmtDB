using System;
using System.Windows;
using AdaptableMgmtWPF.Login;
using AdaptableMgmtWPF.Login.Manager.RegistrationMethods;

namespace AdaptableMgmtWPF
{
    public partial class WinRegister : Window
    {
        bool master;

        public WinRegister()
        {
            InitializeComponent();
        }

        public WinRegister(bool master)
        {
            InitializeComponent();
            this.master = master;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            
            // Confere se não há nenhum campo vazio
            if (string.IsNullOrEmpty(FirstNameTextBox.Text) || string.IsNullOrEmpty(LastNameTextBox.Text) || string.IsNullOrEmpty(SalaryTextBox.Text)
                || string.IsNullOrEmpty(PhoneNumberTextBox.Text) || string.IsNullOrEmpty(AddressLine1TextBox.Text)
                || string.IsNullOrEmpty(CityTextBox.Text) || string.IsNullOrEmpty(StateTextBox.Text) || string.IsNullOrEmpty(PostalCodeTextBox.Text) ||
                   string.IsNullOrEmpty(CpfTextBox.Text))
            {
                MessageBox.Show("Preencha todas as informações necessárias");
            }

            //Conferir se há algum dado fora de formatação
            /*
            else if ()
            {

            }
            */
            else
            {
                // Passagem dos valores para as respectivas variáveis
                string firstName = FirstNameTextBox.Text;
                string lastName = LastNameTextBox.Text;
                double sallary = Convert.ToDouble(SalaryTextBox.Text);
                string phone = PhoneNumberTextBox.Text;
                string address1 = AddressLine1TextBox.Text;
                string address2 = AddressLine2TextBox.Text;
                string city = CityTextBox.Text;
                string state = StateTextBox.Text;
                string cep = PostalCodeTextBox.Text;
                string cpf = CpfTextBox.Text;


                // Caso a variável master esteja como verdadeira
                if (master)
                {
                    DataUser registerUser = new DataUser(firstName, lastName, sallary, phone, address1, address2, city, state, cep, cpf);
                    bool registerManagerWorks = registerUser.RegisterManagerData();

                    if (registerManagerWorks)
                    {
                        MessageBox.Show("Dados salvos com sucesso\n Insira o Login e senha do novo gerente");

                        WinRegister2 winRegister2 = new WinRegister2(master);
                        winRegister2.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro. \n\n Você será redirecionado à tela principal");

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                }



                else
                {

                    DataUser registerUser = new DataUser(firstName, lastName, sallary, phone, address1, address2, city, state, cep, cpf);
                    bool registerWorks = registerUser.RegisterDataUser();

                    if (registerWorks)
                    {
                        MessageBox.Show("Dados salvos com sucesso\n Insira o Login e senha do novo usuário");

                        WinRegister2 winRegister2 = new WinRegister2();
                        winRegister2.Show();
                        this.Close();

                    }

                    else
                    {
                        MessageBox.Show("Ocorreu um erro. \n\n Você será redirecionado à tela principal");

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();

                    }

                }
               

                

            }
        }

    }

}

