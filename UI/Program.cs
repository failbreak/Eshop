using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("Data Source");
builder.Services.AddRazorPages().Services.AddDbContext<EshopContext>(x => x.UseSqlServer(connectionString))
    .AddScoped<IProductService, ProductService>()
    .AddScoped<IOrderService, OrderService>()
    .AddScoped<ICustomerService, CustomerService>().AddSession().AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMvc();
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
