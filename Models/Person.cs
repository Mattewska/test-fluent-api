namespace test_fluent_api.Models;

public class Person
{
    public uint IdPerson { get; set; }
    public int IdRol { get; set; }
    public uint IdCredencial { get; set; }
    public uint Document { get; set; }
    public string NamePerson { get; set; }
    public string SecondNamePerson { get; set; }
    public string LastNamePerson { get; set; }
    public DateTime BirthdayPerson { get; set; }
    public virtual Rol Rols { get; set; }
    public virtual Credential Credentials { get; set; }
}
