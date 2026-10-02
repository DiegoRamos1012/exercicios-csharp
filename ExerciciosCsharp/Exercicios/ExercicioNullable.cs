namespace ExerciciosCsharp.Exercicios;

public class ExercicioNullable
{
    private static readonly ExercicioLinq _exercicioLinq = new();

    private Product? SearchByName(string name)
    {
        return _exercicioLinq.Products.FirstOrDefault(p => p.Name == name);
    }

    bool IsEmailValid(string? email)
    {
        return !string.IsNullOrEmpty(email) && email.Contains('@');
    }

    public void Execute()
    {
        var existentProduct = SearchByName("Elden Ring");

        if (existentProduct != null)
        {
            Console.WriteLine($"{existentProduct.Name} - {existentProduct.Price:C2}");
        }
        
        var produtoInexistente = SearchByName("Jogo Que Não Existe");
        if (produtoInexistente != null)
        {
            Console.WriteLine($"{produtoInexistente.Name} - {produtoInexistente.Price:C2}");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
        
        var produtoPadrao = new Product("Produto Genérico", 0, ProductCategory.Games, 0);

        var produto = SearchByName("Jogo Que Não Existe") ?? produtoPadrao;

        Console.WriteLine($"{produto.Name} - {produto.Price:C2}");

        IsEmailValid("teste@email.com");
    }
}