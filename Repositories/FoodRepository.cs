namespace q1Examen.Repositories;

public interface IFoodRepository
{
    List<Food> GetFoods();
}

public class FoodRepository : IFoodRepository
{
    private Food CreateFood(string line)
    {
        string[] parts = line.Split(';');
        Food food = new Food(
            Convert.ToInt32(parts[0]),
            parts[1],
            Convert.ToDecimal(parts[2], CultureInfo.InvariantCulture),
            parts[3],
            parts[4],
            parts[5]
        );

        return food;
    }
    public List<Food> GetFoods()
    {
        List<Food> foods = new List<Food>();
        try
        {
            string fileName = "./Data/Food.csv";
            // lijn per lijn lezen en inlezen in een lijst van smartphones
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines.Skip(1))
            {
                Food food = CreateFood(line);
                foods.Add(food);

            }


        }
        catch (Exception e)
        {
            throw;
        }

        return foods;
    }
}