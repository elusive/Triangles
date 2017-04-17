using System.Windows;

namespace Triangles
{
    /// <summary>
    /// Refers to the direction the right angle corner is facing.
    /// </summary>
    public enum TriangleDirection
    {
        Up,
        Down
    }

    /// <summary>
    /// Class to represent a triangle in our application.
    /// </summary>
    public class TriangleGeometry
    {
        /// <summary>
        /// The size of the triangle's sides.
        /// </summary>
        public const int Size = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="TriangleGeometry"/> class.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        public TriangleGeometry(int row, int col)
        {
            Direction = col % 2 == 0 
                ? TriangleDirection.Up 
                : TriangleDirection.Down;

            var y = (row * Size) - Size;
            var x = (Direction == TriangleDirection.Up)
                ? ((col / 2) * Size) - Size
                : (col / 2) * Size;

            StartingPoint = new Point(x, y);
            GenerateRemainingPoints();
        }

        /// <summary>
        /// Gets or sets the starting point.
        /// </summary>
        public Point StartingPoint { get; set; }

        /// <summary>
        /// Gets or sets the right angle point.
        /// </summary>
        public Point RightAnglePoint { get; set; }

        /// <summary>
        /// Gets or sets the ending point.
        /// </summary>
        public Point EndingPoint { get; set; }

        /// <summary>
        /// Gets or sets the direction of the triangle's right angled corner.
        /// </summary>
        public TriangleDirection Direction { get; set; }

        /// <summary>
        /// Gets the path data.
        /// </summary>
        /// <returns>String path data using mini-language
        /// for binding in xaml.</returns>
        public string GetPathData()
        {
            const string fmt = @"M{0} L{1} {2} {3}Z";
                
            return string.Format(fmt, 
                StartingPoint, 
                RightAnglePoint, 
                EndingPoint,
                StartingPoint);
        }

        private void GenerateRemainingPoints()
        {
            if (Direction == TriangleDirection.Up)
            {
                RightAnglePoint = new Point(
                    StartingPoint.X + Size,
                    StartingPoint.Y);
                EndingPoint = new Point(
                    RightAnglePoint.X,
                    RightAnglePoint.Y + Size);
            }
            else
            {
                RightAnglePoint = new Point(
                    StartingPoint.X,
                    StartingPoint.Y + Size);
                EndingPoint = new Point(
                    RightAnglePoint.X + Size,
                    RightAnglePoint.Y);
            }
        }
    }
}