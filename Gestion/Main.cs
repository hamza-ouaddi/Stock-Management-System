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


namespace Gestion
{
    public partial class Main : Form
    {
        public static Main instance;
        public Label label;

        public Main()
        {
            InitializeComponent();
            instance = this;
            label = userLabel;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = false;
            usersForm usersForm = new usersForm();
            usersForm.TopLevel = false;
            formPanel.Controls.Add(usersForm);
            usersForm.BringToFront();
            usersForm.Show();


            button2.BackColor = Color.FromArgb(219, 226, 239);
            button3.BackColor = Color.FromArgb(51, 99, 188);
            button4.BackColor = Color.FromArgb(51, 99, 188);
            button5.BackColor = Color.FromArgb(51, 99, 188);
            button6.BackColor = Color.FromArgb(51, 99, 188);
            button7.BackColor = Color.FromArgb(51, 99, 188);
            
            
        }

        private void user_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool flag = false;
            ClientsForm clientsForm = new ClientsForm();
            clientsForm.TopLevel = false;
            formPanel.Controls.Add(clientsForm);
            clientsForm.BringToFront();
            clientsForm.Show();

            button2.BackColor = Color.FromArgb(51, 99, 188);
            button3.BackColor = Color.FromArgb(219, 226, 239);
            button4.BackColor = Color.FromArgb(51, 99, 188);
            button5.BackColor = Color.FromArgb(51, 99, 188);
            button6.BackColor = Color.FromArgb(51, 99, 188);
            button7.BackColor = Color.FromArgb(51, 99, 188);
      
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SuppliersForm suppliersForm = new SuppliersForm();
            suppliersForm.TopLevel = false;
            formPanel.Controls.Add(suppliersForm);
            suppliersForm.BringToFront();
            suppliersForm.Show();

            button2.BackColor = Color.FromArgb(51, 99, 188);
            button3.BackColor = Color.FromArgb(51, 99, 188);
            button4.BackColor = Color.FromArgb(219, 226, 239);
            button5.BackColor = Color.FromArgb(51, 99, 188);
            button6.BackColor = Color.FromArgb(51, 99, 188);
            button7.BackColor = Color.FromArgb(51, 99, 188);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProductsForm productsForm = new ProductsForm();
            productsForm.TopLevel = false;
            formPanel.Controls.Add(productsForm);
            productsForm.BringToFront();
            productsForm.Show();

            button2.BackColor = Color.FromArgb(51, 99, 188);
            button3.BackColor = Color.FromArgb(51, 99, 188);
            button4.BackColor = Color.FromArgb(51, 99, 188);
            button5.BackColor = Color.FromArgb(219, 226, 239);
            button6.BackColor = Color.FromArgb(51, 99, 188);
            button7.BackColor = Color.FromArgb(51, 99, 188);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.TopLevel = false;
            formPanel.Controls.Add(purchaseForm);
            purchaseForm.BringToFront();
            purchaseForm.Show();

            button2.BackColor = Color.FromArgb(51, 99, 188);
            button3.BackColor = Color.FromArgb(51, 99, 188);
            button4.BackColor = Color.FromArgb(51, 99, 188);
            button5.BackColor = Color.FromArgb(51, 99, 188);
            button6.BackColor = Color.FromArgb(219, 226, 239);
            button7.BackColor = Color.FromArgb(51, 99, 188);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaleForm saleForm = new SaleForm();
            saleForm.TopLevel = false;
            formPanel.Controls.Add(saleForm);
            saleForm.BringToFront();
            saleForm.Show();

            button2.BackColor = Color.FromArgb(51, 99, 188);
            button3.BackColor = Color.FromArgb(51, 99, 188);
            button4.BackColor = Color.FromArgb(51, 99, 188);
            button5.BackColor = Color.FromArgb(51, 99, 188);
            button6.BackColor = Color.FromArgb(51, 99, 188);
            button7.BackColor = Color.FromArgb(219, 226, 239);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void formPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
