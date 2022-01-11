using SweetnSaltyDbAccess;
using SweetnSaltyModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SweetnSaltyBusiness
{
    public class SweetnSaltyBusinessClass : ISweetnSaltyBusinessClass
    {
        private readonly ISweetnSaltyDbAccessClass _dbAccess;
        private readonly IMapper _mapper;

        public SweetnSaltyBusinessClass(ISweetnSaltyDbAccessClass Dbaccess, IMapper mapper)//you need a reference to the DbAccess Layer 
        {
            _mapper = mapper;
            _dbAccess = Dbaccess;
        }


        public async Task<Flavor> PostFlavor(string flavor)
        {
            SqlDataReader dr = await _dbAccess.PostFlavor(flavor);
            if (dr.Read())
            {
                Flavor f = _mapper.EntityToFlavor(dr);
                return f;
            }
            else
            {
                return null;
            }
        }


        public async Task<Person> PostPerson(string fname, string lname)
        {
            SqlDataReader dr = await _dbAccess.PostPerson(fname, lname);
            if (dr.Read())
            {
                Person p = _mapper.EntityToPerson(dr);
                return p;
            }
            else
            {
                return null;
            }
        }

        public async Task<Person> GetPerson(string fname, string lname)
        {
            SqlDataReader dr = await this._dbAccess.GetPerson(fname, lname);
            {
                if (dr.Read())
                {
                    Person p = _mapper.EntityToPerson(dr);
                    return p;
                }
                else
                {
                    return null;
                }
            }
        }


        public async Task<Person> GetPersonAndFlavors(int id)
        {
            SqlDataReader dr = await _dbAccess.GetPersonAndFlavors(id);
            if (dr.Read())
            {
                Person p = _mapper.EntityToPerson(dr);
                return p;
            }
            else
            {
                return null;
            }
        }


        public async Task<List<Flavor>> GetAllFlavors()
        {
            SqlDataReader dr = await _dbAccess.GetAllFlavors();
            List<Flavor> f = _mapper.EntityToFlavorList(dr);
            return f;
        }




    }//EoC
}//EoN