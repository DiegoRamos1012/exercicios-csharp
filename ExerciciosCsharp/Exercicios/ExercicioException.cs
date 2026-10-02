namespace ExerciciosCsharp.Exercicios;

public class ExercicioException
{
    
    private static readonly ExercicioLinq ExercicioLinq = new();
    public class InsufficientBalanceException(string message) : Exception(message);

    public class ProductNotFound(string message) : Exception(message);

    private double ProcessWithdraw(double balance, double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("O valor informado do saque não pode ser negativo");
        }
        if (value > balance)
        {
            throw new InsufficientBalanceException($"Saldo de {balance:C2} insuficiente para sacar {value:C2}");
        }

        return balance - value;
    }
    private void Withdraw(double balance, double value)
    {
        try
        {
            var currentBalance = ProcessWithdraw(balance, value);
            Console.WriteLine($"Sucesso: saldo atual é de {currentBalance:C2}");
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine($"Saldo Insuficiente: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Valor negativo: {ex.Message}");
        }
    }
    
    public async Task<Product> SearchByNameAsync(string nome)
    {
        await Task.Delay(1000);

        var targetProduct = ExercicioLinq.Products.FirstOrDefault(p => p.Name == nome);

        return targetProduct ?? throw new ProductNotFound($"Produto '{nome}' não encontrado.");
    }

    public void Execute()
    {
        Withdraw(1000.00, 545.00); // Sucesso
        Withdraw(1000.00, 1200.00); // Catch do InsufficientBalanceException
        Withdraw(1000.00, -50.00); // Catch do ArgumentException
    }
    
    public async Task ExecuteSearch()
    {
        try
        {
            var product = await SearchByNameAsync("Jogo Inexistente");
            Console.WriteLine(product.Name);
        }
        catch (ProductNotFound ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}