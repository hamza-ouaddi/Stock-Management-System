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
    public partial class AddPurchase : Form
    {

        bool isInitialSelection = true; 
        private bool isUserSelection = false;

        public AddPurchase()
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

                // The supplierList control
                using (SqlCommand supplierSqlCommand = new SqlCommand("SELECT * from FOURNISSEURS", sqlConnection))
                {
                    SqlDataAdapter supplierAdapter = new SqlDataAdapter(supplierSqlCommand);
                    DataTable supplierDataTable = new DataTable();
                    supplierAdapter.Fill(supplierDataTable);

                    supplierDataTable.Columns.Add("SupplierInfo", typeof(string));

                    foreach (DataRow row in supplierDataTable.Rows)
                    {
                        row["SupplierInfo"] = row["id_fourn"] + " - " + row["nom_fourn"]; 
                    }


                    // Add a default item as placeholder
                    DataRow promptRow = supplierDataTable.NewRow();
                    promptRow["id_fourn"] = 0;
                    promptRow["nom_fourn"] = "Choose a supplier";
                    promptRow["SupplierInfo"] = promptRow["nom_fourn"];
                    supplierDataTable.Rows.InsertAt(promptRow, 0);

                    supplierList.DisplayMember = "SupplierInfo"; 
                    supplierList.ValueMember = "id_fourn"; 

                    supplierList.DataSource = supplierDataTable;
                    supplierList.SelectedIndex = 0;

                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);
            string date = dateTime.Text;
            int quantity = Convert.ToInt32(quantityBox.Text);
            string selectedProduct = Convert.ToString(productList.SelectedValue);
            int productId = Convert.ToInt32(selectedProduct.Split('|')[0].Trim());
            string selectedSupplier = Convert.ToString(supplierList.SelectedValue);
            int supplierId = Convert.ToInt32(selectedSupplier.Split('|')[0].Trim());
            
            string note = noteBox.Text;
            Achatimp purchaseImp = new Achatimp();
            Produitsimp productsImp = new Produitsimp();
            Fournisseursimp suppliersImp = new Fournisseursimp();

            Achat purchase = new Achat(id, date, quantity, productsImp.getById(productId), suppliersImp.getById(supplierId), note);

            try
            {
                purchaseImp.add(purchase);

                MessageBox.Show("The purchase has been added");

                //To clear TextBox
                increaseId();
                dateTime.Text = string.Empty;
                quantityBox.Text = string.Empty;
                noteBox.Text = string.Empty;
                RefreshList();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        private void supplierIdBox_TextChanged(object sender, EventArgs e)
        {
                    }

        private void productList_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void supplierList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUserSelection && supplierList.SelectedIndex == 0) 
            {
                supplierList.SelectedIndex = -1; 
            }
            else
            {
                isUserSelection = true; 
            }
        }

        //To increase id after every new set
        private void increaseId()
        {
            int nextId = 0;

            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();



                string getIdQuery = "SELECT ISNULL(MAX(id_achat), 0) + 1 FROM ACHAT";
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
                    promptRow["id_prod"] = 0; 
                    promptRow["libelle"] = "Choose a product";
                    promptRow["ProductInfo"] = promptRow["libelle"];
                    productDataTable.Rows.InsertAt(promptRow, 0);

                    productList.DisplayMember = "ProductInfo"; 
                    productList.ValueMember = "id_prod"; 

                    productList.DataSource = productDataTable;
                    productList.SelectedIndex = 0;

                }

                // The supplierList control
                using (SqlCommand supplierSqlCommand = new SqlCommand("SELECT * from FOURNISSEURS", sqlConnection))
                {
                    SqlDataAdapter supplierAdapter = new SqlDataAdapter(supplierSqlCommand);
                    DataTable supplierDataTable = new DataTable();
                    supplierAdapter.Fill(supplierDataTable);

                    supplierDataTable.Columns.Add("SupplierInfo", typeof(string));

                    foreach (DataRow row in supplierDataTable.Rows)
                    {
                        row["SupplierInfo"] = row["id_fourn"] + " - " + row["nom_fourn"]; 
                    }


                    // Add a default item as placeholder
                    DataRow promptRow = supplierDataTable.NewRow();
                    promptRow["id_fourn"] = 0;
                    promptRow["nom_fourn"] = "Choose a supplier";
                    promptRow["SupplierInfo"] = promptRow["nom_fourn"];
                    supplierDataTable.Rows.InsertAt(promptRow, 0);

                    supplierList.DisplayMember = "SupplierInfo"; 
                    supplierList.ValueMember = "id_fourn"; 

                    supplierList.DataSource = supplierDataTable;
                    supplierList.SelectedIndex = 0;

                }
            }
        }
    }
}
