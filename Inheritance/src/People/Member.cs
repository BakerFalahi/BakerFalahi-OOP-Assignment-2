using LibrarySystem;

namespace LibrarySystem.People;

public class Member : Person
{
    private readonly List<Loan> _loans = [];

    public int MaxActiveLoans { get; }
    public decimal PaymentDiscount { get; }
    public IReadOnlyCollection<Loan> Loans => _loans.AsReadOnly();

    protected Member(string personId, string fullName, string phone, int maxActiveLoans, decimal paymentDiscount)
        : base(personId, fullName, phone)
    {
        if (maxActiveLoans <= 0)
            throw new ArgumentException("Maximum active loans must be greater than zero.");

        if (paymentDiscount < 0 || paymentDiscount > 1)
            throw new ArgumentException("Payment discount must be between 0 and 1.");

        MaxActiveLoans = maxActiveLoans;
        PaymentDiscount = paymentDiscount;
    }

    public decimal Pay(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Payment amount must be greater than zero.");

        return amount * (1 - PaymentDiscount);
    }

    public Loan Borrow(LibraryItem item, DateOnly borrowDate)
    {
        if (_loans.Count(loan => loan.Status == LoanStatus.Borrowed) >= MaxActiveLoans)
            throw new InvalidOperationException($"{FullName} reached the active loan limit.");

        Loan loan = item.BorrowTo(this, borrowDate);
        _loans.Add(loan);
        return loan;
    }
}
