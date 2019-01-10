using System;
using Forum.App.UserInterface;
using Forum.App.UserInterface.Views;

namespace Forum.App.Services
{
    using Forum.App.Services.Contracts;
    using Forum.App.UserInterface.Contracts;

    public class LogInController : IController, IReadUserInfoController
    {
        private enum Command
        {
            ReadUsername, ReadPassword, Login, Back 
        }

        public string Username { get; private set; }
        private string Password { get; set; }
        private bool Error { get; set; }

        public LogInController()
        {
            ResetLogin();
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    ReadUsername();
                    return MenuState.Login;

                case Command.ReadPassword:
                    ReadPassword();
                    return MenuState.Login;

                case Command.Login:
                    bool loggedIn = UserService.TryLoginUser(this.Username, this.Password);
                    if (loggedIn)
                    {
                        return MenuState.SuccessfulLogIn;
                    }
                    this.Error = true;
                    return MenuState.Error;

                case Command.Back:
                    ResetLogin();
                    return MenuState.Back;
            }
            
            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            return new LogInView(Error, Username, Password.Length);
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        private void ResetLogin()
        {
            this.Username = String.Empty;
            this.Password = String.Empty;
            this.Error = false;
        }
    }
}
