using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pizza.Services
{
    public interface IStorageService
    {
        Task<(bool IsSuccess, Exception exception)> GetPizzaAsync(Entities.Pizza pizza);

        Task<List<Entities.Pizza>> GetALLAsync(
            Guid id = default(Guid),
            string title = default(string),
            string shortName = default(string),
            string ingradients = default(string),
            Entities.EPizzaStockStatus? stockStatus = null,
            string price = default(string));
        
        Task<(bool IsSuccess, Exception exception)> UpdatePizzaAsync(Entities.Pizza pizza);
        Task<(bool IsSuccess, Exception exception)> CreatePizzaAsync(Entities.Pizza pizza);


        Task<(bool IsSuccess, Exception exception)> DeletePizzaAsync(Guid id);

        
        
    }
}