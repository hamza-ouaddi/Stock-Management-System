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
using System.Data;
using System.Data.SqlClient;

namespace Gestion.Forms.Sale_Form
{
    public partial class DeleteSale : Form
    {
        public DeleteSale()
        {
            InitializeComponent();
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();

                // The productList control
                using (SqlCommand saleSqlCommand = new SqlCommand("SELECT * from VENTE", sqlConnection))
                {
                    SqlDataAdapter saleAdapter = new SqlDataAdapter(saleSqlCommand);
                    DataTable saleDataTable = new DataTable();
                    saleAdapter.Fill(saleDataTable);

                    // Add the "SaleInfo" column to the DataTable
                    saleDataTable.Columns.Add("SaleInfo", typeof(string));

                    foreach (DataRow row in saleDataTable.Rows)
                    {
                        row["SaleInfo"] = row["id_vente"] + " - " + row["date_vente"]; // Combine ID and name
                    }

                    saleList.DisplayMember = "SaleInfo"; 
                    saleList.ValueMember = "id_vente"; 


                    // Add a default prompt item
                    DataRow promptRow = saleDataTable.NewRow();
                    promptRow["id_vente"] = 0; // Set an ID value that is not present in the actual data
                    promptRow["date_vente"] = "Choose a sale";
                    promptRow["SaleInfo"] = promptRow["date_vente"]; // Combine ID and name
                    saleDataTable.Rows.InsertAt(promptRow, 0);

                    saleList.DisplayMember = "SaleInfo"; // Set the display member to the column that contains the product name
                    saleList.ValueMember = "id_vente"; // Set the value member to the column that contains the product ID

                    saleList.DataSource = saleDataTable;
                    saleList.SelectedIndex = 0; // Select the default prompt item

                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            string selectedSale = Convert.ToString(saleList.SelectedValue);
            int saleId = Convert.ToInt32(selectedSale.Split('|')[0].Trim());
            Venteimp saleImp = new Venteimp();
         

            try
            {
                saleImp.delete(saleId);

                MessageBox.Show("The sale has been deleted");

                //To clear TextBox
                RefreshSaleList();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void RefreshSaleList()
        {
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();

                using (SqlCommand productSqlCommand = new SqlCommand("SELECT * from VENTE", sqlConnection))
                {
                    SqlDataAdapter productAdapter = new SqlDataAdapter(productSqlCommand);
                    DataTable productDataTable = new DataTable();
                    productAdapter.Fill(productDataTable);

                    // Add the "SaleInfo" column to the DataTable if it doesn't exist
                    if (!productDataTable.Columns.Contains("SaleInfo"))
                    {
                        productDataTable.Columns.Add("SaleInfo", typeof(string));
                    }

                    foreach (DataRow row in productDataTable.Rows)
                    {
                        row["SaleInfo"] = row["id_vente"] + " - " + row["date_vente"]; // Combine ID and name
                    }

                    // Add a default item as placeholder
                    DataRow promptRow = productDataTable.NewRow();
                    promptRow["id_vente"] = 0;
                    promptRow["date_vente"] = "Choose a sale";
                    promptRow["SaleInfo"] =  promptRow["date_vente"]; 
                    productDataTable.Rows.InsertAt(promptRow, 0);

                    saleList.DisplayMember = "SaleInfo"; 
                    saleList.ValueMember = "id_vente"; 

                    saleList.DataSource = productDataTable;
                    saleList.SelectedIndex = 0; 
                }
            }
        }
    }
}
