using System.ComponentModel.DataAnnotations;

namespace ShiftsLogger.API.Patryk_MM.Models;

public abstract class BaseEntity {
    [Key]
    public Guid Id { get; set; }
}
