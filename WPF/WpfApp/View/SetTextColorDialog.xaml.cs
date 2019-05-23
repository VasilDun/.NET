//-----------------------------------------------------------------------
// <copyright file="SetTextColorDialog.xaml.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------

namespace WpfApp
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for SetTextColorDialog.xaml
    /// </summary>
    public partial class SetTextColorDialog : UserControl
    {
        /// <summary>
        /// <see cref = "Brush"/> for contour
        /// </summary>
        private Brush contour;

        /// <summary>
        /// <see cref = "Brush"/> for fill
        /// </summary>
        private Brush fill;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetTextColorDialog" /> class
        /// </summary>
        public SetTextColorDialog()
        {
            this.InitializeComponent();
            this.NameItem = "item";
            txtName.Text = this.NameItem;
            this.Contour = Brushes.Black;
            btnContour.Background = this.Contour;
            this.Fill = Brushes.White;
            btnFill.Background = this.Fill;
        }

        /// <summary>
        /// Gets or sets item name
        /// </summary>
        public string NameItem { get; set; }

        /// <summary>
        /// Gets or sets <see cref = "Brush"/> contour property
        /// </summary>
        public Brush Contour
        {
            get
            {
                return this.contour;
            }

            set
            {
                this.contour = value;
            }
        }

        /// <summary>
        /// Gets or sets <see cref = "Brush"/> fill property
        /// </summary>
        public Brush Fill
        {
            get
            {
                return this.fill;
            }

            set
            {
                this.fill = value;
            }
        }

        /// <summary>
        /// Set contour color
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Provides data for the RoutedEventArgs event</param>
        private void BtnContour_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog dialog = new System.Windows.Forms.ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Color a = dialog.Color;
                SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(a.A, a.R, a.G, a.B));
                this.Contour = brush;
                btnContour.Background = this.Contour;
            }
        }

        /// <summary>
        /// Set fill color
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Provides data for the RoutedEventArgs event</param>
        private void BtnFill_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog dialog = new System.Windows.Forms.ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Color a = dialog.Color;
                SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(a.A, a.R, a.G, a.B));
                this.Fill = brush;
                btnFill.Background = this.Fill;
            }
        }

        /// <summary>
        /// Press OK
        /// </summary>
        /// <param name="sender">Reference to the object that raised the event</param>
        /// <param name="e">Provides data for the RoutedEventArgs event</param>
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Window window = this.Parent as Window;
            if (window != null)
            {
                this.NameItem = txtName.Text;
                window.DialogResult = true;
                window.Close();
            }
        }
    }
}
