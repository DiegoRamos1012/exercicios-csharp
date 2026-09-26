namespace ExerciciosCsharp.Exercicios;

public class ExercicioPatternMatching
{

    string Classify(Employee employee) => employee switch
    {
        CltEmployee => "CLT",
        CommissionedEmployee {TotalSalesValue: > 10000} => "Vendedor Premium",
        CommissionedEmployee => "Comissionado",
        _ => "Desconhecido"
    };
    
    

    public void Execute()
    {
        var exercicioInterface = new ExercicioInterface();
        
        foreach(var employee in exercicioInterface.Employees)
        {
            Console.WriteLine($"{employee.Name}: {Classify(employee)}");
        }
    }
}

