//-----------------------------------------------------------------------
// <copyright file="EllipseCanvas.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------

namespace WpfApp
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Represents drawing area for ellipses
    /// </summary>
    public class EllipseCanvas
    {
        /// <summary>
        /// Canvas drawing area
        /// </summary>
        private Canvas canvas = new Canvas();

        /// <summary>
        /// <see cref = "List"/> of <see cref = "EllipseInfo"/>
        /// </summary>
        private List<EllipseInfo> ellipses = new List<EllipseInfo>();

        /// <summary>
        /// Current <see cref = "EllipseInfo"/>
        /// </summary>
        private EllipseInfo currentEllipse;

        /// <summary>
        /// Point to implement moving of ellipse
        /// </summary>
        private Point a;

        /// <summary>
        /// Point to implement moving of ellipse
        /// </summary>
        private Point b;

        /// <summary>
        /// Temprorary <see cref = "Ellipse"/> to implement moving of ellipse
        /// </summary>
        private Ellipse ellipseTemp;

        /// <summary>
        /// Allow drawing
        /// </summary>
        private bool isDraw = false;

        /// <summary>
        /// Initializes a new instance of the <see cref = "EllipseCanvas"/> class.
        /// Constructor without parameters
        /// </summary>
        public EllipseCanvas()
        {
            this.ellipseTemp = new Ellipse();
            this.ellipseTemp.Stroke = Brushes.Green;
            this.ellipseTemp.StrokeThickness = EllipseInfo.DefaultStrokeThickness;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "EllipseCanvas"/> class.
        /// Constructor with parameters
        /// </summary>
        /// <param name="canvas">Canvas drawing area</param>
        public EllipseCanvas(Canvas canvas) : this()
        {
            Canvas = canvas;
        }

        /// <summary>
        /// delegate for ListChangedEvent
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="args">Provides data for the EllipseListChangedEventArgs event</param>
        public delegate void ListChangedEvent(object sender, EllipseListChangedEventArgs args);

        /// <summary>
        /// Occurs when an item is added to the underlying list
        /// </summary>
        public event ListChangedEvent OnEllipseAdded;

        /// <summary>
        /// Occurs when an item is removed from the underlying list
        /// </summary>
        public event ListChangedEvent OnEllipseRemoved;

        /// <summary>
        /// Gets or sets canvas property.
        /// </summary>
        /// <value>
        /// A value tag is used to describe the property value.
        /// </value>
        public Canvas Canvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                if (this.canvas != null)
                {
                    this.canvas.MouseLeftButtonDown -= this.CanvasDrawingArea_MouseLeftButtonDown;
                    this.canvas.MouseLeftButtonUp -= this.CanvasDrawingArea_MouseLeftButtonUp;
                    this.canvas.MouseMove -= this.CanvasDrawingArea_MouseMove;
                }

                this.canvas = value;
                if (this.canvas != null)
                {
                    this.canvas.MouseLeftButtonDown += this.CanvasDrawingArea_MouseLeftButtonDown;
                    this.canvas.MouseLeftButtonUp += this.CanvasDrawingArea_MouseLeftButtonUp;
                    this.canvas.MouseMove += this.CanvasDrawingArea_MouseMove;
                }
            }
        }

        /// <summary>
        /// Gets <see cref = "List"/> of <see cref = "EllipseInfo"/>
        /// </summary>
        public List<EllipseInfo> Ellipses
        {
            get
            {
                return this.ellipses;
            }
        }

        /// <summary>
        /// Gets or sets current ellipse property.
        /// </summary>
        /// <value>
        /// A value tag is used to describe the property value.
        /// </value>
        public EllipseInfo CurrentEllipse
        {
            get
            {
                return this.currentEllipse;
            }

            set
            {
                if (this.currentEllipse != null)
                {
                    this.currentEllipse.Shape.StrokeThickness = EllipseInfo.DefaultStrokeThickness;
                    Canvas.SetZIndex(this.currentEllipse.Shape, 0);
                    this.currentEllipse.Shape.MouseLeftButtonDown -= this.Shape_MouseLeftButtonDown;
                    this.currentEllipse.Shape.MouseLeftButtonUp -= this.Shape_MouseLeftButtonUp;
                    this.currentEllipse.Shape.MouseMove -= this.Shape_MouseMove;
                    this.currentEllipse.Shape.KeyDown -= this.Ellipse_KeyDown;
                    this.currentEllipse.Shape.Focusable = false;
                }
                else
                {
                    this.canvas.MouseLeftButtonDown -= this.CanvasDrawingArea_MouseLeftButtonDown;
                    this.canvas.MouseLeftButtonUp -= this.CanvasDrawingArea_MouseLeftButtonUp;
                    this.canvas.MouseMove -= this.CanvasDrawingArea_MouseMove;
                }

                this.currentEllipse = value;
                if (this.currentEllipse != null)
                {
                    this.currentEllipse.Shape.StrokeThickness = EllipseInfo.DefaultStrokeThickness * 2;
                    this.currentEllipse.Shape.MouseLeftButtonDown += this.Shape_MouseLeftButtonDown;
                    this.currentEllipse.Shape.MouseLeftButtonUp += this.Shape_MouseLeftButtonUp;
                    this.currentEllipse.Shape.MouseMove += this.Shape_MouseMove;
                    this.currentEllipse.Shape.KeyDown += this.Ellipse_KeyDown;
                    Canvas.SetZIndex(this.currentEllipse.Shape, 1);
                    this.currentEllipse.Shape.Focusable = true;
                    Keyboard.ClearFocus();
                    Keyboard.Focus(this.currentEllipse.Shape);
                }
                else
                {
                    this.canvas.MouseLeftButtonDown += this.CanvasDrawingArea_MouseLeftButtonDown;
                    this.canvas.MouseLeftButtonUp += this.CanvasDrawingArea_MouseLeftButtonUp;
                    this.canvas.MouseMove += this.CanvasDrawingArea_MouseMove;
                }
            }
        }

        /// <summary>
        /// Adds <see cref = "EllipseInfo"/> to drawing area
        /// </summary>
        /// <param name="ellipse"><see cref = "EllipseInfo"/> to add</param>
        public void AddEllipse(EllipseInfo ellipse)
        {
            this.ellipses.Add(ellipse);
            Canvas.SetZIndex(ellipse.Shape, 0);
            Canvas.SetLeft(ellipse.Shape, ellipse.TopLeft.X);
            Canvas.SetTop(ellipse.Shape, ellipse.TopLeft.Y);
            this.Canvas.Children.Add(ellipse.Shape);
            this.OnEllipseAdded?.Invoke(this, new EllipseListChangedEventArgs(ellipse, this));
        }

        /// <summary>
        /// Clears list of <see cref = "EllipseInfo"/>
        /// </summary>
        public void Clear()
        {
            foreach (EllipseInfo ellipse in this.ellipses)
            {
                this.OnEllipseRemoved?.Invoke(this, new EllipseListChangedEventArgs(ellipse, this));
            }

            this.currentEllipse = null;
            this.ellipses.Clear();
            Canvas.Children.Clear();
        }

        /// <summary>
        /// Removes ellipse from list
        /// </summary>
        /// <param name="ellipse"><see cref = "EllipseInfo"/> to remove</param>
        public void RemoveEllipse(EllipseInfo ellipse)
        {
            this.ellipses.Remove(ellipse);
            if (ReferenceEquals(this.currentEllipse, ellipse))
            {
                this.currentEllipse = null;
            }

            Canvas.Children.Remove(ellipse.Shape);
            this.OnEllipseRemoved?.Invoke(this, new EllipseListChangedEventArgs(ellipse, this));
        }

        /// <summary>
        /// Checks whether list is empty
        /// </summary>
        /// <returns>bool value</returns>
        public bool IsEmpty()
        {
            return this.ellipses.Count == 0;
        }

        /// <summary>
        /// Shift <see cref = "EllipseInfo"/> so it has top left <see cref = "Point"/> similar to given
        /// </summary>
        /// <param name="ellipse"><see cref = "EllipseInfo"/> to shift</param>
        /// <param name="shift"><see cref = "Point"/> destination</param>
        private void MoveEllipse(EllipseInfo ellipse, Point shift)
        {
            ellipse.TopLeft = new Point(ellipse.TopLeft.X + shift.X, ellipse.TopLeft.Y + shift.Y);
            Canvas.SetTop(ellipse.Shape, ellipse.TopLeft.Y);
            Canvas.SetLeft(ellipse.Shape, ellipse.TopLeft.X);
        }

        /// <summary>
        /// Handle the MouseLeftButtonDown event
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event.</param>
        /// <param name="e">Provides data for the MouseButtonEventArgs event</param>
        private void Shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.a = e.GetPosition(Canvas);
            this.isDraw = true;
        }

        /// <summary>
        /// Handle the KeyDown event
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event.</param>
        /// <param name="e">Provides data for the KeyDown event</param>
        private void Ellipse_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.ClearFocus();
            Key k = e.Key;
            switch (k)
            {
                case Key.Down:
                    {
                        this.MoveEllipse(this.currentEllipse, new Point(0.0, 1));
                        break;
                    }

                case Key.Up:
                    {
                        this.MoveEllipse(this.currentEllipse, new Point(0.0, -1));
                        break;
                    }

                case Key.Left:
                    {
                        this.MoveEllipse(this.currentEllipse, new Point(-1, 0.0));
                        break;
                    }

                case Key.Right:
                    {
                        this.MoveEllipse(this.currentEllipse, new Point(1, 0.0));
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

            e.Handled = true;
            Keyboard.Focus(this.currentEllipse.Shape);
        }

        /// <summary>
        /// Handle the MouseLeftButtonUp event
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event.</param>
        /// <param name="e">Provides data for the MouseButtonEventArgs event</param>
        private void Shape_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.isDraw = false;
        }

        /// <summary>
        /// Handle the MouseMove event
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event.</param>
        /// <param name="e">Provides data for the MouseEventArgs event</param>
        private void Shape_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isDraw)
            {
                this.b = e.GetPosition(Canvas);
                this.currentEllipse.TopLeft += this.b - this.a;
                this.a = this.b;
                Canvas.SetTop(this.currentEllipse.Shape, this.currentEllipse.TopLeft.Y);
                Canvas.SetLeft(this.currentEllipse.Shape, this.currentEllipse.TopLeft.X);
            }
        }

        /// <summary>
        /// Handle the OnEndCreation event
        /// </summary>
        /// <param name="e">Provides data for the MouseEventArgs event</param>
        private void OnEndCreation(MouseEventArgs e)
        {
            SetTextColorDialog dialog = new SetTextColorDialog();
            Window window = new Window
            {
                Title = "Name and color",
                Content = dialog,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize
            };
            if (window.ShowDialog() == true)
            {
                EllipseInfo ellipse = new EllipseInfo();
                ellipse.Shape.Height = Math.Abs(this.a.Y - this.b.Y);
                ellipse.Shape.Width = Math.Abs(this.a.X - this.b.X);
                ellipse.Shape.Stroke = dialog.Contour;
                ellipse.Shape.StrokeThickness = EllipseInfo.DefaultStrokeThickness;
                ellipse.Shape.Fill = dialog.Fill;
                ellipse.Name = dialog.NameItem;
                ellipse.TopLeft = new Point(this.a.X > this.b.X ? this.b.X : this.a.X, this.a.Y > this.b.Y ? this.b.Y : this.a.Y);
                this.AddEllipse(ellipse);
            }

            Canvas.Children.Remove(this.ellipseTemp);
            this.isDraw = false;
        }

        /// <summary>
        /// Handle the MouseLeftButtonDown event
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event.</param>
        /// <param name="e">Provides data for the MouseButtonEventArgs event</param>
        private void CanvasDrawingArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.a = e.GetPosition(Canvas);
            this.ellipseTemp.Width = 0;
            this.ellipseTemp.Height = 0;
            Canvas.Children.Add(this.ellipseTemp);
            this.isDraw = true;
        }

        /// <summary>
        /// Handle the MouseLeftButtonUp event
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event.</param>
        /// <param name="e">Provides data for the MouseButtonEventArgs event</param>
        private void CanvasDrawingArea_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.OnEndCreation(e);
        }

        /// <summary>
        /// Handle the MouseMove event
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event.</param>
        /// <param name="e">Provides data for the MouseEventArgs event</param>
        private void CanvasDrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isDraw)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.b = e.GetPosition(Canvas);
                    this.ellipseTemp.Height = Math.Abs(this.a.Y - this.b.Y);
                    this.ellipseTemp.Width = Math.Abs(this.a.X - this.b.X);
                    Canvas.SetLeft(this.ellipseTemp, this.a.X > this.b.X ? this.b.X : this.a.X);
                    Canvas.SetTop(this.ellipseTemp, this.a.Y > this.b.Y ? this.b.Y : this.a.Y);
                }
                else
                {
                    this.OnEndCreation(e);
                }
            }
        }
    }
}
