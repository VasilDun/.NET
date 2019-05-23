//-----------------------------------------------------------------------
// <copyright file="CommandHandler.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------

namespace WpfApp
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Custom command class. Implements <see cref = "ICommand"/> interface
    /// </summary>
    public class CommandHandler : ICommand
    {
        /// <summary>
        /// Action delegate to encapsulate executed method
        /// </summary>
        private Action action;

        /// <summary>
        /// Determines whether the command can execute in its current state
        /// </summary>
        private bool canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref = "CommandHandler"/> class.
        /// Constructor with parameters 
        /// </summary>
        /// <param name="action_">Action delegate to encapsulate executed method</param>
        /// <param name="canExecute_">bool value whether the command can execute</param>
        public CommandHandler(Action action_, bool canExecute_)
        {
            this.action = action_;
            this.canExecute = canExecute_;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Shows whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter">Data used by the command</param>
        /// <returns>bool value whether the command can execute</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute;
        }

        /// <summary>
        /// Is called when the command is invoked
        /// </summary>
        /// <param name="parameter">Data used by the command</param>
        public void Execute(object parameter)
        {
            this.action();
        }
    }
}
