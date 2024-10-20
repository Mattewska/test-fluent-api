using Microsoft.EntityFrameworkCore;
using test_fluent_api.Models;

namespace test_fluent_api;

public class LoginContext : DbContext
{
    
    public DbSet<Person> Persons { get; set; }
    public DbSet<Rol> Rols { get; set; }
    
    public LoginContext(DbContextOptions<LoginContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rol>(rol =>
        {
            rol.ToTable("Rol");
            rol.HasKey(r => r.IdRol);
            rol.Property(r => r.NameRol).IsRequired().HasMaxLength(10);
            
        });
        modelBuilder.Entity<Person>(person =>
        {
            person.ToTable("Person");
            person.ToTable(p => p.HasCheckConstraint("EmailPersonCheck", "[Person].[EmailPerson] LIKE '%@%'"));
            person.HasKey(p => p.IdPerson);
            person.Property(p => p.Document).IsRequired().HasMaxLength(10);
            person.HasOne<Rol>(p => p.Rol).WithMany(r => r.Persons).HasForeignKey(p => p.IdRol);
            person.Property(p => p.NamePerson).IsRequired().HasMaxLength(20);
            person.Property(p => p.SecondNamePerson).HasMaxLength(20);
            person.Property(p => p.LastNamePerson).IsRequired().HasMaxLength(20);
            person.Property(p => p.BirthdayPerson).IsRequired().HasColumnType("date");
            person.Property(p => p.EmailPerson).IsRequired().HasMaxLength(256);
        });
    }
}