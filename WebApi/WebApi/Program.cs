namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Cross-Origin Resource Sharing (CORS) to allow the Web API to accept requests from specific origins.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", policy =>
                {
                    // Define allowed origins for development and production environments.
                    var developmentOrigins = new[] { "http://localhost:3000" }; // Local development origin
                    var productionOrigins = new[] { "https://localhost:3000" }; // Production origin

                    // Choose the allowed origins based on the current environment (Development or Production).
                    var allowedOrigins = builder.Environment.IsDevelopment() ? developmentOrigins : productionOrigins;

                    // Configure the CORS policy with the allowed origins, headers, and methods.
                    policy.WithOrigins(allowedOrigins)
                          .AllowAnyHeader() // Allows all headers.
                          .AllowAnyMethod(); // Allows all HTTP methods.
                });
            });

            // Add controllers to the service collection.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // Enable Swagger UI for API documentation in development environments.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Use the CORS policy
            app.UseCors("AllowSpecificOrigin");

            // Adds Authorization middleware to the pipeline.
            app.UseAuthorization();

            // Map controller routes. This makes the application respond to incoming requests using the configured controllers.
            app.MapControllers();

            app.Run();
        }
    }
}
