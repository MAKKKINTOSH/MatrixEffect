using MatrixEffect;

namespace MatrixEffect
{
    //Matrix color: 15 - white, 10 light green, 2 - green, 0 - black
    internal class MatrixSegment
    {

        private int x = 0;
        private int y = 0;

        private Stack<char> segmentSymbols = new Stack<char>();

        private const string symbols = "123456789abcdefghijklmnopqastuvwxyzABCDEFGHIJKLMNOPQASTUVWXYZ#@$&?+-=";
        private int sybolsLength = symbols.Length;

        private Random rand = new Random();

        public MatrixSegment(int x)
        {
            this.x = x;
        }

        public void Print(AutoResetEvent wait)
        {
            while(true)
            {
                Thread.Sleep(rand.Next(Config.segmentSleepInterval[0], Config.segmentSleepInterval[1]));

                while (true)
                {
                    if (segmentSymbols.Count < Console.WindowHeight)
                    {
                        segmentSymbols.Push(symbols[rand.Next(0, sybolsLength)]);
                    }
                    y++;

                    if (y > (Console.WindowHeight + Config.segmentLength)) break;

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

                    Thread.Sleep(rand.Next(Config.symbolSleepInterval[0], Config.symbolSleepInterval[1]));
                }

                y = 0;
                segmentSymbols.Clear();
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
                 < Config.segmentLength => (ConsoleColor)2,
                 _ => (ConsoleColor)0
             };
        }
    }
}
