using Contracts.RequestModels.Cart;
using Contracts.ResponseModels.Cart;
using Entity.Entity;
using MediatR;

namespace Services.RequestHandlers.ManageCart
{
    public class UpdateCartDataHandler : IRequestHandler<UpdateCartDataRequest, UpdateCartDataResponse>
    {
        private readonly DBContext _db;
        public UpdateCartDataHandler(DBContext db)
        {
            _db = db;
        }

        public async Task<UpdateCartDataResponse> Handle(UpdateCartDataRequest request, CancellationToken cancellationToken)
        {
            var existingData = await _db.Carts.FindAsync(request.CartId);
            if (existingData == null)
            {
                return new UpdateCartDataResponse()
                {
                    Success = false,
                    Message = "Data Tidak Ditemukan"
                };
            }
            existingData.CartId = request.CartId;
            existingData.Quantity = request.Quantity;
            existingData.ProductId = request.ProductId;
            existingData.CustomerId = request.CustomerId;
            _db.Carts.Update(existingData);
            await _db.SaveChangesAsync();
            return new UpdateCartDataResponse()
            {
                Success = true,
                Message = "Data Updated"
            };
        }
    }
}
