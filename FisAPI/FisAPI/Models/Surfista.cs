using FisAPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace FisAPI.Models;

public class Surfista
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome do surfista é obrigatório.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A nacionalidade é obrigatória.")]
    public string Nacionalidade { get; set; }
    public NivelHabilidade NivelHabilidade { get; set; }
}
