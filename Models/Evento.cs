using System.ComponentModel.DataAnnotations;

namespace GestaoEventos.Models
{
    public class Evento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do Evento é obrigatorio")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;


        [Display(Name = "Data do Evento")]
        public DateTime Data { get; set; }

        //Relacionamento com Categoria 
        public int CategoriaId {get; set; }
    public Categoria? Categoria { get; set; }

        //Relacionamento Local

        public int LocalId { get; set; }
        public Local? Local { get; set; }
    }
}
