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
using Gestion.Forms.Clients_Form;

namespace Gestion.Forms.Clients_Form
{
    public partial class UpdateClient : Form
    {
        public UpdateClient()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(idBox.Text);
            string name = nameBox.Text;
            string address = addressBox.Text;
            string phone = phoneBox.Text;
            string note = noteBox.Text;
            Clientimp clientImp = new Clientimp();

            Client client = new Client(id, name, address, phone, note);

            try
            {
                clientImp.update(client);

                MessageBox.Show("The client has been updated");

                //To clear TextBox
                idBox.Text = string.Empty;
                nameBox.Text = string.Empty;
                addressBox.Text = string.Empty;
                phoneBox.Text = string.Empty;
                noteBox.Text = string.Empty;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

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
