using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PrimeiraAPIv01.Data;

namespace PrimeiraAPIv01.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}


public static class BrandEndpoints
{
	public static void MapBrandEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Brand", async (BikestoreContext db) =>
        {
            return await db.Brands.ToListAsync();
        })
        .WithName("GetAllBrands");

        routes.MapGet("/api/Brand/{id}", async (int BrandId, BikestoreContext db) =>
        {
            return await db.Brands.FindAsync(BrandId)
                is Brand model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetBrandById");

        routes.MapPut("/api/Brand/{id}", async (int BrandId, Brand brand, BikestoreContext db) =>
        {
            var foundModel = await db.Brands.FindAsync(BrandId);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(brand);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })   
        .WithName("UpdateBrand");

        routes.MapPost("/api/Brand/", async (Brand brand, BikestoreContext db) =>
        {
            db.Brands.Add(brand);
            await db.SaveChangesAsync();
            return Results.Created($"/Brands/{brand.BrandId}", brand);
        })
        .WithName("CreateBrand");


        routes.MapDelete("/api/Brand/{id}", async (int BrandId, BikestoreContext db) =>
        {
            if (await db.Brands.FindAsync(BrandId) is Brand brand)
            {
                db.Brands.Remove(brand);
                await db.SaveChangesAsync();
                return Results.Ok(brand);
            }

            return Results.NotFound();
        })
        .WithName("DeleteBrand");
    }
}