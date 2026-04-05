using System.Timers;
using DickSnake.BusinessLogic.Helpers;
using DickSnake.Models;

public class SnakeManager
{
    private IKeyHelper _keyHelper;

    System.Timers.Timer timer;
    SnakeDirection way = SnakeDirection.Right;
    int speed = 1000; //  минимальная скорость это 100 
    int eatFood = 0; // кол во фруктов сьединных

    public SnakeManager(IKeyHelper keyHelper)
    {
        _keyHelper = keyHelper;

        _keyHelper.KeyPressed += key =>
        {
            // Блокировка разворота на 180 градусов
            if ((key == ConsoleKey.W && way != SnakeDirection.Down) ||
                (key == ConsoleKey.S && way != SnakeDirection.Up) ||
                (key == ConsoleKey.A && way != SnakeDirection.Right) ||
                (key == ConsoleKey.D && way != SnakeDirection.Left))
            {
                switch (key)
                {
                    case ConsoleKey.W:
                        way = SnakeDirection.Up;
                        break;
                    case ConsoleKey.S:
                        way = SnakeDirection.Down;
                        break;
                    case ConsoleKey.A:
                        way = SnakeDirection.Left;
                        break;
                    case ConsoleKey.D:
                        way = SnakeDirection.Right;
                        break;
                }
            }
        };
        timer = new System.Timers.Timer();
        timer.Interval = speed;
        timer.Elapsed += updateSnake;
        timer.Start();

    }
    public void updateSnake(object? sender, ElapsedEventArgs e)
    {
        bool hasEatenFood = Field.foods.Any(food =>
            food.getX() == Field.snake.facePosX && food.getY() == Field.snake.facePosY);

        int oldFaceX = Field.snake.facePosX;
        int oldFaceY = Field.snake.facePosY;

        switch (way)
        {
            case SnakeDirection.Up:
                Field.snake.facePosY = (Field.snake.facePosY - 1 + Field.gridHeight) % Field.gridHeight;
                break;
            case SnakeDirection.Down:
                Field.snake.facePosY = (Field.snake.facePosY + 1) % Field.gridHeight;
                break;
            case SnakeDirection.Left:
                Field.snake.facePosX = (Field.snake.facePosX - 1 + Field.gridWidth) % Field.gridWidth;
                break;
            case SnakeDirection.Right:
                Field.snake.facePosX = (Field.snake.facePosX + 1) % Field.gridWidth;
                break;
        }

        Field.snake.tailSnakePos.Insert(0, new TailSnakePos(oldFaceX, oldFaceY));

        bool isGameOver = Field.snake.tailSnakePos.Take(Field.snake.tailSnakePos.Count - 1).Any(seg =>
            seg.positionX == Field.snake.facePosX && seg.positionY == Field.snake.facePosY);

        if (hasEatenFood)
        {
            var eatenFood = Field.foods.First(f => f.getX() == Field.snake.facePosX && f.getY() == Field.snake.facePosY);

            Field.foods.Remove(eatenFood);
            Console.SetCursorPosition(eatenFood.getX(), eatenFood.getY());
            Console.Write(" ");
            eatFood++;
            if (46 > eatFood)
            {
                if ((eatFood % 5) == 0)
                {
                    speed = speed - 100;
                    // =-
                    timer.Interval = speed;
                }
            }
        } else {
            var lastSegment = Field.snake.tailSnakePos.Last();
            Console.SetCursorPosition(lastSegment.positionX, lastSegment.positionY);
            Console.Write(" ");
            Field.snake.tailSnakePos.RemoveAt(Field.snake.tailSnakePos.Count - 1);
        }
        if (isGameOver)
        {
            timer.Stop();
            Food.timer.Stop();
            Console.Clear();
            Console.WriteLine("ИГРА ОКОНЧЕНА!");
            return;
        }
        Field.snake.Draw();
        Food.spawnFood();
    }
}
