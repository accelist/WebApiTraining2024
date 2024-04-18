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

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerCartResponse>> Get(Guid id, [FromQuery] CustomerCartModel model, [FromServices] IValidator<CustomerCartRequest> validator, CancellationToken cancellationToken)
        {
            var request = new CustomerCartRequest
            {
                CustomerID = id,
                SearchQuery = model.SearchQuery,
                PageIndex = model.PageIndex,
                ItemPerPage = model.ItemPerPage
            };

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }

            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] CreateUpdateCustomerCartRequest request, [FromServices] IValidator<CreateUpdateCustomerCartRequest> validator, CancellationToken cancellationToken)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id, [FromServices] IValidator<DeleteCustomerCartRequest> validator, CancellationToken cancellationToken)
        {
            var request = new DeleteCustomerCartRequest
            {
                CartID = id
            };

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

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
