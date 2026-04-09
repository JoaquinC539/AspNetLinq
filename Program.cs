using AspNetLinq.Contexts;
using AspNetLinq.Middleware;
using AspNetLinq.Services;
using AspNetLinq.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IVendedorService, VendedorService>();

var connectionString = builder.Configuration.GetConnectionString("Company") ?? "Data Source=Company.db";
builder.Services.AddSqlite<DataContext>(connectionString);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseStaticFiles();
app.MapControllers();
app.UseRouting();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();


app.Run();