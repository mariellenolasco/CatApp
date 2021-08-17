using CatModels;
namespace CatData
{
    public interface IRepository
    {
         List<Cat> GetCats();
    }
}