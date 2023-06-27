using eShopSolution.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Orders
{
    public interface IOrderService
    {
        public Task<int> CreateNewBills(CheckoutRequest request);

        public Task<int> DeleteBill(int id);

        public Task<List<CheckoutRequest>> GetAllBills();

        public Task<List<CheckoutRequest>> GetBillByDateTime(DateTime date);

        public Task<CheckoutRequest> GetBillById(Guid id);

        public Task<int> UpdateBill(CheckoutRequest request);
    }
}
