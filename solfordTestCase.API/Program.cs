using Microsoft.EntityFrameworkCore;
using solfordTestCase.Database.Repository;
using solfordTestCase.Database.Services;
using solfordTestCase.Domain.Repository;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", false);

builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("MsSqlConnection"),
        b => b.MigrationsAssembly("solfordTestCase.API")
        )
);

builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IProviderRepository, ProviderRepository>();
builder.Services.AddTransient<IOrderItemRepository, OrderItemRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDirectoryBrowser();

var app = builder.Build();


app.UseCors(builder => builder.WithOrigins("https://localhost:7252/")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, @"..\clientHtmlApp")),
    //RequestPath = "/clientHtmlApp", - откоменть если хочешь вызывать по отдельному пути а не руту
    EnableDirectoryBrowsing = true //если фалсе то не будет показывать содержание папки когда нету индекс файла
});

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
