﻿using Contracts.RequestModels.Product;
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
    public class DeleteProductValidator: AbstractValidator<DeleteProductRequest>
    {
        private readonly DBContext _db;

        public DeleteProductValidator(DBContext db)
        {
            _db = db;

            RuleFor(Q => Q.ProductID).NotEmpty().WithMessage("Customer ID cannot be empty").MustAsync(CheckID).WithMessage("Customer ID cannot be found!");
        }

        public async Task<bool> CheckID(Guid? id, CancellationToken cancellationToken)
        {
            var idExist = await _db.Products.Where(Q => Q.ProductID == id)
                .AsNoTracking()
                .AnyAsync(cancellationToken);

            return idExist;
        }
    }
}
