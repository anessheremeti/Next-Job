// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();  
// }

// app.MapGet("/", () => "Hello World!");

// app.Run();

using HelloWorld.Data;

var builder = WebApplication.CreateBuilder(args);

// Regjistrimi i serviseve të nevojshme për API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Shtimi i DataDapper për përdorim në controller
builder.Services.AddScoped<DataDapper>();

var app = builder.Build();

// Aktivizimi i Swagger për zhvillim
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers(); // Regjistrimi i routes për kontrollet

app.Run();
