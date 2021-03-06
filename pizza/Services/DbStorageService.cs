using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pizza.Data;
using pizza.Entities;

namespace pizza.Services
{
    public class DbStorageService : IStorageService
    {
        private readonly PizzaDbContext _context;
    
        public DbStorageService(PizzaDbContext context)
        {
            _context = context;
        }

        public async Task<(bool IsSuccess, Exception Exception, Pizza Pizza)> CreatePizzaAsync(Pizza pizza)
        {
            if(await PizzaExistsAsync(pizza.Id))
            {
                return (false, new ArgumentException($"There is no Pizza with given ID: {pizza.Id}"), null);
            }

            try
            {
                await _context.Pizzas.AddAsync(pizza);
                await _context.SaveChangesAsync();

                return (true, null, pizza);
            }
            catch(Exception e)
            {
                return (false, e, null);
            }
        }

        public Task<bool> PizzaExistsAsync(Guid id)
            => _context.Pizzas
            .AnyAsync(p => p.Id == id);

        public Task<Pizza> QueryPizzaAsync(Guid id)
            => _context.Pizzas
            .AsNoTracking()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

        public Task<List<Pizza>> QueryPizzasAsync()
            => _context.Pizzas
            .AsNoTracking()
            .ToListAsync();

        public async Task<(bool IsSuccess, Exception Exception)> RemovePizzaAsync(Guid id)
        {
            if(!await PizzaExistsAsync(id))
            {
                return (false, new ArgumentException($"There is no Pizza with given ID: {id}"));
            }

            _context.Pizzas.Remove(await QueryPizzaAsync(id));
            await _context.SaveChangesAsync();

            return (true, null);
        }

        public async Task<(bool IsSuccess, Exception Exception, Pizza Pizza)> UpdatePizzaAsync(Pizza pizza, Guid id)
        {
            
            var pizz =  _context.Pizzas.FirstOrDefault(p => p.Id == id);
            if(pizz != null)
            {
                pizz.Title = pizza.Title ?? pizz.Title;
                pizz.ShortName = pizza.ShortName ?? pizz.ShortName;
                pizz.Ingradients = pizza.Ingradients ?? pizz.Ingradients;
                                
            }

            if(!_updatedUserValid(pizza))
            {
                return (false, new ArgumentException($"You should change at least one property."), null);
            }

            pizz.ModifiedAt = DateTimeOffset.UtcNow;
            pizz.Price = pizza.Price;
            pizz.StockStatus = pizza.StockStatus;

            _context.Pizzas.Update(pizz);
            await _context.SaveChangesAsync();

            return (true, null, pizza);
        }

        private bool _updatedUserValid(Pizza pizza)
        {
            return !(pizza.Title == null &&
                    pizza.ShortName == null &&
                    pizza.Ingradients == null &&
                    // pizza.StockStatus == null &&
                    // pizza.Price == null &&
                    pizza.CreatedAt == null &&
                    pizza.ModifiedAt == null);
        }
        
    }
}