using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using SharedGroceryListAPI.Models;
//TEST
var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.Authority = "https://dev-1qptdla0pgqbqxfn.us.auth0.com/";
        options.Audience = "https://sharedgrocerylist.mycompany.com";
    });

    builder.Services.AddMvc();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:3000", "http://localhost:5173", "https://appname.azurestaticapps.net");
        });
});

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ItemDBContext>(options => options.UseMySql(configuration.GetConnectionString("Database"), ServerVersion.AutoDetect(configuration.GetConnectionString("Database"))));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.UseAuthentication();
app.UseRouting(); 
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();