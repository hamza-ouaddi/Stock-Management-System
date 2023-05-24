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
using System.Data;
using System.Data.SqlClient;


namespace Gestion.Forms.Suppliers_Form
{
    public partial class AddSupplier : Form
    {
        public AddSupplier()
        {
            InitializeComponent();

            increaseId();

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBox.Text);
            string name = nameBox.Text;
            string address = addressBox.Text;
            string phoneNumber = phoneBox.Text;
            string note = noteBox.Text;

            Fournisseursimp fournisseursImp = new Fournisseursimp();
            Fournisseurs supplier = new Fournisseurs(id, name, address, phoneNumber, note);

            try
            {
                fournisseursImp.add(supplier);

                MessageBox.Show("The new supplier has been added.");

                //To clear TextBox
                increaseId();
                nameBox.Text = string.Empty;
                addressBox.Text = string.Empty;
                phoneBox.Text = string.Empty;
                noteBox.Text = string.Empty;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }


        }

        private void increaseId()
        {
            //To show the latest ID in ID box
            int nextId = 0;

            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();



                string getIdQuery = "SELECT ISNULL(MAX(id_fourn), 0) + 1 FROM FOURNISSEURS";
                using (SqlCommand getIdCommand = new SqlCommand(getIdQuery, sqlConnection))
                {
                    nextId = Convert.ToInt32(getIdCommand.ExecuteScalar());
                }
            }

            idBox.Text = nextId.ToString();
        }
    }
}
