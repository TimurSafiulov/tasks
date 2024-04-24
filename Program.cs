using System;

public class Employee
{
    protected string name;
    private DateTime hiringDate;

    public Employee(string name, DateTime hiringDate)
    {
        this.name = name;
        this.hiringDate = hiringDate;
    }

    public int Experience()
    {
        return DateTime.Now.Year - hiringDate.Year;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"{name} має {Experience()} рокiв досвiду роботи");
    }
}

public class Developer : Employee
{
    private string programLanguage;

    public Developer(string name, DateTime hiringDate, string programLanguage)
        : base(name, hiringDate)
    {
        this.programLanguage = programLanguage;
    }

    public new void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"{name} — програмiст {programLanguage}");
    }
}

public class Tester : Employee
{
    private bool isAutomation;

    public Tester(string name, DateTime hiringDate, bool isAutomation)
        : base(name, hiringDate)
    {
        this.isAutomation = isAutomation;
    }

    public new void ShowInfo()
    {
        base.ShowInfo();
        if (isAutomation)
            Console.WriteLine($"{name} є автотестором i має стаж роботи {Experience()} рокiв");
        else
            Console.WriteLine($"{name} є ручним тестувальником i має досвід роботи {Experience()} рокiв");
    }
}

class Program
{
    static void Main(string[] args)
    {
        DateTime hiringDate = new DateTime(2010, 1, 1);

        Employee employee = new Employee("Василь", hiringDate);
        Developer developer = new Developer("Петро", hiringDate, "C#");
        Tester tester = new Tester("Анна", hiringDate, true);

        employee.ShowInfo();
        developer.ShowInfo();
        tester.ShowInfo();
    }
}
