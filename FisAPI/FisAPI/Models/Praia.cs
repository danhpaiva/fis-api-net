using FisAPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace FisAPI.Models;

public class Praia
{
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public NivelPoluicao NivelPoluicao { get; set; }
    public Classificacao Classificacao { get; set; }
}
