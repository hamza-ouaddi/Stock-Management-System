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

namespace Gestion.Forms.Users_Form
{
    public partial class UpdateUser : Form
    {
        public UpdateUser()
        {
            InitializeComponent();
        }

        private void UpdateUser_Load(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);
            string login = loginBox.Text;
            string password = passwordBox.Text;
            string firstName = fNameBox.Text;
            string lastName = lNameBox.Text;
            string phoneNumber = phoneBox.Text;
            string note = noteBox.Text;
            Usersimp userImp = new Usersimp();
            Boolean check = false;

            Users user = new Users(id, login, password, lastName, firstName, phoneNumber, note);

            try
            {
                userImp.update(user);

                MessageBox.Show("The user has been updated.");

                //To clear TextBox
                idBox.Text = string.Empty;
                loginBox.Text = string.Empty;
                passwordBox.Text = string.Empty;
                fNameBox.Text = string.Empty;
                lNameBox.Text = string.Empty;
                phoneBox.Text = string.Empty;
                noteBox.Text = string.Empty;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            


            //To clear TextBox
            idBox.Text = string.Empty;
            loginBox.Text = string.Empty;
            passwordBox.Text = string.Empty;
            fNameBox.Text = string.Empty;
            lNameBox.Text = string.Empty;
            phoneBox.Text = string.Empty;
            noteBox.Text = string.Empty;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);
            Usersimp userImp = new Usersimp();

            try
            {
                idBox.Text = Convert.ToString(userImp.getById(id).getId_users());
                loginBox.Text = userImp.getById(id).getLogin_users();
                passwordBox.Text = userImp.getById(id).getPassword_users();
                fNameBox.Text = userImp.getById(id).getPrenom_users();
                lNameBox.Text = userImp.getById(id).getNom_users();
                phoneBox.Text = userImp.getById(id).getTele_users();
                noteBox.Text = userImp.getById(id).getNote();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
