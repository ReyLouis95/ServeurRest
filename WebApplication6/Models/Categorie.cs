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
        /// <summary>
        /// renvoi la liste de toutes les categories de la boutique
        /// </summary>
        /// <returns>liste de Categorie</returns>
        public static List<Categorie> GetAllCategories()
        {
            var listeCategories = new List<Categorie>();
            int id;
            string libelle;
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionBdD"].ConnectionString))
            {
                conn.Open();
                string req = "select id, libelle from categories";
                try
                {
                    var commande = new MySqlCommand(req, conn);
                    var lecteur = commande.ExecuteReader();
                    while (lecteur.Read())
                    {
                        id = lecteur.IsDBNull(0) ? -1 : lecteur.GetInt32(0);
                        libelle = lecteur.IsDBNull(1) ? string.Empty : lecteur.GetString(1);
                        var categorie = new Categorie(id, libelle);
                        listeCategories.Add(categorie);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return listeCategories;
        }
    }
}