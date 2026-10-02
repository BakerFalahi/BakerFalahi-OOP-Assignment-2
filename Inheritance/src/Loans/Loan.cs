using LibrarySystem.People;

namespace LibrarySystem;

public class Loan
{
    public Member Borrower { get; }
    public LibraryItem Item { get; }
    public DateOnly BorrowDate { get; }
    public DateOnly? ReturnDate { get; private set; }
    public LoanStatus Status { get; private set; } = LoanStatus.Borrowed;
    public DateOnly DueDate => BorrowDate.AddDays(Item.LoanPeriodDays);
    public decimal LateFee => ReturnDate is null || ReturnDate <= DueDate
        ? 0
        : (ReturnDate.Value.DayNumber - DueDate.DayNumber) * Item.DailyLateFee();

    internal Loan(Member borrower, LibraryItem item, DateOnly borrowDate)
    {
        Borrower = borrower;
        Item = item;
        BorrowDate = borrowDate;
    }

    public void Return(DateOnly returnDate)
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException("Only a borrowed loan can be returned.");

        if (returnDate < BorrowDate)
            throw new ArgumentException("Return date cannot be earlier than borrow date.");

        ReturnDate = returnDate;
        Status = LoanStatus.Returned;
        Item.MarkReturned();
    }

    public void MarkLost()
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException("Only a borrowed loan can be marked as lost.");

        Status = LoanStatus.Lost;
        Item.MarkReturned();
    }
}
