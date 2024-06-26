using BuberDinner.Api;
using BuberDinner.Api.Filters;
using BuberDinner.Api.Middelware;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddPresentiation()
    .AddApplication()
    .AddInfraStructure(builder.Configuration);


//builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseMiddleware<ErorrHandlingMiddelware>();
//app.UseExceptionHandler("/erorr");
//app.Map("/erorr", (HttpContext context) =>
//{
//    Exception? exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
//    return Results.Problem();
//});
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
