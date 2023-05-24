using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.classes
{
    class Fournisseurs
    {
        private int id_fourn;
        private string nom_fourn;
        private string adresse_fourn;
        private string tele_fourn;
        private string note_fourn;

        public Fournisseurs()
        {
        }

        public Fournisseurs(int id_fourn, string nom_fourn, string adresse_fourn, string tele_fourn, string note_fourn)
        {
            this.id_fourn = id_fourn;
            this.nom_fourn = nom_fourn;
            this.adresse_fourn = adresse_fourn;
            this.tele_fourn = tele_fourn;
            this.note_fourn = note_fourn;
        }

        //Getters

        public int getId_fourn()
        {
            return this.id_fourn;
        }

        public string getNom_fourn()
        {
            return this.nom_fourn;
        }

        public string getAdresse_fourn()
        {
            return this.adresse_fourn;
        }

        public string getTele_fourn()
        {
            return this.tele_fourn;
        }

        public string getNote_fourn()
        {
            return this.note_fourn;
        }

        //Setters

        public void setId_fourn(int value)
        {
            this.id_fourn = value;
        }

        public void setNom_fourn(string value)
        {
            this.nom_fourn = value;
        }

        public void setAdresse_fourn(string value)
        {
            this.adresse_fourn = value;
        }

        public void setTele_fourn(string value)
        {
            this.tele_fourn = value;
        }

        public void setNote_fourn(string value)
        {
            this.note_fourn = value;
        }

        //Affichage

        public void afficher()
        {
            Console.WriteLine("Fournisseur ID: " + this.id_fourn);
            Console.WriteLine("Nom: " + this.nom_fourn);
            Console.WriteLine("Adresse: " + this.adresse_fourn);
            Console.WriteLine("Telephone: " + this.tele_fourn);
            Console.WriteLine("Note: " + this.note_fourn);
        }
    }
}
