using System;
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
using Api_Practise.Models.DTO;

namespace Api_Practise.Controllers
{
    public class FootballersController : ApiController
    {
        private Api_PractiseContext db = new Api_PractiseContext();

        FootballersRepo repo = new FootballersRepo();
        DTOFactory _factory = new DTOFactory();

        // GET: api/Footballers

        public IEnumerable<FootballerDTO> GetFootballers()
        {
            var ListofFootballers = new List<FootballerDTO>();
            var List = repo.Get();

            foreach(var item in List)
            {
                // convert footballer to footballerDTO
               ListofFootballers.Add( _factory.CreateFootballerDTO(item));
            }
            return ListofFootballers;
        }

        // GET: api/Footballers/5
        // [ResponseType(typeof(Footballers))]
        public HttpResponseMessage GetFootballers(int id)
        {
            var Footballer = repo.GetFootballers(id);
            if (Footballer != null) {
                var _footballerDTO = _factory.CreateFootballerDTO(Footballer);

                return Request.CreateResponse(HttpStatusCode.OK, _footballerDTO);
                
            }

            HttpError myCustomError = new HttpError("The file has no content or rows to process.") { { "CustomErrorCode", 42 } };
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, myCustomError);


        }

        // PUT: api/Footballers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFootballers(int id, Footballers footballers)
        {
            if (ModelState.IsValid && (id == footballers.FootballersID))
            {
                
                    repo.Put(footballers);
                var returnItems = _factory.CreateFootballerDTO(footballers);
                    return CreatedAtRoute("DefaultApi", new { id = footballers.FootballersID }, returnItems);

                }
                
            
            else
            {
                return BadRequest();
            }
        }

            
           

        // POST: api/Footballers
        [ResponseType(typeof(Footballers))]
        public IHttpActionResult PostFootballers(Footballers footballers)
        {
            if (ModelState.IsValid)
            {
                repo.PostFootballers(footballers);
                 
            }

            var returnables = _factory.CreateFootballerDTO(footballers);

            return CreatedAtRoute("DefaultApi", new { id = footballers.FootballersID }, returnables);
        }

        // DELETE: api/Footballers/5
        [ResponseType(typeof(Footballers))]
        public IHttpActionResult DeleteFootballers(int id)
        {
            //Footballers footballers;
            bool value = repo.Delete(id);
            if (value) {
                return Ok();
            }
            else
            {
                return NotFound();
            }
           




        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FootballersExists(int id)
        {
            return db.Footballers.Count(e => e.FootballersID == id) > 0;
        }
    }
}