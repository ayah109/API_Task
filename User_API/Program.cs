using Microsoft.EntityFrameworkCore;
using User_API.Model;
using User_API.Repo;
using User_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddDbContext<UserContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));
builder.Services.InitServ();
//builder.Services.AddScoped<User_API.Repo.IUser_Repo, User_API.Repo.User_Repo>();

//builder.Services.AddScoped<User_API.Repo.IPost_Repo, User_API.Repo.Post_Repo>();


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
