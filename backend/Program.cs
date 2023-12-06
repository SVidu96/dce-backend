using backend.Services;
using backend.Services.Interfaces;

namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var AllowSpecificOrigins = "_AllowSpecificOrigins";
            
            
            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins(builder.Configuration.GetValue<string>("allowedOrigins").Split(";"));
                                  });
            });

            builder.Services.AddTransient<IMontyHallService, MontyHallService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseCors(AllowSpecificOrigins);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}