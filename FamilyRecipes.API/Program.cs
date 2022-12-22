using FamilyRecipes.API.Repositories;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(swag =>
{
	// setting up xml and comments for Swagger
	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	swag.IncludeXmlComments(xmlPath);
});

builder.Services.AddSingleton<IDBConnector, CosmosDB>();
builder.Services.AddSingleton<ICosmosService, CosmosService>();

// Cross-Origin Resource Sharing (CORS) is an HTTP feature that enables a web application running under one domain to access resources in another domain.
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()); // configure a policy
});

// Setting up the Serilog settings using our settings in appsettings
builder.Host.UseSerilog((context, loggerConfig) =>
		loggerConfig.WriteTo.Console()
		.ReadFrom.Configuration(context.Configuration)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();