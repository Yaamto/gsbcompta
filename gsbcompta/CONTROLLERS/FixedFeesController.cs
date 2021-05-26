using gsbcompta.MODELS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsbcompta.CONTROLLERS
{
    class FixedFeesController
    {
        List<FixedFees> FixedFees;
        Database Db;

        public FixedFeesController()
        {
            Db = new Database();
        }

        public List<FixedFees> getFixedFees(string userid, string month)
        {
            try
            {
                Db.Mysql.Open();

                MySqlCommand cmd = Db.Mysql.CreateCommand();

                cmd.CommandText = "SELECT * FROM lignefraisforfait WHERE idutilisateur ='" + userid + "' AND mois='" +month +"'";
                MySqlDataReader reader = cmd.ExecuteReader();
                FixedFees = new List<FixedFees>();

                while (reader.Read())
                {
                    FixedFees ff = new FixedFees(reader["idutilisateur"].ToString(), reader["mois"].ToString(), reader["idFraisForfait"].ToString(), Int32.Parse(reader["quantite"].ToString()));
                    FixedFees.Add(ff);
                }
                Db.Mysql.Close();
                return FixedFees;

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e );
                return FixedFees;
            }

        }

        public void updateFixedFees(string userid, string month, string quantity, string idFixedFees)
        {
            try
            {
                Db.Mysql.Open();

                MySqlCommand cmd = Db.Mysql.CreateCommand();

                cmd.CommandText = "UPDATE lignefraisforfait SET quantite = " + quantity + " WHERE idutilisateur ='" + userid + "' AND mois='" + month + "' AND idFraisForfait = '" + idFixedFees + "'";
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