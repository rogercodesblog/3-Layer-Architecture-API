using _3LayerAPI.Data;
using _3LayerAPI.Repository.Note;
using _3LayerAPI.Services.Note;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Database
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionString")));

//Auto mapper for DTOs
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Inject Repositories (Data Access Layer)
builder.Services.AddScoped<INoteRepository, NoteRepository>();

//Inject Services (Business Layer)
builder.Services.AddScoped<INoteService, NoteService>();

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
