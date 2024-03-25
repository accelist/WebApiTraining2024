using Contracts.RequestModels.Cart;
using Contracts.RequestModels.Product;
using Contracts.ResponseModels.Cart;
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
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CartController>
        [HttpPost]
        public async Task<ActionResult<CreateCartRequest>> Post([FromBody] CreateCartRequest request, [FromServices] IValidator<CreateCartRequest
            > validator, CancellationToken cancellationToken)
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
        public async Task<ActionResult<UpdateCartDataRequest>> Put(Guid id, [FromBody] UpdateCartDataModel model, [FromServices] IValidator<UpdateCartDataRequest> validator, CancellationToken cancellationToken)
        {
            var request = new UpdateCartDataRequest
            {
                CartID = id, // Use the id from the route as the CartID
                Quantity = model.Quantity
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
        public void Delete(int id)
        {
        }
    }
}
