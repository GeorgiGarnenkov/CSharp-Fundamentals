public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string email;
    private int age;

    public Employee(string name, decimal salary, string position, string email, int age)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Email = email;
        this.Age = age;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public decimal Salary
    {
        get => salary;
        set => salary = value;
    }

    public string Position
    {
        get => position;
        set => position = value;
    }

    public string Email
    {
        get => email;
        set => email = value;
    }

    public int Age
    {
        get => age;
        set => age = value;
    }
}

