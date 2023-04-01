namespace ProductCategoryApp;

/// <summary>
/// Запись для вывода продукта-категории
/// </summary>
/// <param name="ProductName">Имя продукта</param>
/// <param name="CategoryName">Имя категории</param>
public readonly record struct ProductCategory(string ProductName, string CategoryName);