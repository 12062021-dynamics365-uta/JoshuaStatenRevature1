using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Domain
{
    public class Space
    {
        [Key]
        public int CSpaceid { get; set; }
        public int Lineid { get; set; }
        public int Cartid { get; set; }
        public decimal Total { get; set; }
        public int toyhID { get; set; }
        public decimal Price { get; set; }
        public string Script { get; set; }

        public string tname { get; set; }

       
       

        public List<Space> spaces { get; set; }
        

        public Space()
        {
            spaces = new List<Space>();
        }

       
       

    }
}
