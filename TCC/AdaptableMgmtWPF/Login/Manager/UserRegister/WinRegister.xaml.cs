using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AdaptableMgmtWPF.Login;
using AdaptableMgmtWPF.Login.Manager.RegistrationMethods;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace AdaptableMgmtWPF
{
    /// <summary>
    /// Lógica interna para WinRegister.xaml
    /// </summary>
    public partial class WinRegister : Window
    {
        public WinRegister()
        {
            InitializeComponent();
        }

        public bool master { get; set; }

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

                if (master)
                {
                    DataUser registerUser = new DataUser(firstName, lastName, sallary, phone, address1, address2, city, state, cep, cpf, master);
                    bool registerManagerWorks = registerUser.RegisterManagerData();

                    if (registerManagerWorks)
                    {
                        MessageBox.Show("Dados salvos com sucesso\n Insira o Login e senha do novo gerente");

                        WinRegister2 winRegister2 = new WinRegister2(true);
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

