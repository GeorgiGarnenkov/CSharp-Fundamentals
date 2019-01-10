using System.Linq;
using Forum.App.Services;
using Forum.Models;

namespace Forum.App.UserInterface.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class ReplyViewModel
    {
        private const int LINE_LENGHT = 37;

        public ReplyViewModel(Reply reply)
        {
            Author = UserService.GetUser(reply.AuthorId).Username;
            Content = GetLines(reply.Content);
        }

        public ReplyViewModel()
        {
        }

        public string Author { get; set; }

        public IList<string> Content { get; set; }

        private IList<string> GetLines(string content)
        {
            char[] contentChars = content.ToCharArray();
            IList<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i += LINE_LENGHT)
            {
                char[] row = contentChars.Skip(i).Take(LINE_LENGHT).ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }
            return lines;
        }
    }
}