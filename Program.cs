using Microsoft.EntityFrameworkCore;
using HotChocolate.AspNetCore;
using RentalApi.GraphQL.Queries;


var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов в контейнер.
builder.Services.AddDbContext<AppDbContext>();

// Добавление REST контроллеров
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

// Добавление GraphQL с Hot Chocolate
builder.Services
    .AddGraphQLServer()
    .AddQueryType<ApartmentQuery>()
    .AddMutationType<UserMutation>()
    .AddType<ApartmentType>()
    .AddType<UserType>()
    .AddType<ApartmentFilterInputType>()
    .AddType<UserInputType>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

// Настройка CORS
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

app.UseRouting();

// Включение CORS
app.UseCors("AllowAll");

// Подключение REST и GraphQL маршрутов
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // REST API
    endpoints.MapGraphQL();     // GraphQL API
});


app.Run();