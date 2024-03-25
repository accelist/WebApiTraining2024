using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTraining2.Controllers
{
    
    [Route("api/v1/Cart")]
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
        public async Task<ActionResult<GetCartResponse>> Get(CancellationToken ct)
        {
            var request = new GetCartRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCartByIdResponse>> Get(Guid id,
            [FromServices] IValidator<GetCartByIdRequest> validator,
            CancellationToken ct)
        {
            var request = new GetCartByIdRequest { CartId = id };

            var validation = await validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(ModelState);
                ValidationProblem(ModelState);
            }

            var response = await _mediator.Send(request, ct);
            return Ok(response);
        }

        // POST api/<CartController>
        [HttpPost]
        public async Task<ActionResult<CreateCartResponse>> Post([FromBody] CreateCartRequest request, 
            [FromServices] IValidator<CreateCartRequest> validator, CancellationToken ct)
        {
            var validation = await validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(ModelState);
                ValidationProblem(ModelState);
            }

            var response = await _mediator.Send(request, ct);
            return response;
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCartResponse>> Put(Guid id, [FromBody] UpdateCartModel model,
            [FromServices] IValidator<UpdateCartRequest> validator, CancellationToken ct)
        {
            var request = new UpdateCartRequest { CartId = id , Quantity = model.Quantity};
            var validation = await validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(ModelState);
                ValidationProblem(ModelState);
            }
            var response = await _mediator.Send(request, ct);   
            return Ok(response);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCartResponse>> Delete(Guid id,
            [FromServices] IValidator<DeleteCartRequest> validator, CancellationToken ct)
        {
            var request = new DeleteCartRequest
            {
                CartId = id,
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
    }
}
