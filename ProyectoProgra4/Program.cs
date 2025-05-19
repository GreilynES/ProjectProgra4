
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProyectoProgra4.Entities;
using ProyectoProgra4.ProjectDataBase;
using ProyectoProgra4.Services.CandidateC;
using ProyectoProgra4.Services.CandidateOfferC;
using ProyectoProgra4.Services.CandidateSkillC;
using ProyectoProgra4.Services.CompanyC;
using ProyectoProgra4.Services.OfferC;
using ProyectoProgra4.Services.OfferSkillC;
using ProyectoProgra4.Services.SkillC;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProjectDataBaseContext>();
builder.Services.AddScoped<ICandidate, CandidateService>();
builder.Services.AddScoped<IOffer, OfferService>();
builder.Services.AddScoped<ICompany, CompanyService>();
builder.Services.AddScoped<ISkill, SkillService>();
builder.Services.AddScoped<ICandidateOffer, CandidateOfferService>();
builder.Services.AddScoped<ICandidateSkill, CandidateSkillService>();
builder.Services.AddScoped<IOfferSkill,  OfferSkillService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "yourdomain.com",
            ValidAudience = "yourdomain.com",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"))
        };
    });

builder.Services.AddAuthorization();

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(x =>
 x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProjectDataBaseContext>();

    if (!context.Companies.Any())
    {
        context.Companies.AddRange(
            new Company
            {
                Name = "Empresa Demo 1",
                Email = "demo1@empresa.com",
                WebSite = "https://demo1.empresa.com"
            },
            new Company
            {
                Name = "Empresa Demo 2",
                Email = "demo2@empresa.com",
                WebSite = "https://demo2.empresa.com"
            },
            new Company
            {
                Name = "Empresa Demo 3",
                Email = "demo3@empresa.com",
                WebSite = "https://demo3.empresa.com"
            }
        );

        context.SaveChanges();
        Console.WriteLine("🌱 Empresas seed cargadas en memoria.");
    }
}


app.Run();
