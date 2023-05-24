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

namespace Gestion.Forms.Purchase_Form
{
    public partial class SearchPurchase : Form
    {
        public SearchPurchase()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);
            Achatimp purchaseImp = new Achatimp();

            try
            {
                dateBox.Text = purchaseImp.getById(id).getDate_achat();
                quantityBox.Text = purchaseImp.getById(id).getQte_achat().ToString();
                productIdBox.Text = purchaseImp.getById(id).getProduit().getLibelle().ToString();
                supplierIdBox.Text = purchaseImp.getById(id).getFournisseur().getNom_fourn().ToString();
                noteBox.Text = purchaseImp.getById(id).getNote_achat();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
