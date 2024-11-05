using AnimalApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IOutputService, FileOutputService>();
builder.Services.AddScoped<IAnimalSerializer, JsonAnimalSerializer>();
builder.Services.AddScoped<IAnimalSerializer, XmlAnimalSerializer>();

var app = builder.Build();

app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();