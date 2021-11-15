namespace pizza.Mappers
{
    public static class EnumMappers
    {
        public static Entities.EPizzaStockStatus ToEntityEPizzaStockStatus(this Models.EPizzaStockStatus? status)
        {
            return status switch
            {
                Models.EPizzaStockStatus.InProgress => Entities.EPizzaStockStatus.InProgress,
                Models.EPizzaStockStatus.Ready => Entities.EPizzaStockStatus.Ready,
                _ => Entities.EPizzaStockStatus.None
            };
        }
    }
}