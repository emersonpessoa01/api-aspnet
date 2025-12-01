using System.ComponentModel.DataAnnotations;

namespace api.models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int Idade { get; set; }
        public required string Cidade { get; set; }
    }
}