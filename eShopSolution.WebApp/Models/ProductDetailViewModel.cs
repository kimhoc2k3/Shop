using eShopSolution.ViewModel.Catalog.Categories;
using eShopSolution.ViewModel.Catalog.ProductImages;
using eShopSolution.ViewModel.Catalog.Products;
using System.Collections.Generic;

namespace eShopSolution.WebApp.Models
{
	public class ProductDetailViewModel
	{
		public CategoryVm Category { get; set; }

		public ProductVm Product { get; set; }

		public List<ProductVm> RelatedProducts { get; set; }

		public List<ProductImageViewModel> ProductImages { get; set; }
	}
}
