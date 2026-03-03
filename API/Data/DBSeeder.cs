using FastStore.API.Models;

namespace FastStore.API.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Categorias.Any()) return;

        var categorias = new List<Categoria>
        {
            new() { Nombre = "Calzado" },
            new() { Nombre = "Ropa Superior" },
            new() { Nombre = "Pantalones" }
        };
        context.Categorias.AddRange(categorias);
        context.SaveChanges();

        // Se obtienen los IDs generados automáticamente
        var calzado = context.Categorias.First(c => c.Nombre == "Calzado");
        var ropaSuperior = context.Categorias.First(c => c.Nombre == "Ropa Superior");
        var pantalones = context.Categorias.First(c => c.Nombre == "Pantalones");

        var productos = new List<Producto>
        {
            new() { Nombre = "Tenis Nike Air Max 270 - Talla 40",   Precio = 580000, StockActual = 15, StockMinimo = 5,  CategoriaId = calzado.Id },
            new() { Nombre = "Tenis Adidas Ultraboost - Talla 38",  Precio = 620000, StockActual = 2,  StockMinimo = 8,  CategoriaId = calzado.Id },
            new() { Nombre = "Camiseta Básica Oversize Blanca - M", Precio = 85000,  StockActual = 50, StockMinimo = 20, CategoriaId = ropaSuperior.Id },
            new() { Nombre = "Hoodie Negro Algodón - L",            Precio = 145000, StockActual = 4,  StockMinimo = 10, CategoriaId = ropaSuperior.Id },
            new() { Nombre = "Jeans Slim Fit Azul - Talla 32",      Precio = 180000, StockActual = 25, StockMinimo = 15, CategoriaId = pantalones.Id },
            new() { Nombre = "Joggers de Entrenamiento Gris - S",   Precio = 120000, StockActual = 3,  StockMinimo = 7,  CategoriaId = pantalones.Id },
            new() { Nombre = "Tenis Puma Rider - Talla 41",         Precio = 320000, StockActual = 12, StockMinimo = 5,  CategoriaId = calzado.Id },
            new() { Nombre = "Chaqueta Denim Clásica - M",          Precio = 210000, StockActual = 1,  StockMinimo = 5,  CategoriaId = ropaSuperior.Id },
            new() { Nombre = "Shorts Deportivos Pro - L",           Precio = 95000,  StockActual = 30, StockMinimo = 10, CategoriaId = pantalones.Id },
            new() { Nombre = "Tenis Jordan Retro 1 - Talla 42",     Precio = 850000, StockActual = 2,  StockMinimo = 3,  CategoriaId = calzado.Id }
        };
        context.Productos.AddRange(productos);
        context.SaveChanges();
    }
}