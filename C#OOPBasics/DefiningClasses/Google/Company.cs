public class Company
{
    private string name;
    private string department;
    private decimal salary;

    public Company(string name, string department, decimal salary)
    {
        Name = name;
        Department = department;
        Salary = salary;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Department
    {
        get => department;
        set => department = value;
    }

    public decimal Salary
    {
        get => salary;
        set => salary = value;
    }
}