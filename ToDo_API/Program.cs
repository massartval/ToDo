using ToDo_DAL.Interfaces;
using ToDo_DAL.Services;
using Tools.Ado;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddCors(options =>
//  options.AddPolicy("myclient", builder =>
//    builder.WithOrigins("https://localhost:7252", "http://localhost:5033").AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddControllers();
builder.Services.AddTransient(c => new Connection(
    builder.Configuration.GetConnectionString("default")
    ));
builder.Services.AddScoped<IItemRepository, ItemRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors("myclient");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
