using LibraryManagement.DataAccessLayer.Data;
using LibraryManagement.DataAccessLayer.Modules.Books;
using LibraryManagement.DataAccessLayer.Modules.Books.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Register the book repository for dependency injection
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// Global error handling for status codes
app.UseStatusCodePagesWithReExecute("/Error/StatusCode", "?statusCode={0}");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/ServerError");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
