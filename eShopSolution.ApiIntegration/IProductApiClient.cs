﻿using eShopSolution.ViewModel.Catalog.Products;
using eShopSolution.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
	public interface IProductApiClient
	{
		Task<PagedResult<ProductVm>> GetPagings(GetManageProductPagingRequest request);

		Task<bool> CreateProduct(ProductCreateRequest request);

		Task<bool> UpdateProduct(ProductUpdateRequest request);

		Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

		Task<ProductVm> GetById(int id, string languageId);
		Task<ProductVm> GetAll();


		Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);

		Task<List<ProductVm>> GetLatestProducts(string languageId, int take);

		Task<bool> DeleteProduct(int id);
	}
}
