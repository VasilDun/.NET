//-----------------------------------------------------------------------
// <copyright file="TestEllipseCanvas.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------

namespace UnitTest
{
    using System.Windows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WpfApp;

    /// <summary>
    /// Tests class EllipseCanvas
    /// </summary>
    [TestClass]
    public class TestEllipseCanvas
    {
        /// <summary>
        /// Tests Clear() method (whether elements count is zero after clearing)
        /// </summary>
        [TestMethod]
        public void TestClear()
        {
            EllipseCanvas canvas = new EllipseCanvas();
            int ellipseCount = 10;
            for (int i = 0; i < ellipseCount; ++i)
            {
                canvas.AddEllipse(CreateEllipse(new Point(100 * i, 50 * i), 20 * i, 30 * i, "item"));
            }

            canvas.Clear();
            Assert.IsTrue(canvas.IsEmpty());
        }

        /// <summary>
        /// Tests adding element to canvas
        /// </summary>
        [TestMethod]
        public void TestAddEllipse()
        {
            EllipseCanvas canvas = new EllipseCanvas();
            Point pos = new Point(20, 20);
            double height = 10;
            double width = 40;
            string name = "name";
            EllipseInfo ellipse = CreateEllipse(pos, width, height, name);
            canvas.AddEllipse(ellipse);
            EllipseInfo addedEllipse = canvas.Ellipses[0];
            Assert.AreEqual(ellipse.Name, addedEllipse.Name);
            Assert.AreEqual(ellipse.Height, addedEllipse.Height);
            Assert.AreEqual(ellipse.Width, addedEllipse.Width);
            Assert.AreEqual(ellipse.TopLeft, addedEllipse.TopLeft);
            Assert.AreEqual(1, canvas.Ellipses.Count);
        }

        /// <summary>
        /// Tests adding multiple ellipses to canvas
        /// </summary>
        [TestMethod]
        public void TestAddEllipseMultiple()
        {
            EllipseCanvas canvas = new EllipseCanvas();
            int ellipseCount = 10;
            EllipseInfo newbee;

            for (int i = 0; i < ellipseCount; ++i)
            {
                newbee = CreateEllipse(new Point(100 * i, 50 * i), 20 * i, 30 * i, "item");
                canvas.AddEllipse(newbee);
                Assert.IsTrue(canvas.Ellipses.Contains(newbee));
            }

            Assert.AreEqual(ellipseCount, canvas.Ellipses.Count);
        }

        /// <summary>
        /// Tests removing single ellipse from canvas
        /// </summary>
        [TestMethod]
        public void TestRemoveEllipse()
        {
            EllipseCanvas canvas = new EllipseCanvas();
            int ellipseCount = 10;
           
            for (int i = 0; i < ellipseCount; ++i)
            {
                canvas.AddEllipse(CreateEllipse(new Point(100 * i, 50 * i), 20 * i, 30 * i, "item"));
            }

            Point pos = new Point(20, 20);
            double height = 10;
            double width = 40;
            string name = "name";
            EllipseInfo ellipse = CreateEllipse(pos, width, height, name);

            canvas.AddEllipse(ellipse);
            canvas.RemoveEllipse(ellipse);

            Assert.AreEqual(ellipseCount, canvas.Ellipses.Count);
            Assert.IsFalse(canvas.Ellipses.Contains(ellipse));
        }

        /// <summary>
        /// Convenient method to create ellipse
        /// </summary>
        /// <param name="topleft">Top-left coordinate of ellipse's bounding rectangle</param>
        /// <param name="width">Width of ellipse's bounding rectangle</param>
        /// <param name="height">Height of ellipse's bounding rectangle</param>
        /// <param name="name">Name of ellipse</param>
        /// <returns>Newly created ellipse</returns>
        private static EllipseInfo CreateEllipse(Point topleft, double width, double height, string name)
        {
            return new EllipseInfo
            {
                TopLeft = topleft,
                Width = width,
                Height = height,
                Name = name
            };
        }
    }
}
