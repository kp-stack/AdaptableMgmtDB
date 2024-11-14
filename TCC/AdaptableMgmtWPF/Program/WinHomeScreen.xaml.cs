using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using AdaptableMgmtWPF.Program.UserControllers;

namespace AdaptableMgmtWPF.Program
{
    public partial class WinHomeScreen : Window
    {

        bool accesManager;

        public WinHomeScreen(bool accesManager)
        {
            InitializeComponent();

            // Cria o ImageBrush e define o ImageSource da imagem
            ImageBrush userImageBrush = new ImageBrush();
            userImageBrush.ImageSource = new BitmapImage(new Uri("C:\\Leopoldo\\Development\\AdaptableMgmtDB\\TCC\\AdaptableMgmtWPF\\Program\\Assets\\userDefault.png", UriKind.Absolute));

            // Aplica a imagem ao Ellipse
            UserPhotoEllipse.Fill = userImageBrush;

            this.accesManager = accesManager;
        }

     





        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            UserControllers.Products products = new Products(accesManager);
            TelaContentControl.Content = products;
        }

        private void BtnStock_Click(object sender, RoutedEventArgs e)
        {
            Stock stock = new Stock(accesManager);
            TelaContentControl.Content = stock;
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users(accesManager);
            TelaContentControl.Content = users;
        }

        private void BtnCart_Click(object sender, RoutedEventArgs e)
        {
            Cart cart = new Cart(accesManager);
            TelaContentControl.Content = cart;
        }

        private void BtnOUT_Clicks(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
