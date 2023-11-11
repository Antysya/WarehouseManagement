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
            app.MapPost("/api/products/add", async ([FromServices] AppDbContext dbContext, [FromBody] Products product) =>
            {
                await dbContext.Products.AddAsync(product);
                await dbContext.SaveChangesAsync();
            });
            return app;
        }
    }
}
