using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageCart
{
    public class DeleteCartDataHandler : IRequestHandler<DeleteCartDataRequest, DeleteCartDataResponse>
    {
        private readonly DBContext _db;
        public DeleteCartDataHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<DeleteCartDataResponse> Handle(DeleteCartDataRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Carts.FindAsync(request.CartId);
            if (existingData == null)
            {
                return new DeleteCartDataResponse()
                {
                    Success = false,
                    Message = "Data Not Found"
                };
            }
            existingData.CartId = request.CartId;
            existingData.ProductId = request.ProductId;
            existingData.Quantity = request.Quantity;
            existingData.CustomerId = request.CustomerId;
            _db.Carts.Remove(existingData);
            await _db.SaveChangesAsync();

            return new DeleteCartDataResponse()
            {
                Success = true,
                Message = "Data Deleted"
            };
        }
    }
}
