using AOPBussinessLayer;
using AOPBussinessLayer.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CleanCodeAPI;
using CleanCodeAPI.Attributes;
using CleanCodeAPI.Middlewares;
using CleanCodeAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ILogger service tan�m� Add Controllerdan gelir.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service Filter olarak tan�mlanan atributeler uygulama i�erisinde Scoped olarak Web Request bazl� otomatik instance al�nacak �ekilde tan�mlanmal�d�r.
builder.Services.AddScoped<PerformanceBenchMarkAttribute>();
// builder.Services.AddScoped<IRepo<Product>>();



// Not Middlewarelere her bir istekte yep yeni bir instance almas� gerekti�inden transient olarak tan�mlan�r.
builder.Services.AddTransient<ErrorHandlingMiddleware>();

// Service Injection
builder.Services.AddScoped<ScopeInstanceService>();
builder.Services.AddTransient<TransientInstanceService>();
builder.Services.AddSingleton<SingletonInstanceService>();

// AutoFac Module Registeration

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
  builder.RegisterModule(new AopBussinessLayerModule());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// normal tan�mlama
app.Use(async (context, next) =>
{
  // burada yap�lacak i�lmlere ait kodlar yaz�l�p daha sonra s�reci a�a��daki middleware devret.
  await next(context);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Yaz�l�mc�dan Developerdan kaynakl� geli�en istisnalar� MapControllers sonra yakalabiliriz. 

//app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();
