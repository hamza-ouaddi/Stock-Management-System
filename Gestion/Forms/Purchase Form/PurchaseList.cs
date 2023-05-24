using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Gestion.Forms.Purchase_Form
{
    public partial class PurchaseList : Form
    {
        public PurchaseList()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True";
            string sql = "SELECT * FROM Achat";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Achat");
            connection.Close();
            dataList.DataSource = ds;
            dataList.DataMember = "Achat";
        }
    }
}
