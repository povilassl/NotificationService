using Microsoft.EntityFrameworkCore;
using Notifications.Domain.AggregatesModel.UserAggregate;
using Notifications.Infrastructure;
using Notifications.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<NotificationsContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("NotificationsDatabase")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
