using System;
using System.Windows.Input;
using Battleship.ViewModel;

namespace Battleship.Command
{
    public class ExecuteRestartGameCommand : ICommand
    {
        private readonly GameViewModel _gameViewModel;
        public event EventHandler CanExecuteChanged;

        public ExecuteRestartGameCommand(GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _gameViewModel.RestartGame();
        }
    }
}
