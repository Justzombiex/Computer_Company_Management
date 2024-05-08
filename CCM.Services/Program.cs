using CCM.DataAccess.Abstract.Common;
using CCM.DataAccess.Abstract.Components;
using CCM.DataAccess.Repositories;
using CCM.Services.Services;

namespace CCM.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddGrpc();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddSingleton("Data Source=Data.sqlite");
            builder.Services.AddScoped<IPriceRepository, ApplicationRepository>();
            builder.Services.AddScoped<IHardDriveRepository, ApplicationRepository>();
           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<PriceService>();
            app.MapGrpcService<HardDriveService>();
            
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}