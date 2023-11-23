using DataModel;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace Server.Extension
{
    public static class IApplicationBuilderExtensions
    {
        public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/products", (AppDbContext dbContext) =>
            {
                return dbContext.Products.ToListAsync();
            });
            app.MapPost("/api/product/add", async ([FromServices] AppDbContext dbContext, [FromBody] Products product) =>
            {
                await dbContext.Products.AddAsync(product);
                await dbContext.SaveChangesAsync();
            });
            app.MapPut("/api/product/updata", async ([FromServices] AppDbContext dbContext, [FromBody] Products product) =>
            {
                // Получаем предмет по item_number
                var item = await dbContext.Products.FirstOrDefaultAsync(i => i.Name == product.Name);
                if (item == null) return Results.NotFound(new { message = "Товар не найден" });

                // Если предмет найден, изменим данные и отправим обратно клиенту
                item.Name = product.Name;
                item.Code = product.Code;
                item.BoxSize = product.BoxSize;
                item.ProductGroupId = product.ProductGroupId;
                item.ProductStatusId = product.ProductStatusId;
                item.MinimumStock = product.MinimumStock;
                item.MaximumShelfLife = product.MaximumShelfLife;
                await dbContext.SaveChangesAsync();
                return Results.Json(item);
            });

            return app;
        }

        public static IEndpointRouteBuilder MapOrderTypesEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/order-type", (AppDbContext dbContext) =>
            {
                return dbContext.OrderTypes.ToListAsync();
            });
            app.MapGet("/api/order-statuses", (AppDbContext dbContext) =>
            {
                return dbContext.OrderStatuses.ToListAsync();
            });
            app.MapGet("/api/product-status", (AppDbContext dbContext) =>
            {
                return dbContext.ProductStatuses.ToListAsync();
            });
            app.MapGet("/api/product-group", (AppDbContext dbContext) =>
            {
                return dbContext.ProductGroup.ToListAsync();
            });
            app.MapGet("/api/product-in-order", (AppDbContext dbContext) =>
            {
                return dbContext.ProductStatusInOrder.ToListAsync();
            });
            return app;
        }
    }
}
