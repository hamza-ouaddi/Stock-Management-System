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

namespace Gestion.Forms.Sale_Form
{
    public partial class SaleList : Form
    {
        public SaleList()
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
            string sql = "SELECT * FROM Vente";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Vente");
            connection.Close();
            dataList.DataSource = ds;
            dataList.DataMember = "Vente";
        }
    }
}
