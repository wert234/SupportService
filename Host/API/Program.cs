using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modules.Authentication.Controllers;
using Modules.Authentication.Domain.Entitys;
using Modules.Authentication.Domain.JWT.Classes;
using Modules.Authentication.Infrastructure.Data;
using Modules.Chat.Controllers;
using Modules.Chat.Infrastructure.Data;
using Shared.Infrastructure.Common;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Modules.Authentication.Application.Handlers;
using Modules.Authentication.Application.Commands;
using Modules.Chat.Application.Command;
using Modules.Chat.Application.Handlers;
using Modules.Chat.Application.Common;
using Modules.Chat.Infrastructure.Common;
using Modules.Chat.Application.Commands;
using Modules.Chat.Application.Querys;
using Modules.Authentication.Application.Common;
using Modules.Authentication.Infrastructure.Common;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region Jwt Settings

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
options.TokenValidationParameters = new TokenValidationParameters()
{
   ValidateIssuer = true,
   ValidateAudience = true,
   ValidateLifetime = true,
   ValidateIssuerSigningKey = true,
   ValidIssuer = builder.Configuration["Jwt:Issuer"],
   ValidAudience = builder.Configuration["Jwt:Audience"],
   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
};
});
builder.Services.AddTransient<JwtTokenGenerator>(); 

#endregion

builder.Services.AddControllers()
   .AddApplicationPart(typeof(AuthenticationController).Assembly)
   .AddApplicationPart(typeof(AppealsController).Assembly)
   .AddApplicationPart(typeof(MessageController).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
    });
});

#region MediatR Settings

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblies(typeof(RegistrationHandle).Assembly, typeof(RegistrationCommand).Assembly);
    options.RegisterServicesFromAssemblies(typeof(AuthorizationHandle).Assembly, typeof(AuthorizationCommand).Assembly);
    options.RegisterServicesFromAssemblies(typeof(CreateAppealHandler).Assembly, typeof(CreateAppealCommand).Assembly);
    options.RegisterServicesFromAssemblies(typeof(SendMessageHandler).Assembly, typeof(SendMessageCommand).Assembly);
    options.RegisterServicesFromAssemblies(typeof(CreateAppealHandler).Assembly, typeof(CreateAppealCommand).Assembly);
    options.RegisterServicesFromAssemblies(typeof(CloseAppealsHandler).Assembly, typeof(CloseAppealsCommand).Assembly);
    options.RegisterServicesFromAssemblies(typeof(GetHistoryAppealsHandler).Assembly, typeof(GetHistoryAppealsQuery).Assembly);
    options.RegisterServicesFromAssemblies(typeof(GetCurrentAppealsHandler).Assembly, typeof(GetCurrentAppealsQuery).Assembly);
}); 

builder.Services.AddScoped<IAppealRepository, AppealRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

#region DataBase Settings

#region User DataBase

builder.Services.AddDbContext<UserDbContext>(options =>
{
options.UseSqlServer(builder.Configuration.GetConnectionString("UsersDbConnection"), b => b.MigrationsAssembly("Modules.Authentication.Infrastructure"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
{
    options.Password = new PasswordOptions
    {
        RequireNonAlphanumeric = false,
        RequireDigit = false,
        RequiredLength = 3,
        RequiredUniqueChars = 0,
        RequireLowercase = false,
        RequireUppercase = false
    };
})
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

#endregion

#region Appeal DataBase

builder.Services.AddDbContext<AppealDbContext>(options =>
{
options.UseSqlServer(builder.Configuration.GetConnectionString("AppealsDbConnection"), b => b.MigrationsAssembly("Modules.Chat.Infrastructure"));
});  

#endregion

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();