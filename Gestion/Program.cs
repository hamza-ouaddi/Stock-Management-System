using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion.classes;
using Gestion.IDao;
using Gestion.Services;

namespace Gestion
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

            Usersimp usersI = new Usersimp();

            Users user1 = new Users(1, "karim012", "ka23232", "Karim2", "Ben Atia2", "06010203042", "Lorem ipsum dolor sit amet.2");
            Users user2 = new Users(2, "amina_0", "amina123321", "Amina", "Saadani", "0612345678", "consectetur adipiscing elit.");

            /////Users

            /*usersI.add(user1);
            usersI.add(user2);*/

            /*usersI.delete(1);
            usersI.delete(2);*/

            /*foreach(Users user in usersI.getAll()){
                MessageBox.Show("List: " + user.getLogin_users());
            }*/

            /*MessageBox.Show("List: " + foreach(Users user in usersI.getAll())
            {
                user.afficher();
            });*/
            //usersI.update(user1);
            

            /////Produits
            Produitsimp prodI = new Produitsimp();

            Produits prod1 = new Produits(1, "Yawmi2", 7.70, "BOISSON", 8.75, "Excepteur sint occaecat cupidatat.2", "1235ab451a");
            Produits prod2 = new Produits(2, "Milfaya2", 1.80, "GÂTEAU", 1.75, "Duis aute irure dolor in reprehenderit in voluptate velit2.", "01245de2");

            //prodI.add(prod1);
            //prodI.add(prod2);

            //prodI.delete(2);

            //MessageBox.Show(prodI.getById(1).getPrix_vente().ToString());

            /*foreach (Produits produit in prodI.getAll())
            {
                MessageBox.Show("List" + produit.getPu_prod());
            }*/

            prodI.update(prod1);
            prodI.update(prod2);

            //Fournisseurs
            Fournisseursimp fournI = new Fournisseursimp();

            Fournisseurs fourn1 = new Fournisseurs(1, "Omar Boda32", "Maarif, Casablanca32", "055412001232", "voluptate velit esse cillum dolore eu fugiat nulla32");
            Fournisseurs fourn2 = new Fournisseurs(2, "Yasser Kaladi4", "Medina, Marrakech4", "06124578234", "Excepteur sint occaecat cupidatat non proident4");

            //fournI.add(fourn1);
            //fournI.add(fourn2);

           // fournI.delete(2);

           // MessageBox.Show(fournI.getById(1).getAdresse_fourn());

           /* foreach (Fournisseurs fournisseur in fournI.getAll())
            {
                MessageBox.Show(fournisseur.getNote_fourn());
            }*/

            //fournI.update(fourn1);
            //fournI.update(fourn2);

           //Client
            Clientimp clientI = new Clientimp();

            Client client1 = new Client(1, "Ahmed Faroq2", "Derb Ghaflone, Casablanca2", "06124785102", "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit.2");
            Client client2 = new Client(2, "Salima Ben Abbad2", "Daoudiyat, Marrakech2", "05121214472", "Tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.2");

            //clientI.add(client1);
            //clientI.add(client2);

            //clientI.delete(1);

            //MessageBox.Show(clientI.getById(1).getNom_client());

            /*foreach (Client client in clientI.getAll())
            {
                MessageBox.Show(client.getAdresse_client());
            }*/

            //clientI.update(client1);
            //clientI.update(client2);

            //Achat

            Achatimp achatI = new Achatimp();

            Achat achat1 = new Achat(1, "12/01/2022", 10, prodI.getById(2), fournI.getById(1), "Excepteur sint occaecat cupidatat non proident23");
            Achat achat2 = new Achat(2, "05/04/2023", 7, prodI.getById(2), fournI.getById(1), "Tempor incididunt ut labore et dolore");

           // achatI.add(achat1);
           // achatI.add(achat2);

            //achatI.delete(2);

            //MessageBox.Show(achatI.getById(2).getProduit().getLibelle().ToString());

            /*foreach (Achat achat in achatI.getAll())
            {
                MessageBox.Show(achat.getProduit().getPu_prod().ToString());
            }*/

            //achatI.update(achat2);

            //Vente

            Venteimp venteI = new Venteimp();

            Vente vente1 = new Vente(1, "01/03/2022", 7, 10.50, 12.50, prodI.getById(2), clientI.getById(1), "Duis aute irure dolor in reprehenderit in voluptate.2");
            Vente vente2 = new Vente(2, "24/07/2023", 6, 7.12, 8, prodI.getById(1), clientI.getById(2), "Nostrud exercitation ullamco laboris nisi ut aliquip.2");

            // venteI.add(vente1);
            // venteI.add(vente2);

            // venteI.delete(2);

            //MessageBox.Show(venteI.getById(2).getProduit().getLibelle());

            /*foreach (Vente vente in venteI.getAll())
            {
                MessageBox.Show(vente.getProduit().getLibelle());
            }*/

            //venteI.update(vente1);
           // venteI.update(vente2);

            //MessageBox.Show("Done: ");
           
        }
    }
}
