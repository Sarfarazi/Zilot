var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Service Collections Extensions
builder.Services.RegisterSqlServer();
builder.Services.RegisterHttpContextAccessor();
ApplicationConfig.InitializeApplicationConfig(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

// var development_mode = app.Environment.IsDevelopment();
// var production_mode= app.Environment.IsProduction();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
