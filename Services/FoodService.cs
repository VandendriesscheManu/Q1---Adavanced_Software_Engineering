namespace q1Examen.Services;

public interface IFoodService
{
    List<Food> GetFoods();
}

public class FoodService : IFoodService
{
    private IFoodRepository _foodRepository;

    public FoodService(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }

    public List<Food> GetFoods()
    {
        return _foodRepository.GetFoods();
    }
}
