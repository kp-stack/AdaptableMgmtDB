﻿using MySql.Data.MySqlClient;
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
using AdaptableMgmtWPF.Login;


namespace AdaptableMgmtWPF
{

    public partial class WinRegister2 : Window
    {
        public WinRegister2()
        {
            InitializeComponent();

            
        }


        // Aqui um novo usuário é registrado com os dados fornecidos, instanciando uma classe pré desenhada. 
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            
            
            string login = loginTextbox.Text;
            string password = passwordBox.Password;

            new SignUpUser(login, password);

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            

        }

    }
}
