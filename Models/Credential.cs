namespace test_fluent_api.Models;

public class Credential
{
    public uint IdCredentials { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<Person> Credentials { get; set; }
}