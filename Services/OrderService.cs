namespace q1Examen.Services
{
    public interface IOrderService
    {
        void AddOrder(string name, string street, string zipcode, string city, string phonenumber, double totalPrice);
        List<Order> GetOrders();
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddOrder(string name, string street, string zipcode, string city, string phonenumber, double totalPrice)
        {
            int id = _orderRepository.GetOrders().Max(s => s.Id) + 1;
            
            if (zipcode.Length != 4)
            {
                Console.WriteLine("Zipcode must be 4 characters long");
            }

            Order order = new Order(id, name, street, zipcode, city, phonenumber, totalPrice);
            _orderRepository.AddOrder(order);
        }

        public List<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }
    }
}