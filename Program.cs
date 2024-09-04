using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using _8HourHero.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Web;
using Azure.Identity;
using _8HourHero.Client.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Dodaj g³ówny komponent
builder.RootComponents.Add<App>("app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Dodaj us³ugi do kontenera
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();

// Konfiguracja Azure Key Vault
builder.Configuration.AddAzureKeyVault(
    new Uri("https://rhvault.vault.azure.net/"),
    new DefaultAzureCredential());

// Pobierz connection string z konfiguracji
var connectionString = builder.Configuration["rhsqlconnstring"]
    ?? throw new InvalidOperationException("Connection string 'rhsqlconnstring' not found.");

// Dodaj DbContext do kontenera
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Buduj aplikacjê
await builder.Build().RunAsync();
