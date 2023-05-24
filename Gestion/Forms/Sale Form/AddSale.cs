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
    public partial class AddSale : Form
    {
        bool isInitialSelection = true; 
        private bool isUserSelection = false;

        public AddSale()
        {
            InitializeComponent();

            increaseId();

            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();

                // The productList control
                using (SqlCommand productSqlCommand = new SqlCommand("SELECT * from PRODUITS", sqlConnection))
                {
                    SqlDataAdapter productAdapter = new SqlDataAdapter(productSqlCommand);
                    DataTable productDataTable = new DataTable();
                    productAdapter.Fill(productDataTable);

                    productDataTable.Columns.Add("ProductInfo", typeof(string));

                    foreach (DataRow row in productDataTable.Rows)
                    {
                        row["ProductInfo"] = row["id_prod"] + " - " + row["libelle"]; // Combine ID and name
                    }


                    // Add a default item as placeholder
                    DataRow promptRow = productDataTable.NewRow();
                    promptRow["id_prod"] = 0;
                    promptRow["libelle"] = "Choose a product";
                    promptRow["ProductInfo"] = promptRow["libelle"];
                    productDataTable.Rows.InsertAt(promptRow, 0);

                    productList.DisplayMember = "ProductInfo"; 
                    productList.ValueMember = "id_prod"; 

                    productList.DataSource = productDataTable;
                    productList.SelectedIndex = 0; 
                    
                }

                // The clientList control
                using (SqlCommand clientSqlCommand = new SqlCommand("SELECT * from CLIENT", sqlConnection))
                {
                    SqlDataAdapter clientAdapter = new SqlDataAdapter(clientSqlCommand);
                    DataTable clientDataTable = new DataTable();
                    clientAdapter.Fill(clientDataTable);

                    clientDataTable.Columns.Add("ClientInfo", typeof(string));

                    foreach (DataRow row in clientDataTable.Rows)
                    {
                        row["ClientInfo"] = row["id_client"] + " - " + row["nom_client"]; // Combine ID and name
                    }


                    // Add a default item as placeholder
                    DataRow promptRow = clientDataTable.NewRow();
                    promptRow["id_client"] = 0; 
                    promptRow["nom_client"] = "Choose a client";
                    promptRow["ClientInfo"] = promptRow["nom_client"];
                    clientDataTable.Rows.InsertAt(promptRow, 0);

                    clientList.DisplayMember = "ClientInfo";
                    clientList.ValueMember = "id_client";

                    clientList.DataSource = clientDataTable;
                    clientList.SelectedIndex = 0; 

                }
            }
        }

       

        private void addButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);
            string date = dateTime.Text;
            int quantity = Convert.ToInt32(quantityBox.Text);
            double purchasePrice = Convert.ToDouble(purchasePriceBox.Text);
            double salePrice = Convert.ToDouble(salePriceBox.Text);
            string selectedProduct = Convert.ToString(productList.SelectedValue);
            int productId = Convert.ToInt32(selectedProduct.Split('|')[0].Trim());
            string selectedClient = Convert.ToString(clientList.SelectedValue); 
            int clientId = Convert.ToInt32(selectedClient.Split('|')[0].Trim());
            string note = noteBox.Text;
            Venteimp saleImp = new Venteimp();
            Produitsimp productImp = new Produitsimp();
            Clientimp clientImp = new Clientimp();


            Vente sale = new Vente(id, date, quantity, purchasePrice, salePrice, productImp.getById(productId), clientImp.getById(clientId), note);

            try
            {
                saleImp.add(sale);

                MessageBox.Show("The sale has been added.");

                //To clear TextBox
                increaseId();
                dateTime.Text = string.Empty;
                quantityBox.Text = string.Empty;
                purchasePriceBox.Text = string.Empty;
                salePriceBox.Text = string.Empty;
                noteBox.Text = string.Empty;
                RefreshList();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void productList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // To Clear the selection
            if (isInitialSelection)
            {
                isInitialSelection = false;
                return; 
            }

            if (productList.SelectedIndex == 0) 
            {
                productList.SelectedIndex = -1; 
            }
        }

        private void clientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // To Clear the selection
            if (isUserSelection && clientList.SelectedIndex == 0) // 
            {
                clientList.SelectedIndex = -1; 
            }
            else
            {
                isUserSelection = true; 
            }
        }

        private void increaseId()
        {
            //To show the latest ID in ID box

            int nextId = 0;

            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();



                string getIdQuery = "SELECT ISNULL(MAX(id_vente), 0) + 1 FROM VENTE";
                using (SqlCommand getIdCommand = new SqlCommand(getIdQuery, sqlConnection))
                {
                    nextId = Convert.ToInt32(getIdCommand.ExecuteScalar());
                }
            }

            idBox.Text = nextId.ToString();
        }

        private void RefreshList()
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
                        row["ProductInfo"] = row["id_prod"] + " - " + row["libelle"]; // Combine ID and name
                    }


                    // Add a default item as placeholder
                    DataRow promptRow = productDataTable.NewRow();
                    promptRow["id_prod"] = 0; // Set an ID value that is not present in the actual data
                    promptRow["libelle"] = "Choose a product";
                    promptRow["ProductInfo"] = promptRow["libelle"];
                    productDataTable.Rows.InsertAt(promptRow, 0);

                    productList.DisplayMember = "ProductInfo"; 
                    productList.ValueMember = "id_prod"; 

                    productList.DataSource = productDataTable;
                    productList.SelectedIndex = 0;

                }

                // The clientList control
                using (SqlCommand clientSqlCommand = new SqlCommand("SELECT * from CLIENT", sqlConnection))
                {
                    SqlDataAdapter clientAdapter = new SqlDataAdapter(clientSqlCommand);
                    DataTable clientDataTable = new DataTable();
                    clientAdapter.Fill(clientDataTable);

                    clientDataTable.Columns.Add("ClientInfo", typeof(string));

                    foreach (DataRow row in clientDataTable.Rows)
                    {
                        row["ClientInfo"] = row["id_client"] + " - " + row["nom_client"]; // Combine ID and name
                    }


                    // Add a default item as placeholder
                    DataRow promptRow = clientDataTable.NewRow();
                    promptRow["id_client"] = 0;
                    promptRow["nom_client"] = "Choose a client";
                    promptRow["ClientInfo"] = promptRow["nom_client"];
                    clientDataTable.Rows.InsertAt(promptRow, 0);

                    clientList.DisplayMember = "ClientInfo"; // Set the display member to the column that contains the name
                    clientList.ValueMember = "id_client"; // Set the value member to the column that contains the ID

                    clientList.DataSource = clientDataTable;
                    clientList.SelectedIndex = 0;

                }
            }
        }
    }
}
