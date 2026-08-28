using System.Globalization;

namespace ExerciciosCsharp.Exercicios
{
    /*
     * LINQ (Language Integrated Query) é a forma do C# de consultar e transformar coleções de dados
     * (listas, arrays, e até resultados de banco (via EF Core)) usando uma sintaxe declarativa embutida
     * na linguagem, parecida com SQL.
     */
    
    public enum ProductCategory
    {
        Games,
        Peripherals,
        Consoles
    }

    public class Product(
        string name,
        double price,
        ProductCategory category,
        int stock)
    {
        public string Name { get; private set; } = name;
        public double Price { get; private set; } = price;
        public ProductCategory Category { get; private set; } = category;
        public int Stock { get; private set; } = stock;
    }

    public class ExercicioLinq
    {
        public readonly List<Product> products =
        [
            // Games
            new ("God of War Ragnarök", 249.90, ProductCategory.Games, 10),
            new ("The Last of Us Part II", 199.90, ProductCategory.Games, 8),
            new ("Red Dead Redemption 2", 179.90, ProductCategory.Games, 15),
            new ("Elden Ring", 249.90, ProductCategory.Games, 12),
            new ("Cyberpunk 2077", 199.90, ProductCategory.Games, 7),

            // Peripherals
            new ("Logitech G Pro X", 599.90, ProductCategory.Peripherals, 5),
            new ("Razer DeathAdder V3", 399.90, ProductCategory.Peripherals, 10),
            new ("HyperX Alloy Origins", 499.90, ProductCategory.Peripherals, 6),
            new ("Logitech G502 Hero", 299.90, ProductCategory.Peripherals, 14),
            new ("Razer BlackShark V2", 449.90, ProductCategory.Peripherals, 9),

            // Consoles
            new ("PlayStation 5", 3999.90, ProductCategory.Consoles, 4),
            new ("Xbox Series X", 3899.90, ProductCategory.Consoles, 6),
            new ("Nintendo Switch OLED", 2199.90, ProductCategory.Consoles, 11),
            new ("PlayStation 5 Slim", 3599.90, ProductCategory.Consoles, 8),
            new ("Xbox Series S", 2299.90, ProductCategory.Consoles, 13)
        ];

        public void ProductsAbovePrice100()
        {
            var productsAbovePrice100 = products
                .Where(product => product.Price > 100)
                .ToList();

            foreach (var product in productsAbovePrice100)
            {
                Console.WriteLine($"Produtos acima de R$ 100,00: {product.Name}");
            }
        }

        public void ProductsGroupedByCategory()
        {
            var productsGroupedByCategory = products
                .GroupBy(product => product.Category)
                .ToList();

            foreach (var group in productsGroupedByCategory)
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");

                foreach (var product in group)
                {
                    Console.WriteLine(product.Name);
                }
            }
        }

        public void CalculateAllStockValue()
        {
            var calculatedGAllStockValue = products
                .Sum(product => product.Price * product.Stock);

            Console.WriteLine(calculatedGAllStockValue.ToString("C2", CultureInfo.GetCultureInfo("pt-BR")));
        }

        public void FindMostExpensiveProductInCategory()
        {
            var findMostExpensiveProductInCategory = products
                .GroupBy(product => product.Category)
                .Select(group => group.OrderByDescending(product => product.Price).First());

            foreach (var product in findMostExpensiveProductInCategory)
            {
                Console.WriteLine(
                    $"{product.Category}: {product.Name} - " +
                    $"{product.Price.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"))}"
                );
            }
        }

        public void VerifyAnyProductWithEmptyStock()
        {
            var hasEmptyStock = products
                .Any(product => product.Stock == 0);

            var productsWithEmptyStock = products
                .Where(product => product.Stock == 0)
                .ToList();

            Console.WriteLine($"Existe produto sem estoque? {hasEmptyStock}");

            foreach (var product in productsWithEmptyStock)
            {
                Console.WriteLine(product.Name);
            }
        }
    }
}