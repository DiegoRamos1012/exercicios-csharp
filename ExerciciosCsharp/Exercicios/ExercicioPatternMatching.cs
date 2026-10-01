namespace ExerciciosCsharp.Exercicios;

public class ExercicioPatternMatching
{
    private static readonly
        ExercicioLinq _products = new();
    
    string Classify(Employee employee) => employee switch
    {
        CltEmployee => "CLT",
        CommissionedEmployee {TotalSalesValue: > 10000} => "Vendedor Premium",
        CommissionedEmployee => "Comissionado",
        _ => "Desconhecido"
    };
    
    string ClassifyProduct(Product product) => product switch
    { 
        { Category: ProductCategory.Consoles, Stock: < 5 } => "Console raro, últimas unidades",
        { Stock: 0 } => "Em falta",
        _ => "Disponível"
    };
    
    

    public void Execute()
    {
        var exercicioInterface = new ExercicioInterface();
        
        foreach(var employee in exercicioInterface.Employees)
        {
            Console.WriteLine($"{employee.Name}: {Classify(employee)}");
        }
        
        Console.WriteLine("----------------------------------------------------------");
        
        var exercicioLinq = new ExercicioLinq();

        foreach (var product in exercicioLinq.Products)
        {
            Console.WriteLine($"{product.Name}: {ClassifyProduct(product)}");
        }
        
    }
}

