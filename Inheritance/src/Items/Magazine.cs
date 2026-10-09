namespace LibrarySystem;

public class Magazine : LibraryItem
{
    public int IssueNumber { get; }

    public Magazine(string itemId, string title, int issueNumber)
        : base(itemId, title, baseLateFee: 1.00m, loanPeriodDays: 14, lateFeeMultiplier: 0.75m)
    {
        if (issueNumber <= 0)
            throw new ArgumentException("Issue number must be greater than zero.");

        IssueNumber = issueNumber;
    }
}
