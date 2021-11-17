namespace pizza.Mappers
{
    public static class ModelEntityMapper
    {
        public static Entities.Pizza ToPizzaEntity(this Models.UpdatePizza pizza)
        {
            return new Entities.Pizza(
                title: pizza.Title,
                shortName: pizza.ShortName,
                ingradients: string.Join(',', pizza.Ingradients),
                price: pizza.Price,
                stockStatus: pizza.StockStatus.ToEntityEPizzaStockStatus());
        }

        public static Entities.EPizzaStockStatus ToEntityEPizzaStockStatus(this Models.EPizzaStockStatus status)
        => status switch
        {
            Models.EPizzaStockStatus.IN => Entities.EPizzaStockStatus.IN,
            _ => Entities.EPizzaStockStatus.OUT
        };  
          
    }
}