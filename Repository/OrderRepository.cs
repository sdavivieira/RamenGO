using Newtonsoft.Json;
using RamenGo.Model;
using static System.Net.WebRequestMethods;

namespace RamenGo.Repository
{
    public class OrderRepository : IOrderRepository
    {


        public async Task<int> Create(Order order)
        {
            using (var httpClient = new HttpClient())
            {
                var apiUrl = "https://api.tech.redventures.com.br/orders/generate-id";
                httpClient.DefaultRequestHeaders.Add("x-api-key", "ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf");

                var response = await httpClient.PostAsync(apiUrl, null);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeAnonymousType(responseContent, new { orderId = "" });

                    if (int.TryParse(responseObject.orderId, out int orderId))
                    {
                        return orderId;
                    }
                    else
                    {
                        throw new Exception("could not place order");
                    }
                }
                else
                {
                    throw new Exception($"could not place order");
                }
            }
        }

        public Task<List<Broths>> GetBroths()
        {
            var broths = new List<Broths>
        {
        new Broths
        {
            Id = 1,
            ImageInactive = "https://tech.redventures.com.br/icons/salt/inactive.svg",
            ImageActive = "https://tech.redventures.com.br/icons/salt/active.svg",
            Name = "Salt",
            Description = "Simple like the seawater, nothing more",
            Price = 10
        },
        };

            return Task.FromResult(broths);
        }


        public Task<List<Proteins>> GetProteins()
        {
         var proteins = new List<Proteins>
         {
            new Proteins
            {
                Id = 1,
                ImageInactive = "https://tech.redventures.com.br/icons/pork/inactive.svg",
                ImageActive = "https://tech.redventures.com.br/icons/pork/active.svg",
                Name = "Chasu",
                Description = "A sliced flavourful pork meat with a selection of seasonal vegetables.",
                Price = 10
            },
            
         };

            return Task.FromResult(proteins);
        }

        public Broths GetBrothById(int brothId)
        {
            return new Broths
            {
                Id = 1,
                ImageInactive = "https://tech.redventures.com.br/icons/salt/inactive.svg",
                ImageActive = "https://tech.redventures.com.br/icons/salt/active.svg",
                Name = "Salt",
                Description = "Simple like the seawater, nothing more",
                Price = 10
            };
        }

        public Proteins GetProteinById(int proteinId)
        {
            return new Proteins
            {
                Id = 1,
                ImageInactive = "https://tech.redventures.com.br/icons/pork/inactive.svg",
                ImageActive = "https://tech.redventures.com.br/icons/pork/active.svg",
                Name = "Chasu",
                Description = "A sliced flavourful pork meat with a selection of seasonal vegetables.",
                Price = 10
            };
        }
        public async Task<OrderDetails> GetOrderDetails(int orderId, int brothId, int proteinId)
        {
            var broth = GetBrothById(brothId);
            var protein = GetProteinById(proteinId);

            var orderDetails = new OrderDetails
            {
                Id = orderId,
                Description = $"{broth.Name} and {protein.Name} Ramen",
                Image = "https://tech.redventures.com.br/icons/ramen/ramenChasu.png"
            };

            await Task.Delay(100);

            return orderDetails;
        }


    }
}


