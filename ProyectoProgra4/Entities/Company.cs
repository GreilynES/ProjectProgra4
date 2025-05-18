using Proyecto_Final_PrograIV.Entities;
using System.Text.Json.Serialization;

namespace ProyectoProgra4.Entities
{
    public class Company
    {
       
        public int IdCompany { get; set; }
        public string Name { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }

        public List<Offer>? Offers { get; set; } //una empresa tiene una lista de ofertas
    }
}
