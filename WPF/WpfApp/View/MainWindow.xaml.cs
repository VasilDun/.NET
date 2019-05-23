//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Drawing area
        /// </summary>
        private EllipseCanvas ellipseCanvas = new EllipseCanvas();

        /// <summary>
        /// Command to make a new file
        /// </summary>
        private ICommand newFile;

        /// <summary>
        /// Command to open file
        /// </summary>
        private ICommand openFile;

        /// <summary>
        /// Command to save file
        /// </summary>
        private ICommand saveFile;

        /// <summary>
        /// Gets resetEllipse command
        /// </summary>
        private ICommand resetEllipse;

        /// <summary>
        /// bool value whether the command can execute
        /// </summary>
        private bool canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref = "MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.ellipseCanvas.Canvas = this.canvasDrawingArea;
            this.ellipseCanvas.OnEllipseAdded += this.EllipseCanvas_OnEllipseAdded;
            this.canExecute = true;
        }

        /// <summary>
        /// Gets ressetEllipse command
        /// </summary>
        public ICommand ResetEllipse
        {
            get
            {
                return this.resetEllipse ?? (this.resetEllipse = new CommandHandler(() => this.ResetCurrentEllipse(), true));
            }
        }

        /// <summary>
        /// Gets NewFile Command
        /// </summary>
        public ICommand NewFile
        {
            get
            {
                return this.newFile ?? (this.newFile = new CommandHandler(() => this.NewFileExecute(), this.canExecute));
            }
        }

        /// <summary>
        /// Gets OpenFile command
        /// </summary>
        public ICommand OpenFile
        {
            get
            {
                return this.openFile ?? (this.openFile = new CommandHandler(() => this.OpenFileExecute(), this.canExecute));
            }
        }

        /// <summary>
        /// Gets SaveFileCommand
        /// </summary>
        public ICommand SaveFile
        {
            get
            {
                return this.saveFile ?? (this.saveFile = new CommandHandler(() => this.SaveFileExecute(), this.canExecute));
            }
        }

        /// <summary>
        /// Opens new file
        /// </summary>
        public void OpenFileExecute()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Xml files (*.xml)|*.xml"
            };

            if (dialog.ShowDialog() == true)
            {
                this.ClearCanvas();
                List<EllipseInfo> ellipses = FileOperations.Deserialize(dialog.FileName);
                foreach (EllipseInfo ellipse in ellipses)
                {
                    this.ellipseCanvas.AddEllipse(ellipse);
                }
            }
        }

        /// <summary>
        /// Saves current ellipses
        /// </summary>
        public void SaveFileExecute()
        {
            try
            {
                if (this.ellipseCanvas.IsEmpty() == true)
                {
                    throw new ArgumentNullException("There aren't shapes on the drawing area");
                }

                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "Xml files (*.xml)|*.xml"
                };

                if (dialog.ShowDialog() == true)
                {
                    FileOperations.Serialize(this.ellipseCanvas.Ellipses, dialog.FileName);
                }
            }
            catch (ArgumentNullException exp)
            {
                MessageBox.Show(exp.ParamName);
            }
        }

        /// <summary>
        /// Clear drawing area
        /// </summary>
        public void NewFileExecute()
        {
            this.ClearCanvas();
        }

        /// <summary>
        /// Resets current drawing area
        /// </summary>
        private void ResetCurrentEllipse()
        {
            this.ellipseCanvas.CurrentEllipse = null;
        }

        /// <summary>
        /// Adds new ellipse to drawing area
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="args">Provides data for the EllipseListChangedEventArgs event</param>
        private void EllipseCanvas_OnEllipseAdded(object sender, EllipseListChangedEventArgs args)
        {
            ChooseEllipseCommand toadd = new ChooseEllipseCommand { Canvas = this.ellipseCanvas, Ellipse = args.Ellipse };
            menuShapes.Items.Add(toadd);
            menuContext.Items.Add(toadd);
        }

        /// <summary>
        /// Clears all ellipses
        /// </summary>
        private void ClearCanvas()
        {
            for (int i = 1; i < menuContext.Items.Count;)
            {
                menuContext.Items.RemoveAt(i);
                menuShapes.Items.RemoveAt(i);
            }

            this.ellipseCanvas.Clear();
        }
    }
}
