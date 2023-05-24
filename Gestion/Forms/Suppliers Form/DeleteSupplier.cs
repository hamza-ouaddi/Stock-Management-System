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
    public partial class DeleteSupplier : Form
    {
        public DeleteSupplier()
        {
            InitializeComponent();

            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();

                // The supplierList control
                using (SqlCommand supplierSqlCommand = new SqlCommand("SELECT * from FOURNISSEURS", sqlConnection))
                {
                    SqlDataAdapter supplierAdapter = new SqlDataAdapter(supplierSqlCommand);
                    DataTable supplierDataTable = new DataTable();
                    supplierAdapter.Fill(supplierDataTable);

                    
                    supplierDataTable.Columns.Add("SupplierInfo", typeof(string));

                    foreach (DataRow row in supplierDataTable.Rows)
                    {
                        row["SupplierInfo"] = row["id_fourn"] + " - " + row["nom_fourn"]; // Combine ID and name
                    }

                    supplierList.DisplayMember = "SupplierInfo"; 
                    supplierList.ValueMember = "id_fourn";


                    // Add a default item as placeholder
                    DataRow promptRow = supplierDataTable.NewRow();
                    promptRow["id_fourn"] = 0; 
                    promptRow["nom_fourn"] = "Choose a supplier";
                    promptRow["SupplierInfo"] = promptRow["nom_fourn"]; 
                    supplierDataTable.Rows.InsertAt(promptRow, 0);

                    supplierList.DisplayMember = "SupplierInfo"; 
                    supplierList.ValueMember = "id_fourn"; 

                    supplierList.DataSource = supplierDataTable;
                    supplierList.SelectedIndex = 0;

                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string selectedSupplier = Convert.ToString(supplierList.SelectedValue);
            int supplierId = Convert.ToInt32(selectedSupplier.Split('|')[0].Trim());
            Fournisseursimp fournisseursImp = new Fournisseursimp();

            try
            {
                fournisseursImp.delete(supplierId);

                MessageBox.Show("The supplier has been deleted.");

                //To clear TextBox
                RefreshList();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        private void RefreshList()
        {
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True"))
            {
                sqlConnection.Open();

                using (SqlCommand supplierSqlCommand = new SqlCommand("SELECT * from FOURNISSEURS", sqlConnection))
                {
                    SqlDataAdapter supplierAdapter = new SqlDataAdapter(supplierSqlCommand);
                    DataTable supplierDataTable = new DataTable();
                    supplierAdapter.Fill(supplierDataTable);

                    
                    supplierDataTable.Columns.Add("SupplierInfo", typeof(string));

                    foreach (DataRow row in supplierDataTable.Rows)
                    {
                        row["SupplierInfo"] = row["id_fourn"] + " - " + row["nom_fourn"]; // Combine ID and name
                    }

                    supplierList.DisplayMember = "SupplierInfo";
                    supplierList.ValueMember = "id_fourn";


                    // Add a default item as placeholder
                    DataRow promptRow = supplierDataTable.NewRow();
                    promptRow["id_fourn"] = 0; 
                    promptRow["nom_fourn"] = "Choose a supplier";
                    promptRow["SupplierInfo"] = promptRow["nom_fourn"]; 
                    supplierDataTable.Rows.InsertAt(promptRow, 0);

                    supplierList.DisplayMember = "SupplierInfo"; 
                    supplierList.ValueMember = "id_fourn"; 

                    supplierList.DataSource = supplierDataTable;
                    supplierList.SelectedIndex = 0; 

                }
            }
        }
    }
}
