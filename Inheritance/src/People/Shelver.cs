namespace LibrarySystem.People;

public class Shelver : Staff
{
    public string Section { get; }

    public Shelver(string personId, string fullName, string phone, DateOnly hireDate, decimal salary, string section)
        : base(personId, fullName, phone, hireDate, salary)
    {
        Section = Required(section, "Section");
    }
}
