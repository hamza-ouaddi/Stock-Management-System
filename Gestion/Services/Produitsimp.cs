using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion.classes;
using Gestion.IDao;
using System.Data;
using System.Data.SqlClient;

namespace Gestion.Services
{
    class Produitsimp : IDao<Produits>
    {

        List<Produits> produitsList = new List<Produits>();
        SqlDataReader dataReader;

        //SQL Connection
        static string chaineConnection = "Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True";
        SqlConnection connection = new SqlConnection(chaineConnection);


        public void add(Produits p)
        {
            string sql = "insert into Produits values(@id_prod, @libelle, @pu_prod, @type_prod, @prix_vente, @note_prod, @code_barre)";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_prod", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@libelle", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@pu_prod", SqlDbType.Float));
            cmd.Parameters.Add(new SqlParameter("@type_prod", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@prix_vente", SqlDbType.Float));
            cmd.Parameters.Add(new SqlParameter("@note_prod", SqlDbType.VarChar, 200));
            cmd.Parameters.Add(new SqlParameter("@code_barre", SqlDbType.VarChar, 30));

            cmd.Parameters["@id_prod"].Value = p.getId_prod();
            cmd.Parameters["@libelle"].Value = p.getLibelle();
            cmd.Parameters["@pu_prod"].Value = p.getPu_prod();
            cmd.Parameters["@type_prod"].Value = p.getType_prod();
            cmd.Parameters["@prix_vente"].Value = p.getPrix_vente();
            cmd.Parameters["@note_prod"].Value = p.getNote_prod();
            cmd.Parameters["@code_barre"].Value = p.getCode_barre();

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public void delete(int id)
        {
            string sql = "delete from Produits where id_prod = @id_prod";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_prod", SqlDbType.Int));

            cmd.Parameters["@id_prod"].Value = id;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();


        }

        public Produits getById(int id)
        {
            string sql = "select*from Produits where id_prod = @id_prod";
            SqlCommand cmd = new SqlCommand(sql, connection);
            Produits p = new Produits();

            cmd.Parameters.Add(new SqlParameter("id_prod", SqlDbType.Int));
            cmd.Parameters["id_prod"].Value = id;

            connection.Open();
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();
                p = new Produits(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetDouble(2), dataReader.GetString(3), dataReader.GetDouble(4), dataReader.GetString(5), dataReader.GetString(6));
            }

            dataReader.Close();
            connection.Close();

            return p;
        }

        public List<Produits> getAll()
        {
            string sql = "select*from Produits";
            SqlCommand cmd = new SqlCommand(sql, connection);
            Produits p = new Produits();

            connection.Open();
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    p = new Produits(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetDouble(2), dataReader.GetString(3), dataReader.GetDouble(4), dataReader.GetString(5), dataReader.GetString(6));
                    produitsList.Add(p);
                }
            }

            dataReader.Close();
            connection.Close();

            return produitsList;
        }

        public void update(Produits objet)
        {
            string sql = "update Produits set libelle = @libelle, pu_prod = @pu_prod, type_prod = @type_prod, prix_vente = @prix_vente, note_prod = @note_prod, code_barre = @code_barre where id_prod = @id_prod";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_prod", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@libelle", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@pu_prod", SqlDbType.Float));
            cmd.Parameters.Add(new SqlParameter("@type_prod", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@prix_vente", SqlDbType.Float));
            cmd.Parameters.Add(new SqlParameter("@note_prod", SqlDbType.VarChar, 200));
            cmd.Parameters.Add(new SqlParameter("@code_barre", SqlDbType.VarChar, 30));


            cmd.Parameters["@id_prod"].Value = objet.getId_prod();
            cmd.Parameters["@libelle"].Value = objet.getLibelle();
            cmd.Parameters["@pu_prod"].Value = objet.getPu_prod();
            cmd.Parameters["@type_prod"].Value = objet.getType_prod();
            cmd.Parameters["@prix_vente"].Value = objet.getPrix_vente();
            cmd.Parameters["@note_prod"].Value = objet.getNote_prod();
            cmd.Parameters["@code_barre"].Value = objet.getCode_barre();

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();


        }
    }
}
