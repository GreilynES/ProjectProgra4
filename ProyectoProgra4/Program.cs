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

// Inyección de dependencias
builder.Services.AddScoped<ProjectDataBaseContext>();
builder.Services.AddScoped<ICandidate, CandidateService>();
builder.Services.AddScoped<IOffer, OfferService>();
builder.Services.AddScoped<ICompany, CompanyService>();
builder.Services.AddScoped<ISkill, SkillService>();
builder.Services.AddScoped<ICandidateOffer, CandidateOfferService>();
builder.Services.AddScoped<ICandidateSkill, CandidateSkillService>();
builder.Services.AddScoped<IOfferSkill, OfferSkillService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

// Autenticación JWT
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

// Controladores y configuración de JSON
builder.Services.AddControllers()
    .AddNewtonsoftJson(x =>
        x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
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

// 🌱 Crear DB y aplicar seed (HasData)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProjectDataBaseContext>();
    context.Database.EnsureCreated(); // Carga datos de HasData
}

app.Run();
