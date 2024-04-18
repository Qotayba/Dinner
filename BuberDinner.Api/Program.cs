using BuberDinner.Api.Filters;
using BuberDinner.Api.Middelware;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddApplication()
    .AddInfraStructure(builder.Configuration);


builder.Services.AddControllers(options=>options.Filters.Add<ErorrHandlingFilterAttribute>());
//builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
