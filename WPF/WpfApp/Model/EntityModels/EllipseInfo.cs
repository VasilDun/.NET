//-----------------------------------------------------------------------
// <copyright file="EllipseInfo.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------

namespace WpfApp
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents Ellipse with top left point
    /// </summary>
    [Serializable]
    public class EllipseInfo
    {
        /// <summary>
        /// Stroke thickness for ellipse (<see cref="Shape"/> property)
        /// </summary>
        public static readonly double DefaultStrokeThickness = 1.5;

        /// <summary>
        /// Initializes a new instance of the <see cref = "EllipseInfo"/> class.
        /// Constructor without parameters
        /// </summary>
        public EllipseInfo()
        {
            this.Shape = new Ellipse();
            this.Shape.StrokeThickness = DefaultStrokeThickness;
        }

        /// <summary>
        /// Gets or sets point property.
        /// </summary>
        public Point TopLeft { get; set; }

        /// <summary>
        /// Gets or sets name property.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets ellipse property.
        /// </summary>
        [XmlIgnore]
        public Ellipse Shape { get; set; }

        /// <summary>
        /// Gets or sets stroke property.
        /// </summary>
        /// <value>
        /// A value tag is used to describe the property value.
        /// </value>
        public Color Stroke
        {
            get
            {
                return FromBrush(this.Shape.Stroke);
            }

            set
            {
                this.Shape.Stroke = new SolidColorBrush(value);
            }
        }

        /// <summary>
        /// Gets or sets fill property.
        /// </summary>
        /// <value>
        /// A value tag is used to describe the property value
        /// </value>
        public Color Fill
        {
            get
            {
                return FromBrush(this.Shape.Fill);
            }

            set
            {
                this.Shape.Fill = new SolidColorBrush(value);
            }
        }

        /// <summary>
        /// Gets or sets width property.
        /// </summary>
        /// <value>
        /// A value tag is used to describe the property value.
        /// </value>
        public double Width
        {
            get
            {
                return this.Shape.Width;
            }

            set
            {
                this.Shape.Width = value;
            }
        }

        /// <summary>
        /// Gets or sets height property.
        /// </summary>
        /// <value>
        /// A value tag is used to describe the property value.
        /// </value>
        public double Height
        {
            get
            {
                return this.Shape.Height;
            }

            set
            {
                this.Shape.Height = value;
            }
        }

        /// <summary>
        /// Gets color
        /// </summary>
        /// <param name="br">Brush to paint</param>
        /// <returns>New color</returns>
        private static Color FromBrush(Brush br)
        {
            byte a = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).A;
            byte g = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).G;
            byte r = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).R;
            byte b = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).B;
            return new Color { A = a, R = r, G = g, B = b };
        }
    }
}
