using gsbcompta.MODELS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsbcompta.CONTROLLERS
{
    class BillController
    {
        List<Bill> Bills;
        Database Db;
        public BillController()
        {
            Db = new Database();
        }

        public List<Bill> getBills()
        {
            try
            {
                Db.Mysql.Open();

                MySqlCommand cmd = Db.Mysql.CreateCommand();

                cmd.CommandText = "SELECT * FROM fichefrais";
                MySqlDataReader reader = cmd.ExecuteReader();
                Bills = new List<Bill>();

                while (reader.Read())
                {
                    Bill b = new Bill(reader["idutilisateur"].ToString(), reader["mois"].ToString(), Int32.Parse(reader["nbJustificatifs"].ToString()), float.Parse(reader["montantValide"].ToString()), reader["dateModif"].ToString(), reader["idEtat"].ToString());
                    Bills.Add(b);

                }
                Db.Mysql.Close();
                return Bills;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Bills;
            }

        }

        public void UpdateState(string userid, string month, string state)
        {
            try
            {
                Db.Mysql.Open();

                MySqlCommand cmd = Db.Mysql.CreateCommand();

                cmd.CommandText = "UPDATE fichefrais SET idEtat = ('" + state + "' ) WHERE idutilisateur ='" + userid + "' AND mois='" + month + "'";
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

