using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Validators.Cart;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPITraining2.Controllers
{
    [Route("api/v1/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CartControlleer>
        [HttpGet]
        public async Task<ActionResult<CartDataListResponse>> Get(CancellationToken cancellationToken)
        {
            var request = new CartDataListRequest();
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        // GET api/<CartControlleer>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDataDetailResponse>> Get(Guid id, CancellationToken cancellationToken)
        {
            var request = new CartDataDetailRequest()
            {
                CartId = id
            };

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // POST api/<CartControlleer>
        [HttpPost]
        public async Task<ActionResult<CreateCartResponse>> Post([FromBody] CreateCartRequest request, [FromServices]CreateCartValidator validator, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // PUT api/<CartControlleer>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCartDataResponse>> Put(Guid id, [FromBody] UpdateDataModel model, [FromServices]UpdateCartValidator validator, CancellationToken cancellationToken)
        {
            var request = new UpdateCartDataRequest()
            {
                CartId = id,
                Quantity = model.Quantity,
                ProductId = model.ProductId,
                CustomerId = model.CustomerId
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

        // DELETE api/<CartControlleer>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCartDataRequest>> Delete(Guid id, [FromServices] IValidator<DeleteCartDataRequest> validator, CancellationToken cancellationToken)
        {
            var request = new DeleteCartDataRequest()
            {
                CartId = id
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
