// This is the main entry point for our User API application, if you please
namespace UserAPI
{
    // This class serves as the application's primary startup coordinator, my lord
    public class Program
    {
        // This method is the application's grand entrance, graciously starting all services
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // This section adds essential services to the dependency injection container, master
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // This section configures the HTTP request processing pipeline, most respectfully
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
