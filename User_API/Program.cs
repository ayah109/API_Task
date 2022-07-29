using Microsoft.EntityFrameworkCore;
using User_API.Model;
using User_API.Repo;
using User_API;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<Filtter>(RoleKey => new Filtter("Admin"));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//Database connection 
builder.Services.AddDbContext<UserContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));

builder.Services.InitServ();

var app = builder.Build();

app.UseMiddleWareEx();


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
