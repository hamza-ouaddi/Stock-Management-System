using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion.classes;
using Gestion.IDao;
using Gestion.Services;
using Gestion.Forms;
using System.Data.SqlClient;


namespace Gestion.Forms.Products_Form
{
    public partial class DeleteProducts : Form
    {
        public DeleteProducts()
        {
            InitializeComponent();

            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();

                // The clientList control
                using (SqlCommand productSqlCommand = new SqlCommand("SELECT * from PRODUITS", sqlConnection))
                {
                    SqlDataAdapter productAdapter = new SqlDataAdapter(productSqlCommand);
                    DataTable productDataTable = new DataTable();
                    productAdapter.Fill(productDataTable);

                    // Add the "SaleInfo" column to the DataTable
                    productDataTable.Columns.Add("ProductInfo", typeof(string));

                    foreach (DataRow row in productDataTable.Rows)
                    {
                        row["ProductInfo"] = row["id_prod"] + " - " + row["libelle"]; 
                    }

                    productList.DisplayMember = "ProductInfo";
                    productList.ValueMember = "id_prod"; 


                    // Add a default prompt item
                    DataRow promptRow = productDataTable.NewRow();
                    promptRow["id_prod"] = 0; // Set an ID value that is not present in the actual data
                    promptRow["libelle"] = "Choose a product";
                    promptRow["ProductInfo"] = promptRow["libelle"]; // Combine ID and name
                    productDataTable.Rows.InsertAt(promptRow, 0);

                    productList.DisplayMember = "ProductInfo"; // Set the display member to the column that contains the product name
                    productList.ValueMember = "id_prod"; // Set the value member to the column that contains the product ID

                    productList.DataSource = productDataTable;
                    productList.SelectedIndex = 0; 

                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string selectedProduct = Convert.ToString(productList.SelectedValue);
            int productId = Convert.ToInt32(selectedProduct.Split('|')[0].Trim());

            Produitsimp produitsImp = new Produitsimp();

            try
            {
                produitsImp.delete(productId);

                MessageBox.Show("The products has been deleted.");

                //To clear TextBox
                RefreshSaleList();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void RefreshSaleList()
        {
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();

                using (SqlCommand productSqlCommand = new SqlCommand("SELECT * from PRODUITS", sqlConnection))
                {
                    SqlDataAdapter productAdapter = new SqlDataAdapter(productSqlCommand);
                    DataTable productDataTable = new DataTable();
                    productAdapter.Fill(productDataTable);

                    
                    productDataTable.Columns.Add("ProductInfo", typeof(string));

                    foreach (DataRow row in productDataTable.Rows)
                    {
                        row["ProductInfo"] = row["id_prod"] + " - " + row["libelle"]; 
                    }

                    productList.DisplayMember = "ProductInfo"; 
                    productList.ValueMember = "id_prod"; 


                    
                    DataRow promptRow = productDataTable.NewRow();
                    promptRow["id_product"] = 0; 
                    promptRow["libelle"] = "Choose a product";
                    promptRow["ProductInfo"] = promptRow["libelle"]; 
                    productDataTable.Rows.InsertAt(promptRow, 0);

                    productList.DisplayMember = "ProductInfo"; 
                    productList.ValueMember = "id_prod"; 

                    productList.DataSource = productDataTable;
                    productList.SelectedIndex = 0;

                }
            }
        }
    }
}
