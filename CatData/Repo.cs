using Model = CatModels;
using Entity = CatData.Entities;
namespace CatData
{
    public class Repo : IRepository
    {
        private Entity.CatDBContext _context;
        public Repo(Entity.CatDBContext context)
        {
            _context = context;
        }
        public List<Model.Cat> GetCats() {
            return _context.Cats.Select(cat => new Model.Cat{
              Name = cat.Name,
              Id = cat.Id  
            }).ToList();
        }

        public Model.Cat AddCat(Model.Cat cat)
        {
            _context.Cats.Add(new Entity.Cat{
                Name = cat.Name
            });
            _context.SaveChanges();
            return cat;
        }
        public Model.Meal AddMeal(Model.Meal newMeal, int CatId)
        {
            _context.Meals.Add(new Entity.Meal
            {
                Time = newMeal.Time,
                CatId = CatId,
                FoodType = (int) newMeal.Food
            });
            _context.SaveChanges();
            return newMeal;
        }
        public List<Model.Meal> GetMeals(int catId)
        {
            return _context.Meals.Where(meal => meal.CatId == catId).Select(meal => new Model.Meal{
                Time = meal.Time,
                Food = (Model.FoodType) meal.FoodType
            }).ToList();
        }
    }
}