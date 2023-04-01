using ProductCategoryApp;

const string dbPath = "products.db";
const string connectionString = $"Data Source={dbPath}";

//Подготовка бд и данных
await DbInitializer.InitializeAsync(connectionString);
await TestData.AddSampleDataAsync(connectionString);

//Получаем пары продукт-категория
var productCategoryPairs = await ProductCategoryQuery.GetProductCategoryPairsAsync(connectionString);

//Вывод результата
Console.WriteLine("ProductName - CategoryName");
Console.WriteLine(new string('-', 30));
foreach (var (productName, categoryName) in productCategoryPairs)
{
    Console.WriteLine($"{productName} - {categoryName ?? "No Category"}");
}
