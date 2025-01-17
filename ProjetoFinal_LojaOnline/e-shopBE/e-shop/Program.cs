using e_shop.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EShopContext>(
    o => o.UseSqlServer(builder.Configuration
    .GetConnectionString("EshopDBConnectionString")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            //ValidIssuer = builder.Configuration["Authentication:Issuer"],
            //ValidAudience = builder.Configuration["Authentication:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("Authentication:SecretForKey").Value)),
            
        };
    });
builder.Services.AddCors(options => options.AddPolicy(name: "ShoppingList",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

//builder.Services.AddAuthentication("Bearer")
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new()
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = builder.Configuration["Authentication:Issuer"],
//            ValidAudience = builder.Configuration["Authentication:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(
//                Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
//        };
//    }
//    );

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("SomePolicyName", policy =>
//    {
//        policy.RequireAuthenticatedUser();
//        policy.RequireClaim("ClaimName", "SomeString");
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ShoppingList");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
