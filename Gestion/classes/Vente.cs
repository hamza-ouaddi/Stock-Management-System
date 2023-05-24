using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.classes
{
    class Vente
    {
        private int id_vente;
        private string date_vente;
        private int qte_vente;
        private double pu_achat;
        private double pu_vente;
        private Produits produit;
        private Client client;
        private string note_vente;

        public Vente()
        {
        }

        public Vente(int id_vente, string date_vente, int qte_vente, double pu_achat, double pu_vente, Produits produit, Client client, string note_vente)
        {
            this.id_vente = id_vente;
            this.date_vente = date_vente;
            this.qte_vente = qte_vente;
            this.pu_achat = pu_achat;
            this.pu_vente = pu_vente;
            this.produit = produit;
            this.client = client;
            this.note_vente = note_vente;
        }

        //Getters

        public int getId_vente()
        {
            return this.id_vente;
        }

        public string getDate_vente()
        {
            return this.date_vente;
        }

        public int getQte_vente()
        {
            return this.qte_vente;
        }

        public double getPu_achat()
        {
            return this.pu_achat;
        }

        public double getPu_vente()
        {
            return this.pu_vente;
        }

        public Produits getProduit()
        {
            return this.produit;
        }

        public Client getClient()
        {
            return this.client;
        }

        public string getNote_vente()
        {
            return this.note_vente;
        }

        //Setters

        public void setId_vente(int value)
        {
            this.id_vente = value;
        }

        public void setDate_vente(string value)
        {
            this.date_vente = value;
        }

        public void setQte_vente(int value)
        {
            this.qte_vente = value;
        }

        public void setPu_achat(double value)
        {
            this.pu_achat = value;
        }

        public void setPu_vente(double value)
        {
            this.pu_vente = value;
        }

        public void setProduit(Produits value)
        {
            this.produit = value;
        }

        public void setClient(Client value)
        {
            this.client = value;
        }

        public void setNote_vente(string value)
        {
            this.note_vente = value;
        }

        //Affichage

        public void afficher()
        {
            Console.WriteLine("Vente ID:" + this.id_vente);
            Console.WriteLine("Date: " + this.date_vente);
            Console.WriteLine("Quantité: " + this.qte_vente);
            Console.WriteLine("Prix d'achat unitaire: " + this.pu_achat);
            Console.WriteLine("Prix de vente unitaire: " + this.pu_vente);
            Console.WriteLine("Produit: " + this.produit);
            Console.WriteLine("Client: " + this.client);
            Console.WriteLine("Note: " + this.note_vente);
        }
        
    }
}
