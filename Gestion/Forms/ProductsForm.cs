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
using Gestion.Forms.Products_Form;

namespace Gestion.Forms
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            ProductsList productsList = new ProductsList();
            productsList.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddProducts addProducts = new AddProducts();
            addProducts.TopLevel = false;
            productsPanel.Controls.Add(addProducts);
            addProducts.BringToFront();
            addProducts.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteProducts deleteProducts = new DeleteProducts();
            deleteProducts.TopLevel = false;
            productsPanel.Controls.Add(deleteProducts);
            deleteProducts.BringToFront();
            deleteProducts.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchProducts searchProducts = new SearchProducts();
            searchProducts.TopLevel = false;
            productsPanel.Controls.Add(searchProducts);
            searchProducts.BringToFront();
            searchProducts.Show();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateProducts updateProducts = new UpdateProducts();
            updateProducts.TopLevel = false;
            productsPanel.Controls.Add(updateProducts);
            updateProducts.BringToFront();
            updateProducts.Show();
        }
    }
}
