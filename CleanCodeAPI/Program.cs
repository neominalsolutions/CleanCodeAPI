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

// ILogger service tanýmý Add Controllerdan gelir.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service Filter olarak tanýmlanan atributeler uygulama içerisinde Scoped olarak Web Request bazlý otomatik instance alýnacak þekilde tanýmlanmalýdýr.
builder.Services.AddScoped<PerformanceBenchMarkAttribute>();
// builder.Services.AddScoped<IRepo<Product>>();



// Not Middlewarelere her bir istekte yep yeni bir instance almasý gerektiðinden transient olarak tanýmlanýr.
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

// normal tanýmlama
app.Use(async (context, next) =>
{
  // burada yapýlacak iþlmlere ait kodlar yazýlýp daha sonra süreci aþaðýdaki middleware devret.
  await next(context);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Yazýlýmcýdan Developerdan kaynaklý geliþen istisnalarý MapControllers sonra yakalabiliriz. 

//app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();
