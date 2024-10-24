namespace q1Examen.Models;

public class Food : Item
{
    public string Weight { get; set; }
    public string IsSpicy { get; set; }
    public string IsVegan { get; set; }

    public Food(int id, string name, decimal price, string weight, string isSpicy, string isVegan) : base(id, name, price)
    {
        Weight = weight;
        IsSpicy = isSpicy;
        IsVegan = isVegan;
    }

}