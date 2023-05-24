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
using System.Data;
using System.Data.SqlClient;
    
namespace Gestion.Forms
{
    public partial class usersForm : Form
    {
        public usersForm()
        {
            InitializeComponent();
        }

        private void usersForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.TopLevel = false;
            userPanel.Controls.Add(addUser);
            addUser.BringToFront();
            addUser.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteUser deleteUser = new DeleteUser();
            deleteUser.TopLevel = false;
            userPanel.Controls.Add(deleteUser);
            deleteUser.BringToFront();
            deleteUser.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchUser searchUser = new SearchUser();
            searchUser.TopLevel = false;
            userPanel.Controls.Add(searchUser);
            searchUser.BringToFront();
            searchUser.Show();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateUser updateUser = new UpdateUser();
            updateUser.TopLevel = false;
            userPanel.Controls.Add(updateUser);
            updateUser.BringToFront();
            updateUser.Show();
           
           
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            /*AllUsers allUsers = new AllUsers();
            allUsers.TopLevel = false;
            userPanel.Controls.Add(allUsers);
            allUsers.BringToFront();
            allUsers.Show();*/

            Usersimp usersImp = new Usersimp();
            UsersList usersList = new UsersList();
            usersList.Show();
            
            
            

           
           

        }
    }
}
