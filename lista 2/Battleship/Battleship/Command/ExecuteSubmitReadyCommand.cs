using System;
using System.Windows.Input;
using Battleship.ViewModel;

namespace Battleship.Command
{
    public class ExecuteSubmitReadyCommand : ICommand
    {
        private readonly GameViewModel _gameViewModel;
        public event EventHandler CanExecuteChanged;

        public ExecuteSubmitReadyCommand(GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _gameViewModel.SubmitReady();
        }

    }
}
