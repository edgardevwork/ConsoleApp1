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
        int posX = rand.Next(Field.gridWidth);
        int posY = rand.Next(Field.gridHeight);
        int foodType = rand.Next(0, 3);
        if (Field.foods.Count > 0)
        {
            setPosXY(posX, posY);
        }
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
    private void setPosXY(int posX, int posY)
    {
        for (int i = 0; i < Field.foods.Count; i++)
        {
            if (Field.foods[i].getX() == posX && Field.foods[i].getY() == posY)
            {
                posX = rand.Next(Field.gridWidth);
                posY = rand.Next(Field.gridHeight);
                setPosXY(posX, posY);
            }
        }
    }
}
