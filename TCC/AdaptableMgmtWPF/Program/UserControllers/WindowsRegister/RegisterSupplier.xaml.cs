using System;
using System.Windows;
using MySql.Data.MySqlClient;
using AdaptableMgmtWPF.Login.ConnectionFactory;
using System.Windows.Input;

namespace AdaptableMgmtWPF.Program.UserControllers.WindowsRegister
{
    public partial class RegisterSupplier : Window
    {

        bool accessManager;
        public RegisterSupplier(bool accesManager)
        {
            InitializeComponent();
            this.accessManager = accesManager;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string supplierName = SupplierNameTextBox.Text.Trim();

            if (accessManager == false)
            {
                MessageBox.Show("Acesso Manager: False");
            }

            else
            {

                if (string.IsNullOrEmpty(supplierName))
                {
                    MessageBox.Show("O nome do fornecedor não pode estar vazio.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                try
                {
                    // Usando a classe ConnectionBuild para conectar ao banco de dados
                    ConnectionBuild connectionBuild = new ConnectionBuild();
                    using (MySqlConnection connection = connectionBuild.Start())
                    {
                        // Verifica se o fornecedor já existe
                        string checkQuery = "SELECT COUNT(*) FROM supplier WHERE supplier_name = @SupplierName";
                        MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                        checkCommand.Parameters.AddWithValue("@SupplierName", supplierName);

                        int supplierCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (supplierCount > 0)
                        {
                            MessageBox.Show("O fornecedor já existe.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        // Inserir o novo fornecedor
                        string insertQuery = "INSERT INTO supplier (supplier_name) VALUES (@SupplierName)";
                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@SupplierName", supplierName);
                        insertCommand.ExecuteNonQuery();

                        MessageBox.Show("Fornecedor registrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close(); // Fecha a janela após o sucesso
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao registrar fornecedor: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
