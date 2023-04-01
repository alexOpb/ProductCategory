using Dapper;
using Microsoft.Data.Sqlite;

namespace ProductCategoryApp;

/// <summary>
/// Класс для работы с парой продукт-категория
/// </summary>
public static class ProductCategoryQuery
{
    /// <summary>
    /// Получение продукта категории
    /// </summary>
    /// <param name="connectionString">строка подключения</param>
    public static async Task<IEnumerable<ProductCategory>> GetProductCategoryPairsAsync(string connectionString)
    {
        const string query = @"
                SELECT p.ProductName, c.CategoryName
                FROM Products p
                LEFT JOIN ProductCategories pc ON p.ProductId = pc.ProductId
                LEFT JOIN Categories c ON pc.CategoryId = c.CategoryId
                ORDER BY p.ProductName, c.CategoryName;
            ";

        await using var connection = new SqliteConnection(connectionString);
        return await connection.QueryAsync<ProductCategory>(query);
    }
}