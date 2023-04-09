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

        private Queue<char> segmentSymbols = new Queue<char>();
        
        private int sybolsLength = symbols.Length;

        private Random rand = new Random();
        private const string symbols = "123456789abcdefghijklmnopqastuvwxyzABCDEFGHIJKLMNOPQASTUVWXYZ#@$&?+-=";

        public void Print(AutoResetEvent wait)
        {
            while(true)
            {
                segmentSymbols.Enqueue(symbols[rand.Next(0, sybolsLength)]);
                int count = y + 1;

                wait.WaitOne();
                foreach (char symbol in segmentSymbols.Reverse())
                {
                    count--;
                    if (count >= Console.WindowHeight) continue;
                    Console.ForegroundColor = (y - count) switch
                    {
                        0 => (ConsoleColor)15,
                        < 12 => (ConsoleColor)10,
                        < 20 => (ConsoleColor)2,
                        _ => (ConsoleColor)0
                    };
                    Console.SetCursorPosition(x, count);
                    Console.Write(symbol);
                }
                wait.Set();

                y++;
                Thread.Sleep(100);
            }
        }
    }
}
