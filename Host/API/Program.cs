using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modules.Authentication.Domain.Entitys;
using Modules.Authentication.Infrastructure.Data;
using Modules.Chat.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
