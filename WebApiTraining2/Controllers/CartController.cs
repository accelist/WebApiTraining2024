using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTraining2.Controllers
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

        // GET: api/<CartController>
        [HttpGet]
        public async Task<ActionResult<CartDataListResponse>> Get(CancellationToken cancellationToken)
        {
            var request = new CartDataListRequest();
            CartDataListResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDetailResponse>> Get(Guid id, [FromServices] IValidator<CartDetailRequest> _validator, CancellationToken cancellationToken)
        {
            CartDetailRequest request = new CartDetailRequest
            {
                CartId = id
            };
            var validationResult = await _validator.ValidateAsync(request);
            if(!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        // POST api/<CartController>
        [HttpPost]
        public async Task<ActionResult<CreateCartResponse>> Post([FromBody] CreateCartRequest request, [FromServices] IValidator<CreateCartRequest> _validator, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if(!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCartResponse>> Put(Guid id, [FromBody] UpdateCartModel requestModel, 
            [FromServices] IValidator<UpdateCartRequest> _validator, CancellationToken cancellationToken)
        {
            UpdateCartRequest request = new UpdateCartRequest 
            {
                CartId = id,
                Quantity = requestModel.Quantity
            };
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCartResponse>> Delete(Guid id, [FromServices]IValidator<DeleteCartRequest> _validator, CancellationToken cancellationToken)
        {
            var request = new DeleteCartRequest { CartId = id };
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if(!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
    }
}
