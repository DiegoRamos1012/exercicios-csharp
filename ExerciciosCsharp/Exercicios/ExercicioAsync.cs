using System.Diagnostics;

namespace ExerciciosCsharp.Exercicios;

public class ExercicioAsync
{

    private readonly ExercicioLinq _exercicioLinq = new();
    /*
     * Objetos "Task" representa uma operação que está acontecendo ou que vai terminar no futuro,
     * é como se fosse uma promessa de que vai retornar o tipo especificado na sintaxe, parecido
     * com a abordagem de "Promise <T>" do TypeScript.
     */
    
    /*
     * Nos exemplos abaixo, as funções com async se tornam assíncronas, impedindo que a thread fique bloqueada nesse
     * processo e possa trabalhar em outros. "Task" representa uma operação que ainda está acontecendo, então ela é
     * o tipo do retorno da função, agora se a função precisa devolver o valor, podemos usar um "Task <T>".
     * Exemplo logo abaixo.
     */
    public async Task<string> BuscarDadoAsync(string nome, int delayMs)
    {
        await Task.Delay(delayMs);
        return $"Dados do usuário {nome} pronto";
    }
    public async Task ExecutarBuscarDado()
    {
        /*
         * O Stopwatch é uma ferramenta de diagnóstico usado para medir o tempo de execução de um código
         */
        var stopwatch = Stopwatch.StartNew();
        
        
        /*
        var resultado = await BuscarDadoAsync("Diego", 1000);
        var resultado2 = await BuscarDadoAsync("Pedro", 2000);
        var resultado3 = await BuscarDadoAsync("Lara", 500);
        */
        
        var tarefa1 = BuscarDadoAsync("Diego", 1000);
        var tarefa2 = BuscarDadoAsync("Pedro", 2000);
        var tarefa3 = BuscarDadoAsync("Lara", 500);


        /*
         * O Task.WhenAll é uma Task que executa todas as funções Tasks concorrentemente, ao invés
         * de esperar uma terminar pra outra começar
         */
        String[] resultadoWhenAll = await Task.WhenAll(tarefa1, tarefa2, tarefa3);

        /*
        Console.WriteLine(resultado);
        Console.WriteLine(resultado2);
        Console.WriteLine(resultado3);
        */
        
        foreach (var resultados   in resultadoWhenAll)
        {
            Console.WriteLine(resultados);
        }
        stopwatch.Stop();
        
        Console.WriteLine($"Tempo total de execução: {stopwatch.ElapsedMilliseconds} ms");
    }
    
    public async Task<double> CalcularNotaAsync(double b1, double b2)
    {
        try
        {
            await Task.Delay(100);

            if (b1 < 0)
                throw new Exception("B1 não pode ser negativa.");

            return (b1 + b2) / 2;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            return 0;
        }
    }
    
    public async Task ExecutarAsync()
    {
        double nota = await CalcularNotaAsync(-1, 2);

        Console.WriteLine(nota);
    }

    public async Task<Product?> BuscarProdutoPorNomeAsync(string nome)
    {
        await Task.Delay(1000);

        return _exercicioLinq.Products
            .FirstOrDefault(product => product.Name == nome);
    }
    
    
}