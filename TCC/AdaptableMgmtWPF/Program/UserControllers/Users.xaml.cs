using AdaptableMgmtWPF.Login.ConnectionFactory;
using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AdaptableMgmtWPF.Program.UserControllers
{
    public partial class Users : UserControl
    {
        bool accesManager;


        public Users(bool accesManager)
        {
            InitializeComponent(); this.accesManager = accesManager;
        }


        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Implementação da lógica de busca ou deixe vazio, se não for necessário
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            // Implementação da lógica de busca ou deixe vazio, se não for necessário
        }


    }
}
