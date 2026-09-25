namespace ExerciciosCsharp.Exercicios;

public class ExercicioEvento
{
    public class ContaBancaria
    {
        public event Action<double> SaldoBaixo;
        public event Action<double> SaldoAlto;

        private double _saldo;

        public double Saldo
        {
            get => _saldo;
            set
            {
                _saldo = value;
                if (_saldo < 100)
                {
                    SaldoBaixo?.Invoke(_saldo);
                }

                if (_saldo > 10000)
                {
                    SaldoAlto?.Invoke(_saldo);
                }
            }
        }
    }

    private static readonly ExercicioLinq _products = new();

    public class Stock
    {
        public event EventHandler<Product> LowStock;

        private Product _stock;

        public Product _saldo
        {
            get => _stock;
            set
            {
                _stock = value;
                if (_stock.Stock < 5)
                {
                    LowStock?.Invoke(this, _stock);
                }
            }
        }
    }

    public void Executar()
    {
        var conta = new ContaBancaria();

        conta.SaldoBaixo += saldo =>
            Console.WriteLine($"[Alerta] Saldo baixo: {saldo:C2}");

        conta.SaldoBaixo += saldo =>
            Console.WriteLine("[Sugestão] Considere fazer um depósito.");

        conta.SaldoAlto += saldo =>
            Console.WriteLine($"[Alerta] Salto alto: {saldo:C2}");

        conta.SaldoAlto += saldo =>
            Console.WriteLine("[Sugestão] Confira nossa aba de investimentos");

        conta.Saldo = 15000;

        var estoque = new Stock();
        estoque.LowStock += (sender, produto) =>
            Console.WriteLine($"[Alerta] Estoque baixo: {produto.Name} ({produto.Stock} unidades)");

        // Pegando um produto com estoque baixo (< 5) da sua lista de LINQ
        var produtoComEstoqueBaixo = _products.Products.First(p => p.Stock < 5);
        estoque._saldo = produtoComEstoqueBaixo;
    }
}