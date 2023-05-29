namespace NorthWind.Sales.WebAPI
{
    public static class WebApplicationHelper
    {
        public static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddNorthWindSalesServices(builder.Configuration, "NorthWindConnectionString");

            return builder.Build();
        }

        public static WebApplication ConfigureWebApplication(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseNorthWindSalesEndpoints();

            return app;
        }
    }
}
