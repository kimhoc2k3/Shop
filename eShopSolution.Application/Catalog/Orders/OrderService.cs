using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModel.Catalog.Products;
using eShopSolution.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Orders
{
    public class OrderService : IOrderService
    {
        private readonly eShopDbContext _context;

        public OrderService(eShopDbContext context) 
        {  
            _context = context;
        }

        public async Task<int> CreateNewBills(CheckoutRequest request)
        {
            var order = new Order()
            {
                ShipAddress = request.Address,
                ShipEmail = request.Email,
                ShipName = request.Name,
                ShipPhoneNumber = request.PhoneNumber,
                UserId = request.UserId,
                OrderDate = DateTime.Now,
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order.Id;
        
        }

        public async Task<int> DeleteBill(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                throw new EShopException($"Can't find a product : {id}");
            }

            _context.Orders.Remove(order);
            return await _context.SaveChangesAsync();
        }

        public Task<List<CheckoutRequest>> GetAllBills()
        {
            throw new NotImplementedException();
        }

        public Task<List<CheckoutRequest>> GetBillByDateTime(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<CheckoutRequest> GetBillById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateBill(CheckoutRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
