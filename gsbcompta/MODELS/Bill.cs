using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsbcompta.MODELS
{
    class Bill
    {
        public String UserID { get; set; }
        public String Month { get; set; }
        public Int32 Proofs { get; set; }
        public float Amount { get; set; }
        public String LastUpdate { get; set; }
        public String State { get; set; }

        public Bill() { }

        public Bill(string userid, string month, Int32 proofs, float amount, string lastUpdate, string state)
        {
            this.UserID = userid;
            this.Month = month;
            this.Proofs = proofs;
            this.Amount = amount;
            this.LastUpdate = lastUpdate;
            this.State = state;
        }
    }
}
