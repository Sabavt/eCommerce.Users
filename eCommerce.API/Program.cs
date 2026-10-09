using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure; 
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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt => opt.AddDefaultPolicy(plc => plc.AllowAnyMethod()
.AllowAnyHeader()
.AllowAnyOrigin())
);

var app = builder.Build();

app.UseExceptionHandlingMiddleware(); 
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run(); 