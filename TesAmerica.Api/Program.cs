using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure sql server connection
var _config = builder.Configuration;
var connectionStringSection = _config.GetSection("ConnectionStrings");
var sqlServerConnectionString = connectionStringSection.GetValue<string>("SqlServer");

// Build the SqlConnection and execute the SQL command
SqlConnection conn = new SqlConnection(sqlServerConnectionString);
builder.Services.AddKeyedTransient<SqlConnection>(conn);

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
