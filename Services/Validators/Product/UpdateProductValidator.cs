using Contracts.RequestModels.Product;
using Entity.Entity;
using FluentValidation;

namespace Services.Validators.Product
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDataRequest>
    {
        private readonly DBContext _db;

        public UpdateProductValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.Name).NotEmpty().WithMessage("Name Can't Be Empthy!").MaximumLength(20).WithMessage("Maximum Name's Length 20 Characters!");

        }
    }
}
