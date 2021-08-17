using CatData;
using CatModels;
namespace CatUI
{
    public class MainMenu : IMenu
    {
        private IRepository _repo;
        public MainMenu(IRepository repo)
        {
            _repo = repo;
        }
        public void Start()
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("Welcome to my Cat Manager!");
                Console.WriteLine("[1] View my cats");
                Console.WriteLine("[2] Add a cat");
                Console.WriteLine("[3] Feed a cat");
                Console.WriteLine("[4] Meal History");
                Console.WriteLine("[x] Exit?");

                switch (Console.ReadLine())
                {
                    case "x":
                        repeat = false;
                        break;
                    case "1":
                        ViewCats();
                        break;
                    case "2":
                        AddCat();
                        break;
                    case "3":
                        FeedCat();
                        break;
                    case "4":
                        MealHistory();
                        break;
                    default:
                        Console.WriteLine("I don't know what you want from me. Try again. ");
                        break;
                }
            } while (repeat);
        }
        public void ViewCats()
        {
            List<Cat> cats = _repo.GetCats();
            foreach(Cat cat in cats)
            {
                Console.WriteLine(cat.Name);
            }
        }
        public void AddCat()
        {
            Console.WriteLine("Enter Cat Details: ");
            string input = "";
            do{  
                Console.WriteLine("Enter Cat Name: ");
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));
            Cat newCat = new Cat{
                Name = input
            };
            _repo.AddCat(newCat);
            Console.WriteLine("New Cat added");
        }

        public void FeedCat()
        {
            int catId = CatPicker("Choose a cat to feed: ");   
            Console.WriteLine("Select Food Type: ");
            foreach(FoodType foodType in Enum.GetValues(typeof(FoodType)))
            {
                Console.WriteLine(foodType);
            }
            string foodtype = Console.ReadLine();
            Meal  newMeal = new Meal{
                Food = Enum.Parse<FoodType>(foodtype),
                Time = DateTime.Now
            };
            _repo.AddMeal(newMeal, catId);
        }
        public void MealHistory()
        {
            int catId = CatPicker("Pick a cat to get their meal history");
            List<Meal> mealHistory = _repo.GetMeals(catId);
            foreach(Meal meal in mealHistory)
            {
                Console.WriteLine("Time: "+ meal.Time);
                Console.WriteLine("Food Type: "+ meal.Food);
            }
        }
        public int CatPicker(string prompt)
        {
            List<Cat> allCats = _repo.GetCats();
            Console.WriteLine(prompt);
            foreach(Cat cat in allCats)
            {
                Console.WriteLine(cat.Id + " " + cat.Name);
            }
            Console.WriteLine("Enter Cat #: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}