using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RamenGo.Model;
using RamenGo.Repository;

namespace RamenGo.Controllers
{
    public class defaultController : Controller
    {
        private readonly IOrderRepository _repo;

        public defaultController(IOrderRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("broths")]
        [ApiKey]
        public async Task<IActionResult>GetBroths()
        {
            var _list = await _repo.GetBroths();
            if (_list != null)
                return Ok(_list);

            else
                return NotFound("Not Found any Broths!");
        }
        [HttpGet("proteins")]
        [ApiKey]

        public async Task<IActionResult> GetProteins()
        {
            var _list = await _repo.GetProteins();
            if (_list != null)
                return Ok(_list);

            else
                return NotFound("Not Found any Proteins!");
        }

        [HttpPost("orders")]
        [ApiKey]
        public async Task<IActionResult> CreateOrder([FromBody] Order orderInput)
        {
            // Verifica se o cabeçalho 'x-api-key' está presente
            if (!HttpContext.Request.Headers.ContainsKey("x-api-key"))
            {
                return StatusCode(403, "x-api-key header missin");
            }

            // Verifica se o pedido é nulo ou se falta algum dado
            if (orderInput == null || orderInput.BrothId == 0 || orderInput.ProteinId == 0)
            {
                return BadRequest("both brothId and proteinId are required");
            }

            try
            {
                var order = new Order
                {
                    BrothId = orderInput.BrothId,
                    ProteinId = orderInput.ProteinId
                };

                var orderId = await _repo.Create(order);

                var orderDetails = await _repo.GetOrderDetails(orderId, order.BrothId, order.ProteinId);

                // Retorna os detalhes do pedido como resposta
                return Ok(orderDetails);
            }
            catch
            {
                return StatusCode(500, $"could not place order");
            }
        }


    }
}
