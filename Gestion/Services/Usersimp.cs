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
    class Usersimp : IDao<Users>
    {
        List<Users> usersList = new List<Users>();
        SqlDataReader dataReader;

        //SQL Connection
        static string chaineConnection = "Data Source=DESKTOP-4BI89KF;Initial Catalog=gestion;Integrated Security=True";
        SqlConnection connection = new SqlConnection(chaineConnection);

        public void add(Users p)
        {
            string sql = "insert into Users values(@id_users, @login_users, @password_users, @nom_users, @prenom_users, @tele_users, @note)";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_users", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@login_users", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@password_users", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@nom_users", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@prenom_users", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@tele_users", SqlDbType.VarChar, 15));
            cmd.Parameters.Add(new SqlParameter("@note", SqlDbType.VarChar, 200));

            cmd.Parameters["@id_users"].Value = p.getId_users();
            cmd.Parameters["@login_users"].Value = p.getLogin_users();
            cmd.Parameters["@password_users"].Value = p.getPassword_users();
            cmd.Parameters["@nom_users"].Value = p.getNom_users();
            cmd.Parameters["@prenom_users"].Value = p.getPrenom_users();
            cmd.Parameters["@tele_users"].Value = p.getTele_users();
            cmd.Parameters["@note"].Value = p.getNote();

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();


        }

        public void delete(int id)
        {
            string sql = "delete from Users where id_users = @id_users";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("id_users", SqlDbType.Int));

            cmd.Parameters["id_users"].Value = id;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public Users getById(int id)
        {
            string sql = "select*from Users where id_users = @id_users";
            SqlCommand cmd = new SqlCommand(sql, connection);
            Users p = new Users();

            cmd.Parameters.Add(new SqlParameter("id_users", SqlDbType.Int));

            cmd.Parameters["id_users"].Value = id;

            connection.Open();
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();
                p = new Users(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5), dataReader.GetString(6));

            }

            dataReader.Close();
            connection.Close();

            return p;
        }

        public List<Users> getAll()
        {
            string sql = "select*from Users";
            SqlCommand cmd = new SqlCommand(sql, connection);
            Users p = new Users();

            connection.Open();
            dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    p = new Users(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5), dataReader.GetString(6));
                    usersList.Add(p);
                }
            }

            dataReader.Close();
            connection.Close();

            return usersList;

        }

        public void update(Users objet)
        {
            string sql = "update Users set login_users = @login_users, password_users = @password_users, nom_users = @nom_users, prenom_users = @prenom_users, tele_users = @tele_users, note = @note where id_users = @id_users";
            SqlCommand cmd = new SqlCommand(sql, connection);

            cmd.Parameters.Add(new SqlParameter("@id_users", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@login_users", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@password_users", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@nom_users", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@prenom_users", SqlDbType.VarChar, 30));
            cmd.Parameters.Add(new SqlParameter("@tele_users", SqlDbType.VarChar, 15));
            cmd.Parameters.Add(new SqlParameter("@note", SqlDbType.VarChar, 200));


            cmd.Parameters["@id_users"].Value = objet.getId_users();
            cmd.Parameters["@login_users"].Value = objet.getLogin_users();
            cmd.Parameters["@password_users"].Value = objet.getPassword_users();
            cmd.Parameters["@nom_users"].Value = objet.getNom_users();
            cmd.Parameters["@prenom_users"].Value = objet.getPrenom_users();
            cmd.Parameters["@tele_users"].Value = objet.getTele_users();
            cmd.Parameters["@note"].Value = objet.getNote();

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
