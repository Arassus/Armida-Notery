using Amrida.Notery.Presentation.Core.Repositories;
using Amrida.Notery.Presentation.Core.Services;
using API.Profiles;
using API.Services;
using Armida.Notery.Data.EF;
using Armida.Notery.Data.EF.PostgreSQL;
using Armida.Notery.Data.EF.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new NoteryMappingProfile());
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient<INotebookRepository, NotebookRepository>();
builder.Services.AddScoped<INotebookService, NotebookService>();

builder.Services.AddControllers()
    .Services.AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services.AddScoped<IApplicationDataContext, NoteryDataContextPostgreSQL>();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<NoteryDataContextPostgreSQL>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("NoteryDatabaseConnectionString")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
        .UseSwaggerUI();
}

app.UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();
app.Run();