using System;
using System.Windows;
using MySql.Data.MySqlClient;
using AdaptableMgmtWPF.Login.ConnectionFactory;

namespace AdaptableMgmtWPF.Program.UserControllers.WindowsRegister
{
    public partial class RegisterCategory_Supplier : Window
    {
        bool accessManager;
        public RegisterCategory_Supplier(bool accessManager)
        {
            InitializeComponent();
            this.accessManager = accessManager;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = CategoryNameTextBox.Text.Trim();

            if (accessManager == false)
            {
                MessageBox.Show("Acesso Manager: False");
            }

            else
            {

                if (string.IsNullOrEmpty(categoryName))
                {
                    MessageBox.Show("O nome da categoria não pode estar vazio.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                try
                {
                    // Usando a classe ConnectionBuild para conectar ao banco de dados
                    ConnectionBuild connectionBuild = new ConnectionBuild();
                    using (MySqlConnection connection = connectionBuild.Start())
                    {
                        // Verifica se a categoria já existe
                        string checkQuery = "SELECT COUNT(*) FROM category WHERE category_name = @CategoryName";
                        MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                        checkCommand.Parameters.AddWithValue("@CategoryName", categoryName);

                        int categoryCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (categoryCount > 0)
                        {
                            MessageBox.Show("A categoria já existe.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        // Inserir a nova categoria
                        string insertQuery = "INSERT INTO category (category_name) VALUES (@CategoryName)";
                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@CategoryName", categoryName);
                        insertCommand.ExecuteNonQuery();

                        MessageBox.Show("Categoria registrada com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close(); // Fecha a janela após o sucesso
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao registrar categoria: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
