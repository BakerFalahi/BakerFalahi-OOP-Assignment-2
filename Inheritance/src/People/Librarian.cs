namespace LibrarySystem.People;

public class Librarian : Staff
{
    public Librarian(string personId, string fullName, string phone, DateOnly hireDate, decimal salary)
        : base(personId, fullName, phone, hireDate, salary)
    {
    }
}
