namespace pizza.Mappers
{
    public static class ModelEntityMapper
    {
        public static Entities.Pizza ToPizzaEntity(this Models.Pizza pizza)
        {
            return new Entities.Pizza(
                title: pizza.Title,
                shortName: pizza.ShortName,
                ingradients: pizza.Ingradients,
                price: pizza.Price,
                stockStatus: pizza.StockStatus.ToEntityEPizzaStockStatus()
                

            );
        }  
          
    }
}