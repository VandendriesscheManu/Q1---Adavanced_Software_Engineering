namespace q1Examen.Services;

    public interface IDrinkService
    {
        List<Drink> GetDrinks();
    }

    public class DrinkService : IDrinkService
    {
        private IDrinkRepository _drinkRepository;

        public DrinkService(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public List<Drink> GetDrinks()
        {
            return _drinkRepository.GetDrinks();
        }
    }
