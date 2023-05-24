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
using System.Data.SqlClient;

namespace Gestion.Forms.Products_Form
{
    public partial class AddProducts : Form
    {
        public AddProducts()
        {
            InitializeComponent();

            increaseId();
        }

        private void noteBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);
            string title = titleBox.Text;
            double uPrice = Convert.ToDouble(uPriceBox.Text);
            string type = typeBox.Text;
            double sPrice = Convert.ToDouble(sPriceBox.Text);
            string note = noteBox.Text;
            string bareCode = bareCodeBox.Text;

            Produitsimp produitsImp = new Produitsimp();

            Produits product = new Produits(id, title, uPrice, type, sPrice, note, bareCode);

            try
            {
                produitsImp.add(product);

                MessageBox.Show("The product has been added");

                //To clear TextBox
                increaseId();
                titleBox.Text = string.Empty;
                uPriceBox.Text = string.Empty;
                typeBox.Text = string.Empty;
                sPriceBox.Text = string.Empty;
                noteBox.Text = string.Empty;
                bareCodeBox.Text = string.Empty;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        //To show the latest ID in ID box
        private void increaseId()
        {
            
            int nextId = 0;

            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();



                string getIdQuery = "SELECT ISNULL(MAX(id_prod), 0) + 1 FROM Produits";
                using (SqlCommand getIdCommand = new SqlCommand(getIdQuery, sqlConnection))
                {
                    nextId = Convert.ToInt32(getIdCommand.ExecuteScalar());
                }
            }

            idBox.Text = nextId.ToString();
        }
    }
}
