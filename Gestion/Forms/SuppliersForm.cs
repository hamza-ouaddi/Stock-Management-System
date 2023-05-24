using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion.Forms.Suppliers_Form;

namespace Gestion.Forms
{
    public partial class SuppliersForm : Form
    {
        public SuppliersForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddSupplier addSupplier = new AddSupplier();
            addSupplier.TopLevel = false;
            suppliersPanel.Controls.Add(addSupplier);
            addSupplier.BringToFront();
            addSupplier.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteSupplier deleteSupplier = new DeleteSupplier();
            deleteSupplier.TopLevel = false;
            suppliersPanel.Controls.Add(deleteSupplier);
            deleteSupplier.BringToFront();
            deleteSupplier.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchSupplier searchSupplier = new SearchSupplier();
            searchSupplier.TopLevel = false;
            suppliersPanel.Controls.Add(searchSupplier);
            searchSupplier.BringToFront();
            searchSupplier.Show();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateSupplier updateSupplier = new UpdateSupplier();
            updateSupplier.TopLevel = false;
            suppliersPanel.Controls.Add(updateSupplier);
            updateSupplier.BringToFront();
            updateSupplier.Show();
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            SuppliersList suppliersList = new SuppliersList();
            suppliersList.Show();
        }
    }
}
