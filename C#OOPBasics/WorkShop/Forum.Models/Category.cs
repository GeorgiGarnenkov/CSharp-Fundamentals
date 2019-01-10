using System.Collections.Generic;

namespace Forum.Models.Models
{
    public class Category : IIdentifiable
    {
        public Category(int id, string name, ICollection<int> posts)
        {
            Id = id;
            Name = name;
            Posts = new List<int>(posts);
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<int> Posts { get; set; }
    }
}