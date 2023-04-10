using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixEffect
{
    internal static class Config
    {
        public const int symbolsInSegment = 10;
        public const int segmentLength = 20;

        public static readonly int[] segmentSleepInterval = { 1000, 10000 };
        public static readonly int[] symbolSleepInterval = { 5, 400 };
    }
}
