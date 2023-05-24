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
using System.Data.SqlClient;

namespace Gestion.Forms.Users_Form
{
    public partial class DeleteUser : Form
    {
        public DeleteUser()
        {
            InitializeComponent();

            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();

                // The userList control
                using (SqlCommand userSqlCommand = new SqlCommand("SELECT * from USERS", sqlConnection))
                {
                    SqlDataAdapter userAdapter = new SqlDataAdapter(userSqlCommand);
                    DataTable userDataTable = new DataTable();
                    userAdapter.Fill(userDataTable);

                    // Add the "UserInfo" column to the DataTable
                    userDataTable.Columns.Add("UserInfo", typeof(string));

                    foreach (DataRow row in userDataTable.Rows)
                    {
                        row["UserInfo"] = row["id_users"] + " - " + row["nom_users"] + " " + row["prenom_users"]; // Combine ID and name
                    }

                    userList.DisplayMember = "UserInfo"; // Set the display member to the column that contains the product name
                    userList.ValueMember = "id_users"; // Set the value member to the column that contains the product ID


                    // Add a default item as placeholder
                    DataRow promptRow = userDataTable.NewRow();
                    promptRow["id_users"] = 0; 
                    promptRow["nom_users"] = "Choose a user";
                    promptRow["UserInfo"] = promptRow["nom_users"];
                    userDataTable.Rows.InsertAt(promptRow, 0);

                    userList.DisplayMember = "UserInfo"; 
                    userList.ValueMember = "id_users"; 

                    userList.DataSource = userDataTable;
                    userList.SelectedIndex = 0; 

                }
            }
        }

        private void idBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string selectedUser = Convert.ToString(userList.SelectedValue);
            int userId = Convert.ToInt32(selectedUser.Split('|')[0].Trim());
            Usersimp usersImp = new Usersimp();

            try
            {
                usersImp.delete(userId);

                MessageBox.Show("The user has been deleted.");

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

                using (SqlCommand userSqlCommand = new SqlCommand("SELECT * from USERS", sqlConnection))
                {
                    SqlDataAdapter userAdapter = new SqlDataAdapter(userSqlCommand);
                    DataTable userDataTable = new DataTable();
                    userAdapter.Fill(userDataTable);

                    // Add the "UserInfo" column to the DataTable
                    userDataTable.Columns.Add("UserInfo", typeof(string));

                    foreach (DataRow row in userDataTable.Rows)
                    {
                        row["UserInfo"] = row["id_users"] + " - " + row["nom_users"] + " " + row["prenom_users"]; // Combine ID and name
                    }

                    userList.DisplayMember = "UserInfo"; 
                    userList.ValueMember = "id_users"; 


                    // Add a default item as placeholder
                    DataRow promptRow = userDataTable.NewRow();
                    promptRow["id_users"] = 0; 
                    promptRow["nom_users"] = "Choose a user";
                    promptRow["UserInfo"] = promptRow["nom_users"]; 
                    userDataTable.Rows.InsertAt(promptRow, 0);

                    userList.DisplayMember = "UserInfo"; 
                    userList.ValueMember = "id_users";

                    userList.DataSource = userDataTable;
                    userList.SelectedIndex = 0; 

                }
            
            }
        }
    }
}
