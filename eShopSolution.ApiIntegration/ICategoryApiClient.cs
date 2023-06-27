using eShopSolution.ViewModel.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
	public interface ICategoryApiClient
	{
		Task<List<CategoryVm>> GetAll(string languageId);

		Task<CategoryVm> GetById(string languageId, int id);
	}
}
