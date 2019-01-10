using System;
using System.Collections.Generic;
using System.Text;
using Forum.Models;
using Forum.Models.Models;

namespace Forum.Data
{
    public class ForumData
    {
        public ForumData()
        {
            Users = DataMapper.LoadUsers();
            Categories = DataMapper.LoadCategories();
            Posts = DataMapper.LoadPosts();
            Replies = DataMapper.LoadReplies();
        }

        public List<Category> Categories { get; set; }

        public List<User> Users { get; set; }

        public List<Post> Posts { get; set; }

        public List<Reply> Replies { get; set; }

        public void SaveChanges()
        {
            DataMapper.SaveUsers(Users);
            DataMapper.SaveCategories(Categories);
            DataMapper.SavePosts(Posts);
            DataMapper.SaveReplies(Replies);
        }
    }
}