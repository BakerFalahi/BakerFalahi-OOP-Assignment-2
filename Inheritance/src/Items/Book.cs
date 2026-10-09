namespace LibrarySystem;

public class Book : LibraryItem
{
    public string Author { get; }

    public Book(string itemId, string title, string author)
        : base(itemId, title, baseLateFee: 1.50m, loanPeriodDays: 21, lateFeeMultiplier: 1)
    {
        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Author must not be empty.");

        Author = author.Trim();
    }
}
