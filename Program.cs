using Microsoft.EntityFrameworkCore;
using HotChocolate.AspNetCore;
using RentalApi.GraphQL.Queries;


var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов в контейнер.

// Подключение PostgreSQL через EF Core
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AppDbContext>();

// Добавление REST контроллеров
builder.Services.AddControllers();

// Добавление GraphQL с Hot Chocolate
builder.Services
    .AddGraphQLServer()
    .AddQueryType<ApartmentQuery>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

// Настройка CORS (если нужно)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader();
    });
});

var app = builder.Build();

// Использование middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// app.UseHttpsRedirection();

// Включение статических файлов (для index.html)
// app.UseStaticFiles();

app.UseRouting();

// Включение CORS
app.UseCors("AllowAll");

// Подключение REST и GraphQL маршрутов
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // REST API
    endpoints.MapGraphQL();     // GraphQL API
});

// Пример GET-маршрута для проверки работы сервера
// app.MapGet("/", () => Results.Redirect("/index.html"));

app.Run();