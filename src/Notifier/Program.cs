using Notifier;
using Notifier.Features.Sms;
using PayamakCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<SmsService>();

builder.Services.AddPayamakService();

builder.Services.Configure<AppSettings>(builder.Configuration);
 
var app = builder.Build();

// TODO: use it in Production env
//if (app.Environment.IsDevelopment())

app.UseSwagger();
app.UseSwaggerUI();
 

app.UseHttpsRedirection();
app.AddEmailEndpoints();
app.AddSmsEndpoints();



app.Run();

 