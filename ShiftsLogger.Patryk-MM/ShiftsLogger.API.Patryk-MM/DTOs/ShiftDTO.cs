using System.ComponentModel.DataAnnotations;

namespace ShiftsLogger.API.Patryk_MM.DTOs;

public class ShiftDTO {
    public Guid Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }
    public TimeSpan? Duration => End - Start;
}

public class CreateShiftDTO {
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }
}

public class UpdateShiftDTO {
	public DateTime Start { get; set; }
	public DateTime? End { get; set; }
}