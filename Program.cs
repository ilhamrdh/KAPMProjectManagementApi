using System.Reflection;
using KAPMProjectManagementApi.Interfaces.Auth;
using KAPMProjectManagementApi.Interfaces.MasterEmployee;
using KAPMProjectManagementApi.Interfaces.MasterProjectManager;
using KAPMProjectManagementApi.Interfaces.MasterRoleProject;
using KAPMProjectManagementApi.Interfaces.MasterUnitProject;
using KAPMProjectManagementApi.Interfaces.TrnProject;
using KAPMProjectManagementApi.Interfaces.TrnProjectAdendum;
using KAPMProjectManagementApi.Interfaces.TrnProjectIssue;
using KAPMProjectManagementApi.Interfaces.TrnProjectReport;
using KAPMProjectManagementApi.Interfaces.TrnProjectReportDtl;
using KAPMProjectManagementApi.Interfaces.TrnProjectSO;
using KAPMProjectManagementApi.Interfaces.TrnProjectTimeline;
using KAPMProjectManagementApi.Interfaces.TrnScheduleInvoice;
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
        Contact = new()
        {
            Name = "KAPM",
            Url = new("https://www.kapm.com"),
        }
    });

    c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer
    {
        Url = "http://localhost:5014",
        Description = "Development"
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
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
builder.Services.AddScoped<IMstRoleProjectRepository, MstRoleProjectRepository>();
builder.Services.AddScoped<IMstEmployeeRepository, MstEmployeeRepository>();
builder.Services.AddScoped<ITrnProjectRepository, TrnProjectRepository>();
builder.Services.AddScoped<ITrnProjectTimelineRepository, TrnProjectTimelineRepository>();
builder.Services.AddScoped<ITrnProjectSORepository, TrnProjectSORepository>();
builder.Services.AddScoped<ITrnProjectReportRepository, TrnProjectReportRepository>();
builder.Services.AddScoped<ITrnProjectReportDtlRepository, TrnProjectReportDtlRepository>();
builder.Services.AddScoped<ITrnProjectIssueRepository, TrnProjectIssueRepository>();
builder.Services.AddScoped<ITrnProjectAdendumRepository, TrnProjectAdendumRepository>();
builder.Services.AddScoped<ITrnScheduleInvoiceRepository, TrnScheduleInvoiceRepository>();


builder.Services.AddScoped<IMstProjectManagerService, MstProjectManagerService>();
builder.Services.AddScoped<IMstUnitProjectService, MstUnitProjectService>();
builder.Services.AddScoped<IMstRoleProjectService, MstRoleProjectService>();
builder.Services.AddScoped<IMstEmployeeService, MstEmployeeService>();
builder.Services.AddScoped<ITrnProjectService, TrnProjectService>();
builder.Services.AddScoped<ITrnProjectTimelineService, TrnProjectTimelineService>();
builder.Services.AddScoped<ITrnProjectSOService, TrnProjectSOService>();
builder.Services.AddScoped<ITrnProjectReportService, TrnProjectReportService>();
builder.Services.AddScoped<ITrnProjectReportDtlService, TrnProjectReportDtlService>();
builder.Services.AddScoped<ITrnProjectIssueService, TrnProjectIssueService>();
builder.Services.AddScoped<ITrnProjectAdendumService, TrnProjectAdendumService>();
builder.Services.AddScoped<ITrnScheduleInvoiceService, TrnScheduleInvoiceService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddHttpClient();

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