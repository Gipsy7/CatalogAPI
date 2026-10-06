# CatalogAPI

API REST de catálogo de produtos e categorias com ASP.NET Core 6, controllers assíncronos e Entity Framework Core sobre MySQL.

> Projeto de estudo (abril/2022). É a segunda versão do [APICatalogo](https://github.com/Gipsy7/APICatalogo), migrada para .NET 6 e com consultas otimizadas. A versão seguinte, com Minimal API e JWT, é o [CatalogAPI2](https://github.com/Gipsy7/CatalogAPI2).

## O que mudou em relação à primeira versão

- Migração para **.NET 6**, com `Program.cs` enxuto (sem `Startup`), nullable e implicit usings
- Controllers totalmente **assíncronos** (`ToListAsync`, `FindAsync`, `SaveChangesAsync`)
- Consultas com `AsNoTracking` e limite de resultados (`Take`) nas listagens
- `ReferenceHandler.IgnoreCycles` e `[JsonIgnore]` na navegação para evitar ciclos no JSON
- Preço com precisão fixa (`decimal(10,2)`) e migrations que populam categorias e produtos

## Endpoints

| Método | Rota | Descrição |
| --- | --- | --- |
| GET | `/api/categories` | Lista até 10 categorias |
| GET | `/api/categories/products` | Lista as categorias com os produtos |
| GET | `/api/categories/{id}` | Busca uma categoria |
| POST | `/api/categories` | Cria uma categoria |
| PUT | `/api/categories/{id}` | Atualiza uma categoria |
| DELETE | `/api/categories/{id}` | Remove uma categoria |
| GET | `/api/products` | Lista até 20 produtos |
| GET | `/api/products/{id}` | Busca um produto |
| POST | `/api/products` | Cria um produto |
| PUT | `/api/products/{id}` | Atualiza um produto |
| DELETE | `/api/products?id={id}` | Remove um produto |

## Tecnologias

- .NET 6 / ASP.NET Core Web API
- Entity Framework Core 6 com Pomelo (MySQL)
- Swashbuckle (Swagger)

## Como executar

Pré-requisitos: SDK do .NET 6 e um MySQL rodando.

1. Ajuste a connection string `DefaultConnection` em `CatalogAPI/appsettings.json`.
2. Crie e popule o banco:
   ```bash
   dotnet tool install --global dotnet-ef
   dotnet ef database update --project CatalogAPI
   ```
3. Rode a API e abra o Swagger em `/swagger`:
   ```bash
   dotnet run --project CatalogAPI
   ```

---

Feito por **Mikael Francisco** · [Portfólio](https://mikaelfrancisco.vercel.app) · [LinkedIn](https://www.linkedin.com/in/mikael-francisco-a4300b180)
