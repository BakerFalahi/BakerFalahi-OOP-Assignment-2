namespace LibrarySystem.People;

public class HeadLibrarian : Librarian
{
    public decimal BudgetAllowance { get; }

    public HeadLibrarian(string personId, string fullName, string phone, DateOnly hireDate, decimal salary, decimal budgetAllowance)
        : base(personId, fullName, phone, hireDate, salary)
    {
        if (budgetAllowance <= 0)
            throw new ArgumentException("Budget allowance must be greater than zero.");

        BudgetAllowance = budgetAllowance;
    }
}
