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

namespace Gestion.Forms.Products_Form
{
    public partial class UpdateProducts : Form
    {
        public UpdateProducts()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);
            string title = titleBox.Text;
            double uPrice = Convert.ToDouble(uPriceBox.Text);
            string type = typeBox.Text;
            double sPrice = Convert.ToDouble(sPriceBox.Text);
            string note = noteBox.Text;
            string bareCode = bareCodeBox.Text;

            Produitsimp produitsImp = new Produitsimp();

            Produits product = new Produits(id, title, uPrice, type, sPrice, note, bareCode);

            try
            {
                produitsImp.update(product);

                MessageBox.Show("The product has been updated.");

                //To clear TextBox
                idBox.Text = string.Empty;
                titleBox.Text = string.Empty;
                uPriceBox.Text = string.Empty;
                typeBox.Text = string.Empty;
                sPriceBox.Text = string.Empty;
                noteBox.Text = string.Empty;
                bareCodeBox.Text = string.Empty;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
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
