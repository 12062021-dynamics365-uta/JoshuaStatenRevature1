using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Store
    {
        public int Cityid { get; set; }
        public string CityName { get; set; }
        public List<Store> CityList { get; set; }
        public List<Toys> toys { get; set; }

        public Store()
        {
            toys = new List<Toys>();
            CityList = new List<Store>();
        }

    }
}
