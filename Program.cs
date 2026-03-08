using KeyedServiceExample_With_DI.MiddleWare;
using KeyedServiceExample_With_DI.Repositry;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyedScoped<IPaymentService, CreditCard>("CreditCard");
builder.Services.AddKeyedScoped<IPaymentService, DebitCard>("DebitCard");

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.MapAllEndpoints();
app.Run();
