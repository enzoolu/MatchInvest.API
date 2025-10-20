using System.ComponentModel.DataAnnotations;

namespace MatchInvest.API.Models
{
    public class Assessor
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Certificacoes { get; set; }

        public string Especializacao { get; set; }

        public int AnosDeExperiencia { get; set; }
    }
}