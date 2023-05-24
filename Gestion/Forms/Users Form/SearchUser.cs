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
    public partial class SearchUser : Form
    {
        public SearchUser()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
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

        private void idBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {
                    }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
