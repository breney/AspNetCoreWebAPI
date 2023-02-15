using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI;
using SmartSchool.WebAPI.DbContexts;
using SmartSchool.WebAPI.Repository;
using SmartSchool.WebAPI.Repository.IRepository;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

services.AddSingleton(mapper);
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddDbContext<ApplicationDbContext>(context => context.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

services.AddScoped<IStudentRepository, StudentRepository>();
services.AddScoped<ITeacherRepository, TeacherRepository>();

services.AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();

services.AddVersionedApiExplorer(opt =>
{
    opt.GroupNameFormat = "'v'VVV";
    opt.SubstituteApiVersionInUrl = true;
})
.AddApiVersioning(opt =>
{
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    opt.ReportApiVersions = true;
});

var apiProviderDescription = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

services.AddSwaggerGen(opt =>
{
    foreach (var description in apiProviderDescription.ApiVersionDescriptions)
    {
        opt.SwaggerDoc(
        description.GroupName,
        new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = "SmartSchool API",
            Version = description.ApiVersion.ToString(),
            TermsOfService = new Uri("http://TermsOfUse.com"),
            Description = "WebAPI Description",
            License = new Microsoft.OpenApi.Models.OpenApiLicense()
            {
                Name = "SmartSchool License",
                Url = new Uri("http://license.com")
            },
            Contact = new Microsoft.OpenApi.Models.OpenApiContact()
            {
                Name = "Bruno Pereira",
                Email = "brunopy2@gmail.com",
                Url = new Uri("http://programming.com")
            }
        });
    }
    
    var xmlComentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlComentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlComentsFile);

    opt.IncludeXmlComments(xmlComentsFullPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.DocumentTitle = "SchoolWeb API";
        foreach (var description in apiProviderDescription.ApiVersionDescriptions)
        {
            s.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
