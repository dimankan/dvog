using Dvog.API.Controllers;
using Dvog.DataAccess;
using Dvog.DataAccess.Repositories;
using Dvog.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DvogDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DvogDbContext))));
builder.Services.AddControllers().AddControllersAsServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ModelServiceA>(x =>
{
    var repositoryA = x.GetRequiredService<ModelRepositoryA>();
    var repositoryB = x.GetRequiredService<ModelRepositoryB>();
    var logger = x.GetRequiredService<ILogger<ModelServiceA>>();
    return new ModelServiceA(logger, repositoryA, repositoryB);
});
builder.Services.AddScoped<ModelServiceB>();
builder.Services.AddTransient<ModelRepositoryA>();
builder.Services.AddScoped<ModelRepositoryB>();
builder.Services.AddScoped<IBlogsRepository, BlogsRepository>();
builder.Services.AddAutoMapper(x => x.AddProfile<MappingProfile>());
builder.Host.UseDefaultServiceProvider(options =>
{
    options.ValidateOnBuild = true;
    options.ValidateScopes = true;
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
