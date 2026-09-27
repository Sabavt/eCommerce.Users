using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services
    .AddControllers()
    .AddJsonOptions(opt => 
    opt.JsonSerializerOptions.Converters
    .Add(new JsonStringEnumConverter())
    ); 

builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<ApplicationUserMappingProfile>(); 
    cfg.AddProfile<RegisterRequestMappingProfile>(); 
});
 
var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseExceptionHandler(errorHandlingPath: "/Error");
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization(); 
app.MapControllers();

app.Run(); 