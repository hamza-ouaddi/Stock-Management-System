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
using Gestion.Forms.Purchase_Form;
using System.Data;
using System.Data.SqlClient;

namespace Gestion.Forms.Purchase_Form
{
    public partial class DeletePurchase : Form
    {
        public DeletePurchase()
        {
            InitializeComponent();
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();

                // The productList control
                using (SqlCommand purchaseSqlCommand = new SqlCommand("SELECT * from ACHAT", sqlConnection))
                {
                    SqlDataAdapter purchaseAdapter = new SqlDataAdapter(purchaseSqlCommand);
                    DataTable purchaseDataTable = new DataTable();
                    purchaseAdapter.Fill(purchaseDataTable);

                    // Add the "SaleInfo" column to the DataTable
                    purchaseDataTable.Columns.Add("PurchaseInfo", typeof(string));

                    foreach (DataRow row in purchaseDataTable.Rows)
                    {
                        row["PurchaseInfo"] = row["id_achat"] + " - " + row["date_achat"]; // Combine ID and name
                    }

                    purchaseList.DisplayMember = "PurchaseInfo"; // Set the display member to the column that contains the product name
                    purchaseList.ValueMember = "id_achat"; // Set the value member to the column that contains the product ID


                    // Add a default item as placeholder
                    DataRow promptRow = purchaseDataTable.NewRow();
                    promptRow["id_achat"] = 0; 
                    promptRow["date_achat"] = "Choose a purchase";
                    promptRow["PurchaseInfo"] = promptRow["date_achat"]; 
                    purchaseDataTable.Rows.InsertAt(promptRow, 0);

                    purchaseList.DisplayMember = "PurchaseInfo"; 
                    purchaseList.ValueMember = "id_achat";

                    purchaseList.DataSource = purchaseDataTable;
                    purchaseList.SelectedIndex = 0; 

                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string selectedPurchase = Convert.ToString(purchaseList.SelectedValue);
            int purchaseId = Convert.ToInt32(selectedPurchase.Split('|')[0].Trim());
           
            Achatimp purchaseImp = new Achatimp();

            try
            {
                purchaseImp.delete(purchaseId);

                MessageBox.Show("The purchase has been deleted.");

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

                using (SqlCommand purchaseSqlCommand = new SqlCommand("SELECT * from ACHAT", sqlConnection))
                {
                    SqlDataAdapter purchaseAdapter = new SqlDataAdapter(purchaseSqlCommand);
                    DataTable purchaseDataTable = new DataTable();
                    purchaseAdapter.Fill(purchaseDataTable);

                    // Add the "SaleInfo" column to the DataTable
                    purchaseDataTable.Columns.Add("PurchaseInfo", typeof(string));

                    foreach (DataRow row in purchaseDataTable.Rows)
                    {
                        row["PurchaseInfo"] = row["id_achat"] + " - " + row["date_achat"]; 
                    }

                    purchaseList.DisplayMember = "PurchaseInfo";
                    purchaseList.ValueMember = "id_achat"; 


                    // Add a default item as placeholder
                    DataRow promptRow = purchaseDataTable.NewRow();
                    promptRow["id_achat"] = 0; 
                    promptRow["date_achat"] = "Choose a purchase";
                    promptRow["PurchaseInfo"] = promptRow["date_achat"];
                    purchaseDataTable.Rows.InsertAt(promptRow, 0);

                    purchaseList.DisplayMember = "PurchaseInfo";
                    purchaseList.ValueMember = "id_achat"; 

                    purchaseList.DataSource = purchaseDataTable;
                    purchaseList.SelectedIndex = 0; 

                }
            }
        }
    }
}
