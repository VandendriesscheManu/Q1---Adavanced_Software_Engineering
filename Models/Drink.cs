namespace q1Examen.Models;

public class Drink : Item
{
    public string Volume { get; set; }
    public string ContainsAlcohol { get; set; }

    public Drink(int id, string name, decimal price, string volume, string containsAlcohol) : base(id, name, price)
    {
        Volume = volume;
        ContainsAlcohol = containsAlcohol;
    }

}