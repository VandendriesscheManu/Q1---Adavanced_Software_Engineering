namespace q1Examen.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public double TotalPrice { get; set; }

        public Order() { }
        
        public Order(int id, string name, string street, string zipcode, string city, string phoneNumber, double totalPrice)
        {
            Id = id;
            Name = name;
            Street = street;
            Zipcode = zipcode;
            City = city;
            PhoneNumber = phoneNumber;
            TotalPrice = totalPrice;
        }

        public override string ToString()
        {
            return $"Name: {Name} - Street: {Street} - Zipcode: {Zipcode} - City: {City} - PhoneNumber: {PhoneNumber} - TotalPrice: {TotalPrice}";
        }
    }
}