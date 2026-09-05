namespace ExerciciosCsharp.Exercicios;

public class ExercicioDelegate
{
    public delegate bool Validator(string target);

    private static bool IsValidEmail(string email) => email.Contains('@');

    private static bool IsLongerThan3Characters(string target) => target.Length > 3;

    private static bool IsNoSpaces(string target) => !target.Contains(' ');

    private static bool Test(string value, Validator validator)
    {
        return validator(value);
    }

   /* public void Executar()
    {
        Console.WriteLine(Test("teste@email.com", IsValidEmail));
        Console.WriteLine(Test("teste", IsLongerThan3Characters));
        Console.WriteLine(Test("teste sem espaco", IsNoSpaces));
    }
    */
    
    
}