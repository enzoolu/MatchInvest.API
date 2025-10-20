using System.ComponentModel.DataAnnotations;

namespace MatchInvest.API.Models
{
    public class Investor
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public decimal CapitalDisponivel { get; set; }

        public string ApetiteRisco { get; set; }

        public string Objetivos { get; set; }
    }
}