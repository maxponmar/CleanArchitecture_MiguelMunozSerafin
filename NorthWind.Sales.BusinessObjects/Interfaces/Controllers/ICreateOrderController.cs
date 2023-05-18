namespace NorthWind.Sales.BusinessObjects.Interfaces.Controllers
{
    internal interface ICreateOrderController
    {
        ValueTask<int> CreateOrder(CreateOrderDTO order);
    }
}
