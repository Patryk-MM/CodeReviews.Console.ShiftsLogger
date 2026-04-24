using System.ComponentModel.DataAnnotations;

namespace ShiftsLogger.API.Patryk_MM.Models;

public class Shift : BaseEntity {
    [Required]
    public DateTime Start { get; set; }
    [Required]
    public DateTime? End { get; set; }
    public TimeSpan? Duration => End - Start;
}
