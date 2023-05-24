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
using System.Collections.Generic;

namespace Gestion.Forms.Sale_Form
{
    public partial class SearchSale : Form
    {
        public SearchSale()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);
            
            Venteimp saleImp = new Venteimp();
            Produitsimp productImp = new Produitsimp();
            Clientimp clientImp = new Clientimp();

            
            try
            {
                dateBox.Text = saleImp.getById(id).getDate_vente();
                quantityBox.Text = saleImp.getById(id).getQte_vente().ToString();
                purchasePriceBox.Text = saleImp.getById(id).getPu_achat().ToString();
                salePriceBox.Text = saleImp.getById(id).getPu_vente().ToString();
                productIdBox.Text = saleImp.getById(id).getProduit().getLibelle().ToString();
                clientIdBox.Text = saleImp.getById(id).getClient().getNom_client().ToString();
                noteBox.Text = saleImp.getById(id).getNote_vente();

                
                  
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
