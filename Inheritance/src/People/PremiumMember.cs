using LibrarySystem;

namespace LibrarySystem.People;

public class PremiumMember : Member
{
    public int MonthlyReadingGoal { get; }
    public int ReadingPoints => Loans.Count(loan => loan.Status is LoanStatus.Returned) * 10;

    public PremiumMember(string personId, string fullName, string phone, int monthlyReadingGoal)
        : base(personId, fullName, phone, maxActiveLoans: 6, paymentDiscount: 0.30m)
    {
        if (monthlyReadingGoal <= 0)
            throw new ArgumentException("Monthly reading goal must be greater than zero.");

        MonthlyReadingGoal = monthlyReadingGoal;
    }
}
