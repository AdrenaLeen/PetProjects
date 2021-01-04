using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Каяк",
                        Description = "Лодка на одного человека",
                        Category = "Watersports",
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Спасательный жилет",
                        Description = "Защитный и модный",
                        Category = "Watersports",
                        Price = 48.95m
                    },
                    new Product
                    {
                        Name = "Футбольный мяч",
                        Description = "Утвержденный FIFA размер и вес",
                        Category = "Soccer",
                        Price = 19.5m
                    },
                    new Product
                    {
                        Name = "Угловые флаги",
                        Description = "Придаёт профессиональные штрихи вашему игровому полю",
                        Category = "Soccer",
                        Price = 34.95m
                    },
                    new Product
                    {
                        Name = "Стадион",
                        Description = "Плоский стадион на 35 000 мест",
                        Category = "Soccer",
                        Price = 79500
                    },
                    new Product
                    {
                        Name = "Думательная шапочка",
                        Description = "Улучшает эффективность работы вашего мозга на 75%.",
                        Category = "Chess",
                        Price = 16
                    },
                    new Product
                    {
                        Name = "Неустойчивый стул",
                        Description = "Скрыто ставит соперника в неудобное положение.",
                        Category = "Chess",
                        Price = 29.95m
                    },
                    new Product
                    {
                        Name = "Шахматная доска",
                        Description = "Забавная игра для всей семьи",
                        Category = "Chess",
                        Price = 75
                    },
                    new Product
                    {
                        Name = "Блестящий король",
                        Description = "Позолоченный, украшенный бриллиантами король",
                        Category = "Chess",
                        Price = 1200
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
