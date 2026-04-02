using System.Timers;
using DickSnake.BusinessLogic.Helpers;
using DickSnake.Models;

public class Snake
{
    private IKeyHelper _keyHelper;

    System.Timers.Timer timer;
    SnakePos[] snakePos = new SnakePos[Field.gridWidth*Field.gridHeight];
    SnakeDirection way = SnakeDirection.Right;
    int speed = 1000;

    public Snake(IKeyHelper keyHelper)
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

        // дальше хуйня, переделывать
        snakePos[0] = new SnakePos(0, 0);
        Console.SetCursorPosition(snakePos[0].positionX, snakePos[0].positionY);
        Console.Write("@");
        timer = new System.Timers.Timer();
        timer.Interval = speed;
        timer.Elapsed += updateSnake;
        timer.Start();
    }
    public void updateSnake(object? sender, ElapsedEventArgs e)
    {

        Console.SetCursorPosition(snakePos[0].positionX, snakePos[0].positionY);
        Console.Write(" ");
        switch (way)
        {
            case SnakeDirection.Up:
                snakePos[0].positionY -= 1;
                break;
            case SnakeDirection.Down:
                snakePos[0].positionY += 1;
                break;
            case SnakeDirection.Left:
                snakePos[0].positionX -= 1;
                break;
            case SnakeDirection.Right:
                snakePos[0].positionX += 1;
                break;
        }

        // тут мы сейчас только голову рисуем
        // используй SnakePos Head
        // и List<SnakePos> Tail
        // создаешь два свойства, заполняешь голову и ставишь хвост на позицию голова -1 по иксу
        // после этого отрисовываешь голову, а хвост в цикле "подтягиваешь до головы
        // можешь в этом методже просчитать все координаты головы и хвоста, а отрисовать их надо ТОЧНО НЕ ВНУТРИ КЛАССА ЗМЕЯ!
        Console.SetCursorPosition(snakePos[0].positionX, snakePos[0].positionY);
        Console.Write("@");
    }
}
