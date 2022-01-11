using SweetnSaltyModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetnSaltyBusiness
{
    public class Mapper : IMapper
    {
        public Flavor EntityToFlavor(SqlDataReader dr)
        {
            return new Flavor()
            {
                flavorId = dr.GetInt32(0),
                flavor = dr.GetString(1)
            };
        }

        public Person EntityToPerson(SqlDataReader dr)
        {
            return new Person()
            {
                userId = dr.GetInt32(0),
                fname = dr.GetString(1),
                lname = dr.GetString(2),
            };

        }

        public Person EntityToPersonFlavors(SqlDataReader dr)
        {
            Person p = new Person();
            List<Flavor> f = new List<Flavor>();
            do
            {
                Flavor flavor = new Flavor()
                {
                    flavorId = dr.GetInt32(3),
                    flavor = dr.GetString(4),
                };
                f.Add(flavor);
                p = new Person()
                {
                    userId = dr.GetInt32(0),
                    fname = dr.GetString(1),
                    lname = dr.GetString(2),
                    personFlavors = f
                };
            } while (dr.Read());
            return p;
        }
        public List<Flavor> EntityToFlavorList(SqlDataReader dr)
        {
            List<Flavor> flavors = new List<Flavor>();
            while (dr.Read())
            {
                Flavor flavor = new Flavor()
                {
                    flavorId = dr.GetInt32(0),
                    flavor = dr.GetString(1),
                };
                flavors.Add(flavor);
            }
            return flavors;
        }
    }
}