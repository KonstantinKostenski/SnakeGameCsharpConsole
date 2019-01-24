using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SnakeGameConsoleCSharp
{
    public class Snake
    {
        public void Start()
        {
            Queue<Position> snakeElements = new Queue<Position>();

            List<Position> directions = new List<Position>()
            {
                new Position(0, -1),
                new Position(-1, 0),
                new Position(0,1),
                new Position(1, 0)
            }; 

            int left = 0;
            int up = 1;
            int right = 2;
            int down = 3;

            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            Random random = new Random();

            int direction = 2;

            for (int i = 0; i < 6; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }

            foreach (var element in snakeElements)
            {
                Console.SetCursorPosition(element.Col, element.Row);
                Console.Write('*');
            }

            Position food = new Position(random.Next(0, Console.WindowHeight), random.Next(0, Console.WindowWidth));

            while (snakeElements.Contains(food))
            {
                food = new Position(random.Next(0, Console.WindowHeight), random.Next(0, Console.WindowWidth));

            }

            Console.SetCursorPosition(food.Col, food.Row);
            Console.Write('@');

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        direction = left;
                    }
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        direction = up;
                    }
                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        direction = right;
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        direction = down;
                    }
                }


                Position nextDirection = directions[direction];
                Position snakeLastHead = snakeElements.Last();
                Position snakeNewHead = new Position(snakeLastHead.Row + nextDirection.Row, snakeLastHead.Col + nextDirection.Col);
                snakeElements.Enqueue(snakeNewHead);

                if (snakeNewHead.Row >= Console.WindowHeight || snakeNewHead.Row < 0 || snakeNewHead.Col >= Console.WindowWidth || snakeNewHead.Col < 0 )
                {
                    Console.SetCursorPosition(Console.BufferWidth / 2, Console.BufferHeight / 2);
                    Console.WriteLine($"Game Over! Score:{(snakeElements.Count - 6) * 100}");
                }
                else
                {
                    Console.SetCursorPosition(snakeNewHead.Col, snakeNewHead.Row);
                    Console.Write('*');
                }


                if (snakeNewHead.Col == food.Col && snakeNewHead.Row == food.Row)
                {
                    Console.SetCursorPosition(food.Col, food.Row);
                    Console.Write(' ');

                    do
                    {
                        food = new Position(random.Next(0, Console.WindowHeight), random.Next(0, Console.WindowWidth));
                    } while (snakeElements.Contains(food));
                }
                else
                {
                    var tail = snakeElements.First();
                    Console.SetCursorPosition(tail.Col, tail.Row);
                    Console.Write(' ');
                    snakeElements.Dequeue();
                }

                Console.SetCursorPosition(food.Col, food.Row);
                Console.Write('@');

                Thread.Sleep(100);
            }

        }
    }
}
