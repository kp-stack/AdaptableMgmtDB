using System;
using System.Windows;
using System.Windows.Controls;
using AdaptableMgmtWPF.Login.ConnectionFactory;
using MySql.Data.MySqlClient;

namespace AdaptableMgmtWPF.Program.UserControllers
{
    public partial class Stock : UserControl
    {
        bool accesManager;

        
        public Stock(bool accesManager)
        {
            InitializeComponent(); this.accesManager = accesManager;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Aqui você pode adicionar lógica que deve ocorrer quando o texto é alterado.
            // Por exemplo, você pode querer atualizar a interface do usuário ou realizar alguma ação com o texto digitado.
            // Para o momento, você pode deixar vazio ou implementar alguma funcionalidade que desejar.
        }


        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(SearchBox.Text, out int productId))
            {
                var product = GetProductById(productId);

                if (product != null)
                {
                    // Atualiza os labels com as informações do produto
                    ProductNameLabel.Content = product.NameProduct;
                    PriceLabel.Content = product.PriceProduct.ToString("C");
                    ValidityLabel.Content = product.ValidityProductServiceMonth?.ToString() ?? "-";
                    BrandLabel.Content = product.BrandProduct;
                    StockLabel.Content = product.Stock.ToString();
                    SupplierLabel.Content = product.SupplierName;
                    DescriptionLabel.Content = product.AboutProduct ?? "-";
                }
                else
                {
                    MessageBox.Show("Produto não encontrado!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um ID de produto válido.", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                ClearFields();
            }
        }

        private Product GetProductById(int id)
        {
            ConnectionBuild connectionBuild = new ConnectionBuild();
            MySqlConnection connection = connectionBuild.Start();

            string query = "SELECT name_product, brand_product, price_product, stock, validity_product_service_month, about_product, supplier_id " +
                           "FROM product WHERE id_product = @id_product";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id_product", id);

            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Lê a primeira linha dos resultados
                    {
                        return new Product
                        {
                            NameProduct = reader["name_product"].ToString(),
                            BrandProduct = reader["brand_product"].ToString(),
                            PriceProduct = Convert.ToDouble(reader["price_product"]),
                            Stock = Convert.ToInt32(reader["stock"]),
                            ValidityProductServiceMonth = reader["validity_product_service_month"] as int?,
                            AboutProduct = reader["about_product"].ToString(),
                            SupplierName = GetSupplierName(Convert.ToInt32(reader["supplier_id"]))
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar produto: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close(); // Fecha a conexão
            }

            return null; // Produto não encontrado
        }

        private string GetSupplierName(int supplierId)
        {
            // Instanciação da classe ConnectionBuild utilizando o método Start()
            ConnectionBuild connectionBuild = new ConnectionBuild();
            MySqlConnection connection = connectionBuild.Start();

            // Verifica o nome do fornecedor
            string query = "SELECT supplier_name FROM supplier WHERE supplier_id = @supplier_id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@supplier_id", supplierId);

            try
            {
                // Usa ExecuteScalar para obter o nome do fornecedor
                var supplierName = cmd.ExecuteScalar();
                return supplierName?.ToString() ?? "-";
            }
            catch
            {
                return "-"; // Em caso de erro, retorna um valor padrão
            }
            finally
            {
                connection.Close(); // Fecha a conexão
            }
        }

        private void ClearFields()
        {
            // Limpa os campos de exibição
            ProductNameLabel.Content = "-";
            PriceLabel.Content = "-";
            ValidityLabel.Content = "-";
            BrandLabel.Content = "-";
            StockLabel.Content = "-";
            SupplierLabel.Content = "-";
            DescriptionLabel.Content = "-";
        }
    }

    public class Product
    {
        public string NameProduct { get; set; }
        public string BrandProduct { get; set; }
        public double PriceProduct { get; set; }
        public int Stock { get; set; }
        public int? ValidityProductServiceMonth { get; set; }
        public string AboutProduct { get; set; }
        public string SupplierName { get; set; }
    }
}
