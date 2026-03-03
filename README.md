# FastStore – Sistema de Control de Quiebre de Stock

## Descripción
MVP para que el personal de bodega de FastStore pueda visualizar productos con stock crítico y generar órdenes de reposición de forma rápida.

---

## Tecnologías
| Capa     | Tecnología                     |
|----------|-------------------------------|
| Backend  | .NET 10 / C# / EF Core         |
| Base de datos | SQL Server               |
| Frontend | Angular 17 (Standalone)        |

---

## Requisitos previos
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org/) y Angular CLI (`npm install -g @angular/cli`)
- SQL Server (local o instancia en la nube)

---

## Configuración y ejecución

### 1. Clonar el repositorio
```bash
git clone https://github.com/juanrios05/FastStore.git
```

### 2. Configurar el Backend
```bash
cd API
dotnet tool install --global dotnet-ef  # solo si no lo tiene instalado
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```
Actualmente en `appsettings.json` se encuentra el connection string para prueba:
```json
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=FastStoreDb;Trusted_Connection=True;TrustServerCertificate=True;"
```
Si se desea editar `appsettings.json` y reemplazar el connection string:
```json
"DefaultConnection": "Server=TU_SERVIDOR;Database=FastStoreDb;Trusted_Connection=True;TrustServerCertificate=True;"
```

La API quedará disponible en `http://localhost:5000`.

> Los datos del archivo `productos.json` se cargan automáticamente al iniciar.

### 3. Configurar el Frontend
```bash
cd faststore-front
npm install
ng serve
```
La app Angular quedará en `http://localhost:4200`.

---

## Endpoints de la API

| Método | Ruta                       | Descripción                         |
|--------|----------------------------|-------------------------------------|
| GET    | /api/inventario            | Listar todos los productos          |
| GET    | /api/inventario/low-stock  | Productos con stock crítico         |
| POST   | /api/ordenes               | Crear orden de reposición           |

### Ejemplo POST /api/ordenes
```json
{
  "productoId": 2,
  "cantidad": 10
}
```

---

## Funcionalidades
- ✅ Tabla de inventario con todos los productos
- ✅ Resaltado en rojo e ícono ⚠ en productos con stock crítico
- ✅ Botón para únicamente listar productos con stock crítico
- ✅ Buscador en tiempo real por nombre de producto
- ✅ Modal de reposición con validación de campos
- ✅ Validación backend: cantidad > 0 y producto existente
- ✅ Toast de confirmación al crear orden exitosamente
- ✅ Seed automático de datos al iniciar