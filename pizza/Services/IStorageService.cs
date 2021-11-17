using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pizza.Services
{
    public interface IStorageService
    {
        Task<List<Entities.Pizza>> QueryPizzasAsync();
        Task<Entities.Pizza> QueryPizzaAsync(Guid id);
        Task<(bool IsSuccess, Exception Exception, Entities.Pizza Pizza)> CreatePizzaAsync(Entities.Pizza pizza);
        Task<bool> PizzaExistsAsync(Guid id);
        Task<(bool IsSuccess, Exception Exception, Entities.Pizza Pizza)> UpdatePizzaAsync(Entities.Pizza pizza,Guid id);
        Task<(bool IsSuccess, Exception Exception)> RemovePizzaAsync(Guid id);

        
        
    }
}