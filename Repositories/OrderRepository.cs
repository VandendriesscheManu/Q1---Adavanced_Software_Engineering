namespace q1Examen.Repositories;

public interface IOrderRepository
{
    void AddOrder(Order order);

    List<Order> GetOrders();
}

public class OrderRepository : IOrderRepository
{
    public void AddOrder(Order order)
    {
        string fileName = "./Data/Orders.csv";
        string line = $"{order.Id};{order.Name};{order.Street};{order.Zipcode};{order.City};{order.PhoneNumber};{order.TotalPrice}";
        File.AppendAllText(fileName, line + Environment.NewLine);
    }

    private Order CreateOrder(string line)
    {
        string[] parts = line.Split(';');
        Order order = new Order(
            Convert.ToInt32(parts[0]),
            parts[1],
            parts[2],
            parts[3],
            parts[4],
            parts[5],
            Convert.ToDouble(parts[6])
        );

        return order;
    }

    public List<Order> GetOrders()
    {
        List<Order> orders = new List<Order>();
        try
        {
            string fileName = "./Data/Orders.csv";
            // lijn per lijn lezen en inlezen in een lijst van smartphones
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines.Skip(1))
            {
                Order order = CreateOrder(line);
                orders.Add(order);

            }


        }
        catch (Exception e)
        {
            throw;
        }

        return orders;
    }
}