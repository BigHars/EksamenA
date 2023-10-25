using WoodPelletsLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<WoodPelletRepository>(new WoodPelletRepository());

//CORS
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowSpecificOrign",
        builder => builder.WithOrigins("https://zealand.dk").
                AllowAnyMethod().
                AllowAnyHeader());

    option.AddPolicy("AllowAny",
        builder => builder.AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyHeader());

    option.AddPolicy("AllowOnlyGetPut",
            builder => builder.AllowAnyOrigin().
                    WithMethods("GET", "PUT").
                    AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

//Use CORS
app.UseCors("AllowOnlyGetPut");

app.MapControllers();

app.Run();
