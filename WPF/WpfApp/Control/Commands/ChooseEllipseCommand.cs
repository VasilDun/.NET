//-----------------------------------------------------------------------
// <copyright file="ChooseEllipseCommand.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------

namespace WpfApp
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Custom command class to perform choosing an ellipse from drawing area.
    /// Implements ICommand interface
    /// </summary>
    public class ChooseEllipseCommand : ICommand
    {
        /// <summary>
        /// Determines whether the command can execute in its current state
        /// </summary>
        private bool isExecutable = true;

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
        /// Gets or sets <see cref = "EllipseCanvas"/> property which represents canvas drawing area
        /// </summary>
        public EllipseCanvas Canvas { get; set; }

        /// <summary>
        /// Gets or sets <see cref = "EllipseInfo"/> property which represents an ellipse
        /// </summary>
        public EllipseInfo Ellipse { get; set; }

        /// <summary>
        /// Shows whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter">Data used by the command</param>
        /// <returns>bool value whether the command can execute</returns>
        public bool CanExecute(object parameter)
        {
            return this.isExecutable;
        }

        /// <summary>
        /// Is called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command</param>
        public void Execute(object parameter)
        {
            this.Canvas.CurrentEllipse = this.Ellipse;
        }

        /// <summary>
        /// Sets bool value whether the command can execute
        /// </summary>
        /// <param name="isExecutable">bool value whether the command can execute</param>
        public void SetExecutable(bool isExecutable)
        {
            this.isExecutable = isExecutable;
        }

        /// <summary>
        /// Name of ellipse
        /// </summary>
        /// <returns>string that represents the name of current object</returns>
        public override string ToString()
        {
            return this.Ellipse.Name;
        }
    }
}
