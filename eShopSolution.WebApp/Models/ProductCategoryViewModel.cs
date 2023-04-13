using eShopSolution.ViewModel.Catalog.Categories;
using eShopSolution.ViewModel.Catalog.Products;
using eShopSolution.ViewModel.Common;

namespace eShopSolution.WebApp.Models
{
	public class ProductCategoryViewModel
	{
		public CategoryVm Category { get; set; }

		public PagedResult<ProductVm> Products { get; set; }
	}
}
