using System.Timers;
using DickSnake.BusinessLogic.Helpers;
using DickSnake.Models;

public class SnakeManager
{
    private IKeyHelper _keyHelper;

    System.Timers.Timer timer;
    SnakeDirection way = SnakeDirection.Right;
    int speed = 1000;

    public SnakeManager(IKeyHelper keyHelper)
    {
        _keyHelper = keyHelper;

        _keyHelper.KeyPressed += key =>
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
        };

        
    }
    public void updateSnake(object? sender, ElapsedEventArgs e)
    {
        switch (way)
        {
            case SnakeDirection.Up:
                Field.snake.facePosY -= 1;
                break;
            case SnakeDirection.Down:
                Field.snake.facePosY += 1;
                break;
            case SnakeDirection.Left:
                Field.snake.facePosX -= 1;
                break;
            case SnakeDirection.Right:
                Field.snake.facePosX += 1;
                break;
        }
    }
}
