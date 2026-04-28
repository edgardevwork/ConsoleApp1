using System.Timers;
using DickSnake.BusinessLogic.Helpers;
using DickSnake.Models;

public class SnakeManager
{
    private IKeyHelper _keyHelper;

    System.Timers.Timer timer;
    Field field = null;
    Food food = null;
    SnakeDirection way = SnakeDirection.Right;
    int speed = 1000; //  минимальная скорость это 100 
    int eatFood = 0; // кол во фруктов сьединных

    public SnakeManager(Field field, Food food, IKeyHelper keyHelper)
    {
        this.field = field;

        this.food = food;

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
        bool hasEatenFood = field.foods.Any(food =>
            food.getX() == field.snake.facePosX && food.getY() == field.snake.facePosY);

        int oldFaceX = field.snake.facePosX;
        int oldFaceY = field.snake.facePosY;

        switch (way)
        {
            case SnakeDirection.Up:
                switch ((field.snake.facePosY - 1 + field.gridHeight) % field.gridHeight)
                {
                    case 0:
                        field.snake.facePosY = field.gridHeight - 2;
                        break;
                    default:
                        field.snake.facePosY = (field.snake.facePosY - 1 + field.gridHeight) % field.gridHeight;
                        break;
                }
                break;
            case SnakeDirection.Down:
                int result = (field.snake.facePosY + 1) % field.gridHeight;
                if (result == field.gridHeight-1) {
                    field.snake.facePosY = 1;
                } else
                {
                    field.snake.facePosY = (field.snake.facePosY + 1) % field.gridHeight;
                }
                break;
            case SnakeDirection.Left:
                switch ((field.snake.facePosX - 1 + field.gridWidth) % field.gridWidth)
                {
                    case 0:
                        field.snake.facePosX = field.gridWidth - 2;
                        break;
                    default:
                        field.snake.facePosX = (field.snake.facePosX - 1 + field.gridWidth) % field.gridWidth;
                        break;
                }
                break;
            case SnakeDirection.Right:
                int result2 = (field.snake.facePosX + 1) % field.gridWidth;
                if (result2 == field.gridWidth - 1)
                {
                    field.snake.facePosX = 1;
                }
                else
                {
                    field.snake.facePosX = (field.snake.facePosX + 1) % field.gridWidth;
                }
                break;
            }

            field.snake.tailSnakePos.Insert(0, new TailSnakePos(oldFaceX, oldFaceY));

            bool isGameOver = field.snake.tailSnakePos.Take(field.snake.tailSnakePos.Count - 1).Any(seg =>
                seg.positionX == field.snake.facePosX && seg.positionY == field.snake.facePosY);

            if (hasEatenFood)
            {
                var eatenFood = field.foods.First(f => f.getX() == field.snake.facePosX && f.getY() == field.snake.facePosY);

                field.foods.Remove(eatenFood);
                Console.SetCursorPosition(eatenFood.getX(), eatenFood.getY());
                Console.Write(" ");
                eatFood++;
                if (46 > eatFood)
                {
                    if ((eatFood % 5) == 0)
                    {
                        speed -= 100;
                        // =-
                        timer.Interval = speed;
                    }
                }
            } else {
                var lastSegment = field.snake.tailSnakePos.Last();
                Console.SetCursorPosition(lastSegment.positionX, lastSegment.positionY);
                Console.Write(" ");
                field.snake.tailSnakePos.RemoveAt(field.snake.tailSnakePos.Count - 1);
            }
            if (isGameOver)
            {
                timer.Stop();
                //food.timer.Stop();
                Console.Clear();
                Console.WriteLine("ИГРА ОКОНЧЕНА!");
                return;
            }
            field.snake.Draw();
            food.spawnFood();
        }
}
