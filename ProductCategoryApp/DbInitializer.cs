using Dapper;
using Microsoft.Data.Sqlite;

namespace ProductCategoryApp;
/// <summary>
/// Класс для инициализации БД
/// </summary>
public static class DbInitializer
{
    /// <summary>
    /// Инициализирует БД Sqlite таблицами
    /// </summary>
    /// <param name="connectionString"></param>
    public static async Task InitializeAsync(string connectionString)
    {
        if (!File.Exists("products.db"))
        {
            File.Create("products.db").Close();
        }

        await using var connection = new SqliteConnection(connectionString);

        const string createProductsTable = @"
                CREATE TABLE IF NOT EXISTS Products (
                    ProductId INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProductName NVARCHAR(100) NOT NULL
                );
            ";

        const string createCategoriesTable = @"
                CREATE TABLE IF NOT EXISTS Categories (
                    CategoryId INTEGER PRIMARY KEY AUTOINCREMENT,
                    CategoryName NVARCHAR(100) NOT NULL
                );
            ";

        const string createProductCategoriesTable = @"
                CREATE TABLE IF NOT EXISTS ProductCategories (
                    ProductId INTEGER NOT NULL,
                    CategoryId INTEGER NOT NULL,
                    PRIMARY KEY (ProductId, CategoryId),
                    FOREIGN KEY (ProductId) REFERENCES Products (ProductId),
                    FOREIGN KEY (CategoryId) REFERENCES Categories (CategoryId)
                );
            ";

        await connection.ExecuteAsync(createProductsTable);
        await connection.ExecuteAsync(createCategoriesTable);
        await connection.ExecuteAsync(createProductCategoriesTable);
    }
}