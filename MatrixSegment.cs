using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixEffect
{
    //Matrix color: 15 - white, 10 light green, 2 - green, 0 - black
    internal class MatrixSegment
    {
        private int x = /*new Random().Next(0, Console.BufferWidth);*/4;
        private int y = 0;
        private const int segmentLength = Config.segmentLength;

        private Stack<char> segmentSymbols = new Stack<char>();
        
        private int sybolsLength = symbols.Length;

        private Random rand = new Random();
        private const string symbols = "123456789abcdefghijklmnopqastuvwxyzABCDEFGHIJKLMNOPQASTUVWXYZ#@$&?+-=";

        public void Print(AutoResetEvent wait)
        {
            while(true)
            {
                while (true)
                {
                    if (segmentSymbols.Count < Console.WindowHeight)
                    {
                        segmentSymbols.Push(symbols[rand.Next(0, sybolsLength)]);
                    }
                    y++;

                    if (y > (Console.WindowHeight + segmentLength)) break;

                    int count = y;

                    wait.WaitOne();
                    foreach (char symbol in segmentSymbols)
                    {
                        count--;
                        if (count >= Console.WindowHeight) count = Console.WindowHeight - 1;

                        Console.ForegroundColor = MatrixLetterColor(y - count - 1);

                        Console.SetCursorPosition(x, count);
                        Console.Write(symbol);
                    }
                    wait.Set();

                    Thread.Sleep(50);
                }

                
                y = 0;
                segmentSymbols.Clear();
                Thread.Sleep(500);
            }
        }
        private ConsoleColor MatrixLetterColor(int position)
        {
             return position switch
             {
                 0 => (ConsoleColor)14,
                 1 => (ConsoleColor)15,
                 2 => (ConsoleColor)7,
                 < 12 => (ConsoleColor)10,
                 < segmentLength => (ConsoleColor)2,
                 _ => (ConsoleColor)0
             };
        }
    }
}
