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

namespace Gestion.Forms.Suppliers_Form
{
    public partial class SearchSupplier : Form
    {
        public SearchSupplier()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);
            Fournisseursimp fournisseursImp = new Fournisseursimp();

            try
            {
                nameBox.Text = fournisseursImp.getById(id).getNom_fourn();
                addressBox.Text = fournisseursImp.getById(id).getAdresse_fourn();
                phoneBox.Text = fournisseursImp.getById(id).getTele_fourn();
                noteBox.Text = fournisseursImp.getById(id).getNote_fourn();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }
    }
}
