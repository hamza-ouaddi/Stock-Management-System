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


namespace Gestion.Forms.Clients_Form
{
    public partial class SearchClient : Form
    {
        public SearchClient()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);
            Clientimp clientImp = new Clientimp();

            try
            {
                nameBox.Text = clientImp.getById(id).getNom_client();
                addressBox.Text = clientImp.getById(id).getAdresse_client();
                phoneBox.Text = clientImp.getById(id).getTele_client();
                noteBox.Text = clientImp.getById(id).getNote_client();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            

        }
    }
}
