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

namespace Gestion.Forms
{
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.TopLevel = false;
            clientPanel.Controls.Add(addClient);
            addClient.BringToFront();
            addClient.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteClient deleteClient = new DeleteClient();
            deleteClient.TopLevel = false;
            clientPanel.Controls.Add(deleteClient);
            deleteClient.BringToFront();
            deleteClient.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchClient searchClient = new SearchClient();
            searchClient.TopLevel = false;
            clientPanel.Controls.Add(searchClient);
            searchClient.BringToFront();
            searchClient.Show();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateClient updateClient = new UpdateClient();
            updateClient.TopLevel = false;
            clientPanel.Controls.Add(updateClient);
            updateClient.BringToFront();
            updateClient.Show();
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            ClientsList clientList = new ClientsList();
            clientList.Show();
        }
    }
}
