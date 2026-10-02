namespace LibrarySystem;

public class Dvd : LibraryItem
{
    public int RuntimeMinutes { get; }

    public Dvd(string itemId, string title, int runtimeMinutes)
        : base(itemId, title, baseLateFee: 2.00m, loanPeriodDays: 7, lateFeeMultiplier: 1.5m)
    {
        if (runtimeMinutes <= 0)
            throw new ArgumentException("Runtime must be greater than zero.");

        RuntimeMinutes = runtimeMinutes;
    }
}
