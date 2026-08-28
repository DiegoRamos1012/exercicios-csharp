using ExerciciosCsharp.Exercicios;

var exercicioLinq = new ExercicioLinq();
var exercicioAsync = new ExercicioAsync();

/* LINQ */

// exercicioLinq.ProductsAbovePrice100();

// exercicioLinq.ProductsGroupedByCategory();

// exercicioLinq.CalculateAllStockValue();

// exercicioLinq.FindMostExpensiveProductInCategory();

// exercicioLinq.VerifyAnyProductWithEmptyStock();

/* Async/Await - Task */

// await exercicioAsync.ExecutarBuscarDado();

await exercicioAsync.ExecutarAsync();

await exercicioAsync.BuscarProdutoPorNomeAsync("Elden Ring");

