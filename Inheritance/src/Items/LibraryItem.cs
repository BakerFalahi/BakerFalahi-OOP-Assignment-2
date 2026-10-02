using LibrarySystem.People;

namespace LibrarySystem;

public class LibraryItem
{
    public string ItemId { get; }
    public string Title { get; }
    public decimal BaseLateFee { get; private set; }
    public bool IsWithdrawn { get; private set; }
    public bool IsOnLoan { get; private set; }
    public int LoanPeriodDays { get; }
    public decimal LateFeeMultiplier { get; }

    protected LibraryItem(string itemId, string title, decimal baseLateFee, int loanPeriodDays, decimal lateFeeMultiplier)
    {
        if (baseLateFee <= 0)
            throw new ArgumentException("Base late fee must be greater than zero.");

        if (loanPeriodDays <= 0)
            throw new ArgumentException("Loan period must be greater than zero.");

        if (lateFeeMultiplier <= 0)
            throw new ArgumentException("Late fee multiplier must be greater than zero.");

        ItemId = Required(itemId, "Item ID");
        Title = Required(title, "Title");
        BaseLateFee = baseLateFee;
        LoanPeriodDays = loanPeriodDays;
        LateFeeMultiplier = lateFeeMultiplier;
    }

    public void ChangeLateFee(decimal newLateFee)
    {
        if (newLateFee <= 0)
            throw new ArgumentException("New late fee must be greater than zero.");

        BaseLateFee = newLateFee;
    }

    public void Withdraw()
    {
        if (IsOnLoan)
            throw new InvalidOperationException("An item on loan cannot be withdrawn.");

        IsWithdrawn = true;
    }

    public void Restore()
    {
        IsWithdrawn = false;
    }

    public decimal DailyLateFee()
    {
        return BaseLateFee * LateFeeMultiplier;
    }

    internal Loan BorrowTo(Member member, DateOnly borrowDate)
    {
        if (IsWithdrawn)
            throw new InvalidOperationException($"{Title} is withdrawn and cannot be borrowed.");

        if (IsOnLoan)
            throw new InvalidOperationException($"{Title} is already on loan.");

        IsOnLoan = true;
        return new Loan(member, this, borrowDate);
    }

    internal void MarkReturned()
    {
        IsOnLoan = false;
    }

    private static string Required(string value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{fieldName} must not be empty.");

        return value.Trim();
    }
}
