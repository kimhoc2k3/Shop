using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModel.Sales
{
    public class CheckoutRequest
    {
        
        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public List<OrderDetailVm> OrderDetails { set; get; } = new List<OrderDetailVm>();
        public List<string> Users { get; set; } = new List<string>();
    }
}
