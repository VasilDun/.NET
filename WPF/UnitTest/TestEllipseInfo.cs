//-----------------------------------------------------------------------
// <copyright file="TestEllipseInfo.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTest
{
    using System.Windows;
    using System.Windows.Media;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WpfApp;

    /// <summary>
    /// Tests EllipseInfo properties
    /// </summary>
    [TestClass]
    public class TestEllipseInfo
    {
        /// <summary>
        /// Test Name property
        /// </summary>
        [TestMethod]
        public void TestNameProperty()
        {
            string name = "shape1";
            EllipseInfo ellipse = new EllipseInfo();
            ellipse.Name = name;
            Assert.AreEqual(ellipse.Name, name);
        }

        /// <summary>
        /// Test TopLeft property
        /// </summary>
        [TestMethod]
        public void TestTopLeftProperty()
        {
            Point point = new Point(10, 12.5);
            EllipseInfo ellipse = new EllipseInfo();
            ellipse.TopLeft = point;
            Assert.AreEqual(ellipse.TopLeft, point);
        }

        /// <summary>
        /// Test Width property
        /// </summary>
        [TestMethod]
        public void TestWidthProperty()
        {
            double width = 54;
            EllipseInfo ellipse = new EllipseInfo();
            ellipse.Width = width;
            Assert.AreEqual(ellipse.Width, width);
        }

        /// <summary>
        /// Test Height property
        /// </summary>
        [TestMethod]
        public void TestHeightProperty()
        {
            double height = 54;
            EllipseInfo ellipse = new EllipseInfo();
            ellipse.Height = height;
            Assert.AreEqual(ellipse.Height, height);
        }

        /// <summary>
        /// Test Fill property
        /// </summary>
        [TestMethod]
        public void TestFillProperty()
        {
            Color color = Colors.Azure;
            EllipseInfo ellipse = new EllipseInfo();
            ellipse.Fill = color;
            Assert.AreEqual(ellipse.Fill, color);
        }

        /// <summary>
        /// Test Stroke property
        /// </summary>
        [TestMethod]
        public void TestStrokeProperty()
        {
            Color color = Colors.AntiqueWhite;
            EllipseInfo ellipse = new EllipseInfo();
            ellipse.Stroke = color;
            Assert.AreEqual(ellipse.Stroke, color);
        }
    }
}
