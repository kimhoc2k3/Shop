using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModel.Catalog.Products
{
    public class ProductRequestValidator : AbstractValidator<ProductCreateRequest>
    {
        public ProductRequestValidator() 
        {
            //RuleFor(x => x.price).NotEmpty().WithMessage("UserName is required");
            //RuleFor(x => x.OriginalPrice).NotEmpty().
        }

    }
}
