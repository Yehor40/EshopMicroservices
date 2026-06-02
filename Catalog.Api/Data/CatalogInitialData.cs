using Marten.Schema;

namespace Catalogue.Api.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();
        if (await session.Query<Product>().AnyAsync()) return;

        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
    {
        new Product()
        {
            Id = new Guid("a5d5e0ab-8eb2-419b-94d8-a67bdd35bab4"),
            Name = "Olma Milk",
            Description = "Milk is a good idea.",
            ImageFile = "milk.jpg",
            Price = 1.00M,
            Category = new List<string> { "Dairy products" }
        },
        new Product()
        {
            Id = new Guid("dd3cca8f-ab51-4905-beeb-317583c93b71"),
            Name = "Flank steak",
            Description = "Flank steak is tasty",
            ImageFile = "steak.jpg",
            Price = 8.00M,
            Category = new List<string> { "Meats" }
        },
        new Product()
        {
            Id = new Guid("4a2b8e12-cb34-4609-b68a-112233445566"),
            Name = "Ribeye steak",
            Description = "Premium marbled beef cut, incredibly juicy and flavorful",
            ImageFile = "ribeye.jpg",
            Price = 18.50M,
            Category = new List<string> { "Meats" }
        },
        new Product()
        {
            Id = new Guid("9f8e7d6c-b5a4-4321-ae98-77889900aabb"),
            Name = "Chicken breasts",
            Description = "Fresh, skinless chicken breasts, high in protein",
            ImageFile = "chicken_breast.jpg",
            Price = 6.20M,
            Category = new List<string> { "Meats", "Poultry" }
        },
        new Product()
        {
            Id = new Guid("11223344-5566-7788-9900-abcdef123456"),
            Name = "Salmon fillet",
            Description = "Wild-caught Atlantic salmon fillet, rich in Omega-3",
            ImageFile = "salmon.jpg",
            Price = 14.99M,
            Category = new List<string> { "Fish", "Seafood" }
        },
        new Product()
        {
            Id = new Guid("abcdef12-3456-7890-abcd-ef1234567890"),
            Name = "Broccoli rabe",
            Description = "Fresh organic broccoli greens, perfect for steaming",
            ImageFile = "broccoli.jpg",
            Price = 2.50M,
            Category = new List<string> { "Vegetables", "Organic" }
        },
        new Product()
        {
            Id = new Guid("fe3dcba9-8765-4321-ba98-76543210fedc"),
            Name = "Sweet potatoes",
            Description = "Nutrient-rich sweet potatoes, great for baking or fries",
            ImageFile = "sweet_potatoes.jpg",
            Price = 3.10M,
            Category = new List<string> { "Vegetables", "Sides" }
        },
        new Product()
        {
            Id = new Guid("550e8400-e29b-41d4-a716-446655440000"),
            Name = "Basmati rice",
            Description = "Premium long-grain aromatic rice",
            ImageFile = "rice.jpg",
            Price = 4.00M,
            Category = new List<string> { "Sides", "Grains" }
        },
        new Product()
        {
            Id = new Guid("fa4b219c-7231-4d3b-9a4f-8899aabbccdd"),
            Name = "Craft IPA Beer",
            Description = "Locally brewed India Pale Ale with a strong hoppy aroma",
            ImageFile = "craft_beer.jpg",
            Price = 4.50M,
            Category = new List<string> { "Beverages", "Alcohol" }
        },
        new Product()
        {
            Id = new Guid("7c9e3b1a-2d4f-4e6a-8b0c-1d2e3f4a5b6c"),
            Name = "Olive oil Extra Virgin",
            Description = "Cold-pressed Mediterranean olive oil of the highest quality",
            ImageFile = "olive_oil.jpg",
            Price = 9.95M,
            Category = new List<string> { "Pantry", "Organic" }
        }
    };
}