//-----------------------------------------------------------------------
// <copyright file="EllipseListChangedEventArgs.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------

namespace WpfApp
{
    /// <summary>
    /// Class to handle ListChangedEventArgs event
    /// </summary>
    public class EllipseListChangedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseListChangedEventArgs"/> class
        /// </summary>
        /// <param name="ellipse">Shape ellipse</param>
        /// <param name="canvas">Canvas drawing area</param>
        public EllipseListChangedEventArgs(EllipseInfo ellipse, EllipseCanvas canvas)
        {
            this.Ellipse = ellipse;
            this.Canvas = canvas;
        }

        /// <summary>
        /// Gets or sets <see cref = "EllipseInfo"/>
        /// </summary>
        public EllipseInfo Ellipse { get; set; }

        /// <summary>
        /// Gets or sets <see cref = "EllipseCanvas"/>
        /// </summary>
        public EllipseCanvas Canvas { get; set; }
    }
}
