using RamenGo.Model;

namespace RamenGo.Repository
{
    public interface IOrderRepository
    {
        Task<int> Create(Order orders);
        Task<List<Broths>> GetBroths();
        Task<OrderDetails> GetOrderDetails(int orderId, int brothId, int proteinId); 
        Task<List<Proteins>> GetProteins();

    }
}
