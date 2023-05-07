using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Security.Cryptography.X509Certificates;
using UiBlazor;
using DataLayer;
using ServiceLayer;
using ServiceLayer.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddDbContext<EshopContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("EshopContext")));
await builder.Build().RunAsync();
