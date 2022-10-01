using Api.data;
using FastEndpoints.Swagger;
using FastEndpoints;
using FastEndpoints.Security; //add this
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// adicionando o fastApi
builder.Services.AddFastEndpoints();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddSwaggerDoc(); //add this
builder.Services.AddAuthenticationJWTBearer("123456789abcdefgh"); //add this

var app = builder.Build();
app.UseAuthorization();

// utilizando O fast Api
app.UseFastEndpoints();
app.UseOpenApi(); //add this
app.UseSwaggerUi3(s => s.ConfigureDefaults()); //add this

app.Run();
