
using DeveloperStore.Application.Interfaces;
using DeveloperStore.Application.VendaServices;
using DeveloperStore.Domain.Repositories;
using DeveloperStore.Infrastructure.Persistence;
using DeveloperStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);           

            builder.Services.AddControllers();

            // Adiciona o DbContext diretamente
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IVendaRepository, VendaRepository>();
            builder.Services.AddScoped<IVendaService, VendaService>();

            builder.Services.AddEndpointsApiExplorer();
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
