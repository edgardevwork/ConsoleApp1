using DickSnake.BusinessLogic.Helpers;
using DickSnake.ConsoleUi;
using DickSnake.Models;
using System.Timers;
using System.Xml.Linq;

internal class Program
{
    private static SnakeManager snake = null;
    private static System.Timers.Timer timer;
    private static int speed = 1000; //  минимальная скорость это 100 
    private static int eatFood = 0; // кол во фруктов сьединных
    private static Field field = null;
    private static Food food = null;
    private static void Main(string[] args)
    {
        FieldManager fieldManager = new FieldManager();
        field = fieldManager.field;
        food = new Food(field);
        var keyHelper = new KeyHelper();
        snake = new SnakeManager(field, food, keyHelper);
        keyHelper.StartListening();

        timer = new System.Timers.Timer();
        timer.Interval = speed;
        timer.Elapsed += onTick;
        timer.Elapsed += onTick;
        timer.Start();
        while (true) ;
    }

    private static void onTick(object? sender, ElapsedEventArgs e)
    {
        bool hasEatenFood = field.foods.Any(food =>
            food.getX() == field.snake.facePosX && food.getY() == field.snake.facePosY);

        int oldFaceX = field.snake.facePosX;
        int oldFaceY = field.snake.facePosY;

        switch (snake.way)
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
                if (result == field.gridHeight - 1)
                {
                    field.snake.facePosY = 1;
                }
                else
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
            ConsoleManager.FreePrint(eatenFood.getX(), eatenFood.getY());
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
        }
        else
        {
            var lastSegment = field.snake.tailSnakePos.Last();
            ConsoleManager.FreePrint(lastSegment.positionX, lastSegment.positionY);
            field.snake.tailSnakePos.RemoveAt(field.snake.tailSnakePos.Count - 1);
        }
        if (isGameOver)
        {
            timer.Stop();
            //food.timer.Stop();
            ConsoleManager.GameOverPrint();
            return;
        }
        field.snake.Draw();
        food.spawnFood();
    }
}