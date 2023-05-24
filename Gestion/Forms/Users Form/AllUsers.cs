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

namespace Gestion.Forms.Users_Form
{
    public partial class AllUsers : Form
    {
        public AllUsers()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=gestion;Integrated Security=True";
            string sql = "SELECT * FROM Users";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Users");
            connection.Close();
            dataList.DataSource = ds;
            dataList.DataMember = "Users";
        }
    }
}
