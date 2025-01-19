using API.TaskManager.DependencyManager;
using InfrastructureLayer.TaskManager.Context;

using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// SQL SERVER CONNECTION
builder.Services.AddDbContext<TaskManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// --------------------


// DEPENDENCY INJECTION
builder.Services.AddDependency();
// --------------------

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
