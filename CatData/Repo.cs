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
              Name = cat.Name  
            }).ToList();
        }
    }
}