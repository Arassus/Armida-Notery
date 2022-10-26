using Armida.Notery.Data.EF.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder
    //Services Registration
    //Services.AddScoped<IList<int>, List<int>>();
    .Services.AddControllers()
    .Services.AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<NoteryDataContextPostreSQL>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("NoteryDatabaseConnectionString")));

var app = builder.Build();
//Register middleware here
//app.UseAuthentication();
//app.UseCookiePolicy();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
        .UseSwaggerUI();
}

app.UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();
app.Run();