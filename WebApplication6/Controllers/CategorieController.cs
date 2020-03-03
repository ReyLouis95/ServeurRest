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
        public List<Categorie> GetAllCategories()
        {
            return Categorie.GetAllCategories();
        }
    }
}
