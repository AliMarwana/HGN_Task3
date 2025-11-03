
using HGN_Task3.Data;
using HGN_Task3.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;

namespace HGN_Task3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(option =>
option.UseNpgsql(builder.Configuration.GetConnectionString("contextConnection")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSingleton<Kernel>(serviceProvider =>
            {
                var apiKey = builder.Configuration["Groq:ApiKey"]
                           ?? throw new InvalidOperationException("Groq API Key not configured");

                var modelId = builder.Configuration["Groq:ModelId"] ?? "llama-3.1-8b-instant";
                var baseUrl = builder.Configuration["Groq:BaseUrl"] ?? "https://api.groq.com/openai/v1/";

                var kernelBuilder = Kernel.CreateBuilder();

                kernelBuilder.AddOpenAIChatCompletion(
                    modelId: modelId,
                    apiKey: apiKey,
                    httpClient: new HttpClient { BaseAddress = new Uri(baseUrl) });

                return kernelBuilder.Build();
            });
           builder.Services.AddScoped<FlashcardRepository>();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
