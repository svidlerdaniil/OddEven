using OddEvenServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("Policy");

app.MapControllers();

app.Run();

public partial class Program { }
