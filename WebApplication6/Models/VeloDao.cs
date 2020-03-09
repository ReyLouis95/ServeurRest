using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class VeloDao
    {

        private static VeloDao instance;

        public static VeloDao getInstance()
        {
            if (instance == null)
            {
                instance = new VeloDao();
            }

            return instance;
        }

        public IEnumerable<Velo> GetAllVelos()
        {
            var reponse = new List<Velo>();
            int id, quantiteStock;
            string categorie, description, nom;
            double prix;
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionBdD"].ConnectionString))
            {
                conn.Open();
                string req = "select id, nom, (select libelle from categories where id = categorie), prix, description, quantite_stock from produits";
                try
                {
                    var commande = new MySqlCommand(req, conn);
                    MySqlDataReader lecteur = commande.ExecuteReader();
                    while (lecteur.Read())
                    {
                        id = lecteur.IsDBNull(0) ? -1 : lecteur.GetInt32(0);
                        nom = lecteur.IsDBNull(1) ? string.Empty : lecteur.GetString(1);
                        categorie = lecteur.IsDBNull(2) ? string.Empty : lecteur.GetString(2);
                        prix = lecteur.IsDBNull(3) ? -1 : lecteur.GetInt32(3);
                        description = lecteur.IsDBNull(4) ? string.Empty : lecteur.GetString(4);
                        quantiteStock = lecteur.IsDBNull(5) ? -1 : lecteur.GetInt32(5);
                        var velo = new Velo(id, nom, categorie, prix, description, quantiteStock);
                        reponse.Add(velo);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return reponse;
            }
        }

        public Velo GetVeloById(int id)
        {
            var velo = new Velo();
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionBdD"].ConnectionString))
            {
                conn.Open();
                string req = "select id, nom, (select libelle from categories where id = categorie), prix, description, quantite_stock from produits where id = " + id;
                try
                {
                    var commande = new MySqlCommand(req, conn);
                    MySqlDataReader lecteur = commande.ExecuteReader();
                    lecteur.Read();
                    velo.Id = id;
                    velo.Nom = lecteur.IsDBNull(1) ? string.Empty : lecteur.GetString(1);
                    velo.Categorie = lecteur.IsDBNull(2) ? string.Empty : lecteur.GetString(2);
                    velo.Prix = lecteur.IsDBNull(3) ? -1 : lecteur.GetInt32(3);
                    velo.Description = lecteur.IsDBNull(4) ? string.Empty : lecteur.GetString(4);
                    velo.QuantiteStock = lecteur.IsDBNull(5) ? -1 : lecteur.GetInt32(5);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return velo;
        }

        public void CreateVelo(Velo velo)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionBdD"].ConnectionString))
            {
                conn.Open();
                string req = "insert into produits (id, nom, categorie, prix, description, quantite_stock) values (" + velo.Id + ", " + velo.Nom + ", " + velo.Categorie +
                    ", " + velo.Prix + ", " + velo.Description + ", " + velo.QuantiteStock + ")";
                try
                {
                    var commande = new MySqlCommand(req, conn);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Velo> GetVeloByCateg(int idCateg)
        {
            var listeVelo = new List<Velo>();
            int id, quantiteStock;
            string categorie, description, nom;
            double prix;
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionBdD"].ConnectionString))
            {
                conn.Open();
                string req = "select id, nom, (select libelle from categories where id = categorie), prix, description, quantite_stock from produits where categorie = " + idCateg;
                try
                {
                    var commande = new MySqlCommand(req, conn);
                    MySqlDataReader lecteur = commande.ExecuteReader();
                    while (lecteur.Read())
                    {
                        id = lecteur.IsDBNull(0) ? -1 : lecteur.GetInt32(0);
                        nom = lecteur.IsDBNull(1) ? string.Empty : lecteur.GetString(1);
                        categorie = lecteur.IsDBNull(2) ? string.Empty : lecteur.GetString(2);
                        prix = lecteur.IsDBNull(3) ? -1 : lecteur.GetInt32(3);
                        description = lecteur.IsDBNull(4) ? string.Empty : lecteur.GetString(4);
                        quantiteStock = lecteur.IsDBNull(5) ? -1 : lecteur.GetInt32(5);
                        listeVelo.Add(new Velo(id, nom, categorie, prix, description, quantiteStock));
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return listeVelo;
        }
    }
}