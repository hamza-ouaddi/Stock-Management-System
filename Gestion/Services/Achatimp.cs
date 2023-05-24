using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Gestion.IDao;
using Gestion.classes;

namespace Gestion.Services
{
    class Achatimp : IDao<Achat>
    {
        List<Achat> achatList = new List<Achat>();
        SqlDataReader dataReader;

        //SQl Connection
        static string chaineConnection = "Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True";
        SqlConnection connection = new SqlConnection(chaineConnection);


        public void add(Achat p)
        {
            string sql = "insert into Achat values(@id_achat, @date_achat, @qte_achat, @id_prod, @id_fourn, @note_achat)";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_achat", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@date_achat", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@qte_achat", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@id_prod", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@id_fourn", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@note_achat", SqlDbType.VarChar, 200));

            cmd.Parameters["@id_achat"].Value = p.getId_achat();
            cmd.Parameters["@date_achat"].Value = p.getDate_achat();
            cmd.Parameters["@qte_achat"].Value = p.getQte_achat();
            cmd.Parameters["@id_prod"].Value = p.getProduit().getId_prod();
            cmd.Parameters["@id_fourn"].Value = p.getFournisseur().getId_fourn();
            cmd.Parameters["@note_achat"].Value = p.getNote_achat();

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public void delete(int id)
        {
            string sql = "delete from Achat where id_achat = @id_achat";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_achat", SqlDbType.Int));

            cmd.Parameters["@id_achat"].Value = id;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public Achat getById(int id)
        {
            string sql = "select*from Achat where id_achat = @id_achat";
            SqlCommand cmd = new SqlCommand(sql, connection);
            Achat p = new Achat();
            Produitsimp proudI = new Produitsimp();
            Fournisseursimp fournI = new Fournisseursimp();

            cmd.Parameters.Add(new SqlParameter("id_achat", SqlDbType.Int));

            cmd.Parameters["id_achat"].Value = id;

            connection.Open();
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();
                p = new Achat(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2), proudI.getById(dataReader.GetInt32(3)), fournI.getById(dataReader.GetInt32(4)), dataReader.GetString(5));
            }

            dataReader.Close();
            connection.Close();

            return p;
        }

        public List<Achat> getAll()
        {
            string sql = "select*from Achat";
            SqlCommand cmd = new SqlCommand(sql, connection);
            Achat p = new Achat();
            Produitsimp proudI = new Produitsimp();
            Fournisseursimp fournI = new Fournisseursimp();

            connection.Open();
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    p = new Achat(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2), proudI.getById(dataReader.GetInt32(3)), fournI.getById(dataReader.GetInt32(4)), dataReader.GetString(5));
                    achatList.Add(p);
                }

            }

            dataReader.Close();
            connection.Close();

            return achatList;

        }

        public void update(Achat objet)
        {
            string sql = "update Achat set date_achat = @date_achat, qte_achat = @qte_achat, id_prod = @id_prod, id_fourn = @id_fourn, note_achat = @note_achat where id_achat = @id_achat";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_achat", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@date_achat", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@qte_achat", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@id_prod", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@id_fourn", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@note_achat", SqlDbType.VarChar, 200));

            cmd.Parameters["@id_achat"].Value = objet.getId_achat();
            cmd.Parameters["@date_achat"].Value = objet.getDate_achat();
            cmd.Parameters["@qte_achat"].Value = objet.getQte_achat();
            cmd.Parameters["@id_prod"].Value = objet.getProduit().getId_prod();
            cmd.Parameters["@id_fourn"].Value = objet.getFournisseur().getId_fourn();
            cmd.Parameters["@note_achat"].Value = objet.getNote_achat();

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
