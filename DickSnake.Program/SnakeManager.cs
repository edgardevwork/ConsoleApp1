using System.Timers;
using DickSnake.BusinessLogic.Helpers;
using DickSnake.Models;

public class SnakeManager
{
    private IKeyHelper _keyHelper;

    public SnakeDirection way = SnakeDirection.Right;

    public SnakeManager(Field field, Food food, IKeyHelper keyHelper)
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
    }
}
