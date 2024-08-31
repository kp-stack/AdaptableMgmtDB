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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*

            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            int sallary = Convert.ToInt32(SalaryTextBox.Text);
            int phone = Convert.ToInt32(PhoneNumberTextBox.Text);
            string address1 = AddressLine1TextBox.Text;
            string address2 = AddressLine2TextBox.Text;
            string city = CityTextBox.Text;
            string state = StateTextBox.Text;
            int cep = Convert.ToInt32(PostalCodeTextBox.Text);
            int cpf = Convert.ToInt32(CpfTextBox.Text);



            new DataUser(firstName, lastName, sallary, phone, address1, address2, city, state, cep, cpf);
            */
            /*
            WinRegister2 winRegister2 = new WinRegister2();
            winRegister2.Show();
            this.Close();
            */


        }


        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Conexao pro banco de dados....

            mostrar uma mensagem que deu certo

            GERAR UM CÓDIGO DE USUARIO UNICO
        }
        */
    }
}
