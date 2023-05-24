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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();

            increaseId();
        }

        //To show the latest ID in ID box
        private void increaseId()
        {

            int nextId = 0;

            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();



                string getIdQuery = "SELECT ISNULL(MAX(id_users), 0) + 1 FROM USERS";
                using (SqlCommand getIdCommand = new SqlCommand(getIdQuery, sqlConnection))
                {
                    nextId = Convert.ToInt32(getIdCommand.ExecuteScalar());
                }
            }

            idBox.Text = nextId.ToString();
        }

        private void idBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lNameBox_Click(object sender, EventArgs e)
        {

        }

        private void fNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void loginBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);
            string login = loginBox.Text;
            string password = passwordBox.Text;
            string firstName = fNameBox.Text;
            string lastName = lNameBox.Text;
            string phoneNumber = phoneBox.Text;
            string note = noteBox.Text;
            Usersimp usersImp = new Usersimp();
            Users user = new Users(id, login, password, firstName, lastName, phoneNumber, note);
           

            try
            {
                usersImp.add(user);
                MessageBox.Show("The new user has been added.");

                //To clear TextBox
                increaseId();
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
            
            

        }
    }
}
