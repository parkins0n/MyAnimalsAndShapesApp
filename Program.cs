using MyAnimalsAndShapesApp.Models.Animals;
using MyAnimalsAndShapesApp.Models.Shapes;
using MyAnimalsAndShapesApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IAnimal, Dog>();
builder.Services.AddSingleton<IAnimal, Cat>();
builder.Services.AddSingleton<IShape, Circle>();
builder.Services.AddSingleton<IShape, Square>();
builder.Services.AddSingleton<IOutputService, ConsoleOutputService>();
builder.Services.AddSingleton<IAnimalRepository, AnimalRepository>();
builder.Services.AddSingleton<IShapeRepository, ShapeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
