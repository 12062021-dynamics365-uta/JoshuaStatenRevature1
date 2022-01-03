using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cart
    {
        public int Cartid { get; set; }
        public int Cityid { get; set; }
        public int Customerid { get; set; }
        public decimal Total { get; set; }
        public decimal CartTotal { get; set; }

        public Cart()
        {
            
        }
    }
}
