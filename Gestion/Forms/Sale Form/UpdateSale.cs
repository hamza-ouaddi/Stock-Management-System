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
    public partial class UpdateSale : Form
    {
        bool isInitialSelection = true; 
        private bool isUserSelection = false;

        public UpdateSale()
        {
            InitializeComponent();
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();

                // The productList control
                using (SqlCommand saleSqlCommand = new SqlCommand("SELECT * from PRODUITS", sqlConnection))
                {
                    SqlDataAdapter saleAdapter = new SqlDataAdapter(saleSqlCommand);
                    DataTable saleDataTable = new DataTable();
                    saleAdapter.Fill(saleDataTable);

                    productList.DisplayMember = "libelle"; // Set the display member to the column that contains the product name
                    productList.ValueMember = "id_prod"; // Set the value member to the column that contains the product ID


                    // Add a default placeholder item
                    DataRow promptRow = saleDataTable.NewRow();
                    promptRow["id_prod"] = 0; 
                    promptRow["libelle"] = "Choose a product";
                    saleDataTable.Rows.InsertAt(promptRow, 0);

                    productList.DataSource = saleDataTable;
                    productList.SelectedIndex = 0; 

                }

                // The clientList control
                using (SqlCommand clientSqlCommand = new SqlCommand("SELECT * from CLIENT", sqlConnection))
                {
                    SqlDataAdapter clientAdapter = new SqlDataAdapter(clientSqlCommand);
                    DataTable clientDataTable = new DataTable();
                    clientAdapter.Fill(clientDataTable);

                    clientList.DisplayMember = "nom_client"; // Set the display member to the column that contains the product name
                    clientList.ValueMember = "id_client"; // Set the value member to the column that contains the product ID



                    // Add a default placeholder item
                    DataRow promptRow = clientDataTable.NewRow();
                    promptRow["id_client"] = 0; 
                    promptRow["nom_client"] = "Choose a client";
                    clientDataTable.Rows.InsertAt(promptRow, 0);

                    clientList.DataSource = clientDataTable;
                    clientList.SelectedIndex = 0;

                    
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
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
                saleImp.update(sale);

                MessageBox.Show("The sale has been updated.");

                //To clear TextBox
                idBox.Text = string.Empty;
                dateTime.Text = string.Empty;
                quantityBox.Text = string.Empty;
                purchasePriceBox.Text = string.Empty;
                salePriceBox.Text = string.Empty;
                productList.Text = string.Empty;
                clientList.Text = string.Empty;
                noteBox.Text = string.Empty;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);

            Venteimp saleImp = new Venteimp();
            Produitsimp productImp = new Produitsimp();
            Clientimp clientImp = new Clientimp();


            try
            {
                dateTime.Text = saleImp.getById(id).getDate_vente();
                quantityBox.Text = saleImp.getById(id).getQte_vente().ToString();
                purchasePriceBox.Text = saleImp.getById(id).getPu_achat().ToString();
                salePriceBox.Text = saleImp.getById(id).getPu_vente().ToString();
                productList.Text = saleImp.getById(id).getProduit().getLibelle().ToString();
                clientList.Text = saleImp.getById(id).getClient().getNom_client().ToString();
                noteBox.Text = saleImp.getById(id).getNote_vente();



            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void clientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUserSelection && clientList.SelectedIndex == 0) 
            {
                clientList.SelectedIndex = -1; 
            }
            else
            {
                isUserSelection = true; 
            }
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void salePriceBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
