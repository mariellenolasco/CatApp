using System;
using System.Collections.Generic;

namespace CatData.Entities
{
    public partial class Food
    {
        public Food()
        {
            Meals = new HashSet<Meal>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}
