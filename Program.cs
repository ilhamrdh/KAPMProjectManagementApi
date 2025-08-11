using KAPMProjectManagementApi.Interfaces.MasterProjectManager;
using KAPMProjectManagementApi.Interfaces.MasterUnitProject;
using KAPMProjectManagementApi.Interfaces.TrnProject;
using KAPMProjectManagementApi.Repositories;
using KAPMProjectManagementApi.Schema;
using KAPMProjectManagementApi.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "API for Project Management KAPM",
        Version = "v1",
        Description = "API for Project Management KAPM",

    });

    c.UseAllOfToExtendReferenceSchemas();
    c.SupportNonNullableReferenceTypes();
});
builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddDbContext<ProjectManagementDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

builder.Services.AddScoped<IMstProjectManagerRepository, MstProjectManagerRepository>();
builder.Services.AddScoped<IMstUnitProjectRepository, MstUnitProjectRepository>();
builder.Services.AddScoped<ITrnProjectRepository, TrnProjectRepository>();


builder.Services.AddScoped<IMstProjectManagerService, MstProjectManagerService>();
builder.Services.AddScoped<IMstUnitProjectService, MstUnitProjectService>();
builder.Services.AddScoped<ITrnProjectService, TrnProjectService>();

builder.Services.AddProblemDetails();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();