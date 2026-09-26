namespace ExerciciosCsharp.Exercicios;

public class ExercicioInterface
{
    
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
    
    
    public void Execute()
    {
        var employees = new List<Employee>
        {
            new CltEmployee("Alberto da Silva", 4500),
            new CommissionedEmployee("Maria Cristina", 5500, 4530.23, 10)
        };

        foreach (var employee in employees)
        {
            employee.PrintData();
            
            if (employee is IDismissible dismissible)
            {
                dismissible.Dismiss();
            }
        }
    }
}