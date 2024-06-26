using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Services.RequestHandlers.ManageCustomer;
using FluentValidation;
using Services.Validators.Customer;
using Serilog;
using Serilog.Events;
using Microsoft.AspNetCore.Authentication.JwtBearer;
/*using FluentValidation.AspNetCore;*/

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Host.UseSerilog((ctx, config) => config
	.MinimumLevel.Information()
	.WriteTo.Console()
	.WriteTo.File("Logs/WebApiTraining.log", LogEventLevel.Warning, rollingInterval: RollingInterval.Day)
);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<DBContext>(dbContextBuilder =>
{
	dbContextBuilder.UseSqlite(configuration.GetConnectionString("Sqlite"));
});

builder.Services.AddMediatR(typeof(CreateCustomerHandler));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCustomerValidator));
/*builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCustomerValidator>());*/

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
        options.Authority = configuration["Jwt:Authority"];

        // audience is optional, make sure you read the following paragraphs
        // to understand your options
        options.TokenValidationParameters.ValidateAudience = false;

        // it's recommended to check the type header to avoid "JWT confusion" attacks
        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();

	using var scope = app.Services.CreateScope();
	var db = scope.ServiceProvider.GetRequiredService<DBContext>();
	db.Database.EnsureCreated();
}

app.UseExceptionHandler("/error");

app.UseAuthorization();

app.MapControllers();

try
{
	Log.Information("Starting web api host.");
	app.Run();
	return 0;
}
catch (Exception ex)
{
	Log.Fatal(ex, "Host terminated unexpectedly.");
	return 1;
}
finally
{
	Log.CloseAndFlush();
}
