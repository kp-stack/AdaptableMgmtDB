using AdaptableMgmtWPF.Program;
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

//Aqui não foi necessária a utilização de classes criadas.

namespace AdaptableMgmtWPF.Login.Manager
{
    


    public partial class WinManager : Window
    {
        
        string classe;

        public WinManager()
        {

            InitializeComponent();

        }

        //Saudação simples com a permissão
        public WinManager(string classe)
        {
            
            InitializeComponent();

            this.classe = classe;

            greetingLabel.Content = "Olá, " + classe;
        }


        //Abrir o programa
        private void Buttonlogin_Click(object sender, RoutedEventArgs e)
        {
            WinHomeScreen winHomeScreen = new WinHomeScreen(true);
            winHomeScreen.Show();
            this.Close();
        }


        //Abrir a tela de cadastro de novo usuário
        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            WinRegister winRegister = new WinRegister();
            winRegister.Show();
            this.Close();
        }

     
    }
}
