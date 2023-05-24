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



namespace Gestion.Forms.Purchase_Form
{
    public partial class UpdatePurchase : Form
    {
        bool isInitialSelection = true;
        private bool isUserSelection = false;

        public UpdatePurchase()
        {
            InitializeComponent();
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();

                // The productList control
                using (SqlCommand productSqlCommand = new SqlCommand("SELECT * from PRODUITS", sqlConnection))
                {
                    SqlDataAdapter productAdapter = new SqlDataAdapter(productSqlCommand);
                    DataTable productDataTable = new DataTable();
                    productAdapter.Fill(productDataTable);

                    productList.DisplayMember = "libelle"; 
                    productList.ValueMember = "id_prod"; 

                    // Add a default item as placeholder
                    DataRow promptRow = productDataTable.NewRow();
                    promptRow["id_prod"] = 0; 
                    promptRow["libelle"] = "Choose a product";
                    productDataTable.Rows.InsertAt(promptRow, 0);

                    productList.DataSource = productDataTable;
                    productList.SelectedIndex = 0; 

                }

                // The supplierList control
                using (SqlCommand supplierSqlCommand = new SqlCommand("SELECT * from FOURNISSEURS", sqlConnection))
                {
                    SqlDataAdapter supplierAdapter = new SqlDataAdapter(supplierSqlCommand);
                    DataTable supplierDataTable = new DataTable();
                    supplierAdapter.Fill(supplierDataTable);

                    supplierList.DisplayMember = "nom_fourn";
                    supplierList.ValueMember = "id_fourn";

                    // Add a default item as placeholder
                    DataRow promptRow = supplierDataTable.NewRow();
                    promptRow["id_fourn"] = 0;
                    promptRow["nom_fourn"] = "Choose a supplier";
                    supplierDataTable.Rows.InsertAt(promptRow, 0);

                    

                    supplierList.DataSource = supplierDataTable;
                    supplierList.SelectedIndex = 0;

                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
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
            Produitsimp productImp = new Produitsimp();
            Fournisseursimp supplierImp = new Fournisseursimp();

            Achat purchase = new Achat(id, date, quantity, productImp.getById(productId), supplierImp.getById(supplierId), note);

            try
            {
                purchaseImp.update(purchase);
                MessageBox.Show("The purchase has been updated.");

                //To clear TextBox
                idBox.Text = string.Empty;
                dateTime.Text = string.Empty;
                quantityBox.Text = string.Empty;
                productList.Text = string.Empty;
                supplierList.Text = string.Empty;
                noteBox.Text = string.Empty;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);
            Achatimp purchaseImp = new Achatimp();

            try
            {
                dateTime.Text = purchaseImp.getById(id).getDate_achat();
                quantityBox.Text = purchaseImp.getById(id).getQte_achat().ToString();
                productList.Text = purchaseImp.getById(id).getProduit().getLibelle().ToString();
                supplierList.Text = purchaseImp.getById(id).getFournisseur().getNom_fourn().ToString();
                noteBox.Text = purchaseImp.getById(id).getNote_achat();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
