using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Entity.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators.Product
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
    {
        private readonly DBContext _db;

        public DeleteProductValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.ProductID).MustAsync(IsValidID).WithMessage("Data Does Not Exist");
        }

        private async Task<bool> IsValidID(Guid id, CancellationToken cancellationToken)
        {
            var data = await _db.Products.Where(Q => Q.ProductID == id)
                .AnyAsync();

            if (!data)
            {
                return false;
            }
            return true;
        }
    }
}
