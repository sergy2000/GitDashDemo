using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitDashDemo
{
	using System;
	using System.Windows.Input;

		public class RelayCommand : ICommand
		{
        private readonly Action<object?> _executeParam;
        private readonly Func<object?, bool>? _canExecuteParam;

        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _executeParam = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecuteParam = canExecute;
        }

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            if (_canExecuteParam != null)
                return _canExecuteParam(parameter);
            if (_canExecute != null)
                return _canExecute();
            return true;
        }

        public void Execute(object? parameter)
        {
            if (_executeParam != null)
                _executeParam(parameter);
            else
                _execute();
        }

        public event EventHandler? CanExecuteChanged;

       
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

