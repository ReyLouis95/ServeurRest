using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class CategorieController : ApiController
    {
        private CategorieDao dao = CategorieDao.GetInstance();
        /// <summary>
        /// renvoi la liste de toute les categories
        /// </summary>
        /// <returns></returns>
        public List<Categorie> GetAllCategories()
        {
            return dao.GetAllCategories();
        }
    }
}
