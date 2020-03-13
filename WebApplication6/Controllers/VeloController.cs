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
        private static VeloDao dao = VeloDao.getInstance();

        // GET api/values
        /// <summary>
        /// Documentation.
        /// </summary>
        /// <returns>retourne documentation.</returns>
        public IEnumerable<Velo> Get()
        {
            return dao.GetAllVelos();
        }

        // GET api/values/5
        public Velo Get(int id)
        {
            return dao.GetVeloById(id);
        }

        [Route("api/Velo/Categorie/{id}")]
        public List<Velo> GetCateg(int id)
        {
            return dao.GetVeloByCateg(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }
        [HttpPatch]
        //PATCH api/values/5
        public void Patch([FromBody]int id, [FromBody]int nbCommande)
        {
            dao.DeleteProduit(id, nbCommande);
        }
    }
}
