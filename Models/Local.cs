using System.ComponentModel.DataAnnotations;

namespace GestaoEventos.Models
{
    public class Local
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="O nomo do Local é obrigatorio")]
            [StringLength(100)]
            public string Nome { get; set; }= string.Empty;
        [Display(Name="Capacidade Máxima")]
                public int Capaciade { get; set; }

    }
}
