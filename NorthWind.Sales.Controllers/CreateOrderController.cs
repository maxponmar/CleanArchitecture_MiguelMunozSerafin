﻿namespace NorthWind.Sales.Controllers
{
    public class CreateOrderController : ICreateOrderController
    {
        readonly ICreateOrderInputPort InputPort;
        readonly ICreateOrderPresenter Presenter;

        public CreateOrderController(ICreateOrderInputPort inputPort, ICreateOrderPresenter presenter)
        {
            InputPort = inputPort;
            Presenter = presenter;
        }

        public async ValueTask<int> CreateOrder(CreateOrderDTO order)
        {
            await InputPort.Handle(order);

            return Presenter.OrderId;
        }
    }
}
