using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Api_Practise.Models;
using Api_Practise.Service;
using System.Web.Http.ModelBinding;

namespace Api_Practise.Service
{
    public class FootballersRepo : FootballersInterface
    {
        private Api_PractiseContext db = new Api_PractiseContext();

         //Get
        public IEnumerable<Footballers> Get()
        {
            var FootballersList = db.Footballers;
            return FootballersList;
        }
        //Get (ID)
        [ResponseType(typeof(Footballers))]
        public Footballers GetFootballers(int id)
        {
            

            Footballers footballer = db.Footballers.Find(id);

            if (footballer != null)
            {
                return footballer;
            }

            return null;
        }


        // POST: api/Footballers
        [ResponseType(typeof(Footballers))]
        public void PostFootballers(Footballers footballers)
        {
            db.Footballers.Add(footballers);
            db.SaveChanges();

        }


        //Put
        public void Put(Footballers footballers)
        {
            db.Entry(footballers).State = EntityState.Modified;
            db.SaveChanges();
            
            
        }

        //Delete
        public bool Delete(int id)
        {
            Footballers footballer = db.Footballers.Find(id);
            if (footballer != null) { 
            db.Footballers.Remove(footballer);
            db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        
    }
}