namespace NorthWind.Sales.UseCases.CreateOrder
{
    public class CreateOrderInteractor : ICreateOrderInputPort
    {
        readonly ICreateOrderOutputPort OutputPort;
        readonly INorthWindSalesCommandsRepository Repository;

        public CreateOrderInteractor(ICreateOrderOutputPort outputPort, INorthWindSalesCommandsRepository repository)
        {
            OutputPort = outputPort;
            Repository = repository;
        }

        public async ValueTask Handle(CreateOrderDTO orderDTO)
        {
            OrderAggregate Order = OrderAggregate.From(orderDTO);

            await Repository.CreateOrder(Order);
            await Repository.SaveChanges();
            await OutputPort.Handle(Order.Id);
        }
    }
}