using System;
using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class PostCommand : ICommand
    {
        private ISession session;
        private IPostService postService;
        private ICommandFactory commandFactory;

        public PostCommand(ISession session, IPostService postService, ICommandFactory commandFactory)
        {
            this.session = session;
            this.postService = postService;
            this.commandFactory = commandFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int userId = this.session.UserId;

            string postTitle = args[0];
            string postCategory = args[1];
            string postContent = args[2];

            bool validTitle = !string.IsNullOrWhiteSpace(postTitle);
            bool validCategory = !string.IsNullOrWhiteSpace(postCategory);
            bool validContent = !string.IsNullOrWhiteSpace(postContent);

            if (!validTitle || !validCategory || !validContent)
            {
                throw new ArgumentException("All fields must be filled!");
            }

            int postId = this.postService.AddPost(userId, postTitle, postCategory, postContent);

            this.session.Back();
            ICommand viewPostCommand = this.commandFactory.CreateCommand("ViewPostMenu");
            return viewPostCommand.Execute(postId.ToString());
            }
    }
}