using System.ComponentModel.DataAnnotations;
using System.Threading;
using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Customer;
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
        public async Task<ActionResult<GetCartDataListResponse>> Get(CancellationToken cancellationToken)
        {
            var request = new GetCartDataListRequest();
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCartByIdResponse>> Get(Guid id, CancellationToken cancellationToken,
            [FromServices] IValidator<GetCartByIdRequest> validator)
        {
            var request = new GetCartByIdRequest
            {
                CartId = id
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

        // POST api/<CartController>
        [HttpPost]
        public async Task<ActionResult<CreateCartResponse>> Post([FromBody] CreateCartRequest request, CancellationToken cancellationToken,
            [FromServices] IValidator<CreateCartRequest> validator)
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

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCartResponse>> Put(Guid id, [FromBody] UpdateCartModel model, CancellationToken cancellationToken,
             [FromServices] IValidator<UpdateCartRequest> validator)
        {
            var request = new UpdateCartRequest
            {
                Id = id,
                Quantity = model.Quantity,

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

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCartResponse>> Delete(Guid id, CancellationToken cancellationToken,
            [FromServices] IValidator<DeleteCartRequest> validator)
        {
            var request = new DeleteCartRequest
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
