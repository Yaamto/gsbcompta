using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsbcompta
{
    class UserController
    {
        List<User> Users;
        Database Db;
        public UserController()
        {
            Db = new Database();
        }

        public List<User> getUsers()
        {
            try
            {
                Db.Mysql.Open();

                MySqlCommand cmd = Db.Mysql.CreateCommand();

                cmd.CommandText = "SELECT * FROM utilisateur";
                MySqlDataReader reader = cmd.ExecuteReader();
                Users = new List<User>();

                while (reader.Read())
                {
                    User u = new User(reader["id"].ToString(), reader["nom"].ToString(), reader["prenom"].ToString(), reader["login"].ToString(), reader["adresse"].ToString(), reader["cp"].ToString(), reader["ville"].ToString(), reader["mdp"].ToString(), reader["dateEmbauche"].ToString());
                    Users.Add(u);
                                       
                }
                Db.Mysql.Close();
                return Users;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Users;
            }
            
        }

        public void AddUser(string id, string nom, string prenom, string login, string password, string adresse, string cp, string ville, string date, string role)
        {
            try
            {
                Db.Mysql.Open();

                MySqlCommand cmd = Db.Mysql.CreateCommand();

                cmd.CommandText = "INSERT INTO utilisateur (id,nom,prenom,login,mdp,adresse,cp,ville,dateEmbauche,role) VALUES ('" + id + "','" + nom + "','" + prenom + "','" + login + "','" + password + "','" + adresse + "','" + cp + "','" + ville + "','" + date + "','" + role +"' )";
                cmd.ExecuteNonQuery();

                Db.Mysql.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e);
            }


        }




    }
}
