namespace test_fluent_api.Models;

public class Person
{
    public uint IdPerson { get; set; }
    public int IdRol { get; set; }
    public uint Document { get; set; }
    public string NamePerson { get; set; }
    public string LastNamePerson { get; set; }
    public DateTime BirthdayPerson { get; set; }
    public string EmailPerson { get; set; }
    public virtual Rol Rol { get; set; }
}
