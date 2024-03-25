using Contracts.RequestModels.Customer;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Customer;
using Contracts.ResponseModels.Product;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTraining2.Controllers
{
    [Route("api/[controller]")]
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<CreateProductResponse>> Post([FromBody] CreateProductRequest request, [FromServices] IValidator<CreateProductRequest> validator, CancellationToken cancellationToken)
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
        public async Task<ActionResult<UpdateProductDataRequest>> Put(Guid id, [FromBody] UpdateProductDataModel model, [FromServices] IValidator<UpdateProductDataRequest> validator, CancellationToken cancellationToken)
        {
            var request = new UpdateProductDataRequest { ProductID = id, Name = model.Name, Price = model.Price };
            //request.CustomerId = id;
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
        public async Task<ActionResult<DeleteProductDataRequest>> Delete(Guid id, [FromServices] IValidator<DeleteProductDataRequest> validator, CancellationToken cancellationToken)
        {
            var request = new DeleteProductDataRequest { ProductID = id };

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
