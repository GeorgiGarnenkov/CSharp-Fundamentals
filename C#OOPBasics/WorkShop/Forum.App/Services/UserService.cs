using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forum.App.Controllers;
using Forum.Data;
using Forum.Models;
using static Forum.App.Controllers.SignUpController;

namespace Forum.App.Services
{
    public static class UserService
    {
        public static bool TryLoginUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            ForumData forumData = new ForumData();

            bool userExists = forumData.Users.Any(u => u.Username.Equals(username) && u.Password.Equals(password));

            return userExists;
        }

        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;

            if (!validUsername || !validPassword)
            {
                return SignUpStatus.DetailsError;
            }

            ForumData forumData = new ForumData();

            bool userAlreadyExists = forumData.Users.Any(x => x.Username.Equals(username));

            if (!userAlreadyExists)
            {
                int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;

                User user = new User(userId, username, password);
                forumData.Users.Add(user);
                forumData.SaveChanges();

                return SignUpStatus.Success;
            }
            return SignUpStatus.UsernameTakenError;
        }

        internal static User GetUser(int userId)
        {
            ForumData forumData = new ForumData();
            User user = forumData.Users.Find(u => u.Id.Equals(userId));
            return user;
        }

        internal static User GetUser(string username)
        {
            ForumData forumData = new ForumData();
            User user = forumData.Users.Find(x => x.Username.Equals(username));
            return user;
        }
    }

}