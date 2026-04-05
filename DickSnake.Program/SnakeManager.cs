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
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Interval = speed;
        timer.Elapsed += updateSnake;
        timer.Start();

    }
    public void updateSnake(object? sender, ElapsedEventArgs e)
    {
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
        Console.SetCursorPosition(oldFaceX, oldFaceY);
        Console.Write("-");
        Console.SetCursorPosition(Field.snake.facePosX, Field.snake.facePosY);
        Console.Write("@");
    }
}
