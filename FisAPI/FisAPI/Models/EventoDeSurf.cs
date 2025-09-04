using System.ComponentModel.DataAnnotations;

namespace FisAPI.Models;

public class EventoDeSurf
{
    public int Id { get; set; }
    [Required]
    public string NomeDoEvento { get; set; }
    [Required]
    public DateTime Data { get; set; }
    public int PraiaId { get; set; }
    public List<int> IdsSurfistas { get; set; } = new List<int>();
}
