using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsbcompta
{
    class Bdd
    {
        private MySqlConnection mysql;

        public Bdd()
        {
            this.connect();
        }

        private void connect()
        {
            string connexionString = "SERVER=127.0.0.1; DATABASE=gsb; UID=root; PASSWORD=root";
            this.mysql = new MySqlConnection(connexionString);
        }

        public void getUsers()
        {
            try
            {
                this.mysql.Open();
                MySqlCommand cmd = this.mysql.CreateCommand();
                cmd.CommandText = "SELECT * FROM utilisateur";
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("Nom:" + reader["nom"].ToString());
                }
                this.mysql.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

      
        public BindingSource getBindingSource()
        {
            this.mysql.Open();
            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
            string getAll = "SELECT * FROM utilisateur";
            myAdapter.SelectCommand = new MySqlCommand(getAll, this.mysql);
            DataTable table = new DataTable();
            myAdapter.Fill(table);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = table;
            this.mysql.Close();

            return bindingSource;
        }
        public BindingSource getBindingSource1()
        {
            this.mysql.Open();
            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
            string getAll = "SELECT * FROM utilisateur where id='a131'";
            myAdapter.SelectCommand = new MySqlCommand(getAll, this.mysql);
            DataTable table = new DataTable();
            myAdapter.Fill(table);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = table;
            this.mysql.Close();

            return bindingSource;
        }
    }
}
