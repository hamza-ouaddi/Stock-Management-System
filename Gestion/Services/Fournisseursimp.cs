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
    class Fournisseursimp : IDao<Fournisseurs>
    {

        List<Fournisseurs> fournisseursList = new List<Fournisseurs>();
        SqlDataReader dataReader;

        //SQL Connection
        static string chaineConnection = "Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True";
        SqlConnection connection = new SqlConnection(chaineConnection);

        public void add(Fournisseurs p)
        {
            string sql = "insert into Fournisseurs values(@id_fourn, @nom_fourn, @adresse_fourn, @tele_fourn, @note_fourn)";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_fourn", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@nom_fourn", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@adresse_fourn", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@tele_fourn", SqlDbType.VarChar, 15));
            cmd.Parameters.Add(new SqlParameter("@note_fourn", SqlDbType.VarChar, 200));

            cmd.Parameters["@id_fourn"].Value = p.getId_fourn();
            cmd.Parameters["@nom_fourn"].Value = p.getNom_fourn();
            cmd.Parameters["@adresse_fourn"].Value = p.getAdresse_fourn();
            cmd.Parameters["@tele_fourn"].Value = p.getTele_fourn();
            cmd.Parameters["@note_fourn"].Value = p.getNote_fourn();

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void delete(int id)
        {
            string sql = "delete from Fournisseurs where id_fourn = @id_fourn";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_fourn", SqlDbType.Int));

            cmd.Parameters["@id_fourn"].Value = id;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public Fournisseurs getById(int id)
        {
            string sql = "select*from Fournisseurs where id_fourn = @id_fourn";
            SqlCommand cmd = new SqlCommand(sql, connection);
            Fournisseurs p = new Fournisseurs();

            cmd.Parameters.Add(new SqlParameter("id_fourn", SqlDbType.Int));

            cmd.Parameters["id_fourn"].Value = id;

            connection.Open();
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();

                p = new Fournisseurs(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4));

            }

            dataReader.Close();
            connection.Close();

            return p;
        }

        public List<Fournisseurs> getAll()
        {
            string sql = "select*from Fournisseurs";
            SqlCommand cmd = new SqlCommand(sql, connection);
            Fournisseurs p = new Fournisseurs();

            connection.Open();
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    p = new Fournisseurs(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4));
                    fournisseursList.Add(p);
                }
            }

            dataReader.Close();
            connection.Close();

            return fournisseursList;

        }

        public void update(Fournisseurs objet)
        {
            string sql = "update Fournisseurs set nom_fourn = @nom_fourn, adresse_fourn = @adresse_fourn, tele_fourn = @tele_fourn, note_fourn = @note_fourn where id_fourn = @id_fourn";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_fourn", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@nom_fourn", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@adresse_fourn", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@tele_fourn", SqlDbType.VarChar, 15));
            cmd.Parameters.Add(new SqlParameter("@note_fourn", SqlDbType.VarChar, 200));
    

            cmd.Parameters["@id_fourn"].Value = objet.getId_fourn();
            cmd.Parameters["@nom_fourn"].Value = objet.getNom_fourn();
            cmd.Parameters["@adresse_fourn"].Value = objet.getAdresse_fourn();
            cmd.Parameters["@tele_fourn"].Value = objet.getTele_fourn();
            cmd.Parameters["@note_fourn"].Value = objet.getNote_fourn();

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
    }
}
