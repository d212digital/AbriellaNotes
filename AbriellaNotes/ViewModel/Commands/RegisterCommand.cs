using AbriellaNotes.Model;
using System;
using System.Windows.Input;


namespace AbriellaNotes.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        public LoginVM ViewModel { get; set; }
        public event EventHandler CanExecuteChanged;

        public RegisterCommand(LoginVM vm)
        {
            ViewModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            User user = parameter as User;
            if (user == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.ConfirmPassword)) 
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.Register();
        }
    }
}
