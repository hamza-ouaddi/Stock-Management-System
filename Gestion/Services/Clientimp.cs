using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Gestion.classes;
using Gestion.IDao;

namespace Gestion.Services
{
    class Clientimp : IDao<Client>
    {
        List<Client> clienList = new List<Client>();
        SqlDataReader dataReader;

        //SQL Connection
        static string chaineConnection = "Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True";
        SqlConnection connection = new SqlConnection(chaineConnection);


        public void add(Client p)
        {
            string sql = "insert into Client values(@id_client, @nom_client, @adresse_client, @tele_client, @note_client)";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_client", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@nom_client", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@adresse_client", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@tele_client", SqlDbType.VarChar, 15));
            cmd.Parameters.Add(new SqlParameter("@note_client", SqlDbType.VarChar, 200));

            cmd.Parameters["@id_client"].Value = p.getId_client();
            cmd.Parameters["@nom_client"].Value = p.getNom_client();
            cmd.Parameters["@adresse_client"].Value = p.getAdresse_client();
            cmd.Parameters["@tele_client"].Value = p.getTele_client();
            cmd.Parameters["@note_client"].Value = p.getNote_client();

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public void delete(int id)
        {
            string sql = "delete from Client where id_client = @id_client";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("id_client", SqlDbType.Int));

            cmd.Parameters["id_client"].Value = id;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public Client getById(int id)
        {
            string sql = "select*from Client where id_client = @id_client";
            SqlCommand cmd = new SqlCommand(sql, connection);
            Client p = new Client();

            cmd.Parameters.Add(new SqlParameter("id_client", SqlDbType.Int));

            cmd.Parameters["id_client"].Value = id;

            connection.Open();

            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();
                p = new Client(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4));

            }

            dataReader.Close();
            connection.Close();
            return p;
        }

        public List<Client> getAll()
        {
            string sql = "select*from Client";
            SqlCommand cmd = new SqlCommand(sql, connection);
            Client p = new Client();
            
            connection.Open();
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    p = new Client(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4));
                    clienList.Add(p);
                }
            }

            dataReader.Close();
            connection.Close();

            return clienList;
            
        }

        public void update(Client objet)
        {
            string sql = "update Client set nom_client = @nom_client, adresse_client = @adresse_client, tele_client = @tele_client, note_client = @note_client where id_client = @id_client";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_client", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@nom_client", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@adresse_client", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@tele_client", SqlDbType.VarChar, 15));
            cmd.Parameters.Add(new SqlParameter("@note_client", SqlDbType.VarChar, 200));


            cmd.Parameters["@id_client"].Value = objet.getId_client();
            cmd.Parameters["@nom_client"].Value = objet.getNom_client();
            cmd.Parameters["@adresse_client"].Value = objet.getAdresse_client();
            cmd.Parameters["@tele_client"].Value = objet.getTele_client();
            cmd.Parameters["@note_client"].Value = objet.getNote_client();

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
    }
}
