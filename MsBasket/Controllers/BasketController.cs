using Microsoft.AspNetCore.Mvc;
using MsBasket.Entities;
using MsBasket.GrpcServices;
using MsBasket.Repositories;

namespace MsBasket.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        private readonly DiscountGrpcService _discountGrpcService;

        public BasketController(IBasketRepository repository, DiscountGrpcService discountGrpcService)
        {
            _repository = repository;
            _discountGrpcService = discountGrpcService;
        }

        [HttpGet("{userName}", Name ="GetBasket")]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await _repository.GetBasket(userName);

            return Ok(basket ?? new ShoppingCart(userName));  // se for null significa que é o primeiro acesso, então eu crio a cesta com o nome do usuário
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket) 
        {
            //Comunicar com o Discount Grpc e calcular o valor total dos produtos no carrinho
            foreach(var item in basket.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductName);

                item.Price -= coupon.Amount;
            }

            return Ok(await _repository.UpdateBasket(basket));
        }

        [HttpDelete("{userName}", Name ="DeleteBasket")]
        public async Task<ActionResult> DeleteBasket(string userName)
        {
            await _repository.DeleteBasket(userName);
            return Ok();    
        }
    }
}