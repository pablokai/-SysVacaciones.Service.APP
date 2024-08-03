using DataAccess;
using DataAccess.Interface;
using SysVacacionesDAL;
using SysVacacionesDAL.Interface;

var builder = WebApplication.CreateBuilder(args);

//Inyeccion dependencias
builder.Services.AddTransient<IConnectionManager, ConnectionManager>();
builder.Services.AddTransient<IDisponiblesDA, DisponiblesDA>();
builder.Services.AddTransient<IEmpleadosDA, EmpleadosDA>();
builder.Services.AddTransient<IPuestosDA, PuestosDA>();
builder.Services.AddTransient<IVacacionesDA, VacacionesDA>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});


var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseCors("AllowAll");

// Configure the HTTP request pipeline. 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
