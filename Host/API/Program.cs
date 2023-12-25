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
using Modules.Authentication.Application.Queries;

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
   .AddApplicationPart(typeof(ChatController).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region MediatR Settings

builder.Services.AddMediatR(options =>
{
options.RegisterServicesFromAssemblies(typeof(GetTokenHandler).Assembly, typeof(GetTokenQuerie).Assembly);
}); 

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

app.UseAuthorization();

app.MapControllers();

app.Run();
