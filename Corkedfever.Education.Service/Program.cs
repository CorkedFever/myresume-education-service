using Corkedfever.Common.Data;
using Corkedfever.Educations.Business;
using Corkedfever.Educations.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IEducationService, EducationService>();
builder.Services.AddSingleton<IEducationRepository, EducationRepository>();
builder.Services.AddDbContextFactory<CorkedFeverDataContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentConnection"), b => b.MigrationsAssembly("Corkedfever.Education.Service"));
    }
    else
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ContainerConnection"), b => b.MigrationsAssembly("Corkedfever.Education.Service"));
    }
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
