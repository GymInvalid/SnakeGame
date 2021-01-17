using System;
using System.Threading;

namespace ConsoleApp1
{
    public class Snake
    {
        int[] tailX = new int[100];
        int[] tailY = new int[100];
        int score = 0;
        int height = 20;
        int width = 20;
        int nTail;
        int headX;
        int headY;
        int fruitX;
        int fruitY;
        public bool gameOver;
        public int speed = 90;
        public Snake()
        {
            headX = width / 2;
            headY = height / 2;
            gameOver = false;
        }
        enum eDirection
        {
            STOP,
            LEFT,
            RIGHT,
            UP,
            DOWN
        }
        eDirection dir;

        public void getFruitsCords()
        {
            Random ran = new Random();
            fruitX = ran.Next(1, width - 2);
            fruitY = ran.Next(1, height - 2);
        }
        public void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo name = Console.ReadKey(true);
                switch (name.KeyChar)
                {
                    case 'a':
                        if (dir != eDirection.RIGHT)
                        {
                            dir = eDirection.LEFT;
                        }
                        break;
                    case 'd':
                        if (dir != eDirection.LEFT)
                        {
                            dir = eDirection.RIGHT;
                        }
                        break;
                    case 's':
                        if (dir != eDirection.UP)
                        {
                            dir = eDirection.DOWN;
                        }
                        break;
                    case 'w':
                        if (dir != eDirection.DOWN)
                        {
                            dir = eDirection.UP;
                        }
                        break;
                    case 'ф':
                        if (dir != eDirection.RIGHT)
                        {
                            dir = eDirection.LEFT;
                        }
                        break;
                    case 'в':
                        if (dir != eDirection.LEFT)
                        {
                            dir = eDirection.RIGHT;
                        }
                        break;
                    case 'ы':
                        if (dir != eDirection.UP)
                        {
                            dir = eDirection.DOWN;
                        }
                        break;
                    case 'ц':
                        if (dir != eDirection.DOWN)
                        {
                            dir = eDirection.UP;
                        }
                        break;
                    case 'x':
                        gameOver = true;
                        break;
                }
            }
        }

        public void Logic()
        {
            int prevX = tailX[0];
            int prevY = tailY[0];
            int prev2X, prev2Y;
            tailX[0] = headX;
            tailY[0] = headY;
            for (int i = 1; i < nTail; i++)
            {
                prev2X = tailX[i];
                prev2Y = tailY[i];
                tailX[i] = prevX;
                tailY[i] = prevY;
                prevX = prev2X;
                prevY = prev2Y;
                if (headX == prev2X && headY == prev2Y)
                {
                    gameOver = true;
                }
            }

            if (headX == fruitX && headY == fruitY)
            {
                Random ran = new Random();
                fruitX = ran.Next(1, width - 2);
                fruitY = ran.Next(1, height - 2);
                score += 1;
                nTail += 1;
                speed -= 3;
            }

            if ((headX == 0 || headY == 0) || (headX == width - 1 || headY == height - 1))
            {
                gameOver = true;
            }

            switch (dir)
            {
                case (eDirection.LEFT):
                    headX -= 1;
                    break;
                case (eDirection.RIGHT):
                    headX += 1;
                    break;
                case (eDirection.DOWN):
                    headY++;
                    break;
                case (eDirection.UP):
                    headY--;
                    break;
            }
        }
        public void Draw()
        {

            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bool isEmpty = true;
                    if (y == headY && x == headX && isEmpty == true)
                    {
                        Console.Write("0");
                        isEmpty = false;
                    }

                    for (int k = 0; k < nTail; k++)
                    {
                        if (tailY[k] == y && tailX[k] == x)
                        {
                            Console.Write("1");
                            isEmpty = false;
                        }
                    }

                    if (y == fruitY && x == fruitX && isEmpty == true)
                    {
                        Console.Write("F");
                        isEmpty = false;
                    }

                    if (y > 0 && y < height - 1 && x != 0 && x != width - 1)
                    {
                        if (isEmpty == true)
                            Console.Write(" ");
                    }
                    else
                    {
                        if (isEmpty == true)
                            Console.Write("#");
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine(score);

        }
    }
    class Program
    {
        static void Main()
        {
            Snake snake = new Snake();
            snake.getFruitsCords();
            while (snake.gameOver == false)
            {
                Thread.Sleep(snake.speed);
                snake.Input();
                snake.Logic();
                snake.Draw();
            }
                if (snake.gameOver == true)
                {
                    Console.Clear();
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine("Press R to restart");
                        ConsoleKeyInfo name = Console.ReadKey(true);
                        switch (name.KeyChar)
                        {
                            case 'r':
                            Console.Clear();
                            Main();
                                break;
                        }

                }
            Console.ReadKey();
        }
    }
}
