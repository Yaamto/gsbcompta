using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsbcompta
{
    class User
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public String Firstname { get; set; }
        public String Login { get; set; }
        public String Address { get; set; }
        public String Zip { get; set; }
        public String City { get; set; }
        private String Password { get; set; }
        public String DateEmbauche { get; set; }


        public User() { }
        public User(string id, string name, string firstname, string login, string address, string zip, string city, string password, string date)
        {
            this.ID = id;
            this.Name = name;
            this.Firstname = firstname;
            this.Login = login;
            this.Address = address;
            this.Zip = zip;
            this.City = city;
            this.Password = password;
            this.DateEmbauche = date;
            
        }

        public Boolean checkPassword (string password)
        {
            if (this.Password == password) return true;
            else return false;
        }

        public override String ToString()
        {
            return Name + " " + Firstname;
        }

    }
}
