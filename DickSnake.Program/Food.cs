using DickSnake.Models;
using System.Timers;

public class Food
{
    static Random rand;
    int speed = 1000;
    Field field = null;
    public static System.Timers.Timer timer;
    public Food(Field field)
    {
        this.field = field;
        rand = new Random();
    }

    public void spawnFood()
    {
        if (field.foods.Count + field.snake.tailSnakePos.Count + 1 == field.gridWidth * field.gridHeight)
        {
            return;
        }
        int posX, posY;
        bool isPositionValid;

        do
        {
            posX = rand.Next(field.gridWidth);
            posY = rand.Next(field.gridHeight);

            isPositionValid = true;

            foreach (var food in field.foods)
            {
                if (food.getX() == posX && food.getY() == posY)
                {
                    isPositionValid = false;
                    break;
                }
            }

            if (!isPositionValid)
            {
                continue;
            }

            if (field.snake.facePosX == posX && field.snake.facePosY == posY)
            {
                isPositionValid = false;
                continue;
            }
            
            foreach (var tailSegment in field.snake.tailSnakePos)
            {
                if (tailSegment.positionX == posX && tailSegment.positionY == posY)
                {
                    isPositionValid = false;
                    break;
                }
            }

        } while (!isPositionValid);

        int foodType = rand.Next(0, 3);

        field.foods.Add(new FoodModel(posX, posY, (FoodType)foodType));

        Console.SetCursorPosition(posX, posY);
        switch (foodType)
        {
            case (int)FoodType.Apple:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("A");
                    break;
                }
            case (int)FoodType.Banana:
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("B");
                    break;
                }
            case (int)FoodType.Watermelon:
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("W");
                    break;
                }
        }

        Console.ForegroundColor = ConsoleColor.White;
    }
}
