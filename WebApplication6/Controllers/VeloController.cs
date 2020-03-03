using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class VeloController : ApiController
    {
        // GET api/values
        public IEnumerable<Velo> Get()
        {
            return Velo.GetAllVelos();
        }

        // GET api/values/5
        public Velo Get(int id)
        {
            return Velo.GetVeloById(id);
        }

        [Route("api/Velo/Categorie/{id}")]
        public List<Velo> GetCateg(int id)
        {
            return Velo.GetVeloByCateg(id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
