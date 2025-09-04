using FisAPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace FisAPI.Models;

public class Onda
{
    public int Id { get; set; }
    [Range(0.5, 15.0)]
    public double Tamanho { get; set; }
    [Range(1, 10)]
    public int Forca { get; set; }
    public Direcao Direcao { get; set; }
}
