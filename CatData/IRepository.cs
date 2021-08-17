using CatModels;
namespace CatData
{
    public interface IRepository
    {
         List<Cat> GetCats();
         Cat AddCat(Cat cat);

         Meal AddMeal(Meal meal, int CatId);
         List<Meal> GetMeals(int catId);
    }
}