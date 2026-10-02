namespace LibrarySystem.People;

public class Staff : Person
{
    public DateOnly HireDate { get; }
    public decimal Salary { get; private set; }

    protected Staff(string personId, string fullName, string phone, DateOnly hireDate, decimal salary)
        : base(personId, fullName, phone)
    {
        if (salary <= 0)
            throw new ArgumentException("Salary must be greater than zero.");

        HireDate = hireDate;
        Salary = salary;
    }

    public void GiveRaise(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Raise amount must be greater than zero.");

        Salary += amount;
    }
}
