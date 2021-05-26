using gsbcompta.MODELS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsbcompta.CONTROLLERS
{
    class OffPriceController
    {
        List<OffPrice> OffPrices;
        Database Db;

        public OffPriceController()
        {
            Db = new Database();
        }

        public List<OffPrice> getOffPrices(string userid, string month)
        {
            try
            {
                Db.Mysql.Open();

                MySqlCommand cmd = Db.Mysql.CreateCommand();

                cmd.CommandText = "SELECT * FROM lignefraishorsforfait WHERE idutilisateur ='" + userid + "' AND mois='" + month + "'";
                MySqlDataReader reader = cmd.ExecuteReader();
                OffPrices = new List<OffPrice>();

                while (reader.Read())
                {
                    OffPrice op = new OffPrice (Int32.Parse(reader["id"].ToString()), reader["idutilisateur"].ToString(), reader["mois"].ToString(), reader["libelle"].ToString(), reader["date"].ToString(), float.Parse(reader["montant"].ToString()), reader["justificatif"].ToString());
                    OffPrices.Add(op);
                }
                Db.Mysql.Close();
                return OffPrices;

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e);
                return OffPrices;
            }

        }

        public void updateOffPrices(string id, string name, string date, string amount)
        {
            try
            {
                Db.Mysql.Open();

                MySqlCommand cmd = Db.Mysql.CreateCommand();

                cmd.CommandText = "UPDATE lignefraishorsforfait SET libelle = '" + name + "' , date= '" + date + "', montant= '"+ amount + "' WHERE id = '"+ id +"'";
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
