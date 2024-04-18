using Contracts.RequestModels.Customer;
using Contracts.ResponseModels.Customer;
using MediatR;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTraining2.Controllers
{
	[Route("api/v1/customer")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
			_mediator = mediator;
        }

        [HttpGet]
		public async Task<ActionResult<CustomerDataListResponse>> Get([FromQuery] CustomerDataListRequest request, CancellationToken cancellationToken)
		{
			var response = await _mediator.Send(request, cancellationToken);

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CustomerDetailResponse>> Get(Guid id, [FromServices] IValidator<CustomerDetailRequest> validator, CancellationToken cancellationToken)
		{
			var request = new CustomerDetailRequest
			{
				CustomerID = id
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

		[HttpPost]
		public async Task<ActionResult<CreateCustomerResponse>> Post([FromBody] CreateCustomerRequest request,  [FromServices] IValidator<CreateCustomerRequest> validator, CancellationToken cancellationToken)
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

		[HttpPut("{id}")]
		public async Task<ActionResult<bool>> Put(Guid id, [FromBody] EditCustomerModel model, [FromServices] IValidator<EditCustomerRequest> validator, CancellationToken cancellationToken)
		{
            var request = new EditCustomerRequest
            {
                CustomerID = id,
				Email = model.Email,
				Name = model.Name
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

		[HttpDelete("{id}")]
		public async Task<ActionResult<bool>> Delete(Guid id, [FromServices] IValidator<DeleteCustomerRequest> validator, CancellationToken cancellationToken)
		{
            var request = new DeleteCustomerRequest
            {
                CustomerID = id
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
