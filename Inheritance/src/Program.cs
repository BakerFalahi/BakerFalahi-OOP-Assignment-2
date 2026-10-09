using LibrarySystem;
using LibrarySystem.People;

static void Show(string title, Action action)
{
    Console.WriteLine($"\n{title}");

    try
    {
        action();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

var student = new StudentMember("M-100", "Nour Hassan", "01000000000", "S-44");
var premium = new PremiumMember("M-200", "Omar Ali", "01111111111", 4);
var librarian = new Librarian("ST-10", "Mona Adel", "01222222222", new DateOnly(2021, 3, 1), 9000);
var shelver = new Shelver("ST-11", "Karim Samir", "01333333333", new DateOnly(2023, 1, 15), 5000, "History");
var headLibrarian = new HeadLibrarian("ST-12", "Sara Amin", "01444444444", new DateOnly(2018, 7, 20), 14000, 50000);

var book = new Book("B-1", "Clean Code", "Robert C. Martin");
var dvd = new Dvd("D-1", "Library Safety Training", 95);
var magazine = new Magazine("MG-1", "Science Monthly", 42);

Console.WriteLine("Library system demo");
Console.WriteLine($"{student.FullName} can borrow {student.MaxActiveLoans} items.");
Console.WriteLine($"{premium.FullName} pays {premium.Pay(100):0.00} after discount.");
Console.WriteLine($"{librarian.FullName}, {shelver.FullName}, and {headLibrarian.FullName} are staff members.");
Console.WriteLine($"{book.Title}, {dvd.Title}, and {magazine.Title} use their own loan periods and late fees.");

Show("Borrow and return", () =>
{
    Loan loan = student.Borrow(book, new DateOnly(2026, 10, 1));
    Console.WriteLine($"Due date: {loan.DueDate}");
    loan.Return(new DateOnly(2026, 10, 25));
    Console.WriteLine($"Status: {loan.Status}, late fee: {loan.LateFee:0.00}");
});

Show("No double loan", () =>
{
    premium.Borrow(dvd, new DateOnly(2026, 10, 1));
    student.Borrow(dvd, new DateOnly(2026, 10, 2));
});

Show("No withdrawn items", () =>
{
    magazine.Withdraw();
    student.Borrow(magazine, new DateOnly(2026, 10, 1));
});

Show("Loan limit", () =>
{
    student.Borrow(new Book("B-2", "Refactoring", "Martin Fowler"), new DateOnly(2026, 10, 1));
    student.Borrow(new Book("B-3", "The Pragmatic Programmer", "David Thomas"), new DateOnly(2026, 10, 1));
    student.Borrow(new Book("B-4", "C# in Depth", "Jon Skeet"), new DateOnly(2026, 10, 1));
    student.Borrow(new Book("B-7", "Head First Design Patterns", "Eric Freeman"), new DateOnly(2026, 10, 1));
});

Show("Invalid status change", () =>
{
    Loan loan = premium.Borrow(new Book("B-5", "Domain-Driven Design", "Eric Evans"), new DateOnly(2026, 10, 1));
    loan.Return(new DateOnly(2026, 10, 5));
    loan.MarkLost();
});

Show("Positive values", () => librarian.GiveRaise(0));
Show("Non-empty identity fields", () => new StudentMember("", "No ID", "01555555555", "S-77"));
Show("Valid return date", () =>
{
    Loan loan = premium.Borrow(new Book("B-6", "Patterns of Enterprise Application Architecture", "Martin Fowler"), new DateOnly(2026, 10, 10));
    loan.Return(new DateOnly(2026, 10, 9));
});

Console.WriteLine("\nPlain Person, Member, Staff, and LibraryItem cannot be created from Program.cs because their constructors are protected.");
