using Dapper;
using Microsoft.Data.Sqlite;
namespace ProductCategoryApp;

/// <summary>
/// Класс с тестовыми данными
/// </summary>
public static class TestData
{
    /// <summary>
    /// Заполняет тестовыми данными БД
    /// </summary>
    /// <param name="connectionString">Строка подключения</param>
    public static async Task AddSampleDataAsync(string connectionString)
    {
        await using var connection = new SqliteConnection(connectionString);

        const string insertProducts = @"
                INSERT OR IGNORE INTO Products (ProductId, ProductName) VALUES
                (1, 'Product 1'),
                (2, 'Product 2'),
                (3, 'Product 3'),
                (4, 'Product 4'),
                (5, 'Product 5'),
                (6, 'Product 6');
            ";

        const string insertCategories = @"
                INSERT OR IGNORE INTO Categories (CategoryId, CategoryName) VALUES
                (1, 'Category 1'),
                (2, 'Category 2'),
                (3, 'Category 3');
            ";

        const string insertProductCategories = @"
                INSERT OR IGNORE INTO ProductCategories (ProductId, CategoryId) VALUES
                (1, 1),
                (1, 2),
                (1, 3),
                (2, 1),
                (2, 3),
                (3, 1);
            ";

        await connection.ExecuteAsync(insertProducts);
        await connection.ExecuteAsync(insertCategories);
        await connection.ExecuteAsync(insertProductCategories);
    }
}