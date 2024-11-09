using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using AdaptableMgmtWPF.Login.ConnectionFactory;  // Adicionar o namespace da ConnectionBuild
using AdaptableMgmtWPF.Program.UserControllers.WindowsRegister;

namespace AdaptableMgmtWPF.Program.UserControllers
{
    public partial class Products : UserControl
    {
        bool accesManager;
        public Products(bool accesManager)
        {
            InitializeComponent();
            this.accesManager = accesManager;
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            string productName = ProductNameTextBox.Text.Trim();
            string brand = BrandTextBox.Text.Trim();
            double price;
            int stock, validity;
            string description = DescriptionTextBox.Text.Trim();
            int categoryId, supplierId;

            // Validação de preço e valores numéricos
            if (!double.TryParse(PriceTextBox.Text, out price) || !int.TryParse(StockTextBox.Text, out stock) || !int.TryParse(ValidityTextBox.Text, out validity))
            {
                MessageBox.Show("Verifique se todos os campos numéricos estão corretos.");
                return;
            }

            // Verificação de campos vazios
            if (string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Todos os campos obrigatórios devem ser preenchidos.");
                return;
            }

            // Obter categoria e fornecedor
            if (!int.TryParse(CategoryIdTextBox.Text, out categoryId) || !int.TryParse(SupplierIdTextBox.Text, out supplierId))
            {
                MessageBox.Show("Por favor, insira IDs válidos para categoria e fornecedor.");
                return;
            }

            try
            {
                // Usando o ConnectionBuild para obter a conexão
                ConnectionBuild connectionBuild = new ConnectionBuild();
                using (MySqlConnection conn = connectionBuild.Start())
                {
                    // Verificar se a categoria e o fornecedor existem
                    if (!CategoryExists(conn, categoryId))
                    {
                        MessageBox.Show("Categoria não encontrada. Por favor, adicione a categoria primeiro.");
                        return;
                    }

                    if (!SupplierExists(conn, supplierId))
                    {
                        MessageBox.Show("Fornecedor não encontrado. Por favor, adicione o fornecedor primeiro.");
                        return;
                    }

                    // Caso ambos existam, inserir o produto
                    InsertProduct(conn, productName, brand, price, stock, validity, description, categoryId, supplierId);
                    MessageBox.Show("Produto adicionado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private bool CategoryExists(MySqlConnection conn, int categoryId)
        {
            string query = "SELECT COUNT(*) FROM category WHERE category_id = @CategoryId";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private bool SupplierExists(MySqlConnection conn, int supplierId)
        {
            string query = "SELECT COUNT(*) FROM supplier WHERE supplier_id = @SupplierId";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void InsertProduct(MySqlConnection conn, string productName, string brand, double price, int stock, int validity, string description, int categoryId, int supplierId)
        {
            string query = "INSERT INTO product (name_product, brand_product, price_product, stock, validity_product_service_month, about_product, category_id, supplier_id) " +
                           "VALUES (@ProductName, @Brand, @Price, @Stock, @Validity, @Description, @CategoryId, @SupplierId)";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ProductName", productName);
                cmd.Parameters.AddWithValue("@Brand", brand);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@Validity", validity);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                cmd.ExecuteNonQuery();
            }
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            // Abrindo a tela de cadastro de categoria
            RegisterCategory_Supplier categoryRegisterWindow = new RegisterCategory_Supplier(accesManager); // Instancia a janela de cadastro de categoria
            categoryRegisterWindow.Show(); // Exibe a janela
        }


        private void AddSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            // Abrindo a tela de cadastro de fornecedor
            RegisterSupplier supplierRegisterWindow = new RegisterSupplier(accesManager); // Instancia a janela de cadastro de fornecedor
            supplierRegisterWindow.Show(); // Exibe a janela
        }

    }
}
