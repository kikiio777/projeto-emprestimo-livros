using Emprestimos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Emprestimos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //criando novo serviço e adicionando o dbContext  q e o contexto que foi criado dentro da  pasta data


            builder.Services.AddDbContext<AplicationDbContext>(options =>
            {                        //criando uma configuração  da concetion string  // configurando  conection banco de dados
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); 
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
