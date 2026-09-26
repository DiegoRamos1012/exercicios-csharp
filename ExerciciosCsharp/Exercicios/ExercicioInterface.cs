namespace ExerciciosCsharp.Exercicios;

public interface IDismissible
{
    void Dismiss();
}

public abstract class Employee
{
    public string Name { get; protected set; }

    protected Employee(string name)
    {
        Name = name;
    }

    public abstract double CalcSalary();

    public void PrintData()
    {
        Console.WriteLine($"{Name}: {CalcSalary():C2}");
    }
}

public class CltEmployee : Employee, IDismissible
{
    public double BaseSalary { get; private set; }

    public CltEmployee(string name, double baseSalary) : base(name)
    {
        BaseSalary = baseSalary;
    }

    public override double CalcSalary()
    {
        return BaseSalary;
    }

    public void Dismiss()
    {
        Console.WriteLine($"Funcionário/a {Name} foi demitido");
    }
}

public class CommissionedEmployee : Employee
{
    public double BaseSalary { get; private set; }

    public double TotalSalesValue { get; private set; }

    public int PercentageCommission { get; private set; }

    public CommissionedEmployee(string name, double baseSalary, double totalSalesValue, int percentageCommission) : base(name)
    {
        BaseSalary = baseSalary;
        TotalSalesValue = totalSalesValue;
        PercentageCommission = percentageCommission;
    }

    public override double CalcSalary()
    {
        return BaseSalary + (TotalSalesValue * PercentageCommission / 100.00);
    }
}

public class ExercicioInterface
{
    public List<Employee> Employees { get; } = new()
    {
        // CLT
        new CltEmployee("Alberto da Silva", 4500),
        new CltEmployee("Fernanda Oliveira", 3200),
        new CltEmployee("Ricardo Mendes", 7800),
        new CltEmployee("Juliana Costa", 5100),
        new CltEmployee("Carlos Eduardo", 6250),

        // Comissionados
        new CommissionedEmployee("Maria Cristina", 5500, 4530.23, 10),
        new CommissionedEmployee("Lucas Ferreira", 3800, 2750.50, 7),
        new CommissionedEmployee("Patrícia Almeida", 6200, 8100.75, 12),
        new CommissionedEmployee("Rafael Santos", 4500, 3200.00, 8),
        new CommissionedEmployee("Camila Rodrigues", 7000, 12500.90, 15),
    };

    public void Execute()
    {
        foreach (var employee in Employees)
        {
            employee.PrintData();

            if (employee is IDismissible dismissible)
            {
                dismissible.Dismiss();
            }
        }
    }
}