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

namespace Gestion.Forms
{
    public partial class PurchaseForm : Form
    {
        public PurchaseForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddPurchase addPurchase = new AddPurchase();
            addPurchase.TopLevel = false;
            purchasePanel.Controls.Add(addPurchase);
            addPurchase.BringToFront();
            addPurchase.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeletePurchase deletePurchase = new DeletePurchase();
            deletePurchase.TopLevel = false;
            purchasePanel.Controls.Add(deletePurchase);
            deletePurchase.BringToFront();
            deletePurchase.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchPurchase searchPurchase = new SearchPurchase();
            searchPurchase.TopLevel = false;
            purchasePanel.Controls.Add(searchPurchase);
            searchPurchase.BringToFront();
            searchPurchase.Show();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdatePurchase updatePurchase = new UpdatePurchase();
            updatePurchase.TopLevel = false;
            purchasePanel.Controls.Add(updatePurchase);
            updatePurchase.BringToFront();
            updatePurchase.Show();
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            PurchaseList purchaseList = new PurchaseList();
            purchaseList.Show();
        }
    }
}
