interface IEmployee
{
    decimal GetSalary();
}

class Employee : IEmployee
{
    public virtual decimal GetSalary()
    {
        return 5000;
    }
}

interface IIntern
{
    void GetExperience();
}

class Intern : IIntern
{
    public void GetExperience()
    {
        Console.WriteLine("Получаю опыт в качестве стажёра");
    }
}