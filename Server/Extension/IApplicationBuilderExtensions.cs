using DataModel;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace Server.Extension
{
    public static class IApplicationBuilderExtensions
    {
        //public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
        //{
        //    app.MapGet("/api/products", (AppDbContext dbContext) =>
        //    {
        //        return dbContext.Products.ToListAsync();
        //    });
        //    app.MapPost("/api/product/add", async ([FromServices] AppDbContext dbContext, [FromBody] Products product) =>
        //    {
        //        await dbContext.Products.AddAsync(product);
        //        await dbContext.SaveChangesAsync();
        //    });

        //    return app;
        //}

        //public static IEndpointRouteBuilder MapPlacementEndpoints(this IEndpointRouteBuilder app)
        //{
        //    app.MapGet("/api/placement", (AppDbContext dbContext) =>
        //    {
        //        return dbContext.ProductsOnShelves.ToListAsync();
        //    });
        //    return app;
        //}

        //public static IEndpointRouteBuilder MapOrderTypesEndpoints(this IEndpointRouteBuilder app)
        //{
        //    app.MapGet("/api/order-type", (AppDbContext dbContext) =>
        //    {
        //        return dbContext.OrderTypes.ToListAsync();
        //    });
        //    app.MapPost("/api/order-type/add", async ([FromServices] AppDbContext dbContext, [FromBody] OrderTypes type) =>
        //    {
        //        await dbContext.OrderTypes.AddAsync(type);
        //        await dbContext.SaveChangesAsync();
        //    });
        //    app.MapGet("/api/order-statuses", (AppDbContext dbContext) =>
        //    {
        //        return dbContext.OrderStatuses.ToListAsync();
        //    });
        //    app.MapGet("/api/product-status", (AppDbContext dbContext) =>
        //    {
        //        return dbContext.ProductStatuses.ToListAsync();
        //    });
        //    app.MapGet("/api/product-group", (AppDbContext dbContext) =>
        //    {
        //        return dbContext.ProductGroup.ToListAsync();
        //    });
        //    app.MapGet("/api/product-in-order", (AppDbContext dbContext) =>
        //    {
        //        return dbContext.ProductStatusInOrder.ToListAsync();
        //    });
        //    return app;
        //}
    }
}
