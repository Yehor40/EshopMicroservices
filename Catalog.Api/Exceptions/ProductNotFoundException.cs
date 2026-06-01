using ClassLibrary1.Exceptions;

namespace Catalogue.Api.Exceptions;

public class ProductNotFoundException: NotFoundException
{
    public ProductNotFoundException(Guid Id): base("Product",Id)
    {
    }
}