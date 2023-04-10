using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixEffect
{
    internal class Matrix
    {
        private List<MatrixSegment> matrix = new List<MatrixSegment>();
        private AutoResetEvent wait = new AutoResetEvent(true);

        public void Start()
        {
            Console.CursorVisible = false;

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                matrix.Add(new MatrixSegment(i));
            }

            foreach (MatrixSegment segment in matrix)
            {
                Thread drawThread = new Thread(() => segment.Print(wait));
                drawThread.Start();
            }
        }
    }
}
