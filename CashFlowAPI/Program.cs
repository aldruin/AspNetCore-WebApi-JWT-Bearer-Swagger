using CashFlowAPI.Application.Configuration;
using CashFlowAPI.Infrastructure.Configuration;
namespace CashFlowAPI.Api;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services
            .RegisterApplication(builder.Configuration)
            .RegisterRepository(builder.Configuration.GetConnectionString("CashFlow"));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("CorsPolicy");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}