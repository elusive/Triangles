using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Triangles
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            Model = new ViewModel();
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public ViewModel Model { get; set; }

        private void MainWindow_GenerateTrianglesButton_OnClick(object sender, RoutedEventArgs e)
        {
            var t = new TriangleGeometry(Model.RowEntered + 1, Model.ColumnEntered + 1);

            Model.PathData = t.GetPathData();
        }

        /// <summary>
        ///     Internal view model class for databinding.
        /// </summary>
        /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
        public class ViewModel : INotifyPropertyChanged
        {
            private int _columnEntered;
            private string _pathData;
            private int _rowEntered;
            private string _answer;
            private string _pointV1;
            private string _pointV2;
            private string _pointV3;

            /// <summary>
            /// Gets or sets the answer.
            /// </summary>
            public string Answer
            {
                get { return _answer; }
                set
                {
                    if (value == _answer)
                    {
                        return;
                    }

                    _answer = value;
                    OnPropertyChanged();
                }
            }

            /// <summary>
            /// Gets or sets the point v1.
            /// </summary>
            public string PointV1
            {
                get { return _pointV1; }
                set
                {
                    if (value == _pointV1)
                    {
                        return;
                    }

                    _pointV1 = value;
                    OnPropertyChanged();
                }
            }

            /// <summary>
            /// Gets or sets the point v2.
            /// </summary>
            public string PointV2
            {
                get { return _pointV2; }
                set
                {
                    if (value == _pointV2)
                    {
                        return;
                    }

                    _pointV2 = value;
                    OnPropertyChanged();
                }
            }

            /// <summary>
            /// Gets or sets the point v3.
            /// </summary>
            public string PointV3
            {
                get { return _pointV3; }
                set
                {
                    if (value == _pointV3)
                    {
                        return;
                    }

                    _pointV3 = value;
                    OnPropertyChanged();
                }
            }

            /// <summary>
            /// Gets or sets the row entered.
            /// </summary>
            public int RowEntered
            {
                get { return _rowEntered; }
                set
                {
                    if (value == _rowEntered)
                    {
                        return;
                    }

                    _rowEntered = value;
                    OnPropertyChanged();
                }
            }

            /// <summary>
            /// Gets or sets the column entered.
            /// </summary>
            public int ColumnEntered
            {
                get { return _columnEntered; }
                set
                {
                    if (value == _columnEntered)
                    {
                        return;
                    }

                    _columnEntered = value;
                    OnPropertyChanged();
                }
            }

            /// <summary>
            /// Gets or sets the path data.
            /// </summary>
            public string PathData
            {
                get { return _pathData; }
                set
                {
                    if (value == _pathData)
                    {
                        return;
                    }

                    _pathData = value;
                    OnPropertyChanged();
                }
            }

            /// <summary>
            /// Occurs when [property changed].
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;

            /// <summary>
            /// Called when [property changed].
            /// </summary>
            /// <param name="propertyName">Name of the property.</param>
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void MainWindowReverseCalculateButton_OnClick(object sender, RoutedEventArgs e)
        {
            // clear answer
            Model.Answer = "";

            const string rows = "ABCDEF";

            // validate point input strings
            try
            {
                var v1 = Point.Parse(Model.PointV1);
                var v2 = Point.Parse(Model.PointV2);
                var v3 = Point.Parse(Model.PointV3);

                var row = Convert.ToInt32(v2.Y / TriangleGeometry.Size);

                var col = v2.X == v1.X 
                    ? (v3.X / TriangleGeometry.Size).ToString(CultureInfo.InvariantCulture) 
                    : ((v3.X + TriangleGeometry.Size) / TriangleGeometry.Size).ToString();

                Model.Answer = rows[row] + col;
            }
            catch (Exception)
            {
                Model.Answer = "XX";
            }
        }
    }
}