namespace q1Examen.Repositories;

public interface IDrinkRepository
{
    List<Drink> GetDrinks();
}

public class DrinkRepository : IDrinkRepository
{
    private Drink CreateDrink(string line)
    {
        string[] parts = line.Split(';');
        Drink drink = new Drink(
            Convert.ToInt32(parts[0]),
            parts[1],
            Convert.ToDecimal(parts[2], CultureInfo.InvariantCulture),
            parts[3],
            parts[4]
        );

        return drink;
    }
    public List<Drink> GetDrinks()
    {
        List<Drink> drinks = new List<Drink>();
        try
        {
            string fileName = "./Data/drinks.csv";
            // lijn per lijn lezen en inlezen in een lijst van smartphones
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines.Skip(1))
            {
                Drink drink = CreateDrink(line);
                drinks.Add(drink);

            }


        }
        catch (Exception e)
        {
            throw;
        }

        return drinks;
    }
}