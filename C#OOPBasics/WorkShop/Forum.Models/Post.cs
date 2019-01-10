using System.Collections.Generic;

namespace Forum.Models
{
    public class Post : IIdentifiable
    {
        public Post(int id, string title, string content, int categoryId, int authorId, ICollection<int> repliesIds)
        {
            Id = id;
            Title = title;
            Content = content;
            CategoryId = categoryId;
            AuthorId = authorId;
            ReplyIds = new List<int>(repliesIds);
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public int AuthorId { get; set; }

        public ICollection<int> ReplyIds { get; set; }
    }
}