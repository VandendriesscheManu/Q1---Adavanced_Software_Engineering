DrinkRepository DrinkRepository = new DrinkRepository();
DrinkService smartphoneADrinkService = new DrinkService(DrinkRepository);
var drinks = smartphoneADrinkService.GetDrinks();

FoodRepository foodRepository = new FoodRepository();
FoodService foodService = new FoodService(foodRepository);
var foods = foodService.GetFoods();

OrderRepository orderRepository = new OrderRepository();
OrderService orderService = new OrderService(orderRepository);
var orders = orderService.GetOrders();

while (true)
{
    Console.WriteLine("1. Create Order");
    Console.WriteLine("2. Show Orders");
    Console.WriteLine("3. Exit");
    Console.WriteLine("Maak uw keuze (1, 2 of 3):");
    string Option = Console.ReadLine();
    ChooseOption(Option);
}

void ChooseOption(string option)
{
    switch (option)
    {
        case "1":
            CreateOrder();
            break;
        case "2":
            ShowAllOrders();
            break;
        case "3":
            Environment.Exit(0);
            break;

    }
}

void CreateOrder()
{
    Console.WriteLine("What is your name?");
    string name = Console.ReadLine();
    Console.WriteLine("What is your street name?");
    string streetname = Console.ReadLine();
    Console.WriteLine("What is your zipcode?");
    string zipcode = Console.ReadLine();
    Console.WriteLine("What is your city?");
    string city = Console.ReadLine();
    Console.WriteLine("What is your phone number?");
    string phonenumber = Console.ReadLine();

    double totalPrice = 0;
    List<string> foodChoices = foods.Select(food => food.ToString()).ToList();
    List<string> orderedFoods = new List<string>(); // Lijst voor bestelde eten
    List<string> orderedDrinks = new List<string>(); // Lijst voor bestelde drankjes

    // Eten bestellen
    while (true)
    {
        Console.WriteLine("What food do you want to order? Type the number or 'done' to finish:");
        for (int i = 0; i < foodChoices.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {foodChoices[i]}");
        }

        string foodOption = Console.ReadLine();
        if (foodOption.ToLower() == "done")
            break;

        if (int.TryParse(foodOption, out int foodIndex) && foodIndex > 0 && foodIndex <= foodChoices.Count)
        {
            // Vraag het aantal dat de gebruiker wil bestellen
            Console.WriteLine($"How many of {foods[foodIndex - 1].Name} would you like to order?");
            string quantityInput = Console.ReadLine();

            // Controleer of de hoeveelheid een geldig nummer is
            if (int.TryParse(quantityInput, out int quantity) && quantity > 0)
            {
                double itemPrice = Convert.ToDouble(foods[foodIndex - 1].Price);
                totalPrice += itemPrice * quantity; // Vermenigvuldig prijs met aantal
                orderedFoods.Add($"{quantity} x €{itemPrice:F2} {foods[foodIndex - 1].Name} = €{itemPrice * quantity:F2}");
                Console.WriteLine($"Added {quantity} of {foods[foodIndex - 1].Name}. Total price now: €{totalPrice:F2}");
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please enter a positive number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid option. Please try again.");
        }
    }

    // Drankjes bestellen
    List<string> drinkChoices = drinks.Select(drink => drink.ToString()).ToList();
    while (true)
    {
        Console.WriteLine("What drink do you want to order? Type the number or 'done' to finish:");
        for (int i = 0; i < drinkChoices.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {drinkChoices[i]}");
        }

        string drinkOption = Console.ReadLine();
        if (drinkOption.ToLower() == "done")
            break;

        if (int.TryParse(drinkOption, out int drinkIndex) && drinkIndex > 0 && drinkIndex <= drinkChoices.Count)
        {
            // Vraag het aantal dat de gebruiker wil bestellen
            Console.WriteLine($"How many of {drinks[drinkIndex - 1].Name} would you like to order?");
            string quantityInput = Console.ReadLine();

            // Controleer of de hoeveelheid een geldig nummer is
            if (int.TryParse(quantityInput, out int quantity) && quantity > 0)
            {
                double itemPrice = Convert.ToDouble(drinks[drinkIndex - 1].Price);
                totalPrice += itemPrice * quantity; // Vermenigvuldig prijs met aantal
                orderedDrinks.Add($"{quantity} x €{itemPrice:F2} {drinks[drinkIndex - 1].Name} = €{itemPrice * quantity:F2}");
                Console.WriteLine($"Added {quantity} of {drinks[drinkIndex - 1].Name}. Total price now: €{totalPrice:F2}");
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please enter a positive number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid option. Please try again.");
        }
    }

    // Samenvatting van de bestelling afdrukken
    Console.WriteLine("\nOrder Summary:");
    Console.WriteLine($"{name} - {streetname} - {zipcode} - {city} - {phonenumber}");

    if (orderedDrinks.Count > 0)
    {
        Console.WriteLine("Drinks:");
        foreach (var drink in orderedDrinks)
        {
            Console.WriteLine(drink);
        }
    }

    if (orderedFoods.Count > 0)
    {
        Console.WriteLine("Food:");
        foreach (var food in orderedFoods)
        {
            Console.WriteLine(food);
        }
    }

    Console.WriteLine($"Total Price: €{totalPrice:F2}");

    // Voeg de bestelling toe aan de service
    orderService.AddOrder(name, streetname, zipcode, city, phonenumber, totalPrice);
    Console.WriteLine("Order has been created successfully.");
}

void ShowAllOrders()
{
    foreach (var order in orders)
    {
        Console.WriteLine(order);
    }
}








