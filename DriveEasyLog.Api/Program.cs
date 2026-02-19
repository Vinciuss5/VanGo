using System.Text;
using DriveEasyLog.Application;
using DriveEasyLog.Application.Contratos;
using DriveEasyLog.Domain;
using DriveEasyLog.Persistence;
using DriveEasyLog.Persistence.Contexto;
using DriveEasyLog.Persistence.Contratos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddCors();
builder.Services.AddDbContext<DriveEasyContext>(options =>
    options.UseSqlite("Data Source=driveeasylog.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DriveEasyLog API",
        Version = "v1",
        Description = "API de transporte escolar"
    });
});
builder.Services.AddScoped<IGeralPersist, GeralPersist>();
builder.Services.AddScoped<IAlunoPersist, AlunoPersist>();
builder.Services.AddScoped<IGeralPersist, GeralPersist>();
builder.Services.AddScoped<IAlunoPersist, AlunoPersist>();
builder.Services.AddScoped<IAlunosService, AlunoService>();
builder.Services.AddScoped<IMotoristaPersist, MotoristaPersist>();
builder.Services.AddScoped<IResponsavelPersist, ResponsavelPersist>();
builder.Services.AddScoped<IMotoristaService, MotoristaService>();
builder.Services.AddScoped<IResponsavelService, ResponsavelService>();
builder.Services.AddScoped<IMotoristaPersist, MotoristaPersist>();
builder.Services.AddScoped<IResponsavelPersist, ResponsavelPersist>();
builder.Services.AddScoped<IEscolaPersist, EscolaPersist>();
builder.Services.AddScoped<IViagemPersist, ViagemPersist>();
builder.Services.AddScoped<IViagemService, ViagemService>();
builder.Services.AddScoped<IPresencaService, PresencaService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddControllers()
    .AddJsonOptions(options => 
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
    );

builder.Services.AddIdentityCore<User>(options => {
    options.Password.RequireDigit = false; // Ajuste conforme a segurança que deseja
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
    options.User.RequireUniqueEmail = true;
})
.AddRoles<Role>()
.AddEntityFrameworkStores<DriveEasyContext>();

// Configuração do JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Sua_Chave_Super_Secreta_Com_Mais_De_64_Caracteres_Para_Seguranca_Total_123456")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins("http://localhost:8080"); // Coloque aqui a URL do seu Front
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x =>
    x.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DriveEasyContext>();
    context.Database.EnsureCreated(); // Cria o banco se não existir
    //DriveEasyContextSeed.Seed(context);
}

app.Run();