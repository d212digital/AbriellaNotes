using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AbriellaNotes.ViewModel.Commands
{
    internal class EditCommand : ICommand

    {
        public event EventHandler CanExecuteChanged;

        public NotesVM ViewModel { get; set; }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.StartEditing();
        }
        
    }
}
