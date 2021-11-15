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
        private readonly ILogger<DbStorageService> _logger;

        public DbStorageService(PizzaDbContext context, ILogger<DbStorageService> logger)
        {
            _context = context;
            _logger = logger;
        }

        // public async Task<List<Entities.Pizza>> GetAllAsync(
        //     Guid id = default(Guid),
        //     string title = default(string),
        //     string shortName = default(string),
        //     string ingradients = default(string),
        //     Entities.EPizzaStockStatus? stockStatus = null,
        //     string price = default(string))

        //     {
        //         var pizz = _context.Pizzas.AsNoTracking();

        //         if(id != default(Guid))
        //         {
        //             pizz = pizz.Where(p => p.Id == id);
        //         }

        //         if(title != default(string))
        //         {
        //             pizz = pizz.Where(p => p.Title.ToLower().Equals(title.ToLower()) 
        //                         || p.Title.ToLower().Contains(title.ToLower()));
        //         }

        //         if(shortName != default(string))
        //         {
        //             // TO-DO: optimize
        //             pizz = pizz.Where(p => p.ShortName.Equals(shortName));
        //         }

        //         if(ingradients != default(string))
        //         {
        //             // TO-DO: optimize
        //             pizz = pizz.Where(p => p.Ingradients.ToLower().Equals(ingradients.ToLower()));
        //         }

        //         if(stockStatus.HasValue)
        //         {
        //             pizz = pizz.Where(p => p.StockStatus == stockStatus.Value);
        //         }

        //         if(price != default(string))
        //         {
        //             pizz = pizz.Where(p => p.Price.Equals(price));
        //         }

        //         return await pizz.ToListAsync();
        //     }

        public async Task<(bool IsSuccess, Exception exception)> CreatePizzaAsync(Entities.Pizza pizza)
        {
            try
            {
                _context.Pizzas.Add(pizza);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Task inserted in DB: {pizza.Id}");

                return (true, null);
            }
            catch(Exception e)
            {
                _logger.LogInformation($"Inserting task to DB failed: {e.Message}", e);
                return (false, e);
            }
        }
        public async Task<(bool IsSuccess, Exception exception)> UpdatePizzaAsync(Entities.Pizza pizza)
        {
            try
            {
                if(await _context.Pizzas.AnyAsync(p => p.Id == pizza.Id))
                {
                    _context.Pizzas.Update(pizza);
                    await _context.SaveChangesAsync();

                    return (true, null);
                }
                else
                {
                    return (false, new Exception($"Task with given ID: {pizza.Id} doesnt exist!"));
                }
            }
            catch(Exception e)
            {
                return (false, e);
            }
        }
        public async Task<(bool IsSuccess, Exception exception)> DeletePizzaAsync(Guid id)
        {
            try
            {
                _context.Pizzas.Remove(_context.Pizzas.FirstOrDefault(u => u.Id == id));
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Task deleted from DB: {id}");

                return (true, null);
            }
            catch(Exception e)
            {
                _logger.LogInformation($"Deleting failed: {e.Message}", e);
                return (false, e);
            }
            

        }
        public async Task<(bool IsSuccess, Exception exception)> GetPizzaAsync(Entities.Pizza pizza)
        {
            await _context.SaveChangesAsync();
            return (true, null);
        }

        public async Task<List<Pizza>> GetALLAsync(Guid id = default, string title = null, string shortName = null, string ingradients = null, EPizzaStockStatus? stockStatus = null, string price = null)
        {
            var pizz = _context.Pizzas.AsNoTracking();

            if(id != default(Guid))
            {
                pizz = pizz.Where(p => p.Id == id);
            }

            if(title != default(string))
            {
                pizz = pizz.Where(p => p.Title.ToLower().Equals(title.ToLower()) 
                            || p.Title.ToLower().Contains(title.ToLower()));
            }

            if(shortName != default(string))
            {
                // TO-DO: optimize
                pizz = pizz.Where(p => p.ShortName.Equals(shortName));
            }

            if(ingradients != default(string))
            {
                // TO-DO: optimize
                pizz = pizz.Where(p => p.Ingradients.ToLower().Equals(ingradients.ToLower()));
            }

            if(stockStatus.HasValue)
            {
                pizz = pizz.Where(p => p.StockStatus == stockStatus.Value);
            }

            if(price != default(string))
            {
                pizz = pizz.Where(p => p.Price.Equals(price));
            }

            return await pizz.ToListAsync();
        }
    }
}