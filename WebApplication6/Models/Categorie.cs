using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        public string Libelle { get; set; }

        public Categorie()
        {

        }

        public Categorie(int id, string libelle)
        {
            Id = id;
            Libelle = libelle;
        }
    }
}