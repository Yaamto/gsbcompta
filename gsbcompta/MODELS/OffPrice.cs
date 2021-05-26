using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsbcompta.MODELS
{
    class OffPrice
    {
        public int ID { get; set; }
        public String UserID { get; set; }
        public String Month { get; set; }
        public String Name { get; set; }
        public String Date { get; set; }
        public float Amount { get; set; }
        public String FileURL { get; set; }
        public OffPrice() { }

        public OffPrice(int id,string userid, string month, string name, string date, float amount, string fileurl)
        {
            this.ID = id;
            this.UserID = userid;
            this.Month = month;
            this.Name = name;
            this.Date = date;
            this.Amount = amount;
            this.FileURL = fileurl;
        }
    }
}
