using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Product;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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
        public async Task<ActionResult<GetProductByIdResponse>> Get(Guid id, CancellationToken cancellationToken,
            [FromServices] IValidator<GetProductByIdRequest> validator)
        {
            var request = new GetProductByIdRequest
            {
                ProductId = id,
            };

            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }

            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<CreateProductResponse>> Post([FromBody] CreateProductRequest request, CancellationToken cancellationToken,
            [FromServices] IValidator<CreateProductRequest> validator)
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
        public async Task<ActionResult<UpdateProductResponse>> Put(Guid id, [FromBody] UpdateProductModel model, CancellationToken cancellationToken,
            [FromServices] IValidator<UpdateProductRequest> validator)
        {
            var request = new UpdateProductRequest
            {
                Id = id,
                ProductName = model.ProductName,
                Price = model.Price,
            };

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
        public async Task<ActionResult<DeleteProductResponse>> Delete(Guid id, CancellationToken cancellationToken,
            [FromServices] IValidator<DeleteProductRequest> validator)
        {
            var request = new DeleteProductRequest
            {
                Id = id

            };

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
