using DickSnake.Models;
using System.Timers;

public class Food
{
    Random rand;
    int speed = 1000;
    public Food()
    {
        rand = new Random();
    }

    public void start()
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Interval = speed;
        timer.Elapsed += spawnFood;
        timer.Start();
    }

    private void spawnFood(object? sender, ElapsedEventArgs e)
    {
        if (Field.foods.Count + Field.snake.tailSnakePos.Count + 1 == Field.gridWidth * Field.gridHeight)
        {
            return;
        }
        int posX, posY;
        bool isPositionValid;

        do
        {
            posX = rand.Next(Field.gridWidth);
            posY = rand.Next(Field.gridHeight);

            isPositionValid = true;

            foreach (var food in Field.foods)
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

            if (Field.snake.facePosX == posX && Field.snake.facePosY == posY)
            {
                isPositionValid = false;
                continue;
            }
            
            foreach (var tailSegment in Field.snake.tailSnakePos)
            {
                if (tailSegment.positionX == posX && tailSegment.positionY == posY)
                {
                    isPositionValid = false;
                    break;
                }
            }

        } while (!isPositionValid);

        int foodType = rand.Next(0, 3);

        Field.foods.Add(new FoodModel(posX, posY, (FoodType)foodType));

        Console.SetCursorPosition(posX, posY);
        switch (foodType)
        {
            case (int)FoodType.Apple:
                {
                    Console.Write("A");
                    break;
                }
            case (int)FoodType.Banana:
                {
                    Console.Write("B");
                    break;
                }
            case (int)FoodType.Watermelon:
                {
                    Console.Write("W");
                    break;
                }
        }
    }
}
