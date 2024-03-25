using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Cart;
using Contracts.ResponseModels.Customer;
using Contracts.ResponseModels.Product;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTraining2.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<ProductDataListResponse>> Get(CancellationToken cancellationToken)
        {
            var request = new ProductDataListRequest();
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductData>> Get(Guid id, CancellationToken cancellationToken)
        {
            var request = new ProductDataListRequest();
            var response = await _mediator.Send(request, cancellationToken);

            var productData = response.ProductDatas.FirstOrDefault(data => data.ProductID == id);

            if (productData == null)
            {
                return NotFound();
            }

            return Ok(productData);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<CreateProductRequest>> Post([FromBody] CreateProductRequest request, [FromServices] IValidator<CreateProductRequest> validator, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }

            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateProductResponse>> Put(Guid id, [FromBody] UpdateProductModel model, [FromServices] IValidator<UpdateProductRequest> validator, CancellationToken cancellationToken)
        {
            var request = new UpdateProductRequest { ProductID = id, Name = model.Name, Price = model.Price };

            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }

            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteProductRequest>> Delete(Guid id, [FromServices] IValidator<DeleteProductRequest> validator, CancellationToken cancellationToken)
        {
            var request = new DeleteProductRequest { ProductID = id };
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
