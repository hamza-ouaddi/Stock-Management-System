using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gestion.classes
{
    class Users
    {
        private int id_users;
        private string login_users;
        private string password_users;
        private string nom_users;
        private string prenom_users;
        private string tele_users;
        private string note;

        public Users()
        {
        }

        public Users(int id_users, string login_users, string password_users, string nom_users, string prenom_users, string tele_users, string note)
        {
            this.id_users = id_users;
            this.login_users = login_users;
            this.password_users = password_users;
            this.nom_users = nom_users;
            this.prenom_users = prenom_users;
            this.tele_users = tele_users;
            this.note = note;
        }

        //Getters

        public int getId_users()
        {
            return this.id_users;
        }

        public string getLogin_users()
        {
            return this.login_users;
        }

        public string getPassword_users()
        {
            return this.password_users;
        }

        public string getNom_users()
        {
            return this.nom_users;
        }

        public string getPrenom_users()
        {
            return this.prenom_users;
        }

        public string getTele_users()
        {
            return this.tele_users;
        }

        public string getNote()
        {
            return this.note;
        }
   

        //Setters

        public void setId_users(int value)
        {
            this.id_users = value;
        }

        public void setLogin_users(string value)
        {
            this.login_users = value;
        }

        public void setPassword_users(string value)
        {
            this.password_users = value;
        }

        public void setNom_users(string value)
        {
            this.nom_users = value;
        }

        public void setPrenom_users(string value)
        {
            this.prenom_users = value;
        }

        public void setTele_users(string value)
        {
            this.tele_users = value;
        }

        public void setNote(string value)
        {
            this.note = value;
        }

        //Affichage

        public void afficher()
        {
            Console.WriteLine("User ID: " + this.id_users);
            Console.WriteLine("Login: " + this.login_users);
            Console.WriteLine("Password: " + this.password_users);
            Console.WriteLine("Nom: " + this.nom_users);
            Console.WriteLine("Prenom: " + this.prenom_users);
            Console.WriteLine("Telephone: " + this.tele_users);
            Console.WriteLine("Note: " + this.note);
        }


    }

}
