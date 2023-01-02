using AutoMapper;
using CozyThings.Services.ShoppingCartApi.Data;
using CozyThings.Services.ShoppingCartApi.Data.Entities.Cart;
using CozyThings.Services.ShoppingCartApi.Models.Cart;
using Microsoft.EntityFrameworkCore;

namespace CozyThings.Services.ShoppingCartApi.Repository.Imp
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public CartRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CartDto> GetCartByUserId(string userId)
        {
            var cart = new Cart()
            {
                CartHeader = await dbContext.CartHeaders
                .FirstOrDefaultAsync(x => x.UserId == userId)
            };

            cart.CartDetails = dbContext.CartDetails
                .Where(x => x.CartHeaderId == cart.CartHeader.Id).Include(x => x.Product);

            return mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto> CreateUpdateCart(CartDto dto)
        {
            var cart = mapper.Map<Cart>(dto);

            var entity = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == dto.CartDetails.FirstOrDefault().ProductId);
            if (entity == null)
            {
                dbContext.Products.Add(cart.CartDetails.FirstOrDefault().Product);
                await dbContext.SaveChangesAsync();
            }

            var cartHeader = await dbContext.CartHeaders.AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == cart.CartHeader.UserId);
            if (cartHeader == null)
            {
                dbContext.CartHeaders.Add(cart.CartHeader);
                await dbContext.SaveChangesAsync();
                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                cart.CartDetails.FirstOrDefault().Product = null;
                dbContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await dbContext.SaveChangesAsync();
            }
            else 
            {
                var cartDetails = await dbContext.CartDetails.FirstOrDefaultAsync(
                    x => x.ProductId == cart.CartDetails.FirstOrDefault().ProductId && 
                    x.CartHeaderId == cartHeader.Id);
                if (cartDetails == null)
                {
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeader.Id;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    dbContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await dbContext.SaveChangesAsync();
                }
                else 
                {
                    cart.CartDetails.FirstOrDefault().Count += cartDetails.Count;
                    dbContext.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    await dbContext.SaveChangesAsync();
                }
            }
            return mapper.Map<CartDto>(cart);
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeader = await dbContext.CartHeaders
                .FirstOrDefaultAsync(x => x.UserId == userId);
            if (cartHeader != null)
            {
                dbContext.CartDetails
                    .RemoveRange(dbContext.CartDetails.Where(x => x.CartHeaderId == cartHeader.Id));
                dbContext.CartHeaders.Remove(cartHeader);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveFromCart(int cartDetailsId)
        {
            try
            {
                var cartDetails = await dbContext.CartDetails
                .FirstOrDefaultAsync(x => x.Id == cartDetailsId);

                int totalCartItems = dbContext.CartDetails
                    .Where(x => x.CartHeaderId == cartDetails.CartHeaderId)
                    .Count();

                dbContext.CartDetails.Remove(cartDetails);
                if (totalCartItems == 1)
                {
                    var cartHeaderToRemove = await dbContext.CartHeaders
                        .FirstOrDefaultAsync(x => x.Id == cartDetails.CartHeaderId);

                    dbContext.CartHeaders.Remove(cartHeaderToRemove);
                }
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            var cartFromDb = await dbContext.CartHeaders.FirstOrDefaultAsync(x => x.UserId == userId);  
            cartFromDb.CouponCode = couponCode; 
            dbContext.Update(cartFromDb);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            var cartFromDb = await dbContext.CartHeaders.FirstOrDefaultAsync(x => x.UserId == userId);
            cartFromDb.CouponCode = string.Empty;
            dbContext.Update(cartFromDb);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
