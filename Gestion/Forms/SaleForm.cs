using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion.Forms;
using Gestion.Forms.Sale_Form;

namespace Gestion.Forms
{
    public partial class SaleForm : Form
    {
        public SaleForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddSale addSale = new AddSale();
            addSale.TopLevel = false;
            salePanel.Controls.Add(addSale);
            addSale.BringToFront();
            addSale.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteSale deleteSale = new DeleteSale();
            deleteSale.TopLevel = false;
            salePanel.Controls.Add(deleteSale);
            deleteSale.BringToFront();
            deleteSale.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchSale searchSale = new SearchSale();
            searchSale.TopLevel = false;
            salePanel.Controls.Add(searchSale);
            searchSale.BringToFront();
            searchSale.Show();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateSale updateSale = new UpdateSale();
            updateSale.TopLevel = false;
            salePanel.Controls.Add(updateSale);
            updateSale.BringToFront();
            updateSale.Show();
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            SaleList saleList = new SaleList();
            saleList.Show();
        }
    }
}
