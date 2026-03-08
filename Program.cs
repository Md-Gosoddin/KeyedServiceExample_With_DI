using KeyedServiceExample_With_DI.MiddleWare;
using KeyedServiceExample_With_DI.Repositry;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPaymentService, CreditCard>();
builder.Services.AddScoped<IPaymentService, DebitCard>();
builder.Services.AddKeyedScoped<IPaymentFactory, PaymentFactory>(Paymentsystems.SelectedPayment);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.MapAllEndpoints();
app.Run();
