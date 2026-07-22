using ClassLibrary1.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders;

public class GetOrdersHandler(IApplicationDbContext dbContext):IQueryHandler<GetOrdersQuery,GetOrdersResult>
{
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.paginationRequest.PageIndex;
        var pageSize = query.paginationRequest.PageSize;
        var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);
        var orders = await dbContext.Orders
            .Include(order => order.OrderItems)
            .OrderBy(o=>o.OrderName.Value)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        return new GetOrdersResult(
            new PaginatedResult<OrderDto>(pageIndex, pageSize, totalCount,orders.ToOrderDtoList()));
    }
}