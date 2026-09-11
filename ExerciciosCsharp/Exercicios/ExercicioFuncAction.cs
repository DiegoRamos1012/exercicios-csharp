using System.Globalization;
using System.Runtime.Intrinsics.X86;

namespace ExerciciosCsharp.Exercicios;

public class ExercicioFuncAction
{
    private static readonly ExercicioLinq _products = new();

    private static List<Product> ApplyFilter(
        List<Product> products,
        Func<List<Product>, List<Product>> filter)
    {
        return filter(products);
    }

    private static readonly Func<List<Product>, List<Product>> Expensive =
        list => list.Where(p => p.Price > 300).ToList();

    private static readonly Func<List<Product>, List<Product>> EmptyStock =
        list => list.Where(p => p.Stock == 0).ToList();

    private static readonly Func<List<Product>, List<Product>> Consoles =
        list => list.Where(p => p.Category == ProductCategory.Consoles).ToList();

    public void ExecuteFilters()
    {
        var expensiveProducts = ApplyFilter(_products.Products, Expensive);
        Console.WriteLine("Itens caros:");
        foreach (var product in expensiveProducts)
        {
            Console.WriteLine($"- {product.Name} - R$ {product.Price:F2}");
        }

        var emptyStockProducts = ApplyFilter(_products.Products, EmptyStock);
        Console.WriteLine("\nItens sem estoque:");
        foreach (var product in emptyStockProducts)
        {
            Console.WriteLine($"- {product.Name}");
        }

        var consoleProducts = ApplyFilter(_products.Products, Consoles);
        Console.WriteLine("\nConsoles:");
        foreach (var product in consoleProducts)
        {
            Console.WriteLine($"- {product.Name}");
        }
    }

     Func<string, bool> isLongerThan3Characters = value => value.Length > 3;
     
     Func<string, bool> isValidEmail = email => email.Contains("@");

     Func<string, bool> isNoSpaces = value => !value.Contains(' ');

     private static bool Test(string value, Func<string, bool> validator)
     {
         return validator(value);
     }

     private readonly Action<Product> _printProduct = product =>
     {
         Console.WriteLine($"Nome: {product.Name}, Preço: {product.Price:C2}");
     };

     public void ExecuteFiltersV2()
     {
         var expensiveProducts = ApplyFilter(_products.Products, Expensive);

         foreach (var product in expensiveProducts)
         {
             _printProduct(product); 
         }
     }

     private Func<double, double, double> calcularMediaNota = (nota1, nota2) =>
     {
         return (nota1 + nota2) / 2;
     };

     private Action<double> verificarResultado = media =>
     {
         if (media >= 6)
         {
             Console.WriteLine("Aluno aprovado");
         }
         else
         {

             Console.WriteLine("Aluno reprovado");
         }
     };
     
     

}