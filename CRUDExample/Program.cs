using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Add services into IOC Container
builder.Services.AddScoped<ICountriesService,CountriesService>();
builder.Services.AddScoped<IPersonsService, PersonsService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
