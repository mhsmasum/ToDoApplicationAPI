using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDoApp.API.Data;
using ToDoApp.API.Models;
using ToDoApp.API.Services;
using ToDoApp.API.UOW;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "http://www.contoso.com").AllowAnyHeader().AllowAnyMethod();
                      });
});
builder.Services.AddControllers();








#region Identity
builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           );

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddRoles<IdentityRole>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;

}
);
#endregion Identity



#region JWT
var key = Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:JWT_Secret"].ToString());

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});
#endregion Jwt



var serviceProvider = builder.Services.BuildServiceProvider();
var logger = serviceProvider.GetService<ILogger<ControllerBase>>();
builder.Services.AddSingleton(typeof(ILogger), logger);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<INoteService, NoteSservice>();
builder.Services.AddScoped<IBookmarkService, BookmarkService>();
builder.Services.AddScoped<IReminderService, ReminderService>();

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
app.UseCors(MyAllowSpecificOrigins);
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
