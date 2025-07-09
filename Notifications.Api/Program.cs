using Microsoft.EntityFrameworkCore;
using Notifications.Api.Services.Localizations;
using Notifications.Api.Services.Notifications.Send.Email.AmazonSns;
using Notifications.Api.Services.Notifications.Send.Email.Twilio;
using Notifications.Api.Services.Notifications.Send.Email.Vonage;
using Notifications.Domain.AggregatesModel.Entities.Notification;
using Notifications.Domain.AggregatesModel.Entities.User;
using Notifications.Infrastructure;
using Notifications.Infrastructure.AppSettings.NotificationServices;
using Notifications.Infrastructure.Managers.Notifications.Email;
using Notifications.Infrastructure.Managers.Notifications.Sms;
using Notifications.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<NotificationServicesSettings>(
    builder.Configuration.GetSection("NotificationServices")
);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

builder.Services.AddScoped<IAmazonSnsEmailNotificationService, AmazonSnsEmailNotificationService>();
builder.Services.AddScoped<ITwilioEmailNotificationService, TwilioEmailNotificationService>();
builder.Services.AddScoped<IVonageEmailNotificationService, VonageEmailNotificationService>();

builder.Services.AddScoped<ILocalizationService, LocalizationService>();

builder.Services.AddSingleton<IEmailNotificationServicesManager, EmailNotificationServicesManager>();
builder.Services.AddSingleton<ISmsNotificationServicesManager, SmsNotificationServicesManager>();

//TODO: Register hangfire + register recurring Job

builder.Services.AddDbContext<NotificationsContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

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
