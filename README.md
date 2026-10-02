# OOP Assignment 2

This repository contains the work for the second OOP assignment. The assignment is split into four main parts: SRP refactoring, creational design patterns, an inheritance-based library system, and a LeetCode sliding-window problem.

## Assignment Overview

The project is organized to match the required submission structure from the assignment PDF. Each part has its own folder so the work stays separated and easy to review.

```text
.
+-- README.md
+-- SRP/
|   +-- Responsibilities.md
|   +-- src/
+-- DesignPatterns/
|   +-- linked.md
|   +-- src/
+-- Inheritance/
|   +-- README.md
|   +-- src/
+-- LeetCode/
    +-- 1456_MaxVowelsInSubstring/
        +-- Solution.cs
        +-- leetcode.md
```

## Part 1: Single Responsibility Principle

The `SRP` folder is prepared for the SRP refactoring lab.

`Responsibilities.md` contains sections for the ten required classes:

- `WardBoard`
- `CheckoutBasket`
- `SupportTicket`
- `LoanDesk`
- `CourseEnrollmentDesk`
- `KitchenTicket`
- `SubscriptionBilling`
- `WarehousePickList`
- `GradeBook`
- `AppointmentDesk`

Each section is ready for identifying the responsibilities in the original class and explaining why those responsibilities should be separated.

## Part 2: Creational Design Patterns

The `DesignPatterns` folder is prepared for the Singleton, Prototype, and Builder tasks.

The `linked.md` file is included for the required LinkedIn post links:

- Singleton post
- Prototype post
- Builder post

The `src` folder is reserved for the completed design patterns lab projects.

## Part 3: Inheritance Library System

The `Inheritance/src` folder contains a complete C# console project named `LibrarySystem`.

The project models a small library system using inheritance:

- `Person` is the base type for members and staff.
- `Member` is the base type for `StudentMember` and `PremiumMember`.
- `Staff` is the base type for `Librarian`, `Shelver`, and `HeadLibrarian`.
- `LibraryItem` is the base type for `Book`, `Dvd`, and `Magazine`.
- `Loan` controls borrowing, returning, lost items, due dates, and late fees.

The base classes use protected constructors, so they cannot be created directly from `Program.cs`. The demo also checks the main business rules, including loan limits, withdrawn items, double loans, valid status changes, positive values, non-empty identity fields, and valid return dates.

Add the class diagram later at:

```text
Inheritance/ClassDiagram.png
```

## Part 4: LeetCode

The `LeetCode/1456_MaxVowelsInSubstring` folder contains the solution for:

**1456. Maximum Number of Vowels in a Substring of Given Length**

The solution in `Solution.cs` uses the required sliding-window approach:

1. Count the vowels in the first window of size `k`.
2. Slide the window one character at a time.
3. Remove the character that leaves the window.
4. Add the character that enters the window.
5. Keep track of the maximum vowel count.

After submitting on LeetCode, add the accepted screenshot and submission link:

```text
LeetCode/1456_MaxVowelsInSubstring/accepted_screenshot.png
LeetCode/1456_MaxVowelsInSubstring/leetcode.md
```

## How to Run

Run the inheritance project from the repository root:

```bash
dotnet run --project Inheritance/src/LibrarySystem.csproj
```

Build the full solution:

```bash
dotnet build OOP_Assignment_2.sln
```

## Notes

- Build outputs such as `bin/` and `obj/` are ignored by `.gitignore`.
- Rider and Visual Studio local files are ignored.
- Screenshot files are not included yet because they must come from the final submitted work.
