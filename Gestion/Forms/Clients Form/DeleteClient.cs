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
using System.Data.SqlClient;

namespace Gestion.Forms.Clients_Form
{
    public partial class DeleteClient : Form
    {
        public DeleteClient()
        {
            InitializeComponent();

            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();

                // The clientList control
                using (SqlCommand clientSqlCommand = new SqlCommand("SELECT * from CLIENT", sqlConnection))
                {
                    SqlDataAdapter clientAdapter = new SqlDataAdapter(clientSqlCommand);
                    DataTable clientDataTable = new DataTable();
                    clientAdapter.Fill(clientDataTable);

                    // Add the "ClientInfo" column to the DataTable
                    clientDataTable.Columns.Add("ClientInfo", typeof(string));

                    foreach (DataRow row in clientDataTable.Rows)
                    {
                        row["ClientInfo"] = row["id_client"] + " - " + row["nom_client"]; // Combine ID and name
                    }

                    clientList.DisplayMember = "ClientInfo"; // Set the display member to the column that contains the product name
                    clientList.ValueMember = "id_client"; // Set the value member to the column that contains the product ID


                    // Add a default prompt item
                    DataRow promptRow = clientDataTable.NewRow();
                    promptRow["id_client"] = 0; // Set an ID value that is not present in the actual data
                    promptRow["nom_client"] = "Choose a client";
                    promptRow["ClientInfo"] = promptRow["nom_client"]; // Combine ID and name
                    clientDataTable.Rows.InsertAt(promptRow, 0);

                    clientList.DisplayMember = "ClientInfo"; // Set the display member to the column that contains the product name
                    clientList.ValueMember = "id_client"; // Set the value member to the column that contains the product ID

                    clientList.DataSource = clientDataTable;
                    clientList.SelectedIndex = 0; // Select the default prompt item

                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string selectedClient = Convert.ToString(clientList.SelectedValue);
            int clientId = Convert.ToInt32(selectedClient.Split('|')[0].Trim());
            Clientimp clientImp = new Clientimp();


            try
            {
                clientImp.delete(clientId);

                MessageBox.Show("The client has been deleted");

                //To clear TextBox
                RefreshSaleList();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void RefreshSaleList()
        {
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();

                using (SqlCommand clientSqlCommand = new SqlCommand("SELECT * from CLIENT", sqlConnection))
                {
                    SqlDataAdapter clientAdapter = new SqlDataAdapter(clientSqlCommand);
                    DataTable clientDataTable = new DataTable();
                    clientAdapter.Fill(clientDataTable);

                    // Add the "ClientInfo" column to the DataTable
                    clientDataTable.Columns.Add("ClientInfo", typeof(string));

                    foreach (DataRow row in clientDataTable.Rows)
                    {
                        row["ClientInfo"] = row["id_client"] + " - " + row["nom_client"]; 
                    }

                    clientList.DisplayMember = "ClientInfo"; 
                    clientList.ValueMember = "id_client"; 


                    
                    DataRow promptRow = clientDataTable.NewRow();
                    promptRow["id_client"] = 0; 
                    promptRow["nom_client"] = "Choose a client";
                    promptRow["ClientInfo"] = promptRow["nom_client"]; 
                    clientDataTable.Rows.InsertAt(promptRow, 0);

                    clientList.DisplayMember = "ClientInfo"; 
                    clientList.ValueMember = "id_client"; 

                    clientList.DataSource = clientDataTable;
                    clientList.SelectedIndex = 0; 

                }
            }
         }
        
    }
}
