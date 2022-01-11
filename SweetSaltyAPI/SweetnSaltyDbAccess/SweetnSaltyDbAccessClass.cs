using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SweetnSaltyDbAccess
{
    public class SweetnSaltyDbAccessClass : ISweetnSaltyDbAccessClass
    {
        private readonly string str = "Data source = LAPTOP-NI3BRHG2\\SQLEXPRESS; initial Catalog = SweetnSalty; integrated security = true";
        private readonly SqlConnection _con;

        
        public SweetnSaltyDbAccessClass()
        {
            this._con = new SqlConnection(this.str);
            _con.Open();
        }


        public async Task<SqlDataReader> PostFlavor(string flavor)
        {
            string sqlQuery = $"INSERT INTO Flavors (FlavorName) VALUES ('{flavor}');";
            

            using (SqlCommand cmd = new SqlCommand(sqlQuery, this._con))
            {
                cmd.Parameters.AddWithValue("@flavor", flavor);
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    string retrieveFlavor = "SELECT TOP 1 * FROM Flavors ORDER BY FlavorID DESC;";
                    using (SqlCommand cmd2 = new SqlCommand(retrieveFlavor, _con))
                    {
                        SqlDataReader dr = await cmd2.ExecuteReaderAsync();
                        return dr;
                    }
                }
                catch (DbException ex)
                {
                    Console.WriteLine("I AM ERROR");
                    return null;
                }
            }
        }
        public async Task<SqlDataReader> PostPerson(string fname, string lname)
        {
            string sqlQuery = "INSERT INTO People VALUES (@fname, @lname);";

            using (SqlCommand cmd = new SqlCommand(sqlQuery, this._con))
            {
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    string retrievePerson = "SELECT TOP 1 * FROM People ORDER BY PersonID DESC;";
                    using (SqlCommand cmd2 = new SqlCommand(retrievePerson, _con))
                    {
                        SqlDataReader dr = await cmd2.ExecuteReaderAsync();
                        return dr;
                    }
                }
                catch (DbException ex)
                {
                    Console.WriteLine("I AM ERROR");
                    return null;
                }
            }
        }

        public async Task<SqlDataReader> GetPerson(string fname, string lname)
        {
            string query = "SELECT * FROM People WHERE FirstName = @fname AND LastName = @lname;";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, this._con))
                {
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@lname", lname);
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    return dr;
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine("I AM ERROR");
                return null;
            }
        }


        public async Task<SqlDataReader> GetPersonAndFlavors(int id)
        {
            string query = "SELECT People.PersonID, People.FirstName, People.LastName, Flavors.FlavorID, Flavors.FlavorName FROM People " +
                           "JOIN FlavorJunction ON People.PersonID = FlavorJunction.PersonID " +
                           "JOIN Flavors ON Flavors.FlavorID = FlavorJunction.FlavorID " +
                           "WHERE People.PersonID = @id;";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, _con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    return dr;
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine("I AM ERROR");
                return null;
            }
        }


        public async Task<SqlDataReader> GetAllFlavors()
        {
            string query = "SELECT * From Flavors";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, _con))
                {
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    return (dr);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine("I AM ERROR");
                return null;
            }
        }

    }
}
