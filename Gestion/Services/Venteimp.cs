using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Gestion.classes;
using Gestion.IDao;
using Gestion.Services;

namespace Gestion.Services
{
    class Venteimp : IDao<Vente>
    {
        List<Vente> venteList = new List<Vente>();
        SqlDataReader dataReader;

        //SQl Connection
        static string chaineConnection = "Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True";
        SqlConnection connection = new SqlConnection(chaineConnection);


        public void add(Vente p)
        {
            string sql = "insert into Vente values(@id_vente, @date_vente, @qte_vente, @pu_achat, @pu_vente, @id_prod, @id_client, @note_vente)";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_vente", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@date_vente", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@qte_vente", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@pu_achat", SqlDbType.Float));
            cmd.Parameters.Add(new SqlParameter("@pu_vente", SqlDbType.Float));
            cmd.Parameters.Add(new SqlParameter("@id_prod", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@id_client", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@note_vente", SqlDbType.VarChar, 200));

            cmd.Parameters["@id_vente"].Value = p.getId_vente();
            cmd.Parameters["@date_vente"].Value = p.getDate_vente();
            cmd.Parameters["@qte_vente"].Value = p.getQte_vente();
            cmd.Parameters["@pu_achat"].Value = p.getPu_achat();
            cmd.Parameters["@pu_vente"].Value = p.getPu_vente();
            cmd.Parameters["@id_prod"].Value = p.getProduit().getId_prod();
            cmd.Parameters["@id_client"].Value = p.getClient().getId_client();
            cmd.Parameters["@note_vente"].Value = p.getNote_vente();

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void delete(int id)
        {
            string sql = "delete from Vente where id_vente = @id_vente";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_vente", SqlDbType.Int));

            cmd.Parameters["@id_vente"].Value = id;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public Vente getById(int id)
        {
            string sql = "select*from Vente where id_vente = @id_vente";
            SqlCommand cmd = new SqlCommand(sql, connection);
            Vente p = new Vente();
            Produitsimp prodI = new Produitsimp();
            Clientimp clientI = new Clientimp();

            cmd.Parameters.Add(new SqlParameter("id_vente", SqlDbType.Int));

            cmd.Parameters["id_vente"].Value = id;

            connection.Open();
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();
                p = new Vente(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetDouble(3), dataReader.GetDouble(4), prodI.getById(dataReader.GetInt32(5)), clientI.getById(dataReader.GetInt32(6)), dataReader.GetString(7));

            }

            dataReader.Close();
            connection.Close();
            return p;
        }

        public List<Vente> getAll()
        {
            string sql = "select*from Vente";
            SqlCommand cmd = new SqlCommand(sql, connection);
            Vente p = new Vente();
            Produitsimp prodI = new Produitsimp();
            Clientimp clientI = new Clientimp();

            connection.Open();
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    p = new Vente(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetDouble(3), dataReader.GetDouble(4), prodI.getById(dataReader.GetInt32(5)), clientI.getById(dataReader.GetInt32(6)), dataReader.GetString(7));
                    venteList.Add(p);
                }
            }

            dataReader.Close();
            connection.Close();

            return venteList;

        }

        public void update(Vente objet)
        {
            string sql = "update Vente set date_vente = @date_vente, qte_vente = @qte_vente, pu_achat = @pu_achat, pu_vente = @pu_vente, id_prod = @id_prod, id_client = @id_client, note_vente = @note_vente where id_vente = @id_vente";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_vente", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@date_vente", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@qte_vente", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@pu_achat", SqlDbType.Float));
            cmd.Parameters.Add(new SqlParameter("@pu_vente", SqlDbType.Float));
            cmd.Parameters.Add(new SqlParameter("@id_prod", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@id_client", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@note_vente", SqlDbType.VarChar, 200));

            cmd.Parameters["@id_vente"].Value = objet.getId_vente();
            cmd.Parameters["@date_vente"].Value = objet.getDate_vente();
            cmd.Parameters["@qte_vente"].Value = objet.getQte_vente();
            cmd.Parameters["@pu_achat"].Value = objet.getPu_achat();
            cmd.Parameters["@pu_vente"].Value = objet.getPu_vente();
            cmd.Parameters["@id_prod"].Value = objet.getProduit().getId_prod();
            cmd.Parameters["@id_client"].Value = objet.getClient().getId_client();
            cmd.Parameters["@note_vente"].Value = objet.getNote_vente();

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
