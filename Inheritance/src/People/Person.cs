namespace LibrarySystem.People;

public class Person
{
    public string PersonId { get; }
    public string FullName { get; }
    public string Phone { get; }

    protected Person(string personId, string fullName, string phone)
    {
        PersonId = Required(personId, "Person ID");
        FullName = Required(fullName, "Full name");
        Phone = Required(phone, "Phone");
    }

    protected static string Required(string value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{fieldName} must not be empty.");

        return value.Trim();
    }
}
