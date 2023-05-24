using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.classes
{
    class Produits
    {
        private int id_prod;
        private string libelle;
        private double pu_prod;
        private string type_prod;
        private double prix_vente;
        private string note_prod;
        private string code_barre;

        public Produits()
        {
        }

        public Produits(int id_prod, string libelle, double pu_prod, string type_prod, double prix_vente, string note_prod, string code_barre)
        {
            this.id_prod = id_prod;
            this.libelle = libelle;
            this.pu_prod = pu_prod;
            this.type_prod = type_prod;
            this.prix_vente = prix_vente;
            this.note_prod = note_prod;
            this.code_barre = code_barre;
        }

        //Getters

        public int getId_prod()
        {
            return this.id_prod;
        }

        public string getLibelle()
        {
            return this.libelle;
        }

        public double getPu_prod()
        {
            return this.pu_prod;
        }

        public string getType_prod()
        {
            return this.type_prod;
        }

        public double getPrix_vente()
        {
            return this.prix_vente;
        }

        public string getNote_prod()
        {
            return this.note_prod;
        }

        public string getCode_barre()
        {
            return this.code_barre;
        }

        //Setters

        public void setId_prod(int value)
        {
            this.id_prod = value;
        }

        public void setLibelle(string value)
        {
            this.libelle = value;
        }

        public void setPu_prod(double value)
        {
            this.pu_prod = value;
        }

        public void setType_prod(string value)
        {
            this.type_prod = value;
        }

        public void setPrix_vante(double value)
        {
            this.prix_vente = value;
        }

        public void setNote_prod(string value)
        {
            this.note_prod = value;
        }

        public void setCode_barre(string value)
        {
            this.code_barre = value;
        }

        //Affichage

        public void afficher()
        {
            Console.WriteLine("Produit ID:" + this.id_prod);
            Console.WriteLine("Libelle: " + this.libelle);
            Console.WriteLine("Prix Unitaire: " + this.pu_prod);
            Console.WriteLine("Type: " + this.type_prod);
            Console.WriteLine("Prix de vente: " + this.prix_vente);
            Console.WriteLine("Note: " + this.note_prod);
            Console.WriteLine("Code-barre: " + this.code_barre);
        }

    }
}
