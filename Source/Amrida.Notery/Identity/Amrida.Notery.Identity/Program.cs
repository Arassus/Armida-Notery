using Amrida.Notery.Identity.Core;
using Amrida.Notery.Identity.Core.Repositories;
using Amrida.Notery.Identity.Core.Services;
using Amrida.Notery.Identity.Data.EF.PostgreSQL;
using Amrida.Notery.Identity.Data.EF.Repositories;
using Amrida.Notery.Identity.Data.EF.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IIdentityRepository, IdentityRepository>();
builder.Services.AddScoped<IIdentityDataService, IdentityDataService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IIdentityDataContext, IdentityDataContextPostgreSQL>();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<IdentityDataContextPostgreSQL>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("IdentityDatabaseConnectionString")));

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
