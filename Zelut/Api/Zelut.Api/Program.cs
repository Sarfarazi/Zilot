var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("landing-cors", policy =>
    {
        policy.WithOrigins("http://localhost:5089", "https://localhost:7100","https://zelut.ir")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataProtection();

// Initialize Application Configuration
if (builder.Environment.IsDevelopment())
{
    ApplicationConfig.InitializeApplicationConfig(builder.Configuration);
}

if (builder.Environment.IsProduction())
{
    ApplicationConfig.InitializeProductionApplicationConfig(builder.Configuration);
}

// Register Service Collections Extensions
builder.Services.RegisterSqlServer();
builder.Services.RegisterServices();
builder.Services.RegisterAutoMapper();
builder.Services.RegisterFluentValidation();
builder.Services.RegisterHttpClients();
builder.Services.RegisterHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.

var development_mode = app.Environment.IsDevelopment();
var production_mode = app.Environment.IsProduction();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("landing-cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
