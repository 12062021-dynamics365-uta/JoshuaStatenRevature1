using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain;

namespace Storage
{
    public interface IMapper
    {
        public int CustomerMap(SqlDataReader dr);
        List<Toys> CartSpaceMap(SqlDataReader dr);
        List<Cart> CartMap(SqlDataReader dr);
        List<Toys> ToyMap(SqlDataReader dr);

    }
}
