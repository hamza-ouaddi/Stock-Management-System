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

namespace Gestion.Forms.Suppliers_Form
{
    public partial class UpdateSupplier : Form
    {
        public UpdateSupplier()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, EventArgs e)
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
                fournisseursImp.update(supplier);

                MessageBox.Show("The supplier has been updated.");
                
                //To clear TextBox
                idBox.Text = string.Empty;
                nameBox.Text = string.Empty;
                addressBox.Text = string.Empty;
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
