using System;
using System.Windows.Input;

namespace UnitConversion
{
    public class Command : ICommand
    {
        private Action action;
        private Func<bool> canExecute;

        public Command(Action action, Func<bool> canExecute)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
