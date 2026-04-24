using Microsoft.EntityFrameworkCore;
using ShiftsLogger.API.Patryk_MM.Models;

namespace ShiftsLogger.API.Patryk_MM;

public class AppDbContext : DbContext {

    public DbSet<Shift> Shifts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CSharpAcademy_ShiftsLogger;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Shift>()
            .HasData(
            new Shift {
                Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                Start = new DateTime(2026, 4, 24, 8, 0, 0),
                End = new DateTime(2026, 4, 24, 16, 0, 0)
            });
    }
}
