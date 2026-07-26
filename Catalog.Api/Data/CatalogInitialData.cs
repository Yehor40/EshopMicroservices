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
            Id = new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27"),
            Name = "IPhone 15",
            Description = "Apple iPhone 15 smartphone",
            ImageFile = "iphone15.jpg",
            Price = 550M,
            Category = new List<string> { "Smartphones" }
        },
        new Product()
        {
            Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
            Name = "OnePlus 12",
            Description = "OnePlus 12 smartphone",
            ImageFile = "oneplus12.jpg",
            Price = 350M,
            Category = new List<string> { "Smartphones" }
        },
        new Product()
        {
            Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
            Name = "Samsung S11",
            Description = "Samsung Galaxy S11 smartphone",
            ImageFile = "samsung-s11.jpg",
            Price = 450M,
            Category = new List<string> { "Smartphones" }
        },
        new Product()
        {
            Id = new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8"),
            Name = "Redmi 10",
            Description = "Xiaomi Redmi 10 smartphone",
            ImageFile = "redmi10.jpg",
            Price = 250M,
            Category = new List<string> { "Smartphones" }
        }
    };
}