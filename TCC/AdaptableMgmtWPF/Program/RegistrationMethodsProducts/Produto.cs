using System;
using AdaptableMgmtWPF.Login.ConnectionFactory;
using MySql.Data.MySqlClient;

namespace AdaptableMgmtWPF.Program.RegistrationMethodsProducts
{
    

    public class ProductService
    {
        private MySqlConnection Connection()
        {
            ConnectionBuild connectionBuild = new ConnectionBuild();
            MySqlConnection connection = connectionBuild.Start();
            return connection;
        }

        public (bool categoryExists, bool supplierExists, bool productInserted) InsertProduct(
            string name,
            string brand,
            double price,
            int stock,
            bool isService,
            int validityMonths,
            string aboutProduct,
            int categoryId,
            int supplierId)
        {
            MySqlConnection connection = Connection();
            try
            {
                connection.Open();

                // Verificar se a categoria existe
                string checkCategoryQuery = "SELECT COUNT(*) FROM category WHERE category_id = @categoryId";
                MySqlCommand checkCategoryCmd = new MySqlCommand(checkCategoryQuery, connection);
                checkCategoryCmd.Parameters.AddWithValue("@categoryId", categoryId);
                int categoryExists = Convert.ToInt32(checkCategoryCmd.ExecuteScalar());

                if (categoryExists == 0)
                {
                    connection.Close();
                    return (false, false, false);
                }

                // Verificar se o fornecedor existe
                string checkSupplierQuery = "SELECT COUNT(*) FROM supplier WHERE supplier_id = @supplierId";
                MySqlCommand checkSupplierCmd = new MySqlCommand(checkSupplierQuery, connection);
                checkSupplierCmd.Parameters.AddWithValue("@supplierId", supplierId);
                int supplierExists = Convert.ToInt32(checkSupplierCmd.ExecuteScalar());

                if (supplierExists == 0)
                {
                    connection.Close();
                    return (true, false, false);
                }

                // Inserção do produto
                string insertProductQuery = @"
                INSERT INTO product 
                (name_product, brand_product, price_product, stock, is_service, 
                validity_product_service_month, about_product, category_id, supplier_id)
                VALUES (@name, @brand, @price, @stock, @isService, 
                        @validityMonths, @aboutProduct, @categoryId, @supplierId)";

                MySqlCommand insertProductCmd = new MySqlCommand(insertProductQuery, connection);
                insertProductCmd.Parameters.AddWithValue("@name", name);
                insertProductCmd.Parameters.AddWithValue("@brand", brand);
                insertProductCmd.Parameters.AddWithValue("@price", price);
                insertProductCmd.Parameters.AddWithValue("@stock", stock);
                insertProductCmd.Parameters.AddWithValue("@isService", isService);
                insertProductCmd.Parameters.AddWithValue("@validityMonths", validityMonths);
                insertProductCmd.Parameters.AddWithValue("@aboutProduct", aboutProduct);
                insertProductCmd.Parameters.AddWithValue("@categoryId", categoryId);
                insertProductCmd.Parameters.AddWithValue("@supplierId", supplierId);

                insertProductCmd.ExecuteNonQuery();

                return (true, true, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return (false, false, false);
            }
            finally
            {
                connection.Close();
            }
        }
    }

}
