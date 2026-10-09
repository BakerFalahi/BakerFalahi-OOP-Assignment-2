namespace LibrarySystem.People;

public class StudentMember : Member
{
    public string StudentNumber { get; }

    public StudentMember(string personId, string fullName, string phone, string studentNumber)
        : base(personId, fullName, phone, maxActiveLoans: 3, paymentDiscount: 0.15m)
    {
        StudentNumber = Required(studentNumber, "Student number");
    }
}
