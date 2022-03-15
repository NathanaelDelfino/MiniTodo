using MiniTodo.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbAppContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();



var app = builder.Build();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Versão 1.0");

app.Run();

