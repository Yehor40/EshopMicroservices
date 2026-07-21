namespace Ordering.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers => new List<Customer>
    {
        Customer.Create(CustomerId.Of(new Guid("15d867e3-d37b-4a26-9a40-1d393f2a75f6")), "Tony", "tony@mail.com"),
        Customer.Create(CustomerId.Of(new Guid("08b2ae7a-d753-47b3-ba0e-4da1a172e15a")), "Paulie", "paulie@mail.com")
    };

    public static IEnumerable<Product> Products => new List<Product>
    {
        Product.Create(ProductId.Of(new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27")), "IPhone 15", 550),
        Product.Create(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), "OnePlus 12", 350),
        Product.Create(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), "Samsung S11", 450),
        Product.Create(ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8")), "Redmi 10", 250)
    };
    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("Tony", "Soprano", "tony@gmail.com", "Chinsky blv.", "USA", "New Jersey", "38050");
            var address2 = Address.Of("Paulie", "Wallnuts", "paulie@gmail.com", "Broadway No:1", "USA", "New Jersey", "08050");

            var payment1 = Payment.Of("tony", "5555555555554444", "12/28", "355", 1);
            var payment2 = Payment.Of("paulie", "8885555555554444", "06/30", "222", 2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("15d867e3-d37b-4a26-9a40-1d393f2a75f6")),
                OrderName.Of("ORD_1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1);
            order1.Add(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), 2, 450);
            order1.Add(ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8")), 1, 250);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("08b2ae7a-d753-47b3-ba0e-4da1a172e15a")),
                OrderName.Of("ORD_2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2);
            order2.Add(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), 1, 350);
            order2.Add(ProductId.Of(new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27")), 2, 550);

            return new List<Order> { order1, order2 };
        }
    }

}