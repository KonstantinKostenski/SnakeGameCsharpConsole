using System;

namespace SnakeGameConsoleCSharp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Snake snake = new Snake();
            snake.Start();
        }
    }
}
