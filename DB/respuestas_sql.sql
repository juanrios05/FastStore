============================================================
Evaluación de Base de Datos
============================================================

============================================================
1. CONSULTA DE ANÁLISIS
-- Productos de la categoría 'Hogar' con precio > $50.000
============================================================
SELECT
    p.Nombre        AS NombreProducto,
    p.StockActual,
    c.Nombre        AS NombreCategoria
FROM Productos p
INNER JOIN Categorias c ON p.CategoriaId = c.Id
WHERE c.Nombre = 'Hogar'
  AND p.Precio  > 50000;


============================================================
2. CONSULTA DE AGREGACIÓN
-- Promedio de precios por categoría
============================================================
SELECT
    c.Nombre            AS Categoria,
    AVG(p.Precio)       AS PrecioPromedio,
    COUNT(p.Id)         AS TotalProductos
FROM Productos p
INNER JOIN Categorias c ON p.CategoriaId = c.Id
GROUP BY c.Id, c.Nombre
ORDER BY c.Nombre;