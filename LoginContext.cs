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
        
        List<Rol> RolsList = new List<Rol>();
        List<Credential> CredentialsList = new List<Credential>();
        
        RolsList.Add(new Rol{IdRol = 1, NameRol = "Admin"});
        CredentialsList.Add(new Credential{IdCredentials = 1, Email = "adminTest@LoginTest.com", Password = "123456"});
        
        modelBuilder.Entity<Rol>(rol =>
        {
            rol.ToTable("Rol");
            rol.HasKey(r => r.IdRol);
            rol.Property(r => r.IdRol).ValueGeneratedOnAdd();
            rol.Property(r => r.NameRol).IsRequired().HasMaxLength(10);
            rol.HasData(RolsList);
        });
        modelBuilder.Entity<Credential>(credential =>
        {
            credential.ToTable("Credential");
            credential.ToTable(c => c.HasCheckConstraint("CK_Email_IsValid", "Email LIKE '%@%'"));
            credential.HasKey(c => c.IdCredentials);
            credential.Property(c => c.Email).IsRequired().HasMaxLength(250);
            credential.Property(c => c.Password).IsRequired().HasMaxLength(25);
            credential.HasData(CredentialsList);
        });
        modelBuilder.Entity<Person>(person =>
        {
            person.ToTable("Person");
            person.HasKey(p => p.IdPerson);
            person.Property(p => p.Document).IsRequired().HasMaxLength(10);
            person.HasOne<Rol>(p => p.Rols).WithMany(r => r.Persons).HasForeignKey(p => p.IdRol);
            person.Property(p => p.NamePerson).IsRequired().HasMaxLength(20);
            person.Property(p => p.SecondNamePerson).IsRequired(false).HasMaxLength(20);
            person.Property(p => p.LastNamePerson).IsRequired().HasMaxLength(20);
            person.Property(p => p.BirthdayPerson).IsRequired().HasColumnType("date");
            person.HasOne(p => p.Credentials).WithMany(c => c.Credentials).HasForeignKey(p => p.IdCredencial);
        });
    }
}