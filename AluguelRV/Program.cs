using AluguelRV.Api;
using AluguelRV.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(Authentication.Options);

builder.Services.ConfigureDependencyInjection();
builder.Services.ConfigureAutoMapper();

builder.Services.ConfigureAuthentication(builder);

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

//app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.ConfigureApi();

app.Run();