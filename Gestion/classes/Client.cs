using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.classes
{
    class Client
    {
        private int id_client;
        private string nom_client;
        private string adresse_client;
        private string tele_client;
        private string note_client;

        public Client()
        {
        }

        public Client(int id_client, string nom_client, string adresse_client, string tele_client, string note_client)
        {
            this.id_client = id_client;
            this.nom_client = nom_client;
            this.adresse_client = adresse_client;
            this.tele_client = tele_client;
            this.note_client = note_client;
        }

        //Getters

        public int getId_client()
        {
            return this.id_client;
        }

        public string getNom_client()
        {
            return this.nom_client;
        }

        public string getAdresse_client()
        {
            return this.adresse_client;
        }

        public string getTele_client()
        {
            return this.tele_client;
        }

        public string getNote_client()
        {
            return this.note_client;
        }

        //Setters

        public void setId_client(int value)
        {
            this.id_client = value;
        }

        public void setNom_client(string value)
        {
            this.nom_client = value;
        }

        public void setAdresse_client(string value)
        {
            this.adresse_client = value;
        }

        public void setTele_client(string value)
        {
            this.tele_client = value;
        }

        public void setNote_client(string value)
        {
            this.note_client = value;
        }

        //Affichage

        public void afficher()
        {
            Console.WriteLine("Client ID: " + this.id_client);
            Console.WriteLine("Nom: " + this.nom_client);
            Console.WriteLine("Adresse: " + this.adresse_client);
            Console.WriteLine("Telephone: " + this.tele_client);
            Console.WriteLine("Note: " + this.note_client);
        }
    }
}
