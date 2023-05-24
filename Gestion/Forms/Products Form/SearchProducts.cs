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
using Gestion.Forms.Users_Form;

namespace Gestion.Forms.Products_Form
{
    public partial class SearchProducts : Form
    {
        public SearchProducts()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);

            Produitsimp produitsImp = new Produitsimp();
            try
            {
                titleBox.Text = produitsImp.getById(id).getLibelle();
                uPriceBox.Text = produitsImp.getById(id).getPu_prod().ToString();
                typeBox.Text = produitsImp.getById(id).getType_prod();
                sPriceBox.Text = produitsImp.getById(id).getPrix_vente().ToString();
                bareCodeBox.Text = produitsImp.getById(id).getCode_barre();
                noteBox.Text = produitsImp.getById(id).getNote_prod();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            

        }
    }
}
