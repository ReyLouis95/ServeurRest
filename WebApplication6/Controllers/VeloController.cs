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
        /// Renvoi la liste de tous les produits
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Velo> Get()
        {
            return dao.GetAllVelos();
        }
        /// <summary>
        /// renvoi un produit
        /// </summary>
        /// <param name="id">Id du produit demandé</param>
        /// <returns></returns>
        // GET api/values/5
        public Velo Get(int id)
        {
            return dao.GetVeloById(id);
        }

        /// <summary>
        /// renvoi une liste de produit qui ont la même catégorie
        /// </summary>
        /// <param name="id">Id de la catégorie demandée</param>
        /// <returns></returns>
        [Route("api/Velo/Categorie/{id}")]
        public List<Velo> GetCateg(int id)
        {
            return dao.GetVeloByCateg(id);
        }

        /// <summary>
        /// soustrait un nombre a la quantité stockée d'un produit
        /// </summary>
        /// <param name="id">id du produit demandé</param>
        /// <param name="nbCommande">nombre à soustraire à la quantité stockée</param>
        [HttpPatch]
        //PATCH api/values/5
        public void Patch(int id, [FromBody]int nbCommande)
        {
            dao.DeleteProduit(id, nbCommande);
        }


    }
}
