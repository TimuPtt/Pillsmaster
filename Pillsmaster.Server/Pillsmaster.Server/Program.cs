using Microsoft.EntityFrameworkCore;
using Pillsmaster.Persistence;
using Pillsmaster.Application.Services;
using Pillsmaster.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IPillsmasterDbContext, PillsmasterDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Pillsmaster.API"));
});

builder.Services.AddTransient<IMedicineService, MedicineService>();
builder.Services.AddTransient<IUserMedicineService, UserMedicineService>();
builder.Services.AddTransient<IPlanService, PlanService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
