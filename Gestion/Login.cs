using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion.classes;
using Gestion.IDao;
using Gestion.Services;

namespace Gestion
{
    public partial class Login : Form
    {
        public static Login instance;
        public TextBox textbox;


        public Login()
        {
            InitializeComponent();
            instance = this;
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usersimp userImp = new Usersimp();
            string loginUser = textBox1.Text;
            string passUser = textBox2.Text;
            Boolean check = false;

            foreach (Users users in userImp.getAll())
            {

                if (users.getLogin_users().ToString() == loginUser && users.getPassword_users().ToString() == passUser)
                {
                   
                    Main mainForm = new Main();
                    Login loginForm = new Login();

                    
                    mainForm.Show();
                    this.Hide();

                    Main.instance.label.Text = users.getNom_users().ToString();

                    check = true;
                    
                    
                }
                else
                {

                    check = false;
                }

            }

            if (check != true)
            {
                MessageBox.Show("Incorrect");
            }
            


        }
    }
}
