using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Customer;
using Contracts.ResponseModels.Product;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.RequestHandlers.ManageProduct;


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
        public async Task<ActionResult<GetProductDataResponse>> Get(CancellationToken ct)
        {
            var request = new GetProductDataRequest();
            var response = await _mediator.Send(request, ct);
            return Ok(response);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductByIdResponse>> Get(Guid id,
            [FromServices] IValidator<GetProductByIdRequest> validator, CancellationToken ct)
        {
            var request = new GetProductByIdRequest
            {
                ProductId = id
            };
            var validation = await validator.ValidateAsync(request);
            if (!validation.IsValid) 
            {
                validation.AddToModelState(ModelState);
                ValidationProblem(ModelState);
            }

            var response = await _mediator.Send(request, ct);
            return Ok(response);

        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<CreateProductResponse>> Post([FromBody] CreateProductRequest value,
            [FromServices] IValidator<CreateProductRequest> validator, CancellationToken ct)
        {
            var validation = await validator.ValidateAsync(value);
            if (!validation.IsValid)
            {
                validation.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }

            var response = await _mediator.Send(value, ct);
            return response;
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateProductDataResponse>> Put(Guid id, [FromBody] UpdateProductModel model, 
            [FromServices] IValidator<UpdateProductDataRequest> validator,
            CancellationToken ct)
        {
            var request = new UpdateProductDataRequest { ProductName = model.ProductName, ProductPrice = model.ProductPrice, Id = id };
            var validation = await validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }

            var response = await _mediator.Send(request, ct);
            return response;
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteProductResponse>> Delete(Guid id, 
            [FromServices] IValidator<DeleteProductRequest> validator, CancellationToken ct)
        {
            var req = new DeleteProductRequest
            {
                ProductId = id
            };
            var validation = await validator.ValidateAsync(req);

            if (!validation.IsValid)
            {
                validation.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }

            var response = await _mediator.Send(req, ct);
            return response;
        }
    }
}
