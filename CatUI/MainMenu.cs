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
                Console.WriteLine("[0] Exit?");
                Console.WriteLine("[1] View my cats");
                Console.WriteLine("[2] Add a cat");
                Console.WriteLine("[3] Feed a cat");

                switch (Console.ReadLine())
                {
                    case "0":
                        repeat = false;
                        break;
                    case "1":
                        ViewCats();
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
    }
}