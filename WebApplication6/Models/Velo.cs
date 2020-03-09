using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebApplication6.Models
{
    public class Velo
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Categorie { get; set; }

        public double Prix { get; set; }

        public string Description { get; set; }

        public int QuantiteStock { get; set; }

        public Velo()
        {

        }

        public Velo(int id, string nom, string categorie, double prix, string description, int quantiteStock)
        {
            Id = id;
            Nom = nom;
            Categorie = categorie;
            Prix = prix;
            Description = description;
            QuantiteStock = quantiteStock;
        }
    }
}