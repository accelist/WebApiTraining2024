﻿using Contracts.RequestModels.Product;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services.Validators.Product
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
    {
        private readonly DBContext _db;

        public DeleteProductValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.ProductID).MustAsync(IsProductExist).WithMessage("Product not exist.");
        }

        private async Task<bool> IsProductExist(Guid productID, CancellationToken cancellationToken)
        {
            var isProductExist = await _db.Products.Where(Q => Q.ProductID == productID)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return !isProductExist;
        }
    }
}
