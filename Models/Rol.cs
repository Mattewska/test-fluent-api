namespace test_fluent_api.Models;

public class Rol
{
    public int IdRol { get; set; }
    public string NameRol { get; set; }
    public ICollection<Person> Persons { get; set; }
}