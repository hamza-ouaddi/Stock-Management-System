using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.classes
{
    class Achat
    {
        private int id_achat;
        private string date_achat;
        private int qte_achat;
        private Produits produit;
        private Fournisseurs fournisseur;
        private string note_achat;

        public Achat()
        {
        }

        public Achat(int id_achat, string date_achat, int qte_achat, Produits produit, Fournisseurs fournisseur, string note_achat)
        {
            this.id_achat = id_achat;
            this.date_achat =  date_achat;
            this.qte_achat = qte_achat;
            this.produit = produit;
            this.fournisseur = fournisseur;
            this.note_achat = note_achat;

        }

        /*public Achat(int p1, string p2, int p3, int p4, int p5, string p6)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.p5 = p5;
            this.p6 = p6;
        }*/

        //Getters

        public int getId_achat()
        {
            return this.id_achat;
        }

        public string getDate_achat()
        {
            return this.date_achat;
        }

        public int getQte_achat()
        {
            return this.qte_achat;
        }

        public Produits getProduit()
        {
            return this.produit;
        }

        public Fournisseurs getFournisseur()
        {
            return this.fournisseur;
        }

        public string getNote_achat()
        {
            return this.note_achat;
        }

        //Setters

        public void setId_achat(int value)
        {
            this.id_achat = value;
        }

        public void setDate_achat(string value)
        {
            this.date_achat = value;
        }

        public void setQte_achat(int value)
        {
            this.qte_achat = value;
        }

        public void setProduit(Produits value)
        {
            this.produit = value;
        }

        public void setFournisseur(Fournisseurs value)
        {
            this.fournisseur = value;
        }

        public void setNote_achat(string value)
        {
            this.note_achat = value;
        }

        //Affichage

        public void afficher()
        {
            Console.WriteLine("Achat ID: " + this.id_achat);
            Console.WriteLine("Date: " + this.date_achat);
            Console.WriteLine("Quantité: " + this.qte_achat);
            Console.WriteLine("Produit: " + this.produit);
            Console.WriteLine("Fournisseur: " + this.fournisseur);
            Console.WriteLine("Note: " + this.note_achat);
        }
    }
}
