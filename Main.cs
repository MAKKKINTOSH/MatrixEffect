using System.Drawing;

namespace MatrixEffect
{
    class Program
    {
        private static AutoResetEvent wait = new AutoResetEvent(true);
        public static void Main(string[] args)
        {
            /*Matrix matrix = new Matrix();
            matrix.Start();*/

            MatrixSegment segment = new MatrixSegment();
            segment.Print(wait);
        }
    }
}