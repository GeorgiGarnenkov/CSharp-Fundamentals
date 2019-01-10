using System;
using Forum.App.Services;
using Forum.App.Services.Contracts;
using Forum.App.UserInterface;
using Forum.App.UserInterface.Views;

namespace Forum.App.Controllers
{
    using Forum.App;
    using Forum.App.UserInterface.Contracts;

    public class SignUpController : IController, IReadUserInfoController
    {
        private const string DETAILS_ERROR = "Invalid Username or Password!";
        private const string USERNAME_TAKEN_ERROR = "Username already in use!";

        public string Username { get; private set; }

        private string Password { get; set; }

        private string ErrorMessage { get; set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    ReadUsername();
                    return MenuState.Signup;
                case Command.ReadPassword:
                    ReadPassword();
                    return MenuState.Signup;
                case Command.SignUp:
                    SignUpStatus signedUp = UserService.TrySignUpUser(Username, Password);
                    switch (signedUp)
                    {
                        case SignUpStatus.Success:
                            return MenuState.SuccessfulLogIn;
                        case SignUpStatus.DetailsError:
                            ErrorMessage = DETAILS_ERROR;
                            return MenuState.Error;
                        case SignUpStatus.UsernameTakenError:
                            ErrorMessage = USERNAME_TAKEN_ERROR;
                            return MenuState.Error;
                    }
                    break;
                case Command.Back:
                    ResetSignUp();
                    return MenuState.Back;
            }
            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            return new SignUpView(ErrorMessage);
        }

        public void ReadPassword()
        {
            Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        private void ResetSignUp()
        {
            ErrorMessage = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
        }

        private enum Command
        {
            ReadUsername, ReadPassword, SignUp, Back
        }

        public enum SignUpStatus
        {
            Success, DetailsError, UsernameTakenError
        }
    }
}
