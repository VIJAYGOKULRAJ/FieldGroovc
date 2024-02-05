using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using CRUD.Services.Services;
using CRUD.Services.Validator;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection"), b =>
        b.MigrationsAssembly("CRUD.Data.MySQL")));
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection")), ServiceLifetime.Scoped);


builder.Services.AddControllersWithViews()
        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterValidator>());
builder.Services.AddTransient<IValidator<Login>, LoginValidator >();

// Configure the default Identity for IdentityUser
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ProductContext>()
    .AddDefaultTokenProviders();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; 
        options.JsonSerializerOptions.DictionaryKeyPolicy = null; 
    });


builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddScoped<ILeadsRepository, LeadsRepository>();

builder.Services.AddScoped<IOpportunities, OpportunitiesRepository>();

builder.Services.AddScoped<IEstimatesRepository, EstimatesRepository>();

builder.Services.AddScoped<IWorkOrdersRepository, WorkOrdersRepository>();

builder.Services.AddScoped<IVendorServices, VendorServices>();

builder.Services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();

builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();

builder.Services.AddControllers();
var key = "thisismysecretkeycreatedbyvijay-45234-5435-234-5345-3245-23452345-345-23453245";

builder.Services.AddCors();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}
builder.Logging.AddConsole();


app.UseCors("AllowAll");
//Addding cors
app.UseCors(options =>
{
    options.AllowAnyOrigin();  // You can customize this to specific origins in production
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
/*
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=fieldGroove}/{action=Index}/{id?}");*/

app.Run();
