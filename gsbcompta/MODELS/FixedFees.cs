using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsbcompta.MODELS
{
    class FixedFees
    {
        public String UserID { get; set; }
        public String Month { get; set; }
        public String FixedFeesID { get; set; }
        public int Quantity { get; set; }

        public FixedFees() { }

        public FixedFees(string userid, string month, string fixedfeesid, int quantity)
        {
            this.UserID = userid;
            this.Month = month;
            this.FixedFeesID = fixedfeesid;
            this.Quantity = quantity;
        }
    }
}
