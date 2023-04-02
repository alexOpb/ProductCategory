# ProductCategory

В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

```sql
SELECT p.ProductName, c.CategoryName
FROM Products p
LEFT JOIN ProductCategories pc ON p.ProductId = pc.ProductId
LEFT JOIN Categories c ON pc.CategoryId = c.CategoryId
ORDER BY p.ProductName, c.CategoryName;
```

1. При запуске проекта создается база данных Sqlite (с помощью Dapper).
2. `DbInitializer` создает три таблицы: Products, Categories и ProductCategories для реализации отношения многие-ко-многим между продуктами и категориями.
3. `TestData` заполняет таблицы тестовыми данными. 
4. `ProductCategoryQuery` выполняет запрос и возвращает пары продукт-категория.
5. Результат выводится в консоль, при отсутствии категории выводится "No Category".

Ожидаемый результат выполнения программы:
```
------------------------------
ProductName - CategoryName
------------------------------
Product 1 - Category 1
Product 1 - Category 2
Product 1 - Category 3
Product 2 - Category 1
Product 2 - Category 3
Product 3 - Category 1
Product 4 - No Category
Product 5 - No Category
Product 6 - No Category
```

          
