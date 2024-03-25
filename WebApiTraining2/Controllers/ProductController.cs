using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Product;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Validators.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPITraining2.Controllers
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
        public async Task<ActionResult<ProductDataDetailResponse>> Get(Guid id, CancellationToken cancellationToken)
        {
            var request = new ProductDataDetailRequest()
            {
                ProductId = id,
                
            };
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<CreateProductResponse>> Post([FromBody] CreateProductRequest request, [FromServices]CreateProductValidator validator, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if(!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateProductDataRequest>> Put(Guid id, [FromBody] UpdateProductModel model, [FromServices]UpdateProductValidator validator, CancellationToken cancellationToken)
        {
            var request = new UpdateProductDataRequest
            {
                ProductId = id,
                Name = model.Name,
                Price = model.Price
            };
            var validationResult = await validator.ValidateAsync(request);
            if(!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteProductDataRequest>> Delete(Guid id, [FromServices] IValidator<DeleteProductDataRequest> validator, CancellationToken cancellationToken)
        {
            var request = new DeleteProductDataRequest
            {
                ProductId = id
            };

            var validationResult = await validator.ValidateAsync(request);

            if(!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
